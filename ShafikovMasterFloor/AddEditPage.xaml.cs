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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Partner currentPartner = new Partner();
        bool CheckPartner = false;
        public AddEditPage(Partner selectedPartner)
        {
            InitializeComponent();
            if (selectedPartner != null)
            {
                currentPartner = selectedPartner;
                CheckPartner = true;
                DelBtn.Visibility = Visibility.Visible;
                //ComboType.SelectedIndex = 0;
                /*if (selectedPartner.CompanyTypeID == 1)
                {
                    ComboType.SelectedIndex = 0;
                }*/
                //ComboType.SelectedIndex = selectedPartner.CompanyTypeID - 1;
            }
            else
            {
                DelBtn.Visibility = Visibility.Hidden;
            }
            DataContext = currentPartner;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerCompanyName))
                errors.AppendLine("Укажите название компании");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerDirSurame))
                errors.AppendLine("Укажите фамилию директора");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerDirName))
                errors.AppendLine("Укажите имя директора");
            if(string.IsNullOrWhiteSpace(currentPartner.PartnerPhone))
                errors.AppendLine("Укажите номер телефона");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerEmail))
                errors.AppendLine("Укажите Email");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerINN))
                errors.AppendLine("Укажите ИНН");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerRating.ToString()))
                errors.AppendLine("Укажите рейтинг");
            if (ComboType.SelectedItem == null || ComboType.SelectedIndex == 0)
                errors.AppendLine("Укажите тип компании");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerRegion))
                errors.AppendLine("Укажите регион");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerCity))
                errors.AppendLine("Укажите город");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerStreet))
                errors.AppendLine("Укажите улицу");
            if (string.IsNullOrWhiteSpace(currentPartner.ParnterBuildNumber))
                errors.AppendLine("Укажите номер здания");
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            var allPartner = FloorMasterEntities.GetContext().Partner.ToList();
            allPartner = allPartner.Where(p => p.PartnerCompanyName == currentPartner.PartnerCompanyName).ToList();

            if (allPartner.Count == 0 || (CheckPartner == true && allPartner.Count <= 1))
            {
                if (currentPartner.PartnerID == 0)
                {
                    //currentPartner.CompanyTypeID = ComboType.SelectedIndex + 1;
                    FloorMasterEntities.GetContext().Partner.Add(currentPartner);
                }
                try
                {
                    FloorMasterEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Такой агент уже существует");
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var _currentPartner = (sender as Button).DataContext as Partner;
            var _currentPartnerProdSale = FloorMasterEntities.GetContext().PartnerProductSale.ToList();
            _currentPartnerProdSale = _currentPartnerProdSale.Where(p => p.PartnerID == _currentPartner.PartnerID).ToList();
            if (_currentPartnerProdSale.Count != 0)
            {
                MessageBox.Show("Существуют записи с данными партнерами");
            }
            else
            {
                if(MessageBox.Show("Вы точно хотите удалить данные?", "Внимание!",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FloorMasterEntities.GetContext().Partner.Remove(_currentPartner);
                        FloorMasterEntities.GetContext().SaveChanges();
                        Manager.MainFrame.GoBack();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
    }
}
