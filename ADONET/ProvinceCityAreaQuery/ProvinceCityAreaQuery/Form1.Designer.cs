namespace ProvinceCityAreaQuery
{
    partial class Form1
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
            this.cmbProvince = new System.Windows.Forms.ComboBox();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.labProvince = new System.Windows.Forms.Label();
            this.labCity = new System.Windows.Forms.Label();
            this.labArea = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbProvince
            // 
            this.cmbProvince.DisplayMember = "provinceName";
            this.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.Location = new System.Drawing.Point(84, 72);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(121, 20);
            this.cmbProvince.TabIndex = 0;
            this.cmbProvince.SelectedIndexChanged += new System.EventHandler(this.cmbProvince_SelectedIndexChanged);
            // 
            // cmbCity
            // 
            this.cmbCity.DisplayMember = "cityName";
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(272, 72);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(121, 20);
            this.cmbCity.TabIndex = 1;
            this.cmbCity.SelectedIndexChanged += new System.EventHandler(this.cmbCity_SelectedIndexChanged);
            // 
            // cmbArea
            // 
            this.cmbArea.DisplayMember = "areaName";
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(462, 72);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(121, 20);
            this.cmbArea.TabIndex = 2;
            // 
            // labProvince
            // 
            this.labProvince.AutoSize = true;
            this.labProvince.Location = new System.Drawing.Point(25, 75);
            this.labProvince.Name = "labProvince";
            this.labProvince.Size = new System.Drawing.Size(53, 12);
            this.labProvince.TabIndex = 3;
            this.labProvince.Text = "Province";
            // 
            // labCity
            // 
            this.labCity.AutoSize = true;
            this.labCity.Location = new System.Drawing.Point(237, 75);
            this.labCity.Name = "labCity";
            this.labCity.Size = new System.Drawing.Size(29, 12);
            this.labCity.TabIndex = 4;
            this.labCity.Text = "City";
            // 
            // labArea
            // 
            this.labArea.AutoSize = true;
            this.labArea.Location = new System.Drawing.Point(427, 75);
            this.labArea.Name = "labArea";
            this.labArea.Size = new System.Drawing.Size(29, 12);
            this.labArea.TabIndex = 5;
            this.labArea.Text = "Area";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 198);
            this.Controls.Add(this.labArea);
            this.Controls.Add(this.labCity);
            this.Controls.Add(this.labProvince);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.cmbProvince);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProvince;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label labProvince;
        private System.Windows.Forms.Label labCity;
        private System.Windows.Forms.Label labArea;
    }
}

