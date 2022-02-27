using NUnit.Framework;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.Models;
using Game.ViewModels;

namespace UnitTests.Views
{
    [TestFixture]
    public class PickItemsPageTests
    {
        App app;
        PickItemsPage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new PickItemsPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void PickItemsPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PickItemsPage_CloseButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            //page.CloseButton_Clicked(null, null);

            // Reset

            // Assert
            //Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_ClosePopup_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_ShowPopup_Default_Should_Pass()
        {
            // Arrange

            // Act
            _ = page.ShowPopup(new ItemModel());

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_GetItemToDisplay_Null_Should_Pass()
        {
            // Arrange

            // Act
            _ = page.GetItemToDisplay(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_GetItemToDisplay_InValid_Id_Should_Pass()
        {
            // Arrange

            // Act
            _ = page.GetItemToDisplay(new ItemModel { Id = "" });

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_DrawDroppedItems_Valid_Should_Pass()
        {
            // Arrange

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());

            // Draw two times
            page.DrawDroppedItems();

            // Act
            page.DrawDroppedItems();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void PickItemsPage_DrawSelectedItems_Valid_Should_Pass()
        {
            // Arrange

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(new ItemModel());

            // Draw two times
            page.DrawSelectedItems();

            // Act
            page.DrawSelectedItems();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_DrawItemLists_Valid_Should_Pass()
        {
            // Arrange

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(new ItemModel());

            // Draw two times
            page.DrawItemLists();

            // Act  BattleEngineViewModel.Instance.Engine.EngineSettings.
            page.DrawItemLists();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Finger);
            var StackItem = page.GetItemToDisplay(item);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}