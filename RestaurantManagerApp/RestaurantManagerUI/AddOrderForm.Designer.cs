namespace RestaurantManagerUI
{
    partial class AddOrderForm
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.createOrderButton = new System.Windows.Forms.Button();
            this.removeMenuItemButton = new System.Windows.Forms.Button();
            this.menuItemsListBox = new System.Windows.Forms.ListBox();
            this.menuItemsDropDown = new System.Windows.Forms.ComboBox();
            this.selectMenuItemsLabel = new System.Windows.Forms.Label();
            this.addMenuItemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.headerLabel.Location = new System.Drawing.Point(22, 19);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(224, 50);
            this.headerLabel.TabIndex = 15;
            this.headerLabel.Text = "Create Order";
            // 
            // createOrderButton
            // 
            this.createOrderButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createOrderButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.createOrderButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.createOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createOrderButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createOrderButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.createOrderButton.Location = new System.Drawing.Point(31, 627);
            this.createOrderButton.Name = "createOrderButton";
            this.createOrderButton.Size = new System.Drawing.Size(197, 50);
            this.createOrderButton.TabIndex = 25;
            this.createOrderButton.Text = "Create Order";
            this.createOrderButton.UseVisualStyleBackColor = true;
            this.createOrderButton.Click += new System.EventHandler(this.createOrderButton_Click);
            // 
            // removeMenuItemButton
            // 
            this.removeMenuItemButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.removeMenuItemButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.removeMenuItemButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.removeMenuItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeMenuItemButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeMenuItemButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.removeMenuItemButton.Location = new System.Drawing.Point(31, 505);
            this.removeMenuItemButton.Name = "removeMenuItemButton";
            this.removeMenuItemButton.Size = new System.Drawing.Size(197, 50);
            this.removeMenuItemButton.TabIndex = 24;
            this.removeMenuItemButton.Text = "Remove Selected";
            this.removeMenuItemButton.UseVisualStyleBackColor = true;
            this.removeMenuItemButton.Click += new System.EventHandler(this.removeMenuItemButton_Click);
            // 
            // menuItemsListBox
            // 
            this.menuItemsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuItemsListBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuItemsListBox.FormattingEnabled = true;
            this.menuItemsListBox.ItemHeight = 30;
            this.menuItemsListBox.Location = new System.Drawing.Point(31, 297);
            this.menuItemsListBox.Name = "menuItemsListBox";
            this.menuItemsListBox.Size = new System.Drawing.Size(446, 182);
            this.menuItemsListBox.TabIndex = 23;
            // 
            // menuItemsDropDown
            // 
            this.menuItemsDropDown.FormattingEnabled = true;
            this.menuItemsDropDown.Location = new System.Drawing.Point(31, 162);
            this.menuItemsDropDown.Name = "menuItemsDropDown";
            this.menuItemsDropDown.Size = new System.Drawing.Size(446, 45);
            this.menuItemsDropDown.TabIndex = 22;
            // 
            // selectMenuItemsLabel
            // 
            this.selectMenuItemsLabel.AutoSize = true;
            this.selectMenuItemsLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectMenuItemsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.selectMenuItemsLabel.Location = new System.Drawing.Point(24, 101);
            this.selectMenuItemsLabel.Name = "selectMenuItemsLabel";
            this.selectMenuItemsLabel.Size = new System.Drawing.Size(233, 37);
            this.selectMenuItemsLabel.TabIndex = 21;
            this.selectMenuItemsLabel.Text = "Select Menu Items";
            // 
            // addMenuItemButton
            // 
            this.addMenuItemButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.addMenuItemButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.addMenuItemButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.addMenuItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addMenuItemButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMenuItemButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.addMenuItemButton.Location = new System.Drawing.Point(31, 226);
            this.addMenuItemButton.Name = "addMenuItemButton";
            this.addMenuItemButton.Size = new System.Drawing.Size(197, 50);
            this.addMenuItemButton.TabIndex = 26;
            this.addMenuItemButton.Text = "Add Selected";
            this.addMenuItemButton.UseVisualStyleBackColor = true;
            this.addMenuItemButton.Click += new System.EventHandler(this.addMenuItemButton_Click);
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 716);
            this.Controls.Add(this.addMenuItemButton);
            this.Controls.Add(this.createOrderButton);
            this.Controls.Add(this.removeMenuItemButton);
            this.Controls.Add(this.menuItemsListBox);
            this.Controls.Add(this.menuItemsDropDown);
            this.Controls.Add(this.selectMenuItemsLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "AddOrderForm";
            this.Text = "Create Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button createOrderButton;
        private System.Windows.Forms.Button removeMenuItemButton;
        private System.Windows.Forms.ListBox menuItemsListBox;
        private System.Windows.Forms.ComboBox menuItemsDropDown;
        private System.Windows.Forms.Label selectMenuItemsLabel;
        private System.Windows.Forms.Button addMenuItemButton;
    }
}