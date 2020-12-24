namespace RestaurantManagerUI
{
    partial class AddProductForm
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
            this.productNameLabel = new System.Windows.Forms.Label();
            this.productNameValue = new System.Windows.Forms.TextBox();
            this.portionCountValue = new System.Windows.Forms.TextBox();
            this.portionCountLabel = new System.Windows.Forms.Label();
            this.unitValue = new System.Windows.Forms.TextBox();
            this.unitLabel = new System.Windows.Forms.Label();
            this.portionSizeValue = new System.Windows.Forms.TextBox();
            this.portionSizeLabel = new System.Windows.Forms.Label();
            this.addProductButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.headerLabel.Location = new System.Drawing.Point(28, 28);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(431, 50);
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "Add New Product to Stock";
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.productNameLabel.Location = new System.Drawing.Point(30, 120);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(187, 37);
            this.productNameLabel.TabIndex = 4;
            this.productNameLabel.Text = "Product Name";
            // 
            // productNameValue
            // 
            this.productNameValue.Location = new System.Drawing.Point(230, 120);
            this.productNameValue.Name = "productNameValue";
            this.productNameValue.Size = new System.Drawing.Size(217, 43);
            this.productNameValue.TabIndex = 5;
            // 
            // portionCountValue
            // 
            this.portionCountValue.Location = new System.Drawing.Point(370, 192);
            this.portionCountValue.Name = "portionCountValue";
            this.portionCountValue.Size = new System.Drawing.Size(77, 43);
            this.portionCountValue.TabIndex = 7;
            this.portionCountValue.Text = "0";
            // 
            // portionCountLabel
            // 
            this.portionCountLabel.AutoSize = true;
            this.portionCountLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portionCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.portionCountLabel.Location = new System.Drawing.Point(30, 192);
            this.portionCountLabel.Name = "portionCountLabel";
            this.portionCountLabel.Size = new System.Drawing.Size(182, 37);
            this.portionCountLabel.TabIndex = 6;
            this.portionCountLabel.Text = "Portion Count";
            // 
            // unitValue
            // 
            this.unitValue.Location = new System.Drawing.Point(315, 264);
            this.unitValue.Name = "unitValue";
            this.unitValue.Size = new System.Drawing.Size(132, 43);
            this.unitValue.TabIndex = 9;
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.unitLabel.Location = new System.Drawing.Point(30, 264);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(166, 37);
            this.unitLabel.TabIndex = 8;
            this.unitLabel.Text = "Product Unit";
            // 
            // portionSizeValue
            // 
            this.portionSizeValue.Location = new System.Drawing.Point(370, 332);
            this.portionSizeValue.Name = "portionSizeValue";
            this.portionSizeValue.Size = new System.Drawing.Size(77, 43);
            this.portionSizeValue.TabIndex = 11;
            this.portionSizeValue.Text = "0";
            // 
            // portionSizeLabel
            // 
            this.portionSizeLabel.AutoSize = true;
            this.portionSizeLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portionSizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.portionSizeLabel.Location = new System.Drawing.Point(30, 332);
            this.portionSizeLabel.Name = "portionSizeLabel";
            this.portionSizeLabel.Size = new System.Drawing.Size(157, 37);
            this.portionSizeLabel.TabIndex = 10;
            this.portionSizeLabel.Text = "Portion Size";
            // 
            // addProductButton
            // 
            this.addProductButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.addProductButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.addProductButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.addProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProductButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProductButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.addProductButton.Location = new System.Drawing.Point(37, 443);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(197, 50);
            this.addProductButton.TabIndex = 12;
            this.addProductButton.Text = "Add Product";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(514, 548);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.portionSizeValue);
            this.Controls.Add(this.portionSizeLabel);
            this.Controls.Add(this.unitValue);
            this.Controls.Add(this.unitLabel);
            this.Controls.Add(this.portionCountValue);
            this.Controls.Add(this.portionCountLabel);
            this.Controls.Add(this.productNameValue);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "AddProductForm";
            this.Text = "Add Product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.TextBox productNameValue;
        private System.Windows.Forms.TextBox portionCountValue;
        private System.Windows.Forms.Label portionCountLabel;
        private System.Windows.Forms.TextBox unitValue;
        private System.Windows.Forms.Label unitLabel;
        private System.Windows.Forms.TextBox portionSizeValue;
        private System.Windows.Forms.Label portionSizeLabel;
        private System.Windows.Forms.Button addProductButton;
    }
}