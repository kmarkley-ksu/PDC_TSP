namespace GraphTester
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewData = new System.Windows.Forms.Button();
            this.btnReloadData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startCity = new System.Windows.Forms.ComboBox();
            this.endCity = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
// 
// label1
// 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 135);
            this.label1.TabIndex = 0;
            this.label1.Text = "The graph data resides in the text file data.txt.  On each line is a city name fo" +
                "llowed by a space followed by a city name followed by a space followed by the di" +
                "stance.  If you make changes to this file, click the Reload button to reload the" +
                " data...";
// 
// btnViewData
// 
            this.btnViewData.Location = new System.Drawing.Point(32, 156);
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.Size = new System.Drawing.Size(128, 23);
            this.btnViewData.TabIndex = 1;
            this.btnViewData.Text = "View/Edit Graph Data";
            this.btnViewData.Click += new System.EventHandler(this.btnViewData_Click);
// 
// btnReloadData
// 
            this.btnReloadData.Location = new System.Drawing.Point(178, 156);
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(112, 23);
            this.btnReloadData.TabIndex = 2;
            this.btnReloadData.Text = "Reload Graph Data";
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
// 
// groupBox1
// 
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Controls.Add(this.endCity);
            this.groupBox1.Controls.Add(this.startCity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(32, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 126);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compute Shortest Distance";
// 
// label2
// 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Starting City:";
// 
// label3
// 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ending City:";
// 
// startCity
// 
            this.startCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startCity.FormattingEnabled = true;
            this.startCity.Location = new System.Drawing.Point(83, 15);
            this.startCity.Name = "startCity";
            this.startCity.TabIndex = 2;
// 
// endCity
// 
            this.endCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endCity.FormattingEnabled = true;
            this.endCity.Location = new System.Drawing.Point(83, 51);
            this.endCity.Name = "endCity";
            this.endCity.TabIndex = 3;
// 
// btnGo
// 
            this.btnGo.Location = new System.Drawing.Point(53, 90);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(151, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Compute Shortest Path";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
// 
// Form1
// 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(334, 342);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReloadData);
            this.Controls.Add(this.btnViewData);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewData;
        private System.Windows.Forms.Button btnReloadData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox startCity;
        private System.Windows.Forms.ComboBox endCity;
        private System.Windows.Forms.Button btnGo;

    }
}

