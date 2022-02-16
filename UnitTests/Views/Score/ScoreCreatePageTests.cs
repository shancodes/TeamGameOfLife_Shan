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
    public class ScoreCreatePageTests : ScoreCreatePage
    {
        App app;
        ScoreCreatePage page;

        public ScoreCreatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new ScoreCreatePage(new GenericViewModel<ScoreModel>(new ScoreModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void ScoreCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ScoreCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ScoreCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ScoreCreatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void ScoreCreatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            _ = OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        /// <summary>
        /// Test to check if create button 
        /// is disabled if Name is null
        /// </summary>
        [Test]
        public void ScoreCreatePage_SetCreateVisibility_Name_Null_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = null;
            page.ViewModel.Data.ScoreTotal = 1;

            // Act
            page.SetCreateVisibility();

            // Reset

            // Assert
            Assert.IsTrue(false == page.CreateButton_Enabled());
        }

        /// <summary>
        /// Test to check if create button 
        /// is disabled if Score is null
        /// </summary>
        [Test]
        public void ScoreCreatePage_SetCreateVisibility_Score_Zero_Or_Less_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = "Score1";
            page.ViewModel.Data.ScoreTotal = 0;

            // Act
            page.SetCreateVisibility();

            // Reset

            // Assert
            Assert.IsTrue(false == page.CreateButton_Enabled());
        }

        /// <summary>
        /// Test to check if create button 
        /// is disabled if Score and Name is null
        /// </summary>
        [Test]
        public void ScoreCreatePage_SetCreateVisibility_Name_And_Score_Null_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = null;
            page.ViewModel.Data.Description = null;

            // Act
            page.SetCreateVisibility();
            // Reset

            // Assert
            Assert.IsTrue(false == page.CreateButton_Enabled());
        }

        /// <summary>
        /// Test to check if create button 
        /// is enabled if Score and Name is not null
        /// </summary>
        [Test]
        public void ScoreCreatePage_SetCreateVisibility_Name_And_Score_Not_Null_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = "Score1";
            page.ViewModel.Data.ScoreTotal = 1;

            // Act
            page.SetCreateVisibility();
            // Reset

            // Assert
            Assert.IsTrue(page.CreateButton_Enabled());
        }






    }
}