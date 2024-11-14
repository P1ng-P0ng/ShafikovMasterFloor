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
        public void RegPageTest()
        {
            string PartnerCompanyName = "";
            string PartnerDirSurame = "";
            string PartnerDirName = "";
            string PartnerPhone = "";
            string PartnerEmail = "";
            string PartnerINN = "";
            string PartnerRating = "";
            string PartnerRegion = "";
            string PartnerCity = "";
            string PartnerStreet = "";
            string ParnterBuildNumber = "";
            bool expected = true;

            bool actual = AddEditPageCS.SaveBtn_Click(PartnerCompanyName, PartnerDirSurame, PartnerDirName, PartnerPhone, PartnerEmail, PartnerINN,
                PartnerRating, PartnerRegion, PartnerCity, PartnerStreet, ParnterBuildNumber);

            Assert.AreEqual(expected, actual);
        }
    }
}