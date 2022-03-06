using Game.Models;
using Game.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VillagePage : ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VillagePage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Jump to the Monsters
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void MonstersButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MonsterIndexPage());
		}

		/// <summary>
		/// Jump to the Characters
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void CharactersButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CharacterIndexPage());
		}

		/// <summary>
		/// Jump to the Items
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void ItemsButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ItemIndexPage());
		}

		/// <summary>
		/// Jump to the Scores
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void ScoresButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ScoreIndexPage());
		}

		/// <summary>
		/// Call for Items using Http Post
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void FetchItemsPost_Command(object sender, EventArgs e)
		{
			_ = await GetItemsPost();
		}

		/// <summary>
		/// Get Items using the HTTP Post command
		/// </summary>
		/// <returns></returns>
		public async Task<bool> GetItemsPost()
		{
			//var number = Convert.ToInt32(ServerItemValue.Text);
			if (int.TryParse(ServerItemValue.Text, out var number) == false)
			{
				return false;
			}

			var level = 6;  // Max Value of 6
			var attribute = AttributeEnum.Unknown;  // Any Attribute
			var location = ItemLocationEnum.Unknown;    // Any Location
			var random = true;  // Random between 1 and Level
			var updateDataBase = true;  // Add them to the DB
			var category = 8;   // What category to filter down to, 0 is all

			var dataList = await ItemService.GetItemsFromServerPostAsync(number, level, attribute, location, category, random, updateDataBase);
			//_ = DisplayServerResults(dataList);

			return true;
		}

		/// <summary>
		/// Show the Results of the server call
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		//public bool DisplayServerResults(List<ItemModel> dataList)
		//{
		//	var result = new StringBuilder("");
		//	ServerItemsList.IsVisible = true;
		//	ServerItemsList.Text = "No Results";

		//	if (dataList == null)
		//	{
		//		return false;
		//	}

		//	foreach (var ItemModel in dataList)
		//	{
		//		// Add them line by one, use \n to force new line for output display.
		//		// Build up the output string by adding formatted ItemModel Output
		//		_ = result.AppendLine(ItemModel.FormatOutput());
		//	}

		//	// If there is results show them
		//	if (dataList.Count > 0)
		//	{
		//		ServerItemsList.Text = result.ToString();
		//	}

		//	return true;
		//}
	}
}