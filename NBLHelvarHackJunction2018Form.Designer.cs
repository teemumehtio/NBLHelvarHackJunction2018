namespace NBLHelvarHackJunction2018
{
    partial class NBLHelvarHackJunction2018Form
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
            this.buttonGetDevices = new System.Windows.Forms.Button();
            this.labelInput = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonGetOccupancy = new System.Windows.Forms.Button();
            this.buttonGetHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGetDevices
            // 
            this.buttonGetDevices.Location = new System.Drawing.Point(12, 95);
            this.buttonGetDevices.Name = "buttonGetDevices";
            this.buttonGetDevices.Size = new System.Drawing.Size(75, 23);
            this.buttonGetDevices.TabIndex = 0;
            this.buttonGetDevices.Text = "Devices";
            this.buttonGetDevices.UseVisualStyleBackColor = true;
            this.buttonGetDevices.Click += new System.EventHandler(this.buttonGetDevices_Click);
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(12, 9);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(31, 13);
            this.labelInput.TabIndex = 1;
            this.labelInput.Text = "Input";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(12, 137);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(776, 301);
            this.textBoxOutput.TabIndex = 2;
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(12, 121);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(39, 13);
            this.labelOutput.TabIndex = 3;
            this.labelOutput.Text = "Output";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInput.Location = new System.Drawing.Point(12, 25);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(776, 64);
            this.textBoxInput.TabIndex = 4;
            // 
            // buttonGetOccupancy
            // 
            this.buttonGetOccupancy.Location = new System.Drawing.Point(93, 95);
            this.buttonGetOccupancy.Name = "buttonGetOccupancy";
            this.buttonGetOccupancy.Size = new System.Drawing.Size(75, 23);
            this.buttonGetOccupancy.TabIndex = 5;
            this.buttonGetOccupancy.Text = "Occupancy";
            this.buttonGetOccupancy.UseVisualStyleBackColor = true;
            this.buttonGetOccupancy.Click += new System.EventHandler(this.buttonGetOccupancy_Click);
            // 
            // buttonGetHistory
            // 
            this.buttonGetHistory.Location = new System.Drawing.Point(174, 95);
            this.buttonGetHistory.Name = "buttonGetHistory";
            this.buttonGetHistory.Size = new System.Drawing.Size(75, 23);
            this.buttonGetHistory.TabIndex = 6;
            this.buttonGetHistory.Text = "History";
            this.buttonGetHistory.UseVisualStyleBackColor = true;
            this.buttonGetHistory.Click += new System.EventHandler(this.buttonGetHistory_Click);
            // 
            // NBLHelvarHackJunction2018Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonGetHistory);
            this.Controls.Add(this.buttonGetOccupancy);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.buttonGetDevices);
            this.Name = "NBLHelvarHackJunction2018Form";
            this.Text = "NBL Helvar Hack Junction 2018";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetDevices;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonGetOccupancy;
        private System.Windows.Forms.Button buttonGetHistory;
    }
}

