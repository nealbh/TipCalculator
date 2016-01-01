using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace TipCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Tip tip;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            tip = new Tip();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            performCalculation();
        }

        private void amountTextBox_lostFocus(object sender, RoutedEventArgs e)
        {
            billAmountTextBox.Text = tip.BillAmount;
        }

        private void amountTextBox_textChange(object sender, TextChangedEventArgs e)
        {
            performCalculation();
        }

        private void amountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            billAmountTextBox.Text = "";
        }
        private void performCalculation()
        {
            // var selectedRadio = //myStackPanel.Children.OfType<RadioButton>().
            //   list.FirstOrDefault(r => r.IsChecked == true);

            double selectedRadio = 0.00;
            if (ten.IsChecked == true)
            {
                selectedRadio = 0.10;
            }
            else if(fifteen.IsChecked == true)
            {
                     selectedRadio = 0.15;
            }
            else
            {
                    selectedRadio = 0.20;
            }
            tip.CalculateTip(billAmountTextBox.Text, double.Parse(selectedRadio.ToString()));
            Total.Text = tip.TotalAmount;

            double billAmount = 0.00;
            if (double.TryParse(billAmountTextBox.Text.Replace('$', ' '), out billAmount))
            {
                ten_tip.Text = String.Format("{0:C}", billAmount * 0.1);
                fifteen_tip.Text = String.Format("{0:C}", billAmount * 0.15);
                twenty_tip.Text = String.Format("{0:C}", billAmount * 0.2);
            }

            if (round.IsChecked == true)
            {
                object sender = null;
                RoutedEventArgs e = null;
                CheckBox_Click(sender, e);
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (round.IsChecked == true)
            {
                custom_percentage.Visibility = Visibility.Visible;
                custom_amount.Visibility = Visibility.Visible;

                double billAmt = 0.00;
                double total = 0.00;

                Double.TryParse(billAmountTextBox.Text.Replace('$',' '), out billAmt);
                Double.TryParse(Total.Text.Replace('$', ' '), out total);

                total = Math.Ceiling(total);
                double tipAmt = total - billAmt;

                custom_percentage.Text = String.Format("{0:P2}", tipAmt / billAmt );
                custom_amount.Text = String.Format("{0:C}", tipAmt);
                Total.Text = String.Format("{0:C}",total);
            }
            else
            {
                custom_percentage.Visibility = Visibility.Collapsed;
                custom_amount.Visibility = Visibility.Collapsed;
                performCalculation();
            }
        }
    }
}
