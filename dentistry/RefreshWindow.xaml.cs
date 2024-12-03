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
using dentistry.Properties;

namespace dentistry
{
    public partial class RefreshWindow : Window
    {
        private Request _currentRequest;
        public RefreshWindow(Request request)
        {
            InitializeComponent();
            _currentRequest = request;

            // Загружаем данные для ComboBox
            TypeComboBox.ItemsSource = dentalEntities.GetContext().Service_.ToList();
            StatusComboBox.ItemsSource = dentalEntities.GetContext().Statuses.ToList();
            WorkerComboBox.ItemsSource = dentalEntities.GetContext().Workers.ToList();
            PriceComboBox.ItemsSource = dentalEntities.GetContext().Price.ToList();

            // Заполняем поля
            DescriptionTextBox.Text = request.comments;
            ClientTextBox.Text = request.Clients.name_client;
            TypeComboBox.SelectedItem = request.Service_;
            StatusComboBox.SelectedItem = request.Statuses;

            // Подписываемся на событие SelectionChanged для TypeComboBox
            TypeComboBox.SelectionChanged += TypeComboBox_SelectionChanged;
        }

        // Обработчик события SelectionChanged для TypeComboBox
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

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь код для обновления данных в базе
            var context = dentalEntities.GetContext();

            _currentRequest.comments = DescriptionTextBox.Text;
            _currentRequest.id_service = ((Service_)TypeComboBox.SelectedItem).id_service;
            _currentRequest.id_status = ((Statuses)StatusComboBox.SelectedItem).id_status;
            _currentRequest.id_worker = ((Workers)WorkerComboBox.SelectedItem).id_worker;
            _currentRequest.id_price = ((Price)PriceComboBox.SelectedItem).id_price;

            context.SaveChanges();
            MessageBox.Show("Данные заявки обновлены");
            this.Close();
        }
    }
}
