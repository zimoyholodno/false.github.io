using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using dentistry.Properties;


namespace dentistry
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDentalServiceDataGrid();
            ComboStatus.ItemsSource = dentalEntities.GetContext().Statuses.ToList();
            Vis();
        }
        private void RefreshDentalServiceDataGrid()
        {
            var context = dentalEntities.GetContext();
            var requestsWithRelations = context.Request
            .Include(r => r.Workers)
            .Include(r => r.Clients)
            .Include(r => r.Statuses)
            .Include(r => r.Service_)
            .Include(r => r.Price)
            .Include(r => r.Times)
            .ToList();
            dentalService.ItemsSource = requestsWithRelations;
        }
        private void Vis()
        {
            switch (Authorization.authorizationRole)
            {
                case "Админ":
                    Red.Visibility = Visibility.Collapsed;
                    BtnAdd.Visibility = Visibility.Collapsed;
                    break;
                case "Модер":
                    BtnDelet.Visibility = Visibility.Collapsed;
                    BtnAdd.Visibility = Visibility.Collapsed;
                    break;
                case "Юзер":
                    BtnDelet.Visibility = Visibility.Collapsed;
                    Red.Visibility = Visibility.Collapsed;
                    break;
                default: 
                    return;
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedRequest = (sender as Button)?.DataContext as Request;
            if (selectedRequest != null)
            {
                RefreshWindow addEditWindow = new RefreshWindow(selectedRequest);
                if (addEditWindow.ShowDialog() == true)
                {
                    RefreshDentalServiceDataGrid();
                }
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow();
            if (addEditWindow.ShowDialog() == true)
            {
                RefreshDentalServiceDataGrid();

            }
        }
        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            var servisForRemoving = dentalService.SelectedItems.Cast<Request>().ToList();
            if (servisForRemoving.Any() && MessageBox.Show($"Вы точно хотите удалить следующее {servisForRemoving.Count()}элемент ? ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var context = dentalEntities.GetContext();
                context.Request.RemoveRange(servisForRemoving);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                RefreshDentalServiceDataGrid();
            }
        }
        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            dentalService.ItemsSource = dentalEntities.GetContext().Request.ToList();
            RefreshDentalServiceDataGrid();
        }
        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            if (ComboStatus.SelectedItem is Statuses selectedStatus)
            {
                int selectedStatusId = selectedStatus.id_status;
                var context = dentalEntities.GetContext();
                dentalService.ItemsSource = context.Request
                //.Include(r => r.id_request)
                .Include(r => r.Workers)
                .Include(r => r.Clients)
                .Include(r => r.Statuses)
                .Include(r => r.Service_)
                .Include(r => r.Price)
                .Include(r => r.Times)
                .Where(r => r.id_status == selectedStatusId)
                .ToList();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();
            var context = dentalEntities.GetContext();
            try
            {
                dentalService.ItemsSource = context.Request
                .Include(r => r.Workers)
                .Include(r => r.Clients)
                .Include(r => r.Statuses)
                .Include(r => r.Service_)
                .Include(r => r.Price)
                .Include(r => r.Times)
                .Where(r =>
                r.Workers.name_worker.ToLower().Contains(searchText) ||
                r.Clients.name_client.ToLower().Contains(searchText) ||
                r.Statuses.name_status.ToLower().Contains(searchText) ||
                r.Service_.name_service.ToLower().Contains(searchText) ||
                r.Price.name_price.ToLower().Contains(searchText) ||
                r.Times.name_time.ToLower().Contains(searchText))
                .ToList();
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            {
                // Логирование или отладкаи сключения
                Console.WriteLine(ex.InnerException?.Message);
            }
        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }
    }
}