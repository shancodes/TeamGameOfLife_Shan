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

			// Init the Server Item Value to 100 to get everything
			SetServerItemValue("100");
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

			return true;
		}

		/// <summary>
		/// Set the value for the Server Item
		/// </summary>
		/// <param name="value"></param>
		public void SetServerItemValue(string value)
		{
			ServerItemValue.Text = value;
		}
	}
}