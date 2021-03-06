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
    public class ItemUpdatePageTests : ItemUpdatePage
    {
        App app;
        ItemUpdatePage page;

        public ItemUpdatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new ItemUpdatePage(new GenericViewModel<ItemModel>(new ItemModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void ItemUpdatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemUpdatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void ItemUpdatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            _ = OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_Value_OnStepperValueChanged_Default_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            var ViewModel = new GenericViewModel<ItemModel>(data);

            page = new ItemUpdatePage(ViewModel);
            var oldValue = 0.0;
            var newValue = 1.0;

            var args = new ValueChangedEventArgs(oldValue, newValue);

            // Act
            page.Value_OnStepperValueChanged(null, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_Range_OnStepperValueChanged_Default_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            var ViewModel = new GenericViewModel<ItemModel>(data);

            page = new ItemUpdatePage(ViewModel);
            var oldRange = 0.0;
            var newRange = 1.0;

            var args = new ValueChangedEventArgs(oldRange, newRange);

            // Act
            page.Range_OnStepperValueChanged(null, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_Damage_OnStepperDamageChanged_Default_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            var ViewModel = new GenericViewModel<ItemModel>(data);

            page = new ItemUpdatePage(ViewModel);
            var oldDamage = 0.0;
            var newDamage = 1.0;

            var args = new ValueChangedEventArgs(oldDamage, newDamage);

            // Act
            page.Damage_OnStepperValueChanged(null, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_OnResetButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            page.Reset_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        /// <summary>
        /// Test to check update button
        /// is disabled if name is null
        /// </summary>
        [Test]
        public void ItemUpdatePage_SetUpdateVisibility_Name_Null_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.Name = null;
            page.ViewModel.Data.Description = "Powerful Hammer";

            //Act
            page.SetUpdateVisibility();

            //Reset

            //Assert
            Assert.IsTrue(false == page.UpdateButton_State());

        }

        /// <summary>
        /// Test to check update button
        /// is disabled if Description is null
        /// </summary>
        [Test]
        public void ItemUpdatePage_SetUpdateVisibility_Description_Null_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.Name = "Hammer";
            page.ViewModel.Data.Description = null;

            //Act
            page.SetUpdateVisibility();

            //Reset

            //Assert
            Assert.IsTrue(false == page.UpdateButton_State());
        }

        /// <summary>
        /// Test to check update button is disabled for 
        /// Name and description is null
        /// </summary>
        [Test]
        public void ItemUpdatePage_SetUpdateVisibility_Description_And_Name_Null_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.Name = null;
            page.ViewModel.Data.Description = null;

            //Act
            page.SetUpdateVisibility();

            //Reset

            //Assert
            Assert.IsTrue(false == page.UpdateButton_State());
        }

        /// <summary>
        /// Test to check update button is enabled for 
        /// Name and description is  not null
        /// </summary>
        [Test]
        public void ItemUpdatePage_SetUpdateVisibility_Description_And_Name_Not_Null_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.Name = "Sword";
            page.ViewModel.Data.Description = "Weapon";

            //Act
            page.SetUpdateVisibility();

            //Reset

            //Assert
            Assert.IsTrue(page.UpdateButton_State());
        }
    }
}