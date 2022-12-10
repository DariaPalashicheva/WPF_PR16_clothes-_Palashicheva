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
using WPF_PR16_clothes__Palashicheva.ApplicationData;

namespace WPF_PR16_clothes__Palashicheva.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageTovarsAddEdit.xaml
    /// </summary>
    public partial class PageTovarsAddEdit : Page
    {
        private Tovars _currentTovars = new Tovars();
        public PageTovarsAddEdit(Tovars selectedTovars)
        {
            InitializeComponent();
            if (selectedTovars != null)
                _currentTovars = selectedTovars;

            DataContext = _currentTovars;
            ComboColor.ItemsSource = ClothesEntities.GetContext().Color.ToList();
            ComboStrana.ItemsSource = ClothesEntities.GetContext().Strana.ToList();
            ComboSize.ItemsSource = ClothesEntities.GetContext().Size.ToList();

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // проверка заполняемости полей
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentTovars.naimenov))
                errors.AppendLine("Укажите название товара");

            if (_currentTovars.kolichestvo <= 0)
                errors.AppendLine("Количество товара не может быть меньше или равно 0");

            if (_currentTovars.cena <= 0)
                errors.AppendLine("Цена не может быть меньше или равна 0");

            if (_currentTovars.Strana == null)
                errors.AppendLine("Укажите страну");


            if (_currentTovars.Color == null)
                errors.AppendLine("Выберите цвет");

            if (_currentTovars.Size == null)
                errors.AppendLine("Укажите размер");

            if (string.IsNullOrWhiteSpace(_currentTovars.sostav))
                errors.AppendLine("Укажите состав");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //добавление
            if (_currentTovars.id == 0)
                ClothesEntities.GetContext().Tovars.Add(_currentTovars);
            try
            {
                ClothesEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            AppFrame.FrameMain.Navigate(new PageMain.PageTovars());
        }
    }
}
