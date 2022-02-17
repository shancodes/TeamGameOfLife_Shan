using NUnit.Framework;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace UnitTests.Views
{
    [TestFixture]
    public class MonsterUpdatePageTests : MonsterUpdatePage
    {
        App app;
        MonsterUpdatePage page;

        public MonsterUpdatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MonsterUpdatePage(new GenericViewModel<MonsterModel>(new MonsterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void MonsterUpdatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterUpdatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_Save_Clicked_Null_Image_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.ImageURI = null;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            _ = OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_UpdateUIElements_Default_Should_Pass()
        {
            // Arrange
            var monster = new MonsterModel();
            page.ViewModel.Data = monster;
            Entry nameField = (Entry)page.FindByName("Name_Entry");
            Assert.AreEqual(nameField.Text, "Cruel Monster");
            Entry descriptionField = (Entry)page.FindByName("Description_Entry");
            Assert.AreEqual(descriptionField.Text, "Long thin Cruel Monster");

            // Act
            monster.Name = "Monster Dino";
            monster.Description = "Giant Monster Dino";
            page.UpdateUIElements();

            // Assert
            Assert.AreEqual(nameField.Text, monster.Name);
            Assert.AreEqual(descriptionField.Text, monster.Description);

        }

        [Test]
        public void MonsterUpdatePage_Reset_Clicked_Valid_Should_Pass()
        {
            // Arrange
            var monster = new MonsterModel();
            page.ViewModel.Data = monster;
            Entry nameField = (Entry)page.FindByName("Name_Entry");
            Assert.AreEqual(nameField.Text, "Cruel Monster");
            Entry descriptionField = (Entry)page.FindByName("Description_Entry");
            Assert.AreEqual(descriptionField.Text, "Long thin Cruel Monster");

            // Act
            monster.Name = "Monster Dinos";
            monster.Description = "Giant Cruel Dinos";
            page.Reset_Clicked(null,null);

            // Assert
            Assert.AreEqual(nameField.Text, monster.Name);
            Assert.AreEqual(descriptionField.Text, monster.Description);

        }
    }
}