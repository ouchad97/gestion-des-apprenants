using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scolaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            //combobox pays
            pays.Text = "sélectionnez votre pays";
            pays.Items.Add("Maroc");
            pays.Items.Add("France");
            pays.Items.Add("Espagne");

            ville.Enabled = false; 
            ville.Text = "sélectionnez votre ville";
        }

        private void pays_SelectedIndexChanged(object sender, EventArgs e)
        {
            //combobox ville
            ville.Enabled = true;
            if (pays.SelectedItem.ToString() == "Maroc") {
                ville.Items.Clear();
                ville.Items.Add("Rabat");
                ville.Items.Add("Casablanca");
                ville.Items.Add("Safi");
                ville.Items.Add("Fes");
                ville.Items.Add("Agadir");
            }
            else{
                if (pays.SelectedItem.ToString() == "France") {
                    ville.Items.Clear();
                    ville.Items.Add("Marseille");
                    ville.Items.Add("Bordeaux");
                    ville.Items.Add("Strasbourg");
                    ville.Items.Add("Lyon");
                    ville.Items.Add("Paris");
                }

                if (pays.SelectedItem.ToString() == "Espagne") {
                    ville.Items.Clear();
                    ville.Items.Add("Barcelona");
                    ville.Items.Add("Seville");
                    ville.Items.Add("Madrid");
                    ville.Items.Add("Bilbao");
                    ville.Items.Add("Granada");
                }
            }

        }

        private void prenom_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rpreNom = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$");

            if (string.IsNullOrEmpty(prenom.Text))
            {
                errorProviderNom.SetError(prenom, "Prenom required!");
            }
            else if (!rpreNom.IsMatch(prenom.Text))
            {
                errorProviderNom.SetError(prenom, "PrenomInvalid");
            }
            else
            {
                errorProviderNom.SetError(prenom, null);
            }
        }
        private void nom_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rNom = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$");

            if (string.IsNullOrEmpty(nom.Text))
            {
                errorProviderNom.SetError(nom, "Nom required!");
            }
            else if (!rNom.IsMatch(nom.Text))
            {
                errorProviderNom.SetError(nom, "Nom Invalid");
            }
            else {
                errorProviderNom.SetError(nom, null);
            }
        }
        private void email_Validating(object sender, CancelEventArgs e)
        {
                System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");


                if (string.IsNullOrEmpty(email.Text))
                {
                    errorProviderEmail.SetError(email, "Email required!");
                }
                    else if (!rEMail.IsMatch(email.Text)){
                        errorProviderEmail.SetError(email,"Email Invalid");
                    }
                    else {
                        errorProviderEmail.SetError(email, null);
                    } 
        }

        private void tel_Validating(object sender, CancelEventArgs e)
        {  System.Text.RegularExpressions.Regex rTEL = new System.Text.RegularExpressions.Regex(@"^[0-7]{2}[0-9]{8}$");

            if (string.IsNullOrEmpty(tel.Text)){
                errorProviderTel.SetError(tel, "Phone required!");
                }
            else if (!rTEL.IsMatch(tel.Text)){
                    errorProviderTel.SetError(tel, "Phone Invalid");
                }
                else{
                    errorProviderTel.SetError(tel, null);
                    }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Focus();
                if (!Validate())
                {
                    DialogResult = DialogResult.None;
                    return;
                }
            }
        }

       
    }
}
