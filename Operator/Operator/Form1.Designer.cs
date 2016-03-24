namespace Operator
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
            this.txtOp1 = new System.Windows.Forms.TextBox();
            this.cbOp = new System.Windows.Forms.ComboBox();
            this.txtOp2 = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnEqual = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOp1
            // 
            this.txtOp1.Location = new System.Drawing.Point(23, 25);
            this.txtOp1.Name = "txtOp1";
            this.txtOp1.Size = new System.Drawing.Size(58, 21);
            this.txtOp1.TabIndex = 0;
            // 
            // cbOp
            // 
            this.cbOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOp.FormattingEnabled = true;
            this.cbOp.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.cbOp.Location = new System.Drawing.Point(108, 25);
            this.cbOp.Name = "cbOp";
            this.cbOp.Size = new System.Drawing.Size(44, 20);
            this.cbOp.TabIndex = 1;
            // 
            // txtOp2
            // 
            this.txtOp2.Location = new System.Drawing.Point(174, 24);
            this.txtOp2.Name = "txtOp2";
            this.txtOp2.Size = new System.Drawing.Size(62, 21);
            this.txtOp2.TabIndex = 2;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(136, 62);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 21);
            this.txtResult.TabIndex = 3;
            // 
            // btnEqual
            // 
            this.btnEqual.Location = new System.Drawing.Point(23, 62);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(75, 23);
            this.btnEqual.TabIndex = 4;
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = true;
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtOp2);
            this.Controls.Add(this.cbOp);
            this.Controls.Add(this.txtOp1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOp1;
        private System.Windows.Forms.ComboBox cbOp;
        private System.Windows.Forms.TextBox txtOp2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnEqual;
    }
}

