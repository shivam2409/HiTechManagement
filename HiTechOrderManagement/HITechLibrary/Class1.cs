using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HITechLibrary.Business;
using HITechLibrary.DataAccess;
using HITechLibrary.DLL;
using HITechLibrary.Validation;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

//DataAccess classes OF EmployeeDb,CustomerDb,UtilityDB

namespace HITechLibrary.DataAccess
{
    public static class EmployeeDB
    {
        public static bool IsUniqueId(int tempId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Employee " +
                                " WHERE EmployeeId= " + tempId;
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show(id.ToString()); // debug code
            if (id != 0)
            {
                return false;
            }
            return true;
        }

        //Save Employee Method//****
        public static void SaveRecord(Employee emp)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "INSERT INTO Employee(EmployeeId,FirstName,LastName,JobTitle) " +
                              " VALUES(@EmployeeId,@FirstName,@LastName,@JobTitle) ";
            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmd.ExecuteNonQuery();
            connDB.Close();
        }

        //Search Record For Employee
        public static Employee SearchRecord(int empId)
        {
            Employee emp = new Employee();
            //Connect DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //SqlCommand object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Employee " +
                              "WHERE EmployeeId = @EmployeeId ";
            cmd.Parameters.AddWithValue("@EmployeeId", empId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
            }
            else
            {
                emp = null;
            }
            connDB.Close();
            //Close DB

            return emp;
        }

        //list Employee By Search method
        public static List<Employee> SearchRecord(int option, string name)
        {
            List<Employee> listEmp = new List<Employee>();
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                switch (option)
                {
                    case 1: // search by FirstName
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connDB;
                        cmd.CommandText = "SELECT * FROM Employee " +
                                          "WHERE FirstName = @FirstName ";

                        cmd.Parameters.AddWithValue("@FirstName", name);
                        SqlDataReader reader = cmd.ExecuteReader();
                        Employee emp;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                emp = new Employee();
                                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                                emp.FirstName = reader["FirstName"].ToString();
                                emp.LastName = reader["LastName"].ToString();
                                emp.JobTitle = reader["JobTitle"].ToString();
                                listEmp.Add(emp);
                            }

                        }
                        else
                        {
                            listEmp = null;
                        }
                        break;
                    case 2: // search by LastName
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = connDB;
                        cmd2.CommandText = "SELECT * FROM Employee " +
                                          "WHERE LastName = @LastName ";

