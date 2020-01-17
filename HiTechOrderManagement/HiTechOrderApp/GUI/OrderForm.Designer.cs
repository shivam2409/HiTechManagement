namespace HiTechOrderApp.GUI
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxCreditLimit = new System.Windows.Forms.TextBox();
            this.textBoxCustomerlName = new System.Windows.Forms.TextBox();
            this.textBoxCPhoneNumber = new System.Windows.Forms.TextBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnCancleOrder = new System.Windows.Forms.Button();
            this.listViewOrder = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearchOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCreditLimit
            // 
            this.textBoxCreditLimit.Location = new System.Drawing.Point(117, 63);
            this.textBoxCreditLimit.Name = "textBoxCreditLimit";
            this.textBoxCreditLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreditLimit.TabIndex = 87;
            // 
            // textBoxCustomerlName
            // 
            this.textBoxCustomerlName.Location = new System.Drawing.Point(117, 37);
            this.textBoxCustomerlName.Name = "textBoxCustomerlName";
            this.textBoxCustomerlName.Size = new System.Drawing.Size(100, 20);
            this.textBoxCustomerlName.TabIndex = 86;
            // 
            // textBoxCPhoneNumber
            // 
            this.textBoxCPhoneNumber.Location = new System.Drawing.Point(117, 89);
            this.textBoxCPhoneNumber.Name = "textBoxCPhoneNumber";
            this.textBoxCPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxCPhoneNumber.TabIndex = 83;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(274, 124);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 13);
            this.labelMessage.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 90;
            this.label4.Text = "Fax";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "Phone";
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.Location = new System.Drawing.Point(277, 78);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(105, 34);
            this.btnUpdateOrder.TabIndex = 93;
            this.btnUpdateOrder.Text = "&Update";
            this.btnUpdateOrder.UseVisualStyleBackColor = true;
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(277, 33);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(105, 34);
            this.btnAddOrder.TabIndex = 92;
            this.btnAddOrder.Text = "&Add";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            // 
            // btnCancleOrder
            // 
            this.btnCancleOrder.Location = new System.Drawing.Point(277, 118);
            this.btnCancleOrder.Name = "btnCancleOrder";
            this.btnCancleOrder.Size = new System.Drawing.Size(105, 34);
            this.btnCancleOrder.TabIndex = 94;
            this.btnCancleOrder.Text = "&Delete";
            this.btnCancleOrder.UseVisualStyleBackColor = true;
            // 
            // listViewOrder
            // 
            this.listViewOrder.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.listViewOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewOrder.GridLines = true;
            this.listViewOrder.HideSelection = false;
            this.listViewOrder.Location = new System.Drawing.Point(54, 193);
            this.listViewOrder.Name = "listViewOrder";
            this.listViewOrder.Size = new System.Drawing.Size(200, 150);
            this.listViewOrder.TabIndex = 95;
            this.listViewOrder.UseCompatibleStateImageBehavior = false;
            this.listViewOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Order ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Customer ID";
            this.columnHeader2.Width = 100;
            // 
            // btnSearchOrder
            // 
            this.btnSearchOrder.Location = new System.Drawing.Point(277, 158);
            this.btnSearchOrder.Name = "btnSearchOrder";
            this.btnSearchOrder.Size = new System.Drawing.Size(105, 34);
            this.btnSearchOrder.TabIndex = 96;
            this.btnSearchOrder.Text = "&Search";
            this.btnSearchOrder.UseVisualStyleBackColor = true;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearchOrder);
            this.Controls.Add(this.listViewOrder);
            this.Controls.Add(this.btnCancleOrder);
            this.Controls.Add(this.btnUpdateOrder);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCreditLimit);
            this.Controls.Add(this.textBoxCustomerlName);
            this.Controls.Add(this.textBoxCPhoneNumber);
            this.Controls.Add(this.labelMessage);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxCreditLimit;
        private System.Windows.Forms.TextBox textBoxCustomerlName;
        private System.Windows.Forms.TextBox textBoxCPhoneNumber;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnCancleOrder;
        private System.Windows.Forms.ListView listViewOrder;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnSearchOrder;
    }
}