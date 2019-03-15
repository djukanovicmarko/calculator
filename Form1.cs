using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Domaci3
{
    public partial class Form1 : Form
    {

        
        // Promenljiva koja cuva rezultat operacija
        double rezultat = 0;
        // Promenljiva koja cuva poslednje odabranu operaciju
        string operacija = "";
        /* Promenljiva koja odredjuje da li je na displeju prikazan rezultat racunanja
         ili vrednost koja se unosi putem dugmica*/
        bool prikazRezultata = false;
        public Form1()
        {
            InitializeComponent();
           
        }
        /* Klikom na dugmice sa brojevima,
         unosi se u displej broj koji je na njima prikazan*/
        private void Buttons_Click(object sender, EventArgs e)
        {
            /* Ukoliko je na displeju prikazan rezultat racunanja
             dati prikaz se menja brojevima koji se unose pomocu dugmadi*/
            if (prikazRezultata)
            {
                txtDisplej.Text = ((Button)sender).Text;
                prikazRezultata = false;
            }
            // u protivnom se novi broj dodaje iza vec postojecih brojeva
            else
            {
                txtDisplej.AppendText(((Button)sender).Text);
            }


        }
        /* Klikom na dugmice sa operacijama,
         racuna se rezultat operacija i prikazuje na displeju*/
        private void Operations_Click(object sender, EventArgs e)
        {
            try
            {
                checked
                {
                    switch (operacija)
                    {
                        case "":
                            rezultat = Convert.ToDouble(txtDisplej.Text);
                            prikazRezultata = true;
                            txtDisplej.Text = rezultat.ToString();
                            operacija = ((Button)sender).Text;
                            break;
                        case "+":
                            rezultat += Convert.ToDouble(txtDisplej.Text);
                            prikazRezultata = true;
                            txtDisplej.Text = rezultat.ToString();
                            operacija = ((Button)sender).Text;
                            break;
                        case "*":
                            if (Convert.ToDouble(txtDisplej.Text) > 5000)
                            {
                                Exception mojIzuzetak = new Exception("Maksimalni mnozilac je 5000");
                                throw mojIzuzetak;
                            }
                            rezultat *= Convert.ToDouble(txtDisplej.Text);
                            prikazRezultata = true;
                            txtDisplej.Text = rezultat.ToString();
                            operacija = ((Button)sender).Text;
                            break;
                        case "-":
                            rezultat -= Convert.ToDouble(txtDisplej.Text);
                            prikazRezultata = true;
                            txtDisplej.Text = rezultat.ToString();
                            operacija = ((Button)sender).Text;
                            break;
                        case "x²":
                            rezultat *= rezultat;
                            prikazRezultata = true;
                            txtDisplej.Text = rezultat.ToString();
                            operacija = ((Button)sender).Text;
                            break;
                        case "√x":
                            rezultat = Math.Sqrt(rezultat);
                            prikazRezultata = true;
                            txtDisplej.Text = rezultat.ToString();
                            operacija = ((Button)sender).Text;
                            break;
                       
                        case "/":
                            rezultat /= Convert.ToDouble(txtDisplej.Text);
                            prikazRezultata = true;
                            txtDisplej.Text = rezultat.ToString();
                            operacija = ((Button)sender).Text;
                            break;

                        case "1/x":
                            rezultat = 1 / Convert.ToDouble(txtDisplej.Text);
                            prikazRezultata = true;
                            txtDisplej.Text = rezultat.ToString();
                            operacija = ((Button)sender).Text;
                            break;
                            
                       

                    }
                    // Ukoliko je kliknuto na taster = resetuju se podesavanja
                    if (operacija == "=")
                    {
                        rezultat = 0;
                        operacija = "";
                        prikazRezultata = true;
                    }
                }
            }
                //Greske
            catch (FormatException)
            {
                txtDisplej.Text = "Greska u formatu";
                rezultat = 0;
                operacija = "";
                prikazRezultata = true;
            }
            catch (OverflowException)
            {
                txtDisplej.Text = "Prekoracenje opsega";
                rezultat = 0;
                operacija = "";
                prikazRezultata = true;
            }
            catch (Exception izuzetak)
            {
                txtDisplej.Text = izuzetak.Message;
                rezultat = 0;
                operacija = "";
                prikazRezultata = true;
            }
        }

        private void decimalbtn_Click(object sender, EventArgs e)
        {
            //Dodavanje decimale
            if( !txtDisplej.Text.Contains(".") )
                txtDisplej.Text = txtDisplej.Text + ".";
    
}
        //Ocisti vrednosti sa Displeja
        private void clrbtn_Click(object sender, EventArgs e)
        {
            txtDisplej.Text = String.Empty;
        }

        }
    }