                        cmd2.Parameters.AddWithValue("@LastName", name);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        Employee emp2;
                        if (reader2.HasRows)
                        {
                            while (reader2.Read())
                            {
                                emp2 = new Employee();
                                emp2.EmployeeId = Convert.ToInt32(reader2["EmployeeId"]);
                                emp2.FirstName = reader2["FirstName"].ToString();
                                emp2.LastName = reader2["LastName"].ToString();
                                emp2.JobTitle = reader2["JobTitle"].ToString();
                                listEmp.Add(emp2);
                            }

                        }
                        else
                        {
                            listEmp = null;
                        }
                        break;
                    default:
                        break;
                }
            }
            return listEmp;
        }

        //Employee ListRecord
        public static List<Employee> ListRecord()
        {
            List<Employee> listEmp = new List<Employee>();

            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", connDB);
            SqlDataReader reader = cmd.ExecuteReader();
            Employee emp;
            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
                listEmp.Add(emp);
            }
            return listEmp;
        }

        //Update Employee table
        public static void UpdateRecord(Employee emp)
        {
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connDB;
                cmd.CommandText = "UPDATE Employee " +
                                  " set FirstName = @FirstName, " +
                                    " LastName = @LastName, " +
                                    " JobTitle = @JobTitle " +
                                    " WHERE EmployeeId = @EmployeeId ";
                cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
                cmd.ExecuteNonQuery();
            }

        }

        //Delete Employee Record 
        public static void DeleteRecord(int empId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "delete from [Employee] where EmployeeId=@EmployeeId";
            cmd.Parameters.AddWithValue("@EmployeeId", empId);
            cmd.ExecuteNonQuery();
            connDB.Close();
        }
        /*SqlConnection connDB = UtilityDB.ConnectDB();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connDB;
            cmd.CommandText = "delete from Employees where EmployeeId=@EmployeeId";
            cmd.Parameters.AddWithValue("@EmployeeId", id);
            cmd.ExecuteNonQuery();
            connDB.Close();*/
    }

    //User Class
    public static class UserDB
    {
        //Check if Id Is Unique
        public static bool IsUniqueId(int tempId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Users " +
                                " WHERE UserId= " + tempId;
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show(id.ToString()); // debug code
            if (id != 0)
            {
                return false;
            }
            return true;
        }

        //Save User Method//****
        public static void SaveRecord(User use)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "INSERT INTO Users(UserId,FirstName,LastName,JobTitle) " +
                              " VALUES(@UserId,@FirstName,@LastName,@JobTitle) ";
            cmd.Parameters.AddWithValue("@UserId", use.UserId);
            cmd.Parameters.AddWithValue("@FirstName", use.FirstName);
            cmd.Parameters.AddWithValue("@LastName", use.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", use.JobTitle);
            cmd.ExecuteNonQuery();
            connDB.Close();

        }

        //User Search Record
        public static User SearchRecord(int useId)
        {
            User use = new User();
            //Connect DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //SqlCommand object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Users " +
                              "WHERE UserId = @UserId ";
            cmd.Parameters.AddWithValue("@UserId", useId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                use.UserId = Convert.ToInt32(reader["UserId"]);
                use.FirstName = reader["FirstName"].ToString();
                use.LastName = reader["LastName"].ToString();
                use.JobTitle = reader["JobTitle"].ToString();
            }
            else
            {
                use = null;
            }
            connDB.Close();
            //Close DB
            return use;
        }

        //List User Search Record
        public static List<User> SearchRecord(int option, string name)
        {
            List<User> listUse = new List<User>();
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                switch (option)
                {
                    case 1: // search by FirstName
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connDB;
                        cmd.CommandText = "SELECT * FROM Users " +
                                          "WHERE FirstName = @FirstName ";

                        cmd.Parameters.AddWithValue("@FirstName", name);
                        SqlDataReader reader = cmd.ExecuteReader();
                        User use;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                use = new User();
                                use.UserId = Convert.ToInt32(reader["UserId"]);
                                use.FirstName = reader["FirstName"].ToString();
                                use.LastName = reader["LastName"].ToString();
                                use.JobTitle = reader["JobTitle"].ToString();
                                listUse.Add(use);
                            }
                        }
                        else
                        {
                            listUse = null;
                        }
                        break;
                    case 2: // search by LastName
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = connDB;
                        cmd2.CommandText = "SELECT * FROM Users " +
                                          "WHERE LastName = @LastName ";
                        cmd2.Parameters.AddWithValue("@LastName", name);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        User use2;
                        if (reader2.HasRows)
                        {
                            while (reader2.Read())
                            {
                                use2 = new User();
                                use2.UserId = Convert.ToInt32(reader2["UserId"]);
                                use2.FirstName = reader2["FirstName"].ToString();
                                use2.LastName = reader2["LastName"].ToString();
                                use2.JobTitle = reader2["JobTitle"].ToString();
                                listUse.Add(use2);
                            }
                        }
                        else
                        {
                            listUse = null;
                        }
                        break;
                    default:
                        break;
                }
            }

            return listUse;
        }

        //user Record
        public static List<User> ListRecord()
        {
            List<User> listUse = new List<User>();

            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", connDB);
            SqlDataReader reader = cmd.ExecuteReader();
            User use;
            while (reader.Read())
            {
                use = new User();
                use.UserId = Convert.ToInt32(reader["UserId"]);
                use.FirstName = reader["FirstName"].ToString();
                use.LastName = reader["LastName"].ToString();
                use.JobTitle = reader["JobTitle"].ToString();
                listUse.Add(use);
            }
            return listUse;
        }

        //Update User Record
        public static void UpdateRecord(User use)
        {
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connDB;
                cmd.CommandText = "UPDATE Users " +
                                  " set FirstName = @FirstName, " +
                                    " LastName = @LastName, " +
                                    " JobTitle = @JobTitle " +
                                    " WHERE UserId = @UserId ";
                cmd.Parameters.AddWithValue("@UserId", use.UserId);
                cmd.Parameters.AddWithValue("@FirstName", use.FirstName);
                cmd.Parameters.AddWithValue("@LastName", use.LastName);
                cmd.Parameters.AddWithValue("@JobTitle", use.JobTitle);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteRecord(int useId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "delete from [Users] where userId=@UserId";
            cmd.Parameters.AddWithValue("@UserId", useId);
            cmd.ExecuteNonQuery();
            connDB.Close();
        }
    }

    //Customer For DIsconnected mode
    public static class CustomerDB
    {
        public static object Tables { get; set; }

        public static List<Customer> ListRecord()
        {
            List<Customer> listS = new List<Customer>();
            using (SqlConnection conn = UtilityDB.ConnectDB())
            {
                Customer aCustomer;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        aCustomer = new Customer();
                        aCustomer.CustomerId = Convert.ToInt32(reader["StudentId"]);
                        aCustomer.FirstName = reader["FirstName"].ToString();
                        aCustomer.LastName = reader["LastName"].ToString();
                        aCustomer.Street1 = reader["Street"].ToString();
                        aCustomer.City = reader["City"].ToString();
                        aCustomer.PostalCode = reader["PostalCode"].ToString();
                        aCustomer.FaxNumber = reader["FaxNumber"].ToString();
                        aCustomer.CreditLimit = Convert.ToInt32(reader["CreditLimit"]);
                        aCustomer.PhoneNumber = Convert.ToInt32(reader["PhoneNumber"]);
                        aCustomer.FaxNumber = reader["FaxNumber"].ToString();
                        listS.Add(aCustomer);
                    }
                }
                else
                {
                    listS = null;
                }
            }
            return listS;
        }
    }
}
namespace HITechLibrary.Business
{
    //Employee 
    public class Employee
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private string jobTitle;
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public bool IsUniqueEmpId(int id)
        {
            return (EmployeeDB.IsUniqueId(id));
        }
        public void SaveEmployee(Employee emp)
        {
            EmployeeDB.SaveRecord(emp);
        }

