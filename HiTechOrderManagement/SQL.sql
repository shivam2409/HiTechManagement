 string input = "";
            // input = textBoxISBN.Text.Trim();
            // if (!Validator.IsValidId(input, 4))
            // {
            //     MessageBox.Show("ISBN ID must be 4-digit number.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //     textBoxISBN.Clear();
            //     textBoxISBN.Focus();
            //     return;

            // }

            ISBN bnum = new ISBN();
            int tempId = Convert.ToInt32(textBoxISBN.Text.Trim());
            if (!(emp.IsUniqueEmpId(tempId)))
            {
                MessageBox.Show("Employee ID already exists.", "Duplicate EmployeeID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
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
            emp.EmployeeId = Convert.ToInt32(textBoxISBN.Text.Trim());
            emp.FirstName = textBoxFirstName.Text.Trim();
            emp.LastName = textBoxLastName.Text.Trim();
            emp.JobTitle = textBoxJobTitle.Text.Trim();
            emp.SaveEmployee(emp);
            MessageBox.Show("Employee record has been saved successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }