using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace UI_Project
{
    public partial class Form1 : Form
    {


        private OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb");


        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnl_login.Visible = false;
            pnl_create.Visible = true;
        }

        private void btn_login_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_accname.Text) || string.IsNullOrWhiteSpace(txt_pass.Text))
            {
                MessageBox.Show("Please enter account name and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();

                string query = "SELECT [Status] FROM [User Information] WHERE [Account Name] = @Account_Name AND [Password] = @Password";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@Account_Name", txt_accname.Text);
                command.Parameters.AddWithValue("@Password", txt_pass.Text);

                object statusObj = command.ExecuteScalar();

                if (statusObj != null && statusObj != DBNull.Value)
                {
                    string status = statusObj.ToString();

                    if (status == "Enabled")
                    {
                        // If account name and password are correct and the account is enabled, show Form2
                        Form2 form2 = new Form2(txt_accname.Text);
                        form2.Show();
                        this.Hide();
                    }
                    else if (status == "Disabled")
                    {
                        MessageBox.Show("Your account has been disabled.", "Account Disabled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid account name or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Athlea Baril\\Desktop\\Vs Program OOP2\\UI Project\\UI Project DataBase\\UI_Project Database.accdb";


                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Validate user input
                    if (string.IsNullOrWhiteSpace(txt_regname.Text) ||
                        string.IsNullOrWhiteSpace(txt_regname2.Text) ||
                        string.IsNullOrWhiteSpace(textBox5.Text) ||
                        string.IsNullOrWhiteSpace(textBox4.Text) ||
                        string.IsNullOrWhiteSpace(textBox3.Text) ||
                        string.IsNullOrEmpty(txt_mobnumber.Text))
                    {
                        MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Check if the "not a robot" checkbox is checked
                    if (!checkbox_notrobot.Checked)
                    {
                        MessageBox.Show("We don't accept robots.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Check if password and confirm password match
                    if (textBox4.Text != textBox3.Text)
                    {
                        MessageBox.Show("Password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validate the mobile number
                    if (!Regex.IsMatch(txt_mobnumber.Text, @"^\d{11}$"))
                    {
                        MessageBox.Show("Invalid mobile number. Please enter an 11-digit numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Check if the account name already exists
                    string query = "SELECT COUNT(*) FROM [User Information] WHERE [Account Name] = @accountName";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@accountName", textBox5.Text);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Account Name already in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert registration data into the database
                    // Insert registration data into the database
                    query = "INSERT INTO [User Information] ([Account Name], [First Name], [Last Name], [Account Made], [Password], [Mobile Number], [Status]) " +
                            "VALUES (@accountName, @firstName, @lastName, @accountMade, @password, @mobileNumber, 'Enabled')";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@accountName", textBox5.Text);
                        command.Parameters.AddWithValue("@firstName", txt_regname.Text);
                        command.Parameters.AddWithValue("@lastName", txt_regname2.Text);
                        command.Parameters.AddWithValue("@accountMade", DateTime.Now.ToString("dd/MM/yyyy"));
                        command.Parameters.AddWithValue("@password", textBox4.Text);
                        command.Parameters.AddWithValue("@mobileNumber", txt_mobnumber.Text);

                        command.ExecuteNonQuery();
                    }


                    MessageBox.Show("Registration successful. Log in to your account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearRegistrationFields();

                    string accountName = textBox5.Text;
                    // Form2 form2 = new Form2(accountName); // Instantiate Form2
                    //form2.Show(); // Show Form2

                    pnl_create.Visible = false;
                    pnl_login.Visible = true;
                    pnl_admin.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearRegistrationFields()
        {
            txt_regname.Text = "";
            txt_regname2.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            txt_mobnumber.Text = "";
            checkbox_notrobot.Checked = false;
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearRegistrationFields();
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            pnl_create.Visible = false;
            pnl_login.Visible = true;
            pnl_admin.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_accname.Text = "";
            txt_pass.Text = "";
        }

        private void btn_adlogin_Click(object sender, EventArgs e)
        {
            string username = txt_adusername.Text.Trim();
            string password = txt_adpass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (username == "admin.baril@reverse" && password == "adminpassword")
            {
                MessageBox.Show("Admin login successful!");

                this.Hide(); // Hide Form1 instead of closing it

                Form4 adminServer = new Form4();
                adminServer.ShowDialog(); // Show Form4 as a modal dialog
            }
            else
            {
                MessageBox.Show("Incorrect username or password. Please try again.");
            }

            Form4 form4 = Application.OpenForms.OfType<Form4>().FirstOrDefault();
         
            if (form4 != null)
            {
                // Set opacity of panels in Form4
                form4.SetPanelOpacity();

                // Set opacity of DataGridView controls in Form4
                form4.SetDataGridViewOpacity();
            }

        }

        private void btn_adback_Click(object sender, EventArgs e)
        {
            pnl_login.Visible = true;
            pnl_create.Visible = false;
            pnl_admin.Visible = false;

        }

        private void link_loginad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnl_login.Visible = false;
            pnl_create.Visible = false;
            pnl_admin.Visible = true;
        }

        private void txt_accname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            string accountName = textBox5.Text.Trim();

            if (!string.IsNullOrEmpty(accountName) && !accountName.EndsWith("@reverse"))
            {
                textBox5.Text = accountName + "@reverse";
            }
        }

       
    }   
}





