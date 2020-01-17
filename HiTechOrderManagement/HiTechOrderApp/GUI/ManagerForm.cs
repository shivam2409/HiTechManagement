using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HITechLibrary.Validation;
using HITechLibrary.Business;
using HITechLibrary.DLL;
using HITechLibrary.DataAccess;


namespace HiTechOrderApp.GUI
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void employeeManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = "";
            input = textBoxEmployeeId.Text.Trim();
            if (!Validator.IsValidId(input, 4))
            {
                MessageBox.Show("Employee ID must be 4-digit number.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmployeeId.Clear();
                textBoxEmployeeId.Focus();
                return;

            }

            Employee emp = new Employee();
            int tempId = Convert.ToInt32(textBoxEmployeeId.Text.Trim());
            if (!(emp.IsUniqueEmpId(tempId)))
            {
                MessageBox.Show("Employee ID already exists.", "Duplicate EmployeeID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmployeeId.Clear();
                textBoxEmployeeId.Focus();
                return;
            }

            input = textBoxFirstName.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                MessageBox.Show("First name must contain letters or space(s)", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            input = textBoxLastName.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                MessageBox.Show("Last name must contain letters or space(s)", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }

            input = textBoxJobTitle.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                MessageBox.Show("Job Title must contain letters or space(s)", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxJobTitle.Clear();
                textBoxJobTitle.Focus();
                return;
            }

            //valid data
            emp.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text.Trim());
            emp.FirstName = textBoxFirstName.Text.Trim();
            emp.LastName = textBoxLastName.Text.Trim();
            emp.JobTitle = textBoxJobTitle.Text.Trim();
            emp.SaveEmployee(emp);
            MessageBox.Show("Employee record has been saved successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1EmpId_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //////save For User************

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string input = "";
            input = textBoxUserId.Text.Trim();
            if (!Validator.IsValidId(input, 4))
            {
                MessageBox.Show("User ID must be 4-digit number.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUserId.Clear();
                textBoxUserId.Focus();
                return;

            }

            User use = new User();
            int tempId = Convert.ToInt32(textBoxUserId.Text.Trim());
            if (!(use.IsUniqueUseId(tempId)))
            {
                MessageBox.Show("User ID already exists.", "Duplicate UserID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUserId.Clear();
                textBoxUserId.Focus();
                return;
            }

            input = textBoxUserName.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                MessageBox.Show("First name must contain letters or space(s)", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUserName.Clear();
                textBoxUserName.Focus();
                return;
            }

            input = textBoxUserLast.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                MessageBox.Show("Last name must contain letters or space(s)", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUserLast.Clear();
                textBoxUserLast.Focus();
                return;
            }

            input = textBoxUserJob.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                MessageBox.Show("Job Title must contain letters or space(s)", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUserJob.Clear();
                textBoxUserJob.Focus();
                return;
            }

            //valid data
            use.UserId = Convert.ToInt32(textBoxUserId.Text.Trim());
            use.FirstName = textBoxFirstName.Text.Trim();
            use.LastName = textBoxLastName.Text.Trim();
            use.JobTitle = textBoxJobTitle.Text.Trim();
            use.SaveUser(use);
            MessageBox.Show("User record has been saved successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonListAll_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> listEmp = new List<Employee>();
            listEmp = emp.ListEmployee();
            listViewEmployee.Items.Clear();
            if (listEmp.Count != 0)
            {
                foreach (Employee anEmp in listEmp)
                {
                    ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                    item.SubItems.Add(anEmp.FirstName);
                    item.SubItems.Add(anEmp.LastName);
                    item.SubItems.Add(anEmp.JobTitle);
                    listViewEmployee.Items.Add(item);

                }
            }
            else
            {
                MessageBox.Show("Employee list is empty" + "\n" + "Please enter Employee Data", "No Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxOption.SelectedIndex;
            List<Employee> listEmployee = new List<Employee>();
            switch (selectedIndex)
            {
                case 0: //Search employee by EmployeeId
                    Employee emp = new Employee();
                    emp = emp.SearchEmployee(Convert.ToInt32(textBoxInput.Text));
                    if (emp != null)
                    {
                        textBoxEmployeeId.Text = emp.EmployeeId.ToString();
                        textBoxFirstName.Text = emp.FirstName;
                        textBoxLastName.Text = emp.LastName;
                        textBoxJobTitle.Text = emp.JobTitle;

                    }
                    else
                    {
                        MessageBox.Show("Employee record not found!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 1: //Search employee by First Name
                    Employee anEmp = new Employee();
                    listEmployee = anEmp.SearchEmployee(1, textBoxInput.Text.Trim());
                    listViewEmployee.Items.Clear();
                    if (listEmployee.Count != 0)
                    {
                        foreach (Employee emp1 in listEmployee)
                        {
                            ListViewItem item = new ListViewItem(emp1.EmployeeId.ToString());
                            item.SubItems.Add(emp1.FirstName);
                            item.SubItems.Add(emp1.LastName);
                            item.SubItems.Add(emp1.JobTitle);
                            listViewEmployee.Items.Add(item);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Employee list is empty" + "\n" + "Please enter Employee Data", "No Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    break;
                case 2: //Search employee by LastName
                    Employee anEmp2 = new Employee();
                    listEmployee = anEmp2.SearchEmployee(2, textBoxInput.Text.Trim());
                    listViewEmployee.Items.Clear();
                    if (listEmployee.Count != 0)
                    {
                        foreach (Employee emp1 in listEmployee)
                        {
                            ListViewItem item = new ListViewItem(emp1.EmployeeId.ToString());
                            item.SubItems.Add(emp1.FirstName);
                            item.SubItems.Add(emp1.LastName);
                            item.SubItems.Add(emp1.JobTitle);
                            listViewEmployee.Items.Add(item);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Employee list is empty" + "\n" + "Please enter Employee Data", "No Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    break;
                default:
                    break;
            }
        }

        private void comboBoxOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxOption.SelectedIndex;
            switch (index)
            {
                case 0:
                    labelMessage.Text = "Please enter Employee ID ";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;
                default:
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            List<User> listUser = new List<User>();
            switch (selectedIndex)
            {
                case 0: //Search User by UserId
                    User use = new User();
                    use = use.SearchUser(Convert.ToInt32(textBoxSearchUser.Text));
                    if (use != null)
                    {
                        textBoxUserId.Text = use.UserId.ToString();
                        textBoxUserName.Text = use.FirstName;
                        textBoxUserLast.Text = use.LastName;
                        textBoxUserJob.Text = use.JobTitle;

                    }
                    else
                    {
                        MessageBox.Show("User record not found!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 1: //Search User by First Name
                    User anUse = new User();
                    listUser = anUse.SearchUser(1, textBoxSearchUser.Text.Trim());
                    listViewUser.Items.Clear();
                    if (listUser.Count != 0)
                    {
                        foreach (User use1 in listUser)
                        {
                            ListViewItem item = new ListViewItem(use1.UserId.ToString());
                            item.SubItems.Add(use1.FirstName);
                            item.SubItems.Add(use1.LastName);
                            item.SubItems.Add(use1.JobTitle);
                            listViewUser.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("User list is empty" + "\n" + "Please enter User Data", "No User Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    break;
                case 2: //Search User by LastName
                    User anUse2 = new User();
                    listUser = anUse2.SearchUser(2, textBoxSearchUser.Text.Trim());
                    listViewUser.Items.Clear();
                    if (listUser.Count != 0)
                    {
                        foreach (User use1 in listUser)
                        {
                            ListViewItem item = new ListViewItem(use1.UserId.ToString());
                            item.SubItems.Add(use1.FirstName);
                            item.SubItems.Add(use1.LastName);
                            item.SubItems.Add(use1.JobTitle);
                            listViewUser.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("User list is empty" + "\n" + "Please enter User Data", "No User Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                default:
                    break;
            }
        }

        private void buttonListUser_Click(object sender, EventArgs e)
        {
            User use = new User();
            List<User> listUse = new List<User>();
            listUse = use.ListUser();
            listViewUser.Items.Clear();
            if (listUse.Count != 0)
            {
                foreach (User anUse in listUse)
                {
                    ListViewItem item = new ListViewItem(anUse.UserId.ToString());
                    item.SubItems.Add(anUse.FirstName);
                    item.SubItems.Add(anUse.LastName);
                    item.SubItems.Add(anUse.JobTitle);
                    listViewUser.Items.Add(item);

                }
            }
            else
            {
                MessageBox.Show("User list is empty" + "\n" + "Please enter User Data", "No User Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxSearchUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you really want to delete this emplyee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Employee emp = new Employee();
                emp.DeleteEmployee(Convert.ToInt32(textBoxEmployeeId.Text));
                MessageBox.Show("Employee Record has been deleted successfully!", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }
        }
    

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            {
                Employee emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text.Trim());
                emp.FirstName = textBoxFirstName.Text.Trim();
                emp.LastName = textBoxLastName.Text.Trim();
                emp.JobTitle = textBoxJobTitle.Text.Trim();

                emp.UpdateEmployee(emp);

                MessageBox.Show("Employee Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you really want to delete this User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                User use = new User();
                use.DeleteUser(Convert.ToInt32(textBoxUserId.Text));
                MessageBox.Show("User Record has been deleted successfully!", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }
        }
    }
}
