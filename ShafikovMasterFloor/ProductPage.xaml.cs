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

namespace ShafikovMasterFloor
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();

            var currentProduct = FloorMasterEntities.GetContext().Partner.ToList();
            ProductList.ItemsSource = currentProduct;

            

            UpdatePage();
            //ProductPage 
        }

        private void UpdatePage()
        {
            var currentProduct = FloorMasterEntities.GetContext().Partner.ToList();

            currentProduct = currentProduct.Where(p => p.PartnerID == p.PartnerID).ToList();

            ProductList.ItemsSource = FloorMasterEntities.GetContext().Partner.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Partner));
            UpdatePage();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
            UpdatePage();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FloorMasterEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(t => t.Reload());
                ProductList.ItemsSource = FloorMasterEntities.GetContext().Partner.ToList();
            }
            UpdatePage();
        }
    }
}
