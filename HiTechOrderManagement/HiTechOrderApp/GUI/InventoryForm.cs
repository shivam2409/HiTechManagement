using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HITechLibrary.Business;
using HITechLibrary.Validation;

namespace HiTechOrderApp.GUI
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string input = "";
            input = textBoxISBN.Text.Trim();
            if (!Validator.IsValidId(input, 4))
            {
                MessageBox.Show("Isbn ID must be 4-digit number.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            Book bo = new Book();
            int tempId = Convert.ToInt32(textBoxISBN.Text.Trim());
            if (!bo.IsUniqueBookISBN(tempId))
            {
                MessageBox.Show("Isbn already exists.", "Duplicate EmployeeID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            input = textBoxTitle.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                MessageBox.Show("Title must contain letters or space(s)", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTitle.Clear();
                textBoxTitle.Focus();
                return;
            }

            input = textBoxUnitPrice.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                MessageBox.Show("Price must contain letters or space(s)", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUnitPrice.Clear();
                textBoxUnitPrice.Focus();
                return;
            }

            input = textBoxYear.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                MessageBox.Show("Year must contain letters or space(s)", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxYear.Clear();
                textBoxYear.Focus();
                return;
            }
    
            input = textBoxQOH.Text.Trim();
            if (!(Validator.IsValidName(input)))
            {
                MessageBox.Show("Quantity must contain letters or space(s)", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxQOH.Clear();
                textBoxQOH.Focus();
                return;
            }
            //valid data
            bo.ISBN1 = Convert.ToInt32(textBoxISBN.Text.Trim());
            bo.Title1 = textBoxTitle.Text.Trim();
            bo.UnitPrice1 = Convert.ToInt32(textBoxUnitPrice.Text.Trim());
            bo.Year1 = Convert.ToInt32(textBoxYear.Text.Trim());
            bo.QOH1 = Convert.ToInt32(textBoxQOH.Text.Trim());
            bo.SaveBook(bo);
            MessageBox.Show("Employee record has been saved successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonListAll_Click(object sender, EventArgs e)
        {
            listViewBook.Items.Clear();
            Book book = new Book();
            List<Book> listBk = book.GetBookList();
            if (listBk != null)
            {
                foreach (Book bItem in listBk)
                {
                    ListViewItem item = new ListViewItem(bItem.ISBN1);
                    item.SubItems.Add(bItem.Title1);
                    item.SubItems.Add("$ " + bItem.UnitPrice1.ToString());
                    item.SubItems.Add(bItem.YearPublished.ToString());
                    item.SubItems.Add(bItem.QOH1.ToString());
                    listViewBook.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No Category Data in the database.", "No Category Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxOp.SelectedIndex;

            switch (selectedIndex)
            {
                case 1://search by ISBN
                    if (!Validator.IsValidIsbn(textBoxInp.Text.Trim()))
                    {
                        textBoxInp.Clear();
                        textBoxInp.Focus();
                        return;
                    }
                    Book book = new Book();
                    book = book.SearchBookISBN;
                    if (book != null)
                    {
                        textBoxISBN.Text = book.ISBN;
                        textBoxTitle.Text = book.Title1;
                        textBoxUnitPrice.Text = "$ " + book.UnitPrice1.ToString();
                        textBoxYear.Text = book.YearPublished.ToString();
                        textBoxQOH.Text = book.QOH1.ToString();

                    }
                    else
                    {
                        textBoxInp.Clear();
                        textBoxInp.Focus();
                        string error = "Book not found !" + "\n" + "Please enter book ISBN again.";
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case 2: //search by book title

                    Book tempBook = new Book();
                    List<Book> listTemp = tempBook.SearchBookTitle(textBoxInp.Text.Trim());
                    listViewBook.Items.Clear();
                    if (listTemp != null)
                    {
                        foreach (Book aBook in listTemp)
                        {
                            ListViewItem item = new ListViewItem(aBook.Isbn);
                            item.SubItems.Add(aBook.Title1);
                            item.SubItems.Add("$ " + aBook.UnitPrice1.ToString());
                            item.SubItems.Add(aBook.YearPublished.ToString());
                            item.SubItems.Add(aBook.QuantityOH.ToString());
                            listViewBook.Items.Add(item);
                        }
                    }
                    else
                    {
                        textBoxInp.Clear();
                        textBoxInp.Focus();
                        string error = "Book not found !" + "\n" + "Please enter book title again.";
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDeleteCatagory_Click(object sender, EventArgs e)
        {

        }
    }
}
