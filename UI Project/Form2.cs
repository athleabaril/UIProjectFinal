using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UI_Project.Form2;


namespace UI_Project
{
    public partial class Form2 : Form
    {
        //para ni ma store ang user object
        private string accountName;
        private List<int> selectedGameIds = new List<int>();
        private List<PictureBox> pictureBoxes = new List<PictureBox>();

        public Form2(string accountName)
        {
            InitializeComponent();

            this.accountName = accountName;
            LoadUserData();
            
        }
     
       
        private void Form_Load(object sender, EventArgs e)
        {
            
        }

        public Form2()
        {
            InitializeComponent();
          
        }

       

       
        private void LoadUserData()
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb;Persist Security Info=False;";
                OleDbConnection connection = new OleDbConnection(connectionString); // Update with your connection string
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [First Name], [Last Name], [Password], [Mobile Number] FROM [User Information] WHERE [Account Name] = ?";
                command.Parameters.AddWithValue("@AccountName", accountName);


                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblName.Text = reader["First Name"].ToString() + " " + reader["Last Name"].ToString();
                        txt_f.Text = reader["First Name"].ToString();
                        txt_l.Text = reader["Last Name"].ToString();
                        txt_an.Text = accountName;
                        lblaccname.Text = accountName;
                        lbl_num.Text = reader["Mobile Number"].ToString();
                    }
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //start of Home page menu (panel)
        private void btn_home_Click(object sender, EventArgs e)
        {
            pnl_home.Visible = true;
            pnl_storepg1.Visible = false;
            pnl_storepg2.Visible = false;
            pnl_cart.Visible = false;
            pnl_account.Visible = false;
           
        }
        private void btn_homeicon_Click(object sender, EventArgs e)
        {
            pnl_home.Visible = true;
            pnl_storepg1.Visible = false;
            pnl_cart.Visible = false;
            pnl_account.Visible = false;
          
        }
        private void btn_hog1_Click(object sender, EventArgs e)
        {
            pic_hogwarts.Visible = true;
            pic_ssquad.Visible = false;
            pic_stray.Visible = false;
            pic_tlou.Visible = false;


        }

        private void btn_stray1_Click(object sender, EventArgs e)
        {
            pic_hogwarts.Visible = false;
            pic_ssquad.Visible = false;
            pic_stray.Visible = true;
            pic_tlou.Visible = false;

        }

        private void btn_ssq1_Click(object sender, EventArgs e)
        {
            pic_hogwarts.Visible = false;
            pic_ssquad.Visible = true;
            pic_stray.Visible = false;
            pic_tlou.Visible = false;
        }

        private void btn_tlou1_Click(object sender, EventArgs e)
        {
            pic_hogwarts.Visible = false;
            pic_ssquad.Visible = false;
            pic_stray.Visible = false;
            pic_tlou.Visible = true;
        }

        private void btn_gta1_Click(object sender, EventArgs e)
        {
            pic_spider.Visible = false;
            pic_l4d.Visible = false;
            pic_gta.Visible = true;

        }

        private void btn_l4d1_Click(object sender, EventArgs e)
        {
            pic_spider.Visible = false;
            pic_l4d.Visible = true;
            pic_gta.Visible = false;
        }

        private void btn_spiderman1_Click(object sender, EventArgs e)
        {
            pic_spider.Visible = true;
            pic_l4d.Visible = false;
            pic_gta.Visible = false;
        }
        //end

        //start of store menu (panel)
        private void btn_store_Click(object sender, EventArgs e)
        {
            pnl_home.Visible = false;
            pnl_storepg1.Visible = true;
            pnl_storepg2.Visible = false;
            pnl_cart.Visible = false;
            pnl_account.Visible = false;

        }
        private void btn_storeicon_Click(object sender, EventArgs e)
        {
            pnl_home.Visible = false;
            pnl_storepg1.Visible = true;
            pnl_storepg2.Visible = false;
            pnl_cart.Visible = false;
            pnl_account.Visible = false;

        }

