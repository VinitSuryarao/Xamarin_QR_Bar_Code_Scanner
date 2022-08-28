using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarCode_QRCode_Scanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void BtnScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scan = new ZXing.Net.Mobile.Forms.ZXingScannerPage();
                await Navigation.PushAsync(scan);
                scan.OnScanResult += (result) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PopAsync();
                        lblText.Text = result.Text;
                    });

                };
            }
            catch(Exception ex)
            {
                lblText.Text = ex.Message;
            }
        }
    }
}
