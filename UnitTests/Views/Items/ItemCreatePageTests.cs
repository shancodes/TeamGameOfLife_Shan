using NUnit.Framework;

using Game;
using Game.Views;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Game.Models;

namespace UnitTests.Views
{
    [TestFixture]
    public class ItemCreatePageTests : ItemCreatePage
    {
        App app;
        ItemCreatePage page;

        public ItemCreatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new ItemCreatePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void ItemCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void ItemCreatePage_Save_Clicked_Null_Attribute_Should_Pass()
        {
            // Arrange
             
            page.ViewModel.Data.Location = Game.Models.ItemLocationEnum.Necklace;
            page.ViewModel.Data.Attribute = Game.Models.AttributeEnum.Unknown;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Save_Clicked_Null_ImageURI_Should_Pass()
        {
            // Arrange

            page.ViewModel.Data.Location = Game.Models.ItemLocationEnum.Necklace;
            page.ViewModel.Data.Attribute = Game.Models.AttributeEnum.Attack;
            page.ViewModel.Data.ImageURI = null;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            _ = OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Value_OnStepperValueChanged_Default_Should_Pass()
        {
            // Arrange

            page = new ItemCreatePage();
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
        public void ItemCreatePage_Range_OnStepperValueChanged_Default_Should_Pass()
        {
            // Arrange

            page = new ItemCreatePage();
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
        public void ItemCreatePage_Damage_OnStepperDamageChanged_Default_Should_Pass()
        {
            // Arrange
            page = new ItemCreatePage();
            var oldDamage = 0.0;
            var newDamage = 1.0;

            var args = new ValueChangedEventArgs(oldDamage, newDamage);

            // Act
            page.Damage_OnStepperValueChanged(null, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        /// <summary>
        /// Test to check if create button 
        /// is disabled if Name is null
        /// </summary>
        [Test]
        public void ItemCreatePage_SetCreateVisibility_Name_Null_Should_Pass()
        {
            // Arrange
            page = new ItemCreatePage();
            page.ViewModel.Data = new ItemModel();
            page.ViewModel.Data.Name = null;
            page.ViewModel.Data.Description = "Sword";
        
            // Act
            page.SetCreateVisibility();
            // Reset

            // Assert
            Assert.IsTrue(false == page.CreateButton_state());
        }

        /// <summary>
        /// Test to check if create button 
        /// is disabled if Description is null
        /// </summary>
        [Test]
        public void ItemCreatePage_SetCreateVisibility_Description_Null_Should_Pass()
        {
            // Arrange
            page = new ItemCreatePage();
            page.ViewModel.Data = new ItemModel();
            page.ViewModel.Data.Name = "This is a sword";
            page.ViewModel.Data.Description = null;

            // Act
            page.SetCreateVisibility();
            // Reset

            // Assert
            Assert.IsTrue(false == page.CreateButton_state());
        }

        /// <summary>
        /// Test to check if create button 
        /// is disabled if Description and Name is null
        /// </summary>
        [Test]
        public void ItemCreatePage_SetCreateVisibility_Name_And_Description_Null_Should_Pass()
        {
            // Arrange
            page = new ItemCreatePage();
            page.ViewModel.Data = new ItemModel();
            page.ViewModel.Data.Name = null;
            page.ViewModel.Data.Description = null;

            // Act
            page.SetCreateVisibility();
            // Reset

            // Assert
            Assert.IsTrue(false == page.CreateButton_state());
        }

        /// <summary>
        /// Test to check if create button 
        /// is enabled if Description and Name is not null
        /// </summary>
        [Test]
        public void ItemCreatePage_SetCreateVisibility_Name_And_Description_Not_Null_Should_Pass()
        {
            // Arrange
            page = new ItemCreatePage();
            page.ViewModel.Data = new ItemModel();
            page.ViewModel.Data.Name = "This is a Sword";
            page.ViewModel.Data.Description = "Sword";

            // Act
            page.SetCreateVisibility();
            // Reset

            // Assert
            Assert.IsTrue(page.CreateButton_state());
        }



    }
}