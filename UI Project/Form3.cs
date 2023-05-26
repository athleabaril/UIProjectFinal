using System.Windows.Forms;
using System;
using UI_Project;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UI_Project

{
    public partial class Form3 : Form
    {
        private string accountName; // Variable to store logged in user's account name
        private string oldPassword; // Variable to store user's old password

        public Form3(string accountName, string oldPassword)
        {
            InitializeComponent();
            this.accountName = accountName;
            this.oldPassword = oldPassword;
        }

       
        private void Form3_Load(object sender, EventArgs e)
        {
            txt_oldpass.UseSystemPasswordChar = true;
            txt_newpass.UseSystemPasswordChar = true;
            txt_confirmnewpass.UseSystemPasswordChar = true;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            string oldPass = txt_oldpass.Text;
            string newPass = txt_newpass.Text;
            string confirmPass = txt_confirmnewpass.Text;

            try
            {
                OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Athlea Baril\Desktop\Vs Program OOP2\UI Project\UI Project DataBase\UI_Project Database.accdb;"); // Update with your connection string
                connection.Open();


                // Check if old password matches with the one in the database
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [Password] FROM [User Information] WHERE [Account Name] = ?";
                command.Parameters.AddWithValue("@AccountName", accountName);
                string password = command.ExecuteScalar().ToString();

                if (oldPass != password)
                {
                    MessageBox.Show("Incorrect password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return;
                }
                // Update password in the database
                command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [User Information] SET [Password] = ? WHERE [Account Name] = ?";
                command.Parameters.AddWithValue("@New_Password", newPass);
                command.Parameters.AddWithValue("@Account_Name", accountName);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connection.Close();
                this.Close();

                Form2 form2 = new Form2(accountName);
                form2.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void btn_cancel_Click_1(object sender, EventArgs e)
        {
            // Delay for 1 second (1000 milliseconds)
            await Task.Delay(1000);

            // Close Form3
            this.Close();

            // Show Form2 and set its home panel pnl_home as visible
            Form2 form2 = new Form2(accountName);
            form2.Show();
        }

        
    }
}
