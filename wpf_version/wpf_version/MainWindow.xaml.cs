using System;
using System.Windows;
using Newtonsoft.Json;
using System.Net.Http;
using wpf_version.Models;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Diagnostics;

namespace wpf_version
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Uri _apiUri = new("https://api.spoonacular.com/recipes/complexSearch");
        private const string APIKEY = "aba2b591b71b429e8dc8a2d250f78e90";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetRecipes(object sender, RoutedEventArgs e)
        {
            string urlParams = $"?apiKey={APIKEY}";

            // prendo tutti i valori da i text box controllo se sono stati inseriti dei valori
            _ = max_carbs.Text != "Enter max amount of carbs..." ? urlParams += $"&maxCarbs={max_carbs.Text}" : "";
            _ = max_pro.Text != "Enter max amount of pro..." ? urlParams += $"&maxProtein={max_pro.Text}" : "";
            _ = max_cals.Text != "Enter max amount of cals..." ? urlParams += $"&maxCalories={max_cals.Text}" : "";
            _ = max_fat.Text != "Enter max amount of fat..." ? urlParams += $"&maxFat={max_fat.Text}" : "";
            _ = main_ingredient.Text != "Enter the main ingredient..." ? urlParams += $"&query={main_ingredient.Text}" : "";
            _ = number_recipes.Text != "Enter the number of recipes..." ? urlParams += $"&number={number_recipes.Text}" : "";

            using (HttpClient client = new())
            {
                HttpResponseMessage response = client.GetAsync(_apiUri + urlParams).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;

                Recipe recipe = JsonConvert.DeserializeObject<Recipe>(responseBody);
                listViewRecipes.ItemsSource = recipe.results;
            }
        }

        private void ClearWindow(object sender, RoutedEventArgs e)
        {
            max_carbs.Text = "Enter max amount of carbs...";
            max_pro.Text = "Enter max amount of pro...";
            max_cals.Text = "Enter max amount of cals...";
            max_fat.Text = "Enter max amount of fat...";
            main_ingredient.Text = "Enter the main ingredient...";
            number_recipes.Text = "Enter the number of recipes...";
            listViewRecipes.ItemsSource = null;
        }

        #region "placeholder"
        private void RemoveText(object sender, RoutedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            string text = "";

            switch (txtBox.Name)
            {
                case "max_carbs":
                    text = "Enter max amount of carbs...";
                    break;

                case "max_pro":
                    text = "Enter max amount of pro...";
                    break;

                case "max_cals":
                    text = "Enter max amount of cals...";
                    break;

                case "max_fat":
                    text = "Enter max amount of fat...";
                    break;

                case "main_ingredient":
                    text = "Enter the main ingredient...";
                    break;

                case "number_recipes":
                    text = "Enter the number of recipes...";
                    break;

                default:
                    break;
            }

            if (txtBox.Text == text)
                txtBox.Text = string.Empty;
        }

        private void AddText(object sender, RoutedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            string text = "";
            if (string.IsNullOrWhiteSpace(txtBox.Text))
            {
                switch (txtBox.Name)
                {
                    case "max_carbs":
                        text = "Enter max amount of carbs...";
                        break;

                    case "max_pro":
                        text = "Enter max amount of pro...";
                        break;

                    case "max_cals":
                        text = "Enter max amount of cals...";
                        break;

                    case "max_fat":
                        text = "Enter max amount of fat...";
                        break;

                    case "main_ingredient":
                        text = "Enter the main ingredient...";
                        break;

                    case "number_recipes":
                        text = "Enter the number of recipes...";
                        break;

                    default:
                        break;
                }

                txtBox.Text = text;
            }
        }
        #endregion
    }
}
