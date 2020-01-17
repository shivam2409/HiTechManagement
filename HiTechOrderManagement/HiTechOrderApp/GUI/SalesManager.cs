using HITechLibrary.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HITechLibrary.DataAccess;
using HITechLibrary.DLL;


namespace HiTechOrderApp.GUI
{
    public partial class SalesManager : Form
    {
        SqlDataAdapter da;
        DataSet dsHiTechOrderManagement;

        DataTable dtCustomers;
        SqlCommandBuilder SqlBuilder;
        Customer aCustomer = new Customer();
        public SalesManager()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonListAll_Click(object sender, EventArgs e)
        {
            da.Fill(dsHiTechOrderManagement.Tables["Customers"]);
            dataGridViewCustomer.DataSource = dsHiTechOrderManagement.Tables["Customers"];
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); }

        private void SalesManager_Load(object sender, EventArgs e)
        {

            //Create an object of type DataSet and name it as CollegeDS
            dsHiTechOrderManagement = new DataSet("HiTechDS");

            //Create an object of type DataTable and name it as Students
            // and add the object to the DataSet object
            dtCustomers = new DataTable("Customers");
            dsHiTechOrderManagement.Tables.Add(dtCustomers);
            //dsCollegeDB.Tables.Add("Students");

            // Create columns , add columns to the DataTable Students
            dtCustomers.Columns.Add("CustomerId", typeof(int));
            dtCustomers.Columns.Add("FirstName", typeof(string));
            dtCustomers.Columns.Add("LastName", typeof(string));
            dtCustomers.Columns.Add("Street", typeof(string));
            dtCustomers.Columns.Add("City", typeof(string));
            dtCustomers.Columns.Add("PostalCode", typeof(string));
            dtCustomers.Columns.Add("CreditLimit", typeof(int));
            dtCustomers.Columns.Add("PhoneNumber", typeof(int));
            dtCustomers.Columns.Add("FaxNumber", typeof(string));
            dtCustomers.PrimaryKey = new DataColumn[] { dtCustomers.Columns["CustomerId"] };
            da = new SqlDataAdapter("SELECT * FROM Customers", UtilityDB.ConnectDB());
            SqlBuilder = new SqlCommandBuilder(da);
        
    }

    private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCustomerlName_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //dsHiTechOrderManagement.Tables.Add(dtCustomers);
            DataRow drCurrent = dtCustomers.NewRow();
            drCurrent["CustomerId"] = Convert.ToInt32(textBoxCustomerId.Text.Trim());
            drCurrent["FirstName"] = textBoxCustomerfName.Text.Trim();
            drCurrent["LastName"] = textBoxCustomerlName.Text.Trim();
            drCurrent["Street"] = textBoxStreet.Text.Trim();
            drCurrent["City"] = textBoxCity.Text.Trim();
            drCurrent["PostalCode"] = textBoxPostal.Text.Trim();
            drCurrent["CreditLimit"] = Convert.ToInt32(textBoxCreditLimit.Text.Trim());
            drCurrent["PhoneNumber"] = Convert.ToInt32(textBoxCPhoneNumber.Text.Trim());
            drCurrent["FaxNumber"] = textBoxFaxNumber.Text.Trim();
            dtCustomers.Rows.Add(drCurrent);
            MessageBox.Show(drCurrent.RowState.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxCustomerId.Text.Trim());
            DataRow drCustomer = dtCustomers.Rows.Find(searchId);
            if (drCustomer != null)
            {
                textBoxCustomerfName.Text = drCustomer["FirstName"].ToString();
                textBoxCustomerlName.Text = drCustomer["LastName"].ToString();
                textBoxStreet.Text = drCustomer["Street"].ToString();
                textBoxCity.Text = drCustomer["City"].ToString();
                textBoxPostal.Text = drCustomer["PostalCode"].ToString();
                textBoxCreditLimit.Text = drCustomer["CreditLimit"].ToString();
                textBoxCPhoneNumber.Text = drCustomer["PhoneNumber"].ToString();
                textBoxFaxNumber.Text = drCustomer["FaxNumber"].ToString();
            }
            else
            {
                MessageBox.Show("Customer not found!", "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        { 
            da.Update(dsHiTechOrderManagement.Tables["Customers"]);
            MessageBox.Show("Database has been updated successfully", "Confirmation");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxCustomerId.Text.Trim());
            DataRow drStudent = dtCustomers.Rows.Find(searchId);
            drStudent.Delete();
            MessageBox.Show(drStudent.RowState.ToString());
        }
    }
}