        private void pnl_store_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_storepg2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            pnl_storepg1.Visible = true;
            pnl_storepg2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_storepg1.Visible = false;
            pnl_storepg2.Visible = true;
        }
        //end



        //start sa account menu na panel 
        private void btn_acc_Click(object sender, EventArgs e)
        {
            pnl_home.Visible = false;
            pnl_storepg1.Visible = false;
            pnl_storepg2.Visible = false;
            pnl_account.Visible = true;
            pnl_cart.Visible = false;


            pnl_userinfo.BackColor = Color.FromArgb(210, Color.Black);
            pnl_user.BackColor = Color.FromArgb(210, Color.Black);
            pnl_set.BackColor = Color.FromArgb(210, Color.Black);
        }
        private void btn_accicon_Click(object sender, EventArgs e)
        {
            pnl_home.Visible = false;
            pnl_storepg1.Visible = false;
            pnl_storepg2.Visible = false;
            pnl_account.Visible = true;
            pnl_cart.Visible = false;



            pnl_userinfo.BackColor = Color.FromArgb(220, Color.Black);
            pnl_user.BackColor = Color.FromArgb(220, Color.Black);
            pnl_set.BackColor = Color.FromArgb(220, Color.Black);
        }

        private void btn_changepass_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb;"))
            {
                connection.Open();
                string query = "SELECT [Account Name], [Password] FROM [User Information] WHERE [First Name] = @firstName AND [Last Name] = @lastName";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@firsttName", txt_f.Text);
                    command.Parameters.AddWithValue("@lastName", txt_l.Text);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve the account name and old password from the database
                            string accountName = reader["Account Name"].ToString();
                            string oldPassword = reader["Password"].ToString();

                            Form3 form3 = new Form3(accountName, oldPassword);
                            form3.ShowDialog();
                            this.Hide();
                        }
                        else
                        {
                            // Handle case where user account name is not found in the database
                            MessageBox.Show("Account name not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        private void btn_off_Click(object sender, EventArgs e)         //para ni sa offline na button

        {
            pic_offline.Visible = true;
            pic_online.Visible = false;
            btn_off.Visible = false;
            btn_on.Visible = true;
        }

        private void btn_on_Click(object sender, EventArgs e)
        {
            pic_offline.Visible = false;
            pic_online.Visible = true;
            btn_off.Visible = true;
            btn_on.Visible = false;
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected image file path
                    string imagePath = openFileDialog.FileName;

                    try
                    {
                        // Create the destination folder if it doesn't exist
                        string destinationFolder = @"C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\User's Profile";
                        Directory.CreateDirectory(destinationFolder);

                        // Copy the image to the destination folder
                        string destinationPath = Path.Combine(destinationFolder, "ProfilePicture.jpg");
                        File.Copy(imagePath, destinationPath, true);

                        // Load the image into the PictureBox
                        pic_profile.Image = Image.FromFile(destinationPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }


        private void Logout()
        {

        }



        private void btn_signout_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 form1 = new Form1();
            form1.Show();

            Logout();
        }

        //para sa add to cart ni siya


        //class ni para sa mga game na price para di ko maglisod og butang butang sa calculation.
        //pariho ni sa oop1
        public class Game
        {
            private string Name { get; set; }
            public double Price { get; set; }

            public Game(string name, double price)
            {
                Name = name;
                Price = price;
            }

            public double CalculateDiscountedPrice(double discount)
            {
                return Price * (1 - discount);
            }
        }



        //para sa checkout na button


        //start of cart menu
        private void btn_cart_Click(object sender, EventArgs e)
        {
            pnl_home.Visible = false;
            pnl_storepg1.Visible = false;
            pnl_storepg2.Visible = false;
            pnl_cart.Visible = true;
            pnl_account.Visible = false;

        }

        private void btn_carticon_Click(object sender, EventArgs e)
        {
            pnl_home.Visible = false;
            pnl_storepg1.Visible = false;
            pnl_storepg2.Visible = false;
            pnl_cart.Visible = true;
            pnl_account.Visible = false;

        }


        private void btn_tocart_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb;Persist Security Info=False;";
            string sqlQuery = "SELECT [Game Name] FROM [Game1] WHERE [Game ID] IN (";


            // Build the list of Game IDs to include in the query
            List<int> gameIds = new List<int>();
            if (check1.Checked)
            {
                gameIds.Add(1);
            }
            if (check2.Checked)
            {
                gameIds.Add(2);
            }
            if (check3.Checked)
            {
                gameIds.Add(3);
            }
            if (check4.Checked)
            {
                gameIds.Add(4);
            }
            if (check5.Checked)
            {
                gameIds.Add(5);
            }
            if (check6.Checked)
            {
                gameIds.Add(6);
            }
            if (check7.Checked)
            {
                gameIds.Add(7);
            }
            if (check8.Checked)
            {
                gameIds.Add(8);
            }
            if (check9.Checked)
            {
                gameIds.Add(9);
            }
            if (check10.Checked)
            {
                gameIds.Add(10);
            }
            if (check11.Checked)
            {
                gameIds.Add(11);
            }
            if (check12.Checked)
            {
                gameIds.Add(12);
            }

            // Construct the query string using the list of Game IDs
            sqlQuery = "SELECT [Game Name] FROM [Game1] WHERE [Game ID] IN (";
            if (gameIds.Count > 0)
            {
                sqlQuery += string.Join(",", gameIds) + ")";
            }
            else
            {
                // If no games are selected, return an empty result set
                sqlQuery += "-1)";
            }

            // Execute the query and process the results as before
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(sqlQuery, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                // Add each selected game to the checkedList_out control
                while (reader.Read())
                {
                    checkedList_out.Items.Add(reader["Game Name"].ToString());
                }
            }

            MessageBox.Show("ADDED TO CART!");
        }

        private void checkedList_out_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            decimal totalPrice = 0;

            // Calculate the total price of the selected games
            foreach (string gameName in checkedList_out.CheckedItems)
            {
                // Get the ID of the game based on its name
                int gameId = GetGameIdByName(gameName);

                // Add the price of the checked item to the total price
                totalPrice += GetPriceById(gameId);
            }

            if (e.NewValue == CheckState.Checked)
            {
                // Get the name of the game that was just checked
                string gameName = checkedList_out.Items[e.Index].ToString();

                // Get the ID of the game based on its name
                int gameId = GetGameIdByName(gameName);

                // Add the price of the checked item to the total price
                totalPrice += GetPriceById(gameId);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                // Get the name of the game that was just unchecked
                string gameName = checkedList_out.Items[e.Index].ToString();

                // Get the ID of the game based on its name
                int gameId = GetGameIdByName(gameName);

                // Subtract the price of the unchecked item from the total price
                totalPrice -= GetPriceById(gameId);
            }

            // Update the total price label
            txt_ordertotal.Text = totalPrice.ToString("C2");
            amnt.Text = totalPrice.ToString("C2");
        }

        private decimal GetPriceById(int id)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb;Persist Security Info=False;";
            string sqlQuery = "SELECT [New Price] FROM [Game1] WHERE [Game ID] = " + id;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(sqlQuery, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToDecimal(reader["New Price"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        private int GetGameIdByName(string name)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb;Persist Security Info=False;";
            string sqlQuery = "SELECT [Game ID] FROM [Game1] WHERE [Game Name] = '" + name + "'";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(sqlQuery, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToInt32(reader["Game ID"]);
                }
                else
                {
                    return 0;
                }
            }

        }



        private void btn_del_Click(object sender, EventArgs e)
        {
            decimal totalPrice = 0;

            // Remove the checked items from the checkedList_out control
            for (int i = checkedList_out.Items.Count - 1; i >= 0; i--)
            {
                if (checkedList_out.GetItemChecked(i))
                {
                    checkedList_out.Items.RemoveAt(i);
                }
            }

            // Recalculate the total price of the selected games
            foreach (string gameName in checkedList_out.CheckedItems)
            {
                // Get the ID of the game based on its name
                int gameId = GetGameIdByName(gameName);

                // Add the price of the checked item to the total price
                totalPrice += GetPriceById(gameId);
            }

            // Update the total price label
            txt_ordertotal.Text = totalPrice.ToString("C2");
            amnt.Text = totalPrice.ToString("C2");
        }

        private void btncheckout2_Click(object sender, EventArgs e)
        {
            // Check if at least one game is checked
            if (checkedList_out.CheckedItems.Count == 0 || string.IsNullOrEmpty(mnumber.Text))
            {
                MessageBox.Show("Please select at least one game or don't leave a field empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further execution
            }

            DialogResult confirmationResult = MessageBox.Show("You are about to purchase a game. We need to get a confirmation.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (confirmationResult == DialogResult.OK)
            {
                pnl_purchaseconfirm.BringToFront();
                // Get the IDs of the checked games
                List<int> gameIds = new List<int>();
                foreach (string gameName in checkedList_out.CheckedItems)
                {
                    int gameId = GetGameIdByName(gameName);
                    gameIds.Add(gameId);
                }
                btnoks.Tag = gameIds; // set the gameIds as the Tag property of the OK button
            }
        }

        private void InsertPurchase(int gameId, int userId, DateTime purchaseDate, string mop)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb");
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [Purchase Table] ([Game ID], [User ID], [Purchased Date], [Quantity], [MOP]) VALUES (?, ?, ?, 1, ?)";
                command.Parameters.AddWithValue("@GameID", gameId);
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@PurchasedDate", purchaseDate.ToString("dd/MM/yyyy"));
                command.Parameters.AddWithValue("@MOP", mop);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetUserIdByUsername(string accountName)
        {
            int userId = -1; // Default value if user ID is not found

            try
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb"))
                {
                    connection.Open();

                    string query = "SELECT [User ID] FROM [User Information] WHERE [Account Name] = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountName", accountName);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            userId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return userId;
        }



        private void btnoks_Click(object sender, EventArgs e)
        {
            if (btnoks.Tag is List<int> gameIds && gameIds.Count > 0)
            {
                int userId = GetUserIdByUsername(accountName); // Replace with your logic to get the user ID


                foreach (int gameId in gameIds)
                {
                    InsertPurchase(gameId, userId, DateTime.Now, "Gcash");
                }


                MessageBox.Show("Congratulations on your successful purchase! Please check the email you provided during the purchase for step-by-step installation instructions and the game download link. Follow the instructions carefully to ensure a smooth installation process.In case you encounter any issues during the installation or have any further questions, feel free to contact our dedicated customer support team (09-876-98), who will be more than happy to assist you.\r\n\r\nWe sincerely hope you enjoy playing the game! Thank you again for your purchase, and we appreciate your support.\r\n\r\nBest regards,\r\nReverse");
                // Clear the input fields
                txtaccname.Text = string.Empty;
                txtpass.Text = string.Empty;
                txtemail.Text = string.Empty;
                pnl_purchaseconfirm.SendToBack();
                if (DialogResult == DialogResult.OK)
                {
                    decimal totalPrice = 0;

                    // Remove the checked items from the checkedList_out control
                    for (int i = checkedList_out.Items.Count - 1; i >= 0; i--)
                    {
                        if (checkedList_out.GetItemChecked(i))
                        {
                            checkedList_out.Items.RemoveAt(i);
                        }
                    }

                    // Recalculate the total price of the selected games
                    foreach (string gameName in checkedList_out.CheckedItems)
                    {
                        // Get the ID of the game based on its name
                        int gameId = GetGameIdByName(gameName);

                        // Add the price of the checked item to the total price
                        totalPrice += GetPriceById(gameId);
                    }

                    // Update the total price label
                    txt_ordertotal.Text = totalPrice.ToString("C2");
                    amnt.Text = totalPrice.ToString("C2");
                }
            }
            else
            {
                MessageBox.Show("No games selected for purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            txtaccname.Text = "";
            txtpass.Text = "";
            txtemail.Text = "";
            pnl_purchaseconfirm.SendToBack();
        }

        private void cancelcheckout_Click(object sender, EventArgs e)
        {
            // Clear the mobile number textbox
            mnumber.Text = "";

            // Deselect all items in the checklist
            for (int i = 0; i < checkedList_out.Items.Count; i++)
            {
                checkedList_out.SetItemChecked(i, false);
            }
        }

       
       
    }


}








