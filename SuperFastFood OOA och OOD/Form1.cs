using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Xml.Linq;

namespace SuperFastFood_OOA_och_OOD
{
    public partial class Form1 : Form
    {

        TextBox[] textBoxesCustomer;

        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();

            string server = "localhost";
            string database = "superfastfood";
            string user = "root";
            string password = "MorrisZonya99!";

            string connString = $"SERVER={server}; DATABASE={database}; UID = {user}; PASSWORD ={password};";

            conn = new MySqlConnection(connString);

            //Skapar array referens f�r de boxar d�r kund kan l�mna input 
            textBoxesCustomer = new TextBox[] { txtBoxAdress, txtBoxName };

        }



        private void ShowRestaurants()
        {
            //Skapar en aqlquerry
            string Sqlquerry;

            Sqlquerry = $"CALL ShowRestaurants";

            MySqlCommand cmd = new MySqlCommand(Sqlquerry,conn);

            try
            {
                //�ppnar kopplingen till DB
                conn.Open();

                //Exekvera cmd
                MySqlDataReader reader = cmd.ExecuteReader();

                //Placera data i en DataTable objekt
                DataTable dt = new DataTable();
                dt.Load(reader);

                //Koppla TableData objekt som DataSource till Grid
                GridViewRestaurants.DataSource = dt;

                //Ladda Reader p� nytt
                reader = cmd.ExecuteReader();


                //T�mma den statiska listan 
                Restaurants.rest.Clear();

                //While Loop f�r att spara datan lokalt i en lista
                while (reader.Read())
                {
                    //H�mta och spara data till variabler
                    string Restauranger = reader["Restaurang"].ToString();
                    


                    //Skapar matr�tt objekt och sparar i statisk lista
                    Restaurants.rest.Add(new Restaurants(Restauranger));
                }

                //St�nger kopplingen till DB
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GridViewBomabayFoodMenu()
        {
            //Skapar Sqlquerry
            string Sqlquerry;

            Sqlquerry = $"CALL BombayFoodMenu";

            MySqlCommand cmd = new MySqlCommand(@Sqlquerry, conn);

            //Exekvera Querry mot DB. F� data tillbaka
            try
            {
                //�ppnar kopplingen till DB
                conn.Open();

                //Exekvera cmd
                MySqlDataReader reader = cmd.ExecuteReader();

                //Placera data i en DataTable objekt
                DataTable dt = new DataTable();
                dt.Load(reader);

                //Koppla TableData objekt som DataSource till Grid
                GridViewBombayFood.DataSource = dt;

                //Ladda Reader p� nytt
                reader = cmd.ExecuteReader();


                //T�mma den statiska listan 
                Matr�tter.GetMatr�tter.Clear();

                //While Loop f�r att spara datan lokalt i en lista
                while (reader.Read())
                {
                    //H�mta och spara data till variabler
                    string Dish = reader["Dish"].ToString();
                    string Price = reader["Price"].ToString();


                    //Skapar matr�tt objekt och sparar i statisk lista
                    Matr�tter.GetMatr�tter.Add(new Matr�tter(Dish, Price));
                }

                //St�nger kopplingen till DB
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowRestaurangs_MouseClick(object sender, MouseEventArgs e)
        {
           ShowRestaurants();
           //G�r knapparna f�r att v�lja mellan de olika restaurangerna synliga
           btnBombayFood.Visible = true;
           btnLaoSiam.Visible = true;
           btnBurgers.Visible = true;
           //G�r datagriden synlig med de olika alternativen av restauranger
           GridViewRestaurants.Visible = true;
        }

        private void btnBombayFood_MouseClick(object sender, MouseEventArgs e)
        {
            
            panelBombay.BringToFront();
        }


        private void btnMenuBombayFood_MouseClick(object sender, MouseEventArgs e)
        {
            GridViewBomabayFoodMenu();
            //G�r menyn synlig f�r den valda restautrangen
            GridViewBombayFood.Visible = true;

            //G�r knapparna f�r att v�lja mellan de olika matr�tterna synliga 
            btnTikkaMasala.Visible = true;
            btnBeefKorma.Visible = true;
        }


        private void GridViewLaoSiamMenu()
        {
            //Skapar Sqlquerry
            string Sqlquerry;

            Sqlquerry = $"CALL LaoSiamMenu";

            MySqlCommand cmd = new MySqlCommand(@Sqlquerry, conn);

            //Exekvera Querry mot DB. F� data tillbaka
            try
            {
                //�ppnar kopplingen till DB
                conn.Open();

                //Exekvera cmd
                MySqlDataReader reader = cmd.ExecuteReader();

                //Placera data i en DataTable objekt
                DataTable dt = new DataTable();
                dt.Load(reader);

                //Koppla TableData objekt som DataSource till Grid
                GridViewLaoMenu.DataSource = dt;

                //Ladda Reader p� nytt
                reader = cmd.ExecuteReader();


                //T�mma den statiska listan 
                Matr�tter.GetMatr�tter.Clear();

                //While Loop f�r att spara datan lokalt i en lista
                while (reader.Read())
                {
                    //H�mta och spara data till variabler
                    string Dish = reader["Dish"].ToString();
                    string Price = reader["Price"].ToString();


                    //Skapar matr�tt objekt och sparar i statisk lista
                    Matr�tter.GetMatr�tter.Add(new Matr�tter(Dish, Price));
                }

                //St�nger koppling till DB
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackToStart2_MouseClick(object sender, MouseEventArgs e)
        {
            panelStartsida.BringToFront();
        }

        private void btnLaoSiam_MouseClick(object sender, MouseEventArgs e)
        {
            panelLaoSiam.BringToFront();


        }

        private void btnBackToStart_MouseClick(object sender, MouseEventArgs e)
        {
            panelStartsida.BringToFront();
        }

        private void btnLaoSiamMenu_MouseClick(object sender, MouseEventArgs e)
        {
            GridViewLaoSiamMenu();

            //G�r menyn synlig f�r den valda restautrangen
            GridViewLaoMenu.Visible = true;

            //G�r knapparna f�r att v�lja mellan de olika matr�tterna synliga
            btnPadThai.Visible = true;
            btnPadSateh.Visible = true;
            btnKhaoPad.Visible = true;
        }

        private void GridViewHomeOfBurgersMenu()
        {
            //Skapar Sqlquerry
            string Sqlquerry;

            Sqlquerry = $"CALL HomeOfBurgersMenu";

            MySqlCommand cmd = new MySqlCommand(@Sqlquerry, conn);

            //Exekvera Querry mot DB. F� data tillbaka
            try
            {
                //�ppnar kopplingen till DB
                conn.Open();

                //Exekvera cmd
                MySqlDataReader reader = cmd.ExecuteReader();

                //Placera data i en DataTable objekt
                DataTable dt = new DataTable();
                dt.Load(reader);

                //Koppla TableData objekt som DataSource till Grid
                GridViewBurgers.DataSource = dt;

                //Ladda Reader p� nytt
                reader = cmd.ExecuteReader();


                //T�mma den statiska listan 
                Matr�tter.GetMatr�tter.Clear();

                //While Loop f�r att spara datan lokalt i en lista
                while (reader.Read())
                {
                    //H�mta och spara data till variabler
                    string Dish = reader["Dish"].ToString();
                    string Price = reader["Price"].ToString();


                    //Skapar matr�tt objekt och sparar i statisk lista
                    Matr�tter.GetMatr�tter.Add(new Matr�tter(Dish, Price));
                }

                //St�nger koppling till DB
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBurgersMenu_MouseClick(object sender, MouseEventArgs e)
        {
            GridViewHomeOfBurgersMenu();

            //G�r menyn synlig f�r den valda restautrangen
            GridViewBurgers.Visible = true;

            //G�r knapparna f�r att v�lja mellan de olika matr�tterna synliga
            btnCheeseburger.Visible = true;
            btnTruffle.Visible = true;
            btnBacon.Visible = true;
        }

        private void btnBackToStart3_MouseClick(object sender, MouseEventArgs e)
        {
            panelStartsida.BringToFront();
        }

        private void btnBurgers_MouseClick(object sender, MouseEventArgs e)
        {
            panelBurgers.BringToFront();
        }

        private void btnCheeseburger_MouseClick(object sender, MouseEventArgs e)
        {
            panelCheckOut.BringToFront();

            //�ndrar texten p� checkout sidan utifr�n kundens val
            LabelSelectedDish.Text = "Classic Cheeseburger";
            LabelSelectedDishPrice.Text = "115 Kr";
            
        }
        

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //Validering
            bool valid = true;

            foreach (TextBox txtBox in textBoxesCustomer)
            {
                txtBox.Text = txtBox.Text.Trim();

                //Kontrollera att txtBox har text
                if (txtBox.Text == "")
                {
                    //Validering har misslyckats
                    valid = false;
                    txtBox.BackColor = Color.Red;
                }
                else
                {
                    
                    txtBox.BackColor = TextBox.DefaultBackColor;
                    //Om kraven �r uppfylda g�r best�llningen igenom med validering till kund
                    MessageBox.Show($"{txtBoxName.Text} Your Order is confirmed");
                    
                }

               

            }

            //Kontrollera valid

            if (!valid)
            {
                //Ger felmeddelande ifall textrutor ej �r ifyllda
                MessageBox.Show("Faulty input. Verify the red boxes.");
                return;
            }

        }

        private void btnTruffle_MouseClick(object sender, MouseEventArgs e)
        {
            panelCheckOut.BringToFront();

            //�ndrar texten p� checkout sidan utifr�n kundens val
            LabelSelectedDish.Text = "Truffle Burger";
            LabelSelectedDishPrice.Text = "130 Kr";
        }

        private void btnBacon_MouseClick(object sender, MouseEventArgs e)
        {
            panelCheckOut.BringToFront();

            //�ndrar texten p� checkout sidan utifr�n kundens val
            LabelSelectedDish.Text = "Cheese 'n' Bacon";
            LabelSelectedDishPrice.Text = "120 Kr";
        }

        private void btnPadThai_MouseClick(object sender, MouseEventArgs e)
        {
            panelCheckOut.BringToFront();

            //�ndrar texten p� checkout sidan utifr�n kundens val
            LabelSelectedDish.Text = "Pad Thai";
            LabelSelectedDishPrice.Text = "100 Kr";
        }

        private void btnKhaoPad_MouseClick(object sender, MouseEventArgs e)
        {
            panelCheckOut.BringToFront();

            //�ndrar texten p� checkout sidan utifr�n kundens val
            LabelSelectedDish.Text = "Khao Pad";
            LabelSelectedDishPrice.Text = "110 Kr";
        }

        private void btnPadSateh_MouseClick(object sender, MouseEventArgs e)
        {
            panelCheckOut.BringToFront();

            //�ndrar texten p� checkout sidan utifr�n kundens val
            LabelSelectedDish.Text = "Pad Sateh";
            LabelSelectedDishPrice.Text = "115 Kr";
        }

        private void btnTikkaMasala_MouseClick(object sender, MouseEventArgs e)
        {
            panelCheckOut.BringToFront();

            //�ndrar texten p� checkout sidan utifr�n kundens val
            LabelSelectedDish.Text = "Chicken Tikka Masala";
            LabelSelectedDishPrice.Text = "130 Kr";
        }

        private void btnBeefKorma_MouseClick(object sender, MouseEventArgs e)
        {
            panelCheckOut.BringToFront();

            //�ndrar texten p� checkout sidan utifr�n kundens val
            LabelSelectedDish.Text = "Beef Korma";
            LabelSelectedDishPrice.Text = "125 Kr";
        }

        private void btnBackToStartCheckOut_MouseClick(object sender, MouseEventArgs e)
        {
            panelStartsida.BringToFront();
        }
    }

   

   
}