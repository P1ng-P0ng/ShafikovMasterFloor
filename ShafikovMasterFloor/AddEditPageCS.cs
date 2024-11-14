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

namespace ShafikovMasterFloor
{
    public class AddEditPageCS
    {
        private Partner currentPartner = new Partner();
        bool CheckPartner = false;
        //public AddEditPage(Partner selectedPartner)
        //{
        //InitializeComponent();
        //if (selectedPartner != null)
        //{
        //currentPartner = selectedPartner;
        //CheckPartner = true;
        //DelBtn.Visibility = Visibility.Visible;
        //ComboType.SelectedIndex = 0;
        /*if (selectedPartner.CompanyTypeID == 1)
        {
            ComboType.SelectedIndex = 0;
        }*/
        //ComboType.SelectedIndex = selectedPartner.CompanyTypeID - 1;
        //}
        //else
        //{
        //DelBtn.Visibility = Visibility.Hidden;
        //}
        //DataContext = currentPartner;
        //}

        public static bool SaveBtn_Click(string PartnerCompanyName, string PartnerDirSurame, string PartnerDirName, string PartnerDirpatronymic, string PartnerPhone,
            string PartnerEmail, string PartnerINN, int ComboType, string PartnerRating, string PartnerRegion, string PartnerCity, string PartnerStreet,
            string ParnterBuildNumber)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(PartnerCompanyName))
            {
                errors.AppendLine("Укажите название компании");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PartnerDirSurame))
            {
                errors.AppendLine("Укажите фамилию директора");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PartnerDirName))
            {
                errors.AppendLine("Укажите имя директора");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PartnerPhone))
            {
                errors.AppendLine("Укажите номер телефона");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PartnerEmail))
            {
                errors.AppendLine("Укажите Email");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PartnerINN))
            {
                errors.AppendLine("Укажите ИНН");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PartnerRating.ToString()))
            {
                errors.AppendLine("Укажите рейтинг");
                return false;
            }
            if (ComboType <= 0 || ComboType == null)
            { 
                errors.AppendLine("Укажите тип компании");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PartnerRegion))
            {
                errors.AppendLine("Укажите регион");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PartnerCity))
            {
                errors.AppendLine("Укажите город");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PartnerStreet))
            {
                errors.AppendLine("Укажите улицу");
                return false;
            }
            if (string.IsNullOrWhiteSpace(ParnterBuildNumber))
            {
                errors.AppendLine("Укажите номер здания");
                return false;
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return false;
            }

            var allPartner = FloorMasterEntities.GetContext().Partner.ToList();
            //allPartner = allPartner.Where(p => p.PartnerCompanyName == currentPartner.PartnerCompanyName).ToList();

            if (allPartner.Count == 0 || (/*CheckPartner == true &&*/ allPartner.Count <= 1))
            {
                if (/*currentPartner.PartnerID == 0*/true)
                {
                    //currentPartner.CompanyTypeID = ComboType.SelectedIndex + 1;
                    //FloorMasterEntities.GetContext().Partner.Add(currentPartner);
                    return true;
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
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("Такой агент уже существует");
                return false;
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
                if (MessageBox.Show("Вы точно хотите удалить данные?", "Внимание!",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FloorMasterEntities.GetContext().Partner.Remove(_currentPartner);
                        FloorMasterEntities.GetContext().SaveChanges();
                        Manager.MainFrame.GoBack();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
    }
}
