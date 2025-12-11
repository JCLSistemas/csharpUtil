using System;
using System.Windows.Forms;
using CSharpUtil.Services;

namespace dotNetUtilitiesTester
{
    public partial class frmGoogleMaps : Form
    {
        public frmGoogleMaps()
        {
            InitializeComponent();
            txtToken.Text = "AIzaSyB-FKOO83sFMScIeBWjtUWKJvHJY9bJfys";
            //txtEndereco.Text = "Rua Dionísio da Costa, São Paulo, SP";
            txtEndereco.Text = "Rua Lino de Almeida Pires, São Paulo, SP";
        }


         private void btnGetLatitudeLongitudeByAddress_Click(object sender, EventArgs e)
        {
            GoogleMaps googleMaps = new GoogleMaps(txtToken.Text.Trim());
            txtResult.Text = googleMaps.GetLatLongByAddress(txtEndereco.Text.Trim());
        }

        private void btnGetGeoLocalizationByCEP_Click(object sender, EventArgs e)
        {
            GoogleMaps googleMaps = new GoogleMaps(txtToken.Text.Trim());
            txtResult.Text = googleMaps.GetLatLongByCEP(txtCEP.Text.Trim());
        }

        private void btnGetAddressByCEP_Click(object sender, EventArgs e)
        {
            GoogleMaps googleMaps = new GoogleMaps(txtToken.Text.Trim());
            txtResult.Text = googleMaps.GetAddressByCEP(txtCEP.Text.Trim());
        }
    }
}
