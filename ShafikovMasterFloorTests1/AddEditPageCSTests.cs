using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShafikovMasterFloor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShafikovMasterFloor.Tests
{
    [TestClass()]
    public class AddEditPageCSTests
    {
        [TestMethod()]
        public void TestEmptyCompanyName()
        {
            string PartnerCompanyName = "";
            string PartnerDirSurame = "Бердин";
            string PartnerDirName = "Андрей";
            string PartnerDirpatronymic = "Александрович";
            string PartnerPhone = "89789885848";
            string PartnerEmail = "berdin@mail.ru";
            string PartnerINN = "987678765567";
            int ComboType = 2;
            string PartnerRating = "5";
            string PartnerRegion = "Москвская область";
            string PartnerCity = "Москва";
            string PartnerStreet = "Еловая";
            string ParnterBuildNumber = "43";
            bool expected = false;

            bool actual = AddEditPageCS.SaveBtn_Click(PartnerCompanyName, PartnerDirSurame, PartnerDirName, PartnerDirpatronymic, PartnerPhone, PartnerEmail,
                PartnerINN, ComboType, PartnerRating, PartnerRegion, PartnerCity, PartnerStreet, ParnterBuildNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestEmptyDirSurName()
        {
            string PartnerCompanyName = "Яндекс";
            string PartnerDirSurame = "";
            string PartnerDirName = "Андрей";
            string PartnerDirpatronymic = "Александрович";
            string PartnerPhone = "89789885848";
            string PartnerEmail = "berdin@mail.ru";
            string PartnerINN = "987678765567";
            int ComboType = 2;
            string PartnerRating = "5";
            string PartnerRegion = "Москвская область";
            string PartnerCity = "Москва";
            string PartnerStreet = "Еловая";
            string ParnterBuildNumber = "43";
            bool expected = false;

            bool actual = AddEditPageCS.SaveBtn_Click(PartnerCompanyName, PartnerDirSurame, PartnerDirName, PartnerDirpatronymic, PartnerPhone, PartnerEmail,
                PartnerINN, ComboType, PartnerRating, PartnerRegion, PartnerCity, PartnerStreet, ParnterBuildNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestEmptyDirName()
        {
            string PartnerCompanyName = "Яндекс";
            string PartnerDirSurame = "Бердин";
            string PartnerDirName = "";
            string PartnerDirpatronymic = "Александрович";
            string PartnerPhone = "89789885848";
            string PartnerEmail = "berdin@mail.ru";
            string PartnerINN = "987678765567";
            int ComboType = 2;
            string PartnerRating = "5";
            string PartnerRegion = "Москвская область";
            string PartnerCity = "Москва";
            string PartnerStreet = "Еловая";
            string ParnterBuildNumber = "43";
            bool expected = false;

            bool actual = AddEditPageCS.SaveBtn_Click(PartnerCompanyName, PartnerDirSurame, PartnerDirName, PartnerDirpatronymic, PartnerPhone, PartnerEmail,
                PartnerINN, ComboType, PartnerRating, PartnerRegion, PartnerCity, PartnerStreet, ParnterBuildNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestEmptyDirPatronymic()
        {
            string PartnerCompanyName = "Яндекс";
            string PartnerDirSurame = "Бердин";
            string PartnerDirName = "Андрей";
            string PartnerDirpatronymic = "";
            string PartnerPhone = "89789885848";
            string PartnerEmail = "berdin@mail.ru";
            string PartnerINN = "987678765567";
            int ComboType = 2;
            string PartnerRating = "5";
            string PartnerRegion = "Москвская область";
            string PartnerCity = "Москва";
            string PartnerStreet = "Еловая";
            string ParnterBuildNumber = "43";
            bool expected = true;

            bool actual = AddEditPageCS.SaveBtn_Click(PartnerCompanyName, PartnerDirSurame, PartnerDirName, PartnerDirpatronymic, PartnerPhone, PartnerEmail,
                PartnerINN, ComboType, PartnerRating, PartnerRegion, PartnerCity, PartnerStreet, ParnterBuildNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestEmptyPhone()
        {
            string PartnerCompanyName = "Яндекс";
            string PartnerDirSurame = "Бердин";
            string PartnerDirName = "Андрей";
            string PartnerDirpatronymic = "Александрович";
            string PartnerPhone = "";
            string PartnerEmail = "berdin@mail.ru";
            string PartnerINN = "987678765567";
            int ComboType = 2;
            string PartnerRating = "5";
            string PartnerRegion = "Москвская область";
            string PartnerCity = "Москва";
            string PartnerStreet = "Еловая";
            string ParnterBuildNumber = "43";
            bool expected = false;

            bool actual = AddEditPageCS.SaveBtn_Click(PartnerCompanyName, PartnerDirSurame, PartnerDirName, PartnerDirpatronymic, PartnerPhone, PartnerEmail,
                PartnerINN, ComboType, PartnerRating, PartnerRegion, PartnerCity, PartnerStreet, ParnterBuildNumber);

            Assert.AreEqual(expected, actual);
        }
    }
}