using HITechLibrary.Business;
using HITechLibrary.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechOrderApp.GUI;
using HiTechOrderApp.Properties;
using System.Data.SqlClient;
using HITechLibrary.DLL;

namespace HiTechOrderApp
{
    public partial class UserLogIn : Form
    {
        public UserLogIn()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (textBoxUserID.Text == "" || textBoxUserPassword.Text == "")
            {
                MessageBox.Show("Please enter UserID and Password");
                return;
            }

            try
            {
                SqlConnection connect = UtilityDB.ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "Select * from Users where userId = @userId and password = @password";
                cmd.Parameters.AddWithValue("@userId", textBoxUserID.Text);
                cmd.Parameters.AddWithValue("@password", textBoxUserPassword.Text);

                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                connect.Close();

                if (textBoxUserID.Text == "1111" && textBoxUserPassword.Text == "henry1234")
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    ManagerForm mis = new ManagerForm();
                    mis.Show();
                }
                else if (textBoxUserID.Text == "1112" && textBoxUserPassword.Text == "thomas1234")
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    SalesManager smf = new SalesManager();
                    smf.Show();
                }
                /*else if (textBoxUserID.Text == "4000" && textBoxUserPassword.Text == "kim4000")
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    AccountantForm af = new AccountantForm();
                    af.Show();
                }*/
                else if (textBoxUserID.Text == "1113" && textBoxUserPassword.Text == "peter1234")
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    InventoryForm mf = new InventoryForm();
                    mf.Show();
                }
                else if (textBoxUserID.Text == "1114" && textBoxUserPassword.Text == "mary1234")
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    OrderForm of = new OrderForm();
                    of.Show();
                }
                else if (textBoxUserID.Text == "1115" && textBoxUserPassword.Text == "jennifer1234")
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    OrderForm of = new OrderForm();
                    of.Show();
                }
                else
                {
                    MessageBox.Show("UserId or Password invalid!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadForm(User user)
        {
            int UserTypeID = user.GetUserType(user);
            switch (UserTypeID)
            {
                case 1:
                    MessageBox.Show("Normal user dont have any forms");
                    break;
                case 2:
                    this.Hide();
                    //ManagerForm ManageUser = new ManagerForm();
                
                    break;
                case 3:
                    MessageBox.Show("Under Construction");
                    break;
                default:
                    break;
            }
        }
    }
}

