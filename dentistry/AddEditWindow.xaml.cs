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
using System.Windows.Shapes;

namespace dentistry
{
    public partial class AddEditWindow : Window
    {
        private Request request = new Request();
        private Clients clients = new Clients();
        private Times times = new Times();
        public AddEditWindow()
        {
            InitializeComponent();
            DataContext = request;
            TypeComboBox.ItemsSource = dentalEntities.GetContext().Service_.ToList();
            StatusComboBox.ItemsSource = dentalEntities.GetContext().Statuses.ToList();

            // Подписываемся на событие SelectionChanged для TypeComboBox
            TypeComboBox.SelectionChanged += TypeComboBox_SelectionChanged;
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedService = (Service_)TypeComboBox.SelectedItem;
            if (selectedService != null)
            {
                // Находим Worker по id_worker из selectedService
                var worker = dentalEntities.GetContext().Workers.FirstOrDefault(w => w.id_worker == selectedService.id_worker);
                if (worker != null)
                {
                    WorkerComboBox.SelectedItem = worker; // Устанавливаем выбранного сотрудника
                }

                // Находим Price по id_service из selectedService
                var price = dentalEntities.GetContext().Price.FirstOrDefault(p => p.id_service == selectedService.id_service);
                if (price != null)
                {
                    PriceComboBox.SelectedItem = price; // Устанавливаем выбранную цену
                }
            }
        }

        private void BtnSave_Click(Object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (TypeComboBox.SelectedItem != null && TypeComboBox.SelectedItem is Service_ type_Of_Service)
                request.id_service = type_Of_Service.id_service;
            else error.AppendLine("Выберите тип услуги");

            if (string.IsNullOrWhiteSpace(ClientTextBox.Text))
                error.AppendLine("Укажите клиента");

            if (string.IsNullOrWhiteSpace(DataTextBox.Text))
                error.AppendLine("Укажите дату");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Предупреждение!", MessageBoxButton.OK,
                MessageBoxImage.Information);
                return;

            }

            try
            {
                var context = dentalEntities.GetContext();
                clients.name_client = ClientTextBox.Text;
                times.name_time = DataTextBox.Text;

                context.Clients.Add(clients);
                context.Times.Add(times);
                context.SaveChanges();

                var clientId = clients.id_client;
                var timesId = times.id_time;


                request.id_client = clientId;
                request.id_time = timesId;

                context.Request.Add(request);
                context.SaveChanges();
                MessageBox.Show("Информация сохранена");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
