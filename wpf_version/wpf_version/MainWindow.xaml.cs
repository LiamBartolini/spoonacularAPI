using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_version
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string APIKEY = "aba2b591b71b429e8dc8a2d250f78e90";
        public MainWindow()
        {
            InitializeComponent();
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

                    default:
                        break;
                }

                txtBox.Text = text;
            }
        }
        #endregion
    }
}
