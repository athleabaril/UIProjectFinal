using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static UI_Project.Form2;


namespace UI_Project
{
    public partial class Form4 : Form
    {
        OleDbConnection myConn;
        OleDbDataAdapter da;
        DataSet ds;
        private OleDbConnection connection;


        private Form2 form2;

        public Form4(Form2 form2Instance)
        {
            InitializeComponent();
            form2 = form2Instance;
        }



        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb";

        public Form4()
        {
            InitializeComponent();

        }

        //para design opacity 
        public void SetPanelOpacity()
        {
            p_usinfo.BackColor = Color.FromArgb(220, Color.Black);
            p_gdet.BackColor = Color.FromArgb(220, Color.Black);
            p_gsale.BackColor = Color.FromArgb(220, Color.Black);
        }

        public void SetDataGridViewOpacity()
        {
            dataGridView1.BackColor = Color.FromArgb(220, Color.Black);
            dataGridView2.BackColor = Color.FromArgb(220, Color.Black);
            dataGridView3.BackColor = Color.FromArgb(220, Color.Black);
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataIntoDataGridView1();
                LoadDataIntoDataGridView2();
                LoadDataIntoDataGridView3();

                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb";

                myConn = new OleDbConnection(connectionString);

                ds = new DataSet();

                da = new OleDbDataAdapter("SELECT [User ID], [Account Name], [First Name], [Last Name], [Account Made] FROM [User Information]", myConn);

                da.Fill(ds, "[User Information]");

                dataGridView3.DataSource = ds.Tables["[User Information]"];

                myConn = new OleDbConnection(connectionString);

                myConn.Open();

                ds.Clear();
                da = new OleDbDataAdapter("SELECT * FROM [User Information]", myConn);
                da.Fill(ds, "[User Information]");
                dataGridView3.DataSource = ds.Tables["[User Information]"];

                if (ds.Tables["[User Information]"].Rows.Count > 0)
                {
                    pnluser_id.Text = ds.Tables["[User Information]"].Rows[0]["User ID"].ToString();
                    pnluser_accname.Text = ds.Tables["[User Information]"].Rows[0]["Account Name"].ToString();
                    pnluser_fn.Text = ds.Tables["[User Information]"].Rows[0]["First Name"].ToString();
                    pnluser_ln.Text = ds.Tables["[User Information]"].Rows[0]["Last Name"].ToString();
                    pnluser_accmade.Text = ds.Tables["[User Information]"].Rows[0]["Account Made"].ToString();
                }

                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btn_gamedb_Click(object sender, EventArgs e)
        {
            pnl_gamedb.Visible = true;
            pnl_saledb.Visible = false;
            pnl_userdb.Visible = false;
            LoadDataIntoDataGridView1();
        }

        private void btn_userinfo_Click(object sender, EventArgs e)
        {
            pnl_gamedb.Visible = false;
            pnl_saledb.Visible = false;
            pnl_userdb.Visible = true;
            LoadDataIntoDataGridView3();
        }

        private void btn_saledb_Click(object sender, EventArgs e)
        {
            pnl_gamedb.Visible = false;
            pnl_saledb.Visible = true;
            pnl_userdb.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();

            Form1 form1 = new Form1();
            form1.Show();
        }



        //for datagridview3 - user information
        private void LoadDataIntoDataGridView3()
        {
            /*try
            {
                if (myConn != null)
                {
                    myConn.Open();
                    // Rest of the code



                    string sql = "SELECT * FROM [User Information]";

                    da = new OleDbDataAdapter(sql, myConn);
                    ds = new DataSet();
                    da.Fill(ds, "[User Information]");

                    dataGridView3.DataSource = ds.Tables["[User Information]"];

                    myConn.Close();

                  


                    if (ds.Tables["[User Information]"].Rows.Count > 0)
                    {
                        pnluser_id.Text = ds.Tables["[User Information]"].Rows[0]["User ID"].ToString();
                        pnluser_fn.Text = ds.Tables["[User Information]"].Rows[0]["First Name"].ToString();
                        pnluser_ln.Text = ds.Tables["[User Information]"].Rows[0]["Last Name"].ToString();
                        pnluser_accmade.Text = DateTime.Parse(ds.Tables["[User Information]"].Rows[0]["Account Made"].ToString()).ToString("MM/dd/yyyy");

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading: " + ex.Message);
            }*/


            try
            {
                if (myConn != null)
                {
                    myConn.Open();
                    // Rest of the code

                    string sql = "SELECT [User ID], [First Name], [Last Name], [Account Made] FROM [User Information]";

                    da = new OleDbDataAdapter(sql, myConn);
                    ds = new DataSet();
                    da.Fill(ds, "[User Information]");

                    dataGridView3.DataSource = ds.Tables["[User Information]"];

                    myConn.Close();

                    if (ds.Tables["[User Information]"].Rows.Count > 0)
                    {
                        pnluser_id.Text = ds.Tables["[User Information]"].Rows[0]["User ID"].ToString();
                        pnluser_fn.Text = ds.Tables["[User Information]"].Rows[0]["First Name"].ToString();
                        pnluser_ln.Text = ds.Tables["[User Information]"].Rows[0]["Last Name"].ToString();
                        pnluser_accmade.Text = DateTime.Parse(ds.Tables["[User Information]"].Rows[0]["Account Made"].ToString()).ToString("MM/dd/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading: " + ex.Message);
            }
        }



        //for datagridview1 - game1 table
        private void LoadDataIntoDataGridView1()
        {
            try
            {
                connection = new OleDbConnection(connectionString);
                connection.Open();


                string query = "SELECT * FROM [Game1]";

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data into DataGridView1: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        private void LoadDataIntoDataGridView2()
        {
            try
            {
                // Clear existing data in DataGridView
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                // Create a new DataSet to hold the data
                DataSet ds = new DataSet();

                // Replace "YourQueryName" with the actual name of your query in Access
                string query = @"SELECT Game1.[Game ID], Game1.[Game Name], Game1.[Original Price], Game1.[New Price], 
                        SUM([Purchase Table].Quantity) AS SumOfQuantity, 
                        SUM([Purchase Table].Quantity * Game1.[New Price]) AS Expr1
                        FROM ([User Information] 
                        INNER JOIN (Game1 
                        INNER JOIN [Purchase Table] ON Game1.[Game ID] = [Purchase Table].[Game ID]) 
                        ON [User Information].[User ID] = [Purchase Table].[User ID]) 
                        INNER JOIN [User Library] ON ([User Information].[User ID] = [User Library].[User ID]) 
                        AND (Game1.[Game ID] = [User Library].[Game ID])
                        GROUP BY Game1.[Game ID], Game1.[Game Name], Game1.[Original Price], Game1.[New Price];";

                // Replace "YourConnectionString" with your actual connection string to your Access database
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a new OleDbDataAdapter to fill the DataSet with data from the query
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

                    // Fill the DataSet with data from the query
                    adapter.Fill(ds, "GameSales");
                }

                // Set the DataGridView's DataSource to the DataTable in the DataSet
                dataGridView2.DataSource = ds.Tables["GameSales"];
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the operation
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        //start sa daily sales
        private void btn_daily_Click(object sender, EventArgs e)
        {
            pnl_daily.BringToFront();
            btn_gamedb.Enabled = false;
            btn_userinfo.Enabled = false;
            btn_saledb.Enabled = false;
            btn_monthly.Enabled = false;
            btn_yearly.Enabled = false;
            btn_signout.Enabled = false;
            txt_gamecount.Enabled = false;
            txt_income.Enabled = false;
            txt_totalgp.Enabled = false;

        }
        private void btn_okayd_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = calendar.SelectionStart.Date;

            string queryString = "SELECT Game1.[Game ID], Game1.[Game Name], Game1.[Original Price], Game1.[New Price], " +
                                        "Sum([Purchase Table].[Quantity]) AS SumOfQuantity, " +
                                        "Sum([Game1].[New Price]*[Purchase Table].[Quantity]) AS DailySales " +
                                        "FROM Game1 " +
                                        "INNER JOIN [Purchase Table] ON Game1.[Game ID] = [Purchase Table].[Game ID] " +
                                        "WHERE DateValue([Purchase Table].[Purchased Date]) = @selectedDate " +
                                        "GROUP BY Game1.[Game ID], Game1.[Game Name], Game1.[Original Price], Game1.[New Price];";

            DataTable dataTable; // Define the dataTable variable here

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@selectedDate", selectedDate.ToShortDateString());

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        dataTable = new DataTable(); // Initialize the dataTable variable here
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }

            // Calculate daily total sales and total quantity sold
            int totalQuantity = 0;
            decimal totalSales = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                int quantity = Convert.ToInt32(row["SumOfQuantity"]);
                decimal sales = Convert.ToDecimal(row["DailySales"]);
                totalQuantity += quantity;
                totalSales += sales;
            }

            // Update textboxes with daily total sales and total quantity sold
            txt_totalgp.Text = totalQuantity.ToString();
            txt_income.Text = totalSales.ToString();

            pnl_daily.SendToBack();
            btn_gamedb.Enabled = true;
            btn_userinfo.Enabled = true;
            btn_saledb.Enabled = true;
            btn_monthly.Enabled = true;
            btn_yearly.Enabled = true;
            btn_signout.Enabled = true;
            txt_gamecount.Enabled = true;
            txt_income.Enabled = true;
            txt_totalgp.Enabled = true;

        }

        private void btn_exitdaily_Click(object sender, EventArgs e)
        {

            pnl_daily.SendToBack();
            btn_gamedb.Enabled = true;
            btn_userinfo.Enabled = true;
            btn_saledb.Enabled = true;
            btn_monthly.Enabled = true;
            btn_yearly.Enabled = true;
            btn_signout.Enabled = true;
            txt_gamecount.Enabled = true;
            txt_income.Enabled = true;
            txt_totalgp.Enabled = true;

            calendar.SetDate(DateTime.Today);
        }
        //end sa daily



        //start sa monthly sales
        private void btn_monthly_Click(object sender, EventArgs e)
        {
            pnl_monthly.BringToFront();
            btn_gamedb.Enabled = false;
            btn_userinfo.Enabled = false;
            btn_saledb.Enabled = false;
            btn_daily.Enabled = false;
            btn_yearly.Enabled = false;
            btn_signout.Enabled = false;
            txt_gamecount.Enabled = false;
            txt_income.Enabled = false;
            txt_totalgp.Enabled = false;

        }
        private void btn_okaym_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedMonthYearParam = dateTimePicker1.Value.ToString("MM-yyyy");
                string queryString = $"SELECT Game1.[Game ID], Game1.[Game Name], Game1.[Original Price], Game1.[New Price], " +
                                     $"Sum([Purchase Table].[Quantity]) AS SumOfQuantity, " +
                                     $"Sum([Game1].[New Price]*[Purchase Table].[Quantity]) AS MonthlySales " +
                                     $"FROM Game1 " +
                                     $"INNER JOIN [Purchase Table] ON Game1.[Game ID] = [Purchase Table].[Game ID] " +
                                     $"WHERE FORMAT([Purchase Table].[Purchased Date],'mm-yyyy') = @selectedMonthYear " +
                                     $"GROUP BY Game1.[Game ID], Game1.[Game Name], Game1.[Original Price], Game1.[New Price];";

                using (OleDbCommand command = new OleDbCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@selectedMonthYear", selectedMonthYearParam);

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable;

                        double totalRevenue = 0;
                        double totalSumOfQuantity = 0;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            double monthlySales = Convert.ToDouble(row["MonthlySales"]);
                            double originalPrice = Convert.ToDouble(row["Original Price"]);
                            double newPrice = Convert.ToDouble(row["New Price"]);
                            double sumOfQuantity = Convert.ToDouble(row["SumOfQuantity"]);

                            double revenue = monthlySales * newPrice / (originalPrice + newPrice);
                            double gp = (monthlySales - revenue) / monthlySales;

                            totalRevenue += revenue;

                            totalSumOfQuantity += sumOfQuantity;
                        }

                        txt_income.Text = totalRevenue.ToString("#,##0.00");
                        txt_totalgp.Text = totalSumOfQuantity.ToString();
                    }
                }

                pnl_monthly.SendToBack();
                btn_gamedb.Enabled = true;
                btn_userinfo.Enabled = true;
                btn_saledb.Enabled = true;
                btn_daily.Enabled = true;
                btn_yearly.Enabled = true;
                btn_signout.Enabled = true;
                txt_gamecount.Enabled = true;
                txt_income.Enabled = true;
                txt_totalgp.Enabled = true;
            }
            catch (Exception ex)
            {
                // Handle the exception here, for example, by displaying an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exitm_Click(object sender, EventArgs e)
        {
            pnl_monthly.SendToBack();
            btn_gamedb.Enabled = true;
            btn_userinfo.Enabled = true;
            btn_saledb.Enabled = true;
            btn_daily.Enabled = true;
            btn_yearly.Enabled = true;
            btn_signout.Enabled = true;
            txt_gamecount.Enabled = true;
            txt_income.Enabled = true;
            txt_totalgp.Enabled = true;

        }

        //end sa monthly sales


        //start sa yearly
        private void btn_yearly_Click_1(object sender, EventArgs e)
        {
            pnl_yearly.BringToFront();
            btn_gamedb.Enabled = false;
            btn_userinfo.Enabled = false;
            btn_saledb.Enabled = false;
            btn_monthly.Enabled = false;
            btn_daily.Enabled = false;
            btn_signout.Enabled = false;
            txt_gamecount.Enabled = false;
            txt_income.Enabled = false;
            txt_totalgp.Enabled = false;

        }
        private void btn_oky_Click(object sender, EventArgs e)
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb");

            if (cb_yearyy.SelectedItem != null && int.TryParse(cb_yearyy.SelectedItem.ToString(), out int selectedYear))
            {
                string queryString = "SELECT Game1.[Game ID], Game1.[Game Name], Game1.[Original Price], Game1.[New Price], " +
                    "Sum([Purchase Table].Quantity) AS SumOfQuantity, " +
                    "Year([Purchased Date]) AS [Purchase Year], " +
                    "Sum([Quantity]*[New Price]) AS [Total Revenue] " +
                    "FROM [User Information] " +
                    "INNER JOIN (Game1 INNER JOIN [Purchase Table] ON Game1.[Game ID] = [Purchase Table].[Game ID]) " +
                    "ON [User Information].[User ID] = [Purchase Table].[User ID] " +
                    "WHERE Year([Purchased Date]) = @selectedYear " +
                    "GROUP BY Game1.[Game ID], Game1.[Game Name], Game1.[Original Price], Game1.[New Price], Year([Purchased Date]);";



                using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb"))
                {
                    using (OleDbCommand command = new OleDbCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@selectedYear", selectedYear.ToString());

                        connection.Open();
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView2.DataSource = dataTable;

                            //para ni mo calculate sa katong revenue chuchu
                            decimal totalRevenue = 0;
                            int totalQuantity = 0;
                            foreach (DataRow row in dataTable.Rows)
                            {
                                totalRevenue += Convert.ToDecimal(row["Total Revenue"]);
                                totalQuantity += Convert.ToInt32(row["SumOfQuantity"]);
                            }


                            // Update sa controls
                            txt_income.Text = totalRevenue.ToString();
                            txt_totalgp.Text = totalQuantity.ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid year.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pnl_yearly.SendToBack();
            btn_gamedb.Enabled = true;
            btn_userinfo.Enabled = true;
            btn_saledb.Enabled = true;
            btn_daily.Enabled = true;
            btn_monthly.Enabled = true;
            btn_signout.Enabled = true;
            txt_gamecount.Enabled = true;
            txt_income.Enabled = true;
            txt_totalgp.Enabled = true;
        }

        private void btn_cancely_Click(object sender, EventArgs e)
        {
            pnl_yearly.SendToBack();
            btn_gamedb.Enabled = true;
            btn_userinfo.Enabled = true;
            btn_saledb.Enabled = true;
            btn_daily.Enabled = true;
            btn_monthly.Enabled = true;
            btn_signout.Enabled = true;
            txt_gamecount.Enabled = true;
            txt_income.Enabled = true;
            txt_totalgp.Enabled = true;

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            pnlgame_gn.Enabled = true;
            pnlgame_price.Enabled = true;
            radio_no.Enabled = true;
            radio_yes.Enabled = true;
            combo_discount.Enabled = true;

            btn_gamecancel.Enabled = true;
            btn_gamesave.Enabled = true;

            pnlgame_gn.ReadOnly = false;
            pnlgame_price.ReadOnly = false;

        }

        //end sa yearly


        //start sa game edit na add add


        private void btn_gamesave_Click(object sender, EventArgs e)
        {
           
            string gameName = pnlgame_gn.Text;
            decimal price = decimal.Parse(pnlgame_price.Text);
            bool onSale = radio_yes.Checked;
            int discount = 0;

            // Check if a discount is selected
            if (combo_discount.SelectedItem != null)
            {
                // Attempt to parse the selected discount as an integer
                if (int.TryParse(combo_discount.SelectedItem.ToString().TrimEnd('%'), out int discountValue))
                {
                    discount = discountValue;
                }
            }

            // Get the selected row in the dataGridView1
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

                // Get the game ID of the selected row
                string gameID = GetCellValueAsString(selectedRow.Cells["Game ID"]);

                // Update the database with the values
                UpdateGameInformation( gameID, gameName, price, onSale, discount);

                RefreshDataGridView();

                // Reset the input fields
                pnlgame_gn.Text = string.Empty;
                pnlgame_price.Text = string.Empty;
                radio_no.Checked = true;
                combo_discount.SelectedIndex = -1;

                MessageBox.Show("Game information saved successfully.");
            }
            else
            {
                MessageBox.Show("Please select a game to edit.");
            }


        }

        private void UpdateGameInformation(string gameID, string gameName, decimal price, bool onSale, int discount)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE [Game1] SET [Game Name] = ?, [Original Price] = ?, [On Sale] = ?, [Discount] = ? WHERE [Game ID] = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GameName", string.IsNullOrEmpty(gameName) ? (object)DBNull.Value : gameName);
                        command.Parameters.AddWithValue("@Price", price != 0 ? (object)price : (object)DBNull.Value);
                        command.Parameters.AddWithValue("@OnSale", onSale);
                        command.Parameters.AddWithValue("@Discount", discount != 0 ? (object)discount : (object)DBNull.Value);
                        command.Parameters.AddWithValue("@GameID", gameID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                pnlgame_gn.Text = GetCellValueAsString(row.Cells["Game Name"]);
                pnlgame_price.Text = GetCellValueAsString(row.Cells["Original Price"]);

                bool onSaleValue = GetCellValueAsBoolean(row.Cells["On Sale"]);
                radio_yes.Checked = onSaleValue;
                radio_no.Checked = !onSaleValue;

                if (onSaleValue)
                {
                    string discountValue = GetCellValueAsString(row.Cells["Discount"]);
                    combo_discount.SelectedItem = discountValue;
                }
                else
                {
                    combo_discount.SelectedItem = null;
                }
            }
        }

        private string GetCellValueAsString(DataGridViewCell cell)
        {
            if (!Convert.IsDBNull(cell.Value))
            {
                return cell.Value.ToString();
            }

            return string.Empty;
        }

        private bool GetCellValueAsBoolean(DataGridViewCell cell)
        {
            if (!Convert.IsDBNull(cell.Value))
            {
                return Convert.ToBoolean(cell.Value);
            }

            return false;
        }

        private void btn_gamecancel_Click(object sender, EventArgs e)
        {
            pnlgame_gn.Text = "";
            pnlgame_price.Text = "";
            combo_discount.SelectedIndex = -1;
            radio_yes.Checked = false;
            radio_no.Checked = false;
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the Enter key is pressed
            if (e.KeyChar == (char)Keys.Enter)
            {
                string searchQuery = textBox1.Text.Trim();

                // Create the SQL query with the search condition
                string sqlQuery = "SELECT * FROM Game1 WHERE [Game Name] LIKE '%" + searchQuery + "%'";

                // Perform the database search
                try
                {
                    // Open the database connection
                    connection = new OleDbConnection(connectionString);
                    connection.Open();

                    // Create a new OleDbDataAdapter and DataSet
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlQuery, connection);
                    DataSet ds = new DataSet();

                    // Fill the DataSet with the query results
                    da.Fill(ds, "Game1");

                    // Set the DataGridView's DataSource to the DataSet
                    dataGridView1.DataSource = ds.Tables["Game1"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Close the database connection
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)

            {

                string searchQuery1 = textBox2.Text.Trim();
                //"SELECT * FROM Game1 WHERE [Game Name] LIKE '%" + searchQuery + "%'";
                string query = "SELECT * FROM [User Information] WHERE [First Name] LIKE '%" + searchQuery1 + "%'";

                try
                {
                    // Open the database connection
                    connection = new OleDbConnection(connectionString);
                    connection.Open();

                    // Create a new OleDbDataAdapter and DataSet
                    OleDbDataAdapter da = new OleDbDataAdapter(query, connection);
                    DataSet ds = new DataSet();

                    // Fill the DataSet with the query results
                    da.Fill(ds, "User Information");

                    // Set the DataGridView's DataSource to the DataSet
                    dataGridView3.DataSource = ds.Tables["User Information"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Close the database connection
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }


            }


        }

        private void btn_disable_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView3.SelectedRows[0];
                string userID = row.Cells["User ID"].Value.ToString();
                string currentStatus = row.Cells["Status"].Value.ToString();

                // Determine the new status based on the current status
                string newStatus = (currentStatus == "Enabled") ? "Disabled" : "Enabled";

                // Prompt the user for confirmation
                DialogResult result = MessageBox.Show($"Are you sure you want to {newStatus.ToLower()} this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Update the status in the Access database
                    string query = "UPDATE [User Information] SET [Status] = @NewStatus WHERE [User ID] = @UserID";
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@NewStatus", newStatus);
                            command.Parameters.AddWithValue("@UserID", userID);

                            try
                            {
                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // Update successful
                                    MessageBox.Show($"User {newStatus.ToLower()} successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Refresh the DataGridView
                                    RefreshDataGridView3();
                                }
                                else
                                {
                                    // Update failed
                                    MessageBox.Show($"Failed to {newStatus.ToLower()} user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                // No row selected
                MessageBox.Show("Please select a user to enable/disable.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView3.Rows.Count)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                pnluser_id.Text = row.Cells["User ID"].Value?.ToString();
                pnluser_accname.Text = row.Cells["Account Name"].Value?.ToString();
                pnluser_fn.Text = row.Cells["First Name"].Value?.ToString();
                pnluser_ln.Text = row.Cells["Last Name"].Value?.ToString();
                pnluser_accmade.Text = ((DateTime)row.Cells["Account Made"].Value).ToString("MM-dd-yyyy");
            }
        }

        private void RefreshDataGridView3()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM [User Information]";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to dataGridView3
                    dataGridView3.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
                {
                    int rowIndex = e.RowIndex;

                    // Your logic for handling the selected cell

                    int totalGames = 0;
                    string queryTotalGames = "SELECT COUNT(*) FROM [Game1]";
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();
                        using (OleDbCommand command = new OleDbCommand(queryTotalGames, connection))
                        {
                            totalGames = (int)command.ExecuteScalar();
                        }
                    }
                    txt_gamecount.Text = totalGames.ToString();

                    decimal totalIncome = 0;
                    string queryTotalIncome = "SELECT SUM([Purchase Table].[Quantity] * [Game1].[New Price]) AS TotalIncome FROM ([Purchase Table] INNER JOIN [Game1] ON [Purchase Table].[Game ID] = [Game1].[Game ID])";
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();
                        using (OleDbCommand command = new OleDbCommand(queryTotalIncome, connection))
                        {
                            object result = command.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                totalIncome = Convert.ToDecimal(result);
                            }
                        }
                    }

                    txt_income.Text = totalIncome.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_enable_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string userID = row.Cells["User ID"].Value.ToString();

                // Prompt the user for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to enable this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Perform the update in the Access database
                    string query = "UPDATE [User Information] SET [Status] = 'Enabled' WHERE [User ID] = @UserID";
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserID", userID);

                            try
                            {
                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // Update successful
                                    MessageBox.Show("User enabled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Refresh the DataGridView
                                    RefreshDataGridView();
                                }
                                else
                                {
                                    // Update failed
                                    MessageBox.Show("Failed to enable user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                // No row selected
                MessageBox.Show("Please select a user to enable.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_remove_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("You are about to remove a game.", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                if (dialogResult == DialogResult.OK)
                {
                    int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

                    string gameID = GetCellValueAsString(selectedRow.Cells["Game ID"]);

                    // Delete the selected row from the database
                    DeleteGameFromDatabase(gameID);

                    // Refresh the dataGridView1
                    RefreshDataGridView();
                }
            }
        }

        private void DeleteGameFromDatabase(string gameID)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM [Game1] WHERE [Game ID] = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GameID", gameID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGridView()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Game1";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}





    


