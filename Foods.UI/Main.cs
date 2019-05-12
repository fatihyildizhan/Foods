﻿using System;
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
        List<Country> countries = new List<Country>();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UpdateCountriesListBox();
        }

        private void UpdateCountriesListBox()
        {
            DataAccess db = new DataAccess();
            countries = db.GetCountries();

            countriesListBox.DataSource = countries;
            countriesListBox.DisplayMember = "WithAbbr";
        }

        private void BtnAddCountry_Click(object sender, EventArgs e)
        {
            lblAddCountryResult.Visible = false;

            if (txtCountryName.Text.Length > 0 && txtCountryAbbr.Text.Length > 0)
            {
                try
                {
                    DataAccess db = new DataAccess();
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
    }
}
