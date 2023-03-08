using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Xml.Linq;

namespace SuperFastFood_OOA_och_OOD
{
    public partial class Form1 : Form
    {
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


        }



        private void ShowRestaurants()
        {
            string Sqlquerry;

            Sqlquerry = $"CALL ShowRestaurants";

            MySqlCommand cmd = new MySqlCommand(Sqlquerry,conn);

            try
            {
                //Öppnar kopplingen till DB
                conn.Open();

                //Exekvera cmd
                MySqlDataReader reader = cmd.ExecuteReader();

                //Placera data i en DataTable objekt
                DataTable dt = new DataTable();
                dt.Load(reader);

                //Koppla TableData objekt som DataSource till Grid
                GridViewRestaurants.DataSource = dt;

                //Ladda Reader på nytt
                reader = cmd.ExecuteReader();


                //Tömma den statiska listan 
                Restaurants.rest.Clear();

                //While Loop för att spara datan lokalt i en lista
                while (reader.Read())
                {
                    //Hämta och spara data till variabler
                    string Restauranger = reader["Restaurang"].ToString();
                    


                    //Skapar film  objekt och sparar i statisk lista
                    Restaurants.rest.Add(new Restaurants(Restauranger));
                }

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GridViewBomabayFoodMenu()
        {
            string Sqlquerry;

            Sqlquerry = $"CALL BombayFoodMenu";

            MySqlCommand cmd = new MySqlCommand(@Sqlquerry, conn);

            //Exekvera Querry mot DB. Få data tillbaka
            try
            {
                //Öppnar kopplingen till DB
                conn.Open();

                //Exekvera cmd
                MySqlDataReader reader = cmd.ExecuteReader();

                //Placera data i en DataTable objekt
                DataTable dt = new DataTable();
                dt.Load(reader);

                //Koppla TableData objekt som DataSource till Grid
                GridViewBombayFood.DataSource = dt;

                //Ladda Reader på nytt
                reader = cmd.ExecuteReader();


                //Tömma den statiska listan 
                Maträtter.GetMaträtter.Clear();

                //While Loop för att spara datan lokalt i en lista
                while (reader.Read())
                {
                    //Hämta och spara data till variabler
                    string Dish = reader["Dish"].ToString();
                    string Price = reader["Price"].ToString();


                    //Skapar film  objekt och sparar i statisk lista
                    Maträtter.GetMaträtter.Add(new Maträtter(Dish, Price));
                }

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
           btnBombayFood.Visible = true;
           btnLaoSiam.Visible = true;
           btnBurgers.Visible = true;
            GridViewRestaurants.Visible = true;
        }

        private void btnBombayFood_MouseClick(object sender, MouseEventArgs e)
        {
            panelBombay.BringToFront();
        }


        private void btnMenuBombayFood_MouseClick(object sender, MouseEventArgs e)
        {
            GridViewBomabayFoodMenu();
            GridViewBombayFood.Visible = true;
        }


        private void GridViewLaoSiamMenu()
        {
            string Sqlquerry;

            Sqlquerry = $"CALL LaoSiamMenu";

            MySqlCommand cmd = new MySqlCommand(@Sqlquerry, conn);

            //Exekvera Querry mot DB. Få data tillbaka
            try
            {
                //Öppnar kopplingen till DB
                conn.Open();

                //Exekvera cmd
                MySqlDataReader reader = cmd.ExecuteReader();

                //Placera data i en DataTable objekt
                DataTable dt = new DataTable();
                dt.Load(reader);

                //Koppla TableData objekt som DataSource till Grid
                GridViewLaoMenu.DataSource = dt;

                //Ladda Reader på nytt
                reader = cmd.ExecuteReader();


                //Tömma den statiska listan 
                Maträtter.GetMaträtter.Clear();

                //While Loop för att spara datan lokalt i en lista
                while (reader.Read())
                {
                    //Hämta och spara data till variabler
                    string Dish = reader["Dish"].ToString();
                    string Price = reader["Price"].ToString();


                    //Skapar film  objekt och sparar i statisk lista
                    Maträtter.GetMaträtter.Add(new Maträtter(Dish, Price));
                }

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
            GridViewLaoMenu.Visible = true;
        }

        private void GridViewHomeOfBurgersMenu()
        {
            string Sqlquerry;

            Sqlquerry = $"CALL HomeOfBurgersMenu";

            MySqlCommand cmd = new MySqlCommand(@Sqlquerry, conn);

            //Exekvera Querry mot DB. Få data tillbaka
            try
            {
                //Öppnar kopplingen till DB
                conn.Open();

                //Exekvera cmd
                MySqlDataReader reader = cmd.ExecuteReader();

                //Placera data i en DataTable objekt
                DataTable dt = new DataTable();
                dt.Load(reader);

                //Koppla TableData objekt som DataSource till Grid
                GridViewBurgers.DataSource = dt;

                //Ladda Reader på nytt
                reader = cmd.ExecuteReader();


                //Tömma den statiska listan 
                Maträtter.GetMaträtter.Clear();

                //While Loop för att spara datan lokalt i en lista
                while (reader.Read())
                {
                    //Hämta och spara data till variabler
                    string Dish = reader["Dish"].ToString();
                    string Price = reader["Price"].ToString();


                    //Skapar film  objekt och sparar i statisk lista
                    Maträtter.GetMaträtter.Add(new Maträtter(Dish, Price));
                }

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
            GridViewBurgers.Visible= true;
        }

        private void btnBackToStart3_MouseClick(object sender, MouseEventArgs e)
        {
            panelStartsida.BringToFront();
        }

        private void btnBurgers_MouseClick(object sender, MouseEventArgs e)
        {
            panelBurgers.BringToFront();
        }

       

    }

   

   
}