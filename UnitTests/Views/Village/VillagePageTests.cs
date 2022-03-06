using NUnit.Framework;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.Models;
using UnitTests.TestHelpers;
using System.Threading.Tasks;

namespace UnitTests.Views
{
    [TestFixture]
    public class VillagePageTests
    {
        App app;
        VillagePage page;

        // Base Constructor
        //public VillagePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new VillagePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void VillagePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void VillagePage_ItemsButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.ItemsButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void VillagePage_CharactersButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.CharactersButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void VillagePage_MonstersButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.MonstersButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void VillagePage_ScoresButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.ScoresButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void VillagePage_FetchItemPost_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.FetchItemsPost_Command(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public async Task VillagePage_GetItemsPost_Invalid_BadURL_Should_Fail()
        {
            // Arrange
            var hold = WebGlobalsModel.WebSiteAPIURL;
            WebGlobalsModel.WebSiteAPIURL = "https://bogusurl";

            _ = TestBaseHelper.SetHttpClientToMock();
            ResponseMessage.SetResponseMessageStringContent(JsonSampleData.StringContent_Example_API_Pass);
            ResponseMessage.SetResponseMessageStringContent(ResponseMessage.NullStringContent);
            ResponseMessage.SetHttpStatusCode(ResponseMessage.HttpStatusCodeSuccess);

            // Act
            var result = await page.GetItemsPost();

            // Reset
            WebGlobalsModel.WebSiteAPIURL = hold;
            _ = TestBaseHelper.SetHttpClientToReal();

            // Assert
            Assert.AreEqual(true, result); // Got to here, so it happened...
        }
    }
}