        public Employee SearchEmployee(int empId)
        {
            return (EmployeeDB.SearchRecord(empId));
        }
        public List<Employee> ListEmployee()
        {
            return (EmployeeDB.ListRecord());
        }
        public List<Employee> SearchEmployee(int option, string input)
        {
            return (EmployeeDB.SearchRecord(option, input));
        }
        public void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateRecord(emp);
        }

        public void DeleteEmployee(int empId)
        {
            EmployeeDB.DeleteRecord(empId);
        }
    }

    //class user
    public class User
    {
        private int userId;
        private string firstName;
        private string lastName;
        private string jobTitle;
        private string password;

        public int UserId { get => userId; set => userId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public string Password { get => password; set => password = value; }

        public bool IsUniqueUseId(int id)
        {
            return (UserDB.IsUniqueId(id));
        }
        public void SaveUser(User use)
        {
            UserDB.SaveRecord(use);
        }

        public User SearchUser(int useId)
        {
            return (UserDB.SearchRecord(useId));
        }
        public List<User> ListUser()
        {
            return (UserDB.ListRecord());
        }
        public List<User> SearchUser(int option, string input)
        {
            return (UserDB.SearchRecord(option, input));
        }
        public void UpdateUser(User use)
        {
            UserDB.UpdateRecord(use);
        }

        public bool GetUserDetails(User user)
        {
            throw new NotImplementedException();
        }

        public int GetUserType(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int useId)
        {
            UserDB.DeleteRecord(useId);
        }
    }
    //Customer
    public class Customer
    {
        private int customerId;
        private string firstName;
        private string lastName;
        private string Street;
        private string city;
        private string postalCode;
        private int creditLimit;
        private int phoneNumber;
        private string faxNumber;

      
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Street1 { get => Street; set => Street = value; }
        public string City { get => city; set => city = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public int CreditLimit { get => creditLimit; set => creditLimit = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string FaxNumber { get => faxNumber; set => faxNumber = value; }
        public int CustomerId { get => customerId; set => customerId = value; }

        public List<Customer> ListStudent()
        {
            return (CustomerDB.ListRecord());
        }
    }
    //Book
    public class Book
    {
        private int ISBN;
        private string Title;
        private int UnitPrice;
        private int Year;
        private int QOH;

        public int ISBN1 { get => ISBN; set => ISBN = value; }
        public string Title1 { get => Title; set => Title = value; }
        public int UnitPrice1 { get => UnitPrice; set => UnitPrice = value; }
        public int Year1 { get => Year; set => Year = value; }
        public int QOH1 { get => QOH; set => QOH = value; }
        public object YearPublished { get; set; }

     
        //
        public void SaveBook(Book book)
        {
            BookDB.SaveRecord(book);
        }

        public List<Book> GetBookList()
        {
            return (BookDB.ListRecord());
        }

        public bool IsUniqueIsbn(int ISBN)
        {
            return (BookDB.ListRecord(ISBN));
        }
        public Book SearchBookISBN(int ISBN)
        {
            return (BookDB.SearchRecord(ISBN));
        }
        public List<Book> SearchBookTitle(string title)
        {
            return BookDB.SearchRecord(title);
        }

        public void UpdateBook(Book book)
        {
            BookDB.UpdateRecord(book);
        }
        public void DeleteBook(int ISBN)
        {
            BookDB.DeleteRecord(ISBN);
        }
    }
 }
    namespace HITechLibrary.DLL
{
    public static class UtilityDB
    {
        //version 1
        //public static SqlConnection ConnectDB()
        //{
        //    SqlConnection connDB = new SqlConnection();
        //    connDB.ConnectionString = @"server=TITANCAO-PC\MSSQLSERVER2017; database=EmployeeDB;user=sa;password=lasalle";
        //    connDB.Open();
        //    return connDB;
        //}

        //version 2
        public static SqlConnection ConnectDB()
        {
            SqlConnection connDB = new SqlConnection();
            connDB.ConnectionString = ConfigurationManager.ConnectionStrings["HiTechOrderManagementConnection"].ConnectionString;
            connDB.Open();
            return connDB;
        }
    }
}
namespace HITechLibrary.Validation
{
    public static class Validator
    {
        public static bool IsValidId(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{4}$"))
            {
                MessageBox.Show("Invalid Employee ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }


        public static bool IsValidId(string input, int length)
        {
            if (!Regex.IsMatch(input, @"^\d{4}$"))
            {
                MessageBox.Show("Invalid Employee ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }

        public static bool IsValidName(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                //MessageBox.Show(input[i].ToString());
                if ((!(Char.IsLetter(input[i]))) && (!(Char.IsWhiteSpace(input[i]))))
                {
                    return false;
                }
            }
            return true;
        }

        //
        public static bool IsValidID(string input)
        {
            string error = "Invalid UserID. \nPlease verify you User ID and try again or contact your MIS Manager";

            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9]{5}$"))
            {
                MessageBox.Show(error, "Invalid UserID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static bool IsValidPassword(string input)
        {
            string error = "Invalid Password. \nPlease verify your Password and try again or contact your admin";

            if (!Regex.IsMatch(input, @"^[^.](?!.*[.]{2})[a-zA-Z0-9.!#$%&’'*+/=?^_`{|}~-]{8,16}[^.]+$"))
            {
                MessageBox.Show(error, "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public static bool IsValidName(string input, int type)
        {
            string error = "";
            switch (type)
            {
                case 0: //firstname
                    error = "First name must contain only letters or space(s)";
                    break;
                case 1: //lastname
                    error = "Last name must contain only letters or space(s)";
                    break;
                default:
                    break;
            }

            if (!Regex.IsMatch(input, @"[A-Za-z]{1}[a-z]{1,25}"))
            {
                MessageBox.Show(error, "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsValidEmail(string input)
        {
            string error = "Invalid Email ID. \n Email ID must be in the format \"emailid@somemail.com\"";
            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"))
            {
                MessageBox.Show(error, "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }

        public static bool isValidPhone(string input)
        {
            string error = "Invalid Phone number.\n Phone number ";
            if (!Regex.IsMatch(input, @"^[1-9]{3}[0-9]{7}$"))
            {
                MessageBox.Show(error, "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }
        public static bool IsValidIsbn(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{13}$"))
            {
                MessageBox.Show("Invalid ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }
    }
    //book
    public static class BookDB
    {
        public static object ISBN { get; private set; }

        public static bool IsUniqueId(int tempId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Books " +
                                " WHERE ISBN= " + tempId;
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show(id.ToString()); // debug code
            if (id != 0)
            {
                return false;
            }
            return true;
        }
        //Save Book Method//****
        public static void SaveRecord(Book bo)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "INSERT INTO Books(ISBN,Title,UnitPrice,Year,QOH) " +
                              "VALUES(@ISBN,@Title,@UnitPrice,@Year,@QOH) ";
            cmd.Parameters.AddWithValue("@ISBN", bo.ISBN1);
            cmd.Parameters.AddWithValue("@Title", bo.Title1);
            cmd.Parameters.AddWithValue("@UnitPrice", bo.UnitPrice1);
            cmd.Parameters.AddWithValue("@Year", bo.Year1);
            cmd.Parameters.AddWithValue("@QOH", bo.QOH1);
            cmd.ExecuteNonQuery();
            connDB.Close();

        }
        public static Book SearchRecord(int ISBN)
        {
            Book bo = new Book();
            //Connect DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //SqlCommand object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Books " +
                              "WHERE ISBN = @ISBN ";
            cmd.Parameters.AddWithValue("@ISBN", ISBN);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                bo.ISBN1 = Convert.ToInt32(reader["ISBN"]);
                bo.Title1 = reader["Title"].ToString();
                bo.UnitPrice1 = Convert.ToInt32(reader["UnitPrice"]);
                bo.Year1 = Convert.ToInt32(reader["Year"]);
                bo.QOH1 = Convert.ToInt32(reader["QOH"]);
            }
            else
            {
                bo = null;
            }
            connDB.Close();
            //Close DB

            return bo;
        }
  
        public static List<Book> SearchRecord(int option, string name)
        {
            List<Book> listBook = new List<Book>();
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                object title = null;
                switch (option)
                {
                    case 1: // search by Title
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connDB;
                        cmd.CommandText = "SELECT * FROM Books " +
                                          "WHERE ISBN = @ISBN ";

                        cmd.Parameters.AddWithValue("@ISBN", ISBN);
                        SqlDataReader reader = cmd.ExecuteReader();
                        Book bo;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                bo = new Book();
                                bo.ISBN1 = Convert.ToInt32(reader["ISBN"]);
                                bo.Title1 = reader["Title"].ToString();
                                bo.UnitPrice1 = Convert.ToInt32(reader["UnitPrice"]);
                                bo.Year1 = Convert.ToInt32(reader["Year"]);
                                bo.QOH1 = Convert.ToInt32(reader["QOH"]);
                                listBook.Add(bo);
                            }

                        }
                        else
                        {
                            listBook = null;
                        }
                        break;
                    //case 2: // search by LastName
                    //    SqlCommand cmd = new SqlCommand();
                    //    cmd.Connection = connDB;
                    //    cmd.CommandText = "SELECT * FROM Books " +
                    //                      "WHERE TItle = @TItle ";

                    //    cmd.Parameters.AddWithValue("@TItle", TItle);
                    //    SqlDataReader reader = cmd.ExecuteReader();
                    //    Book bo;
                    //    if (reader.HasRows)
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            bo = new Book();
                    //            bo.ISBN1 = Convert.ToInt32(reader["ISBN"]);
                    //            bo.Title1 = reader["Title"].ToString();
                    //            bo.UnitPrice1 = Convert.ToInt32(reader["UnitPrice"]);
                    //            bo.Year1 = Convert.ToInt32(reader["Year"]);
                    //            bo.QOH1 = Convert.ToInt32(reader["QOH"]);
                    //            listBook.Add(bo);
                    //        }

                    //    }
                    //    else
                    //    {
                    //        listBook = null;
                    //    }
                        break;
                    default:
                        break;
                }
            }

            return listBook;
        }

        public static List<Book> ListRecord()
        {
            List<Book> listBook = new List<Book>();

            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Books", connDB);
            SqlDataReader reader = cmd.ExecuteReader();
            Book bo;
            while (reader.Read())
            {
                bo = new Book();
                bo.ISBN1 = Convert.ToInt32(reader["ISBN"]);
                bo.Title1 = reader["Title"].ToString();
                bo.UnitPrice1 = Convert.ToInt32(reader["UnitPrice"]);
                bo.Year1 = Convert.ToInt32(reader["Year"]);
                bo.QOH1 = Convert.ToInt32(reader["QOH"]);
                listBook.Add(bo);
            }
            return listBook;
        }

        public static void UpdateRecord(Book bo)
        {
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connDB;
                cmd.CommandText = "UPDATE Books " +
                                  " set Title = @Title, " +
                                    " UnitPrice = @UnitPrice, " +
                                    " Year = @Year " +
                                    " QOH = @QOH " +
                                    " WHERE ISBN = @ISBN ";
                cmd.Parameters.AddWithValue("@ISBN", bo.ISBN1);
                cmd.Parameters.AddWithValue("@Title", bo.Title1);
                cmd.Parameters.AddWithValue("@UnitPrice", bo.UnitPrice1);
                cmd.Parameters.AddWithValue("@Year", bo.Year1);
                cmd.Parameters.AddWithValue("@QOH", bo.QOH1);
                cmd.ExecuteNonQuery();
            }

        }
        public static void DeleteRecord(int empId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "delete from [Books] where ISBN=@ISBN";
            cmd.Parameters.AddWithValue("@ISBN", ISBN);
            cmd.ExecuteNonQuery();
            connDB.Close();
        }

        internal static List<Book> SearchRecord(string title)
        {
            throw new NotImplementedException();
        }

        internal static bool ListRecord(int iSBN)
        {
            throw new NotImplementedException();
        }
    }
    //Auther class
    public class Author
    {
        private int authorId;
        private string autFName;
        private string autLName;
        private string autEmail;


        public int AuthorId { get => authorId; set => authorId = value; }
        public string AutFName { get => autFName; set => autFName = value; }
        public string AutLName { get => autLName; set => autLName = value; }
        public string AutEmail { get => autEmail; set => autEmail = value; }

        public void SaveAuthor(Author aut)
        {
            AuthorDB.SaveRecord(aut);
        }
        public List<Author> GetAuthorList()
        {
            return (AuthorDB.GetRecordList());
        }

        public bool IsUniqueAuthorId(int autId)
        {
            return (AuthorDB.IsUniqueId(autId));
        }
        public Author SearchAuthor(int id)
        {
            return (AuthorDB.SearchRecord(id));
        }
        public List<Author> SearchAuthor(string input)
        {
            return (AuthorDB.SearchRecord(input));
        }
        public void UpdateAuthor(Author aut)
        {
            AuthorDB.UpdateRecord(aut);
        }
        public void DeleteAuthor(int autId)
        {
            AuthorDB.DeleteRecord(autId);
        }
    }
    //AutherDB 
    public static class AuthorDB
    {
        public static void SaveRecord(Author emp)
        {
            //connect the database
            SqlConnection connDB = UtilityDB.ConnectDB();

            //create and customize the object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "INSERT INTO Authors(AuthorId,AutFName,AutLName,AutEmail)" +
                                " VALUES (@AuthorId,@AutFName,@AutLName,@AutEmail)";

            cmd.Parameters.AddWithValue("@AuthorId", emp.AuthorId);
            cmd.Parameters.AddWithValue("@AutFName", emp.AutFName);
            cmd.Parameters.AddWithValue("@AutLName", emp.AutLName);
            cmd.Parameters.AddWithValue("@AutEmail", emp.AutEmail);
            cmd.ExecuteNonQuery();

            //close the connection
            connDB.Close();
        }
        public static List<Author> GetRecordList()
        {
            List<Author> listAut = new List<Author>();
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Authors", connDB);
            SqlDataReader reader = cmd.ExecuteReader();
            Author aut;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    aut = new Author();//create the object here, not outside
                    aut.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                    aut.AutFName = reader["AutFName"].ToString();
                    aut.AutLName = reader["AutLName"].ToString();
                    aut.AutEmail = reader["AutEmail"].ToString();
                    listAut.Add(aut);

                }
            }
            else
            {
                listAut = null;
            }

            return listAut;
        }
        public static bool IsUniqueId(int tempId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Authors " +
                             " WHERE AuthorId =" + tempId;
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            if (id != 0)
            {
                connDB.Close();
                return false;
            }
            connDB.Close();
            return true;
        }
        public static Author SearchRecord(int searchId)
        {
            Author aut = new Author();
            SqlConnection sqlConn = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConn;
            cmd.CommandText = "SELECT * from Authors " +
                                "WHERE AuthorId = @AuthorId ";
            cmd.Parameters.AddWithValue("@AuthorId", searchId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                aut.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                aut.AutFName = reader["AutFName"].ToString();
                aut.AutLName = reader["AutLName"].ToString();
                aut.AutEmail = reader["AutEmail"].ToString();

            }
            else
            {
                aut = null;
            }
            return aut;
        }
        public static List<Author> SearchRecord(string input)
        {
            List<Author> listAut = new List<Author>();
            List<Author> listTemp = new List<Author>();
            Author emp = new Author();
            listAut = emp.GetAuthorList();
            Author aut2;
            if (listAut != null)
            {
                foreach (Author anAut in listAut)
                {
                    if ((input.ToUpper() == anAut.AutFName.ToUpper()) || (input.ToUpper() == anAut.AutLName.ToUpper()))
                    {
                        aut2 = new Author();
                        aut2.AuthorId = Convert.ToInt32(anAut.AuthorId);
                        aut2.AutFName = anAut.AutFName;
                        aut2.AutLName = anAut.AutLName;
                        aut2.AutEmail = anAut.AutEmail;
                        listTemp.Add(aut2);
                    }
                }
            }
            return listTemp;
        }
        public static void UpdateRecord(Author aut)
        {
            //connect the database
            SqlConnection connDB = UtilityDB.ConnectDB();

            //create and customize the object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "Update Authors " +
                                "SET AutFName = @AutFName," +
                                    " AutLName = @AutLName," +
                                    " AutEmail = @AutEmail " +
                                    " WHERE AuthorId = @AuthorId ";
            MessageBox.Show(cmd.CommandText);
            cmd.Parameters.AddWithValue("@AuthorId", aut.AuthorId);
            cmd.Parameters.AddWithValue("@AutFName", aut.AutFName);
            cmd.Parameters.AddWithValue("@AutLName", aut.AutLName);
            cmd.Parameters.AddWithValue("@AutEmail", aut.AutEmail);
            cmd.ExecuteNonQuery();

            //close connection
            connDB.Close();
        }
        public static void DeleteRecord(int autId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "delete from Authors where AuthorId=@AuthorId";
            cmd.Parameters.AddWithValue("@AuthorId", autId);
            cmd.ExecuteNonQuery();
            connDB.Close();
        }
    }

    //Class Catagory
    public class Category
    {
        private int catId;
        private string catName;

        public int CatId { get => catId; set => catId = value; }
        public string CatName { get => catName; set => catName = value; }

        public void SaveCategory(Category cat)
        {
            CategoryDB.SaveRecord(cat);
        }
        public List<Category> GetCategoryList()
        {
            return (CategoryDB.GetRecordList());
        }

        public bool IsUniqueCategoryId(int catId)
        {
            return (CategoryDB.IsUniqueId(catId));
        }
        public void UpdateCategory(Category cat)
        {
            CategoryDB.UpdateRecord(cat);
        }
        public void DeleteCategory(int catId)
        {
            CategoryDB.DeleteRecord(catId);
        }
    }

    //Class CatagoryDB
    public static class CategoryDB
    {
        public static void SaveRecord(Category cat)
        {
            //connect the database
            SqlConnection connDB = UtilityDB.ConnectDB();

            //create and customize the object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "INSERT INTO Categories(CatId,CatName)" +
                                " VALUES (@CatId,@CatName)";

            cmd.Parameters.AddWithValue("@CatId", cat.CatId);
            cmd.Parameters.AddWithValue("@CatName", cat.CatName);
            cmd.ExecuteNonQuery();

            //close the connection
            connDB.Close();
        }
        public static List<Category> GetRecordList()
        {
            List<Category> listCat = new List<Category>();
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", connDB);
            SqlDataReader reader = cmd.ExecuteReader();
            Category cat;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cat = new Category();//create the object here, not outside
                    cat.CatId = Convert.ToInt32(reader["CatId"]);
                    cat.CatName = reader["CatName"].ToString();
                    listCat.Add(cat);

                }
            }
            else
            {
                listCat = null;
            }

            return listCat;
        }
        public static bool IsUniqueId(int tempId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Categories " +
                             " WHERE CatId =" + tempId;
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            if (id != 0)
            {
                connDB.Close();
                return false;
            }
            connDB.Close();
            return true;
        }
        public static void UpdateRecord(Category cat)
        {
            //connect the database
            SqlConnection connDB = UtilityDB.ConnectDB();

            //create and customize the object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "Update Categories " +
                                "SET CatName = @CatName " +
                                    " WHERE CatId = @CatId ";
            MessageBox.Show(cmd.CommandText);
            cmd.Parameters.AddWithValue("@CatId", cat.CatId);
            cmd.Parameters.AddWithValue("@CatName", cat.CatName);
            cmd.ExecuteNonQuery();

            //close connection
            connDB.Close();
        }

        //deleting catagory
        public static void DeleteRecord(int catid)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "delete from Categories where CatId=@CatId";
            cmd.Parameters.AddWithValue("@CatId", catid);
            cmd.ExecuteNonQuery();
            connDB.Close();
        }
    }
    //Publisher
    public class Publisher
    {
        private int pubId;
        private string pubName;

        public int PubId { get => pubId; set => pubId = value; }
        public string PubName { get => pubName; set => pubName = value; }

        public void SavePublisher(Publisher pub)
        {
            PublisherDB.SaveRecord(pub);
        }
        public List<Publisher> GetPublisherList()
        {
            return (PublisherDB.GetRecordList());
        }

        public bool IsUniquePublisherId(int pubId)
        {
            return (PublisherDB.IsUniqueId(pubId));
        }
        public void UpdatePublisher(Publisher pub)
        {
            PublisherDB.UpdateRecord(pub);
        }
        public void DeletePublisher(int pubId)
        {
            PublisherDB.DeleteRecord(pubId);
        }
    }

    //PublisherDB
    public static class PublisherDB
    {
        public static void SaveRecord(Publisher pub)
        {
            //connect the database
            SqlConnection connDB = UtilityDB.ConnectDB();

            //create and customize the object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "INSERT INTO Publishers(PubId,PubName)" +
                                " VALUES (@pubId,@PubName)";

            cmd.Parameters.AddWithValue("@PubId", pub.PubId);
            cmd.Parameters.AddWithValue("@PubName", pub.PubName);
            cmd.ExecuteNonQuery();

            //close the connection
            connDB.Close();
        }
        public static List<Publisher> GetRecordList()
        {
            List<Publisher> listPub = new List<Publisher>();
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Publishers", connDB);
            SqlDataReader reader = cmd.ExecuteReader();
            Publisher pub;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    pub = new Publisher();//create the object here, not outside
                    pub.PubId = Convert.ToInt32(reader["PubId"]);
                    pub.PubName = reader["PubName"].ToString();
                    listPub.Add(pub);

                }
            }
            else
            {
                listPub = null;
            }

            return listPub;
        }
        public static bool IsUniqueId(int tempId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "SELECT * FROM Publishers " +
                             " WHERE PubId =" + tempId;
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            if (id != 0)
            {
                connDB.Close();
                return false;
            }
            connDB.Close();
            return true;
        }
        public static void UpdateRecord(Publisher pub)
        {
            //connect the database
            SqlConnection connDB = UtilityDB.ConnectDB();

            //create and customize the object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "Update Publishers " +
                                "SET PubName = @PubName" +
                                    " WHERE PubId = @PubId ";
            MessageBox.Show(cmd.CommandText);
            cmd.Parameters.AddWithValue("@PubId", pub.PubId);
            cmd.Parameters.AddWithValue("@PubName", pub.PubName);
            cmd.ExecuteNonQuery();

            //close connection
            connDB.Close();
        }
        public static void DeleteRecord(int pubId)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "delete from Publishers where PubId=@PubId";
            cmd.Parameters.AddWithValue("@PubId", pubId);
            cmd.ExecuteNonQuery();
            connDB.Close();
        }
    }
}




