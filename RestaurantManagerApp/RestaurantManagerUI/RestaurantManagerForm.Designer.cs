namespace RestaurantManagerUI
{
    partial class RestaurantManagerForm
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
            this.manageStockButton = new System.Windows.Forms.Button();
            this.manageMenuButton = new System.Windows.Forms.Button();
            this.manageOrdersButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.headerLabel.Location = new System.Drawing.Point(38, 37);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(335, 50);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Restaurant Manager";
            // 
            // manageStockButton
            // 
            this.manageStockButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.manageStockButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.manageStockButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.manageStockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageStockButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageStockButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.manageStockButton.Location = new System.Drawing.Point(107, 192);
            this.manageStockButton.Name = "manageStockButton";
            this.manageStockButton.Size = new System.Drawing.Size(197, 50);
            this.manageStockButton.TabIndex = 1;
            this.manageStockButton.Text = "Manage Stock";
            this.manageStockButton.UseVisualStyleBackColor = true;
            this.manageStockButton.Click += new System.EventHandler(this.manageStockButton_Click);
            // 
            // manageMenuButton
            // 
            this.manageMenuButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.manageMenuButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.manageMenuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.manageMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageMenuButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageMenuButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.manageMenuButton.Location = new System.Drawing.Point(107, 291);
            this.manageMenuButton.Name = "manageMenuButton";
            this.manageMenuButton.Size = new System.Drawing.Size(197, 50);
            this.manageMenuButton.TabIndex = 2;
            this.manageMenuButton.Text = "Manage Menu";
            this.manageMenuButton.UseVisualStyleBackColor = true;
            this.manageMenuButton.Click += new System.EventHandler(this.manageMenuButton_Click);
            // 
            // manageOrdersButton
            // 
            this.manageOrdersButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.manageOrdersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.manageOrdersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.manageOrdersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageOrdersButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageOrdersButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.manageOrdersButton.Location = new System.Drawing.Point(107, 394);
            this.manageOrdersButton.Name = "manageOrdersButton";
            this.manageOrdersButton.Size = new System.Drawing.Size(197, 50);
            this.manageOrdersButton.TabIndex = 3;
            this.manageOrdersButton.Text = "Manage Orders";
            this.manageOrdersButton.UseVisualStyleBackColor = true;
            this.manageOrdersButton.Click += new System.EventHandler(this.manageOrdersButton_Click);
            // 
            // RestaurantManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(441, 542);
            this.Controls.Add(this.manageOrdersButton);
            this.Controls.Add(this.manageMenuButton);
            this.Controls.Add(this.manageStockButton);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "RestaurantManagerForm";
            this.Text = "Restaurant Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button manageStockButton;
        private System.Windows.Forms.Button manageMenuButton;
        private System.Windows.Forms.Button manageOrdersButton;
    }
}

