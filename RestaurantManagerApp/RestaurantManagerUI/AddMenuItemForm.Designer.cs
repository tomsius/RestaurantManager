namespace RestaurantManagerUI
{
    partial class AddMenuItemForm
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
            this.menuItemNameValue = new System.Windows.Forms.TextBox();
            this.menuItemNameLabel = new System.Windows.Forms.Label();
            this.selectIngredientsLabel = new System.Windows.Forms.Label();
            this.ingredientsDropDown = new System.Windows.Forms.ComboBox();
            this.ingredientsListBox = new System.Windows.Forms.ListBox();
            this.removeIngredientButton = new System.Windows.Forms.Button();
            this.createMenuItemButton = new System.Windows.Forms.Button();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.headerLabel.Location = new System.Drawing.Point(28, 27);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(345, 50);
            this.headerLabel.TabIndex = 5;
            this.headerLabel.Text = "Add New Menu Item";
            // 
            // menuItemNameValue
            // 
            this.menuItemNameValue.Location = new System.Drawing.Point(265, 133);
            this.menuItemNameValue.Name = "menuItemNameValue";
            this.menuItemNameValue.Size = new System.Drawing.Size(217, 43);
            this.menuItemNameValue.TabIndex = 7;
            // 
            // menuItemNameLabel
            // 
            this.menuItemNameLabel.AutoSize = true;
            this.menuItemNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuItemNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.menuItemNameLabel.Location = new System.Drawing.Point(30, 133);
            this.menuItemNameLabel.Name = "menuItemNameLabel";
            this.menuItemNameLabel.Size = new System.Drawing.Size(88, 37);
            this.menuItemNameLabel.TabIndex = 6;
            this.menuItemNameLabel.Text = "Name";
            // 
            // selectIngredientsLabel
            // 
            this.selectIngredientsLabel.AutoSize = true;
            this.selectIngredientsLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectIngredientsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.selectIngredientsLabel.Location = new System.Drawing.Point(30, 213);
            this.selectIngredientsLabel.Name = "selectIngredientsLabel";
            this.selectIngredientsLabel.Size = new System.Drawing.Size(227, 37);
            this.selectIngredientsLabel.TabIndex = 8;
            this.selectIngredientsLabel.Text = "Select Ingredients";
            // 
            // ingredientsDropDown
            // 
            this.ingredientsDropDown.FormattingEnabled = true;
            this.ingredientsDropDown.Location = new System.Drawing.Point(37, 274);
            this.ingredientsDropDown.Name = "ingredientsDropDown";
            this.ingredientsDropDown.Size = new System.Drawing.Size(445, 45);
            this.ingredientsDropDown.TabIndex = 9;
            // 
            // ingredientsListBox
            // 
            this.ingredientsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ingredientsListBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingredientsListBox.FormattingEnabled = true;
            this.ingredientsListBox.ItemHeight = 30;
            this.ingredientsListBox.Location = new System.Drawing.Point(37, 416);
            this.ingredientsListBox.Name = "ingredientsListBox";
            this.ingredientsListBox.Size = new System.Drawing.Size(445, 182);
            this.ingredientsListBox.TabIndex = 10;
            // 
            // removeIngredientButton
            // 
            this.removeIngredientButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.removeIngredientButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.removeIngredientButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.removeIngredientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeIngredientButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeIngredientButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.removeIngredientButton.Location = new System.Drawing.Point(37, 616);
            this.removeIngredientButton.Name = "removeIngredientButton";
            this.removeIngredientButton.Size = new System.Drawing.Size(197, 50);
            this.removeIngredientButton.TabIndex = 11;
            this.removeIngredientButton.Text = "Remove Selected";
            this.removeIngredientButton.UseVisualStyleBackColor = true;
            this.removeIngredientButton.Click += new System.EventHandler(this.removeIngredientButton_Click);
            // 
            // createMenuItemButton
            // 
            this.createMenuItemButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createMenuItemButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.createMenuItemButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.createMenuItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createMenuItemButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createMenuItemButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.createMenuItemButton.Location = new System.Drawing.Point(37, 769);
            this.createMenuItemButton.Name = "createMenuItemButton";
            this.createMenuItemButton.Size = new System.Drawing.Size(197, 50);
            this.createMenuItemButton.TabIndex = 12;
            this.createMenuItemButton.Text = "Create Menu Item";
            this.createMenuItemButton.UseVisualStyleBackColor = true;
            this.createMenuItemButton.Click += new System.EventHandler(this.createMenuItemButton_Click);
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.addIngredientButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.addIngredientButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.addIngredientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addIngredientButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addIngredientButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.addIngredientButton.Location = new System.Drawing.Point(37, 346);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(197, 50);
            this.addIngredientButton.TabIndex = 13;
            this.addIngredientButton.Text = "Add Selected";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // AddMenuItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 865);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.createMenuItemButton);
            this.Controls.Add(this.removeIngredientButton);
            this.Controls.Add(this.ingredientsListBox);
            this.Controls.Add(this.ingredientsDropDown);
            this.Controls.Add(this.selectIngredientsLabel);
            this.Controls.Add(this.menuItemNameValue);
            this.Controls.Add(this.menuItemNameLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "AddMenuItemForm";
            this.Text = "Add Menu Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox menuItemNameValue;
        private System.Windows.Forms.Label menuItemNameLabel;
        private System.Windows.Forms.Label selectIngredientsLabel;
        private System.Windows.Forms.ComboBox ingredientsDropDown;
        private System.Windows.Forms.ListBox ingredientsListBox;
        private System.Windows.Forms.Button removeIngredientButton;
        private System.Windows.Forms.Button createMenuItemButton;
        private System.Windows.Forms.Button addIngredientButton;
    }
}