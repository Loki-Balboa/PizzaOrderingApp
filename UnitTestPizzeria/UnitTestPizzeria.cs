using ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPizzeria
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void TestNameCorrect()
        {
            string[] names = { "Name", "Peter", "Anna", "Jack" };
            foreach (string name in names)
            {
                Assert.IsTrue(name.ContainsOnlyLetters());
            }
        }
        [TestMethod]
        public void TestNameWrong()
        {
            string[] wrongNames = { "N@me", "Peter Lubszczyk", "Peter1", "Ann_a" };
            foreach (string name in wrongNames)
            {
                Assert.IsFalse(name.ContainsOnlyLetters());
            }
        }
        [TestMethod]
        public void TestZipCorrect()
        {
            string[] corretcZips = { "44100", "44-100" };
            foreach (string zip in corretcZips)
            {
                Assert.IsTrue(zip.IsValidZip());
            }
        }
        [TestMethod]
        public void TestZipWrong()
        {
            string[] wrongZips = { "441000", "4410", "444-100", "4-4100", "441-00" };
            foreach (string zip in wrongZips)
            {
                Assert.IsFalse(zip.IsValidZip());
            }
        }
        [TestMethod]
        public void TestStreetCorrect()
        {
            string[] correctStreets = { "5thAve.", "2ndSt.", "Pszczynska26a/10", "Glebce" };
            foreach (string street in correctStreets)
            {
                Assert.IsTrue(street.IsValidStreet());
            }
        }
        [TestMethod]
        public void TestStreetWrong()
        {
            string[] wrongStreets = { "gl@bce", "Millenium_av" };
            foreach (string street in wrongStreets)
            {
                Assert.IsFalse(street.IsValidStreet());
            }
        }
        [TestMethod]
        public void TestEmailCorrect()
        {
            string[] correctEmails = { "plubs@gmail.com", "some.Mail@outlook.com", "jakis_mail@o2.pl" };
            foreach (string email in correctEmails)
            {
                Assert.IsTrue(email.IsValidEmail());
            }
        }
        [TestMethod]
        public void TestEmailWrong()
        {
            string[] wrongEmails = { "wrong@email@.com", "another wrong email@sthg.com" };
            foreach (string email in wrongEmails)
            {
                Assert.IsFalse(email.IsValidEmail());
            }
        }
    }
}
