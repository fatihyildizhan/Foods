using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
// Self
using Foods.Data;
using Foods.Data.Models;

namespace Foods.UI
{
    public partial class Main : Form
    {
        List<FoodFull> foods = new List<FoodFull>();
        List<Country> countries = new List<Country>();
        List<Currency> currencies = new List<Currency>();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UpdateCountriesListBox();
            UpdateFoodsListBox();
            UpdateCurrenciesComboBox();
            UpdateCountriesComboBox();
        }

        // Fetch Country ListBox
        private void UpdateCountriesListBox()
        {
            CountryDataAccess db = new CountryDataAccess();
            countries = db.GetCountries();

            countriesListBox.DataSource = countries;
            countriesListBox.DisplayMember = "WithAbbr";
        }

        // Fetch Currency ComboBox
        private void UpdateCurrenciesComboBox()
        {
            CurrencyDataAccess db = new CurrencyDataAccess();
            currencies = db.GetCurrencies();

            cmbFoodCurrency.DataSource = currencies;
            cmbFoodCurrency.DisplayMember = "WithSymbol";
        }

        // Only Bind from current list
        private void UpdateCountriesComboBox()
        {
            cmbFoodCountry.DataSource = countries;
            cmbFoodCountry.DisplayMember = "WithAbbr";
        }

        // Fetch Foods ListBox
        private void UpdateFoodsListBox()
        {
            FoodDataAccess db = new FoodDataAccess();
            foods = db.GetFoods();

            foodsListBox.DataSource = foods;
            foodsListBox.DisplayMember = "Full";
        }

        private void BtnAddCountry_Click(object sender, EventArgs e)
        {
            lblAddCountryResult.Visible = false;

            if (txtCountryName.Text.Length > 0 && txtCountryAbbr.Text.Length > 0)
            {
                try
                {
                    CountryDataAccess db = new CountryDataAccess();
                    db.AddCountry(txtCountryName.Text, txtCountryAbbr.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    lblAddCountryResult.ForeColor = Color.Red;
                    lblAddCountryResult.Text = ex.Message;
                    lblAddCountryResult.Visible = true;
                }

                UpdateCountriesListBox();

                txtCountryName.Text = "";
                txtCountryAbbr.Text = "";
            }
            else
            {
                MessageBox.Show("This field cannot be empty!");
            }
        }

        private void BtnAddFood_Click(object sender, EventArgs e)
        {
            Country coun = (Country)cmbFoodCountry.SelectedValue;
            Currency cur = (Currency)cmbFoodCurrency.SelectedValue;

            FoodDataAccess fd = new FoodDataAccess();
            fd.AddFood(new Food { Name = txtFoodName.Text, Price = Convert.ToDecimal(txtFoodPrice.Text), CountryId = coun.Id, CurrencyId = cur.Id });

            // Refresh 
            UpdateFoodsListBox();
        }
    }
}
