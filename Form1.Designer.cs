
namespace Counter_v1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bt_count = new System.Windows.Forms.Button();
            this.tB_in = new System.Windows.Forms.TextBox();
            this.tB_out = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cB_report = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_folder = new System.Windows.Forms.Button();
            this.tB_path = new System.Windows.Forms.TextBox();
            this.lb_path = new System.Windows.Forms.Label();
            this.bt_load = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tB_currentPath = new System.Windows.Forms.TextBox();
            this.bt_print = new System.Windows.Forms.Button();
            this.bt_plan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_count
            // 
            this.bt_count.Location = new System.Drawing.Point(12, 702);
            this.bt_count.Name = "bt_count";
            this.bt_count.Size = new System.Drawing.Size(65, 23);
            this.bt_count.TabIndex = 0;
            this.bt_count.Text = "Count";
            this.bt_count.UseVisualStyleBackColor = true;
            this.bt_count.Click += new System.EventHandler(this.bt_count_Click);
            // 
            // tB_in
            // 
            this.tB_in.Location = new System.Drawing.Point(51, 23);
            this.tB_in.Name = "tB_in";
            this.tB_in.Size = new System.Drawing.Size(255, 20);
            this.tB_in.TabIndex = 1;
            // 
            // tB_out
            // 
            this.tB_out.Location = new System.Drawing.Point(12, 117);
            this.tB_out.Multiline = true;
            this.tB_out.Name = "tB_out";
            this.tB_out.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_out.Size = new System.Drawing.Size(294, 578);
            this.tB_out.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(51, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 20);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cB_report
            // 
            this.cB_report.AutoSize = true;
            this.cB_report.Location = new System.Drawing.Point(228, 5);
            this.cB_report.Name = "cB_report";
            this.cB_report.Size = new System.Drawing.Size(58, 17);
            this.cB_report.TabIndex = 4;
            this.cB_report.Text = "Report";
            this.cB_report.UseVisualStyleBackColor = true;
            this.cB_report.CheckedChanged += new System.EventHandler(this.cB_report_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "PCB:";
            // 
            // bt_folder
            // 
            this.bt_folder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_folder.BackgroundImage")));
            this.bt_folder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_folder.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_folder.Location = new System.Drawing.Point(197, 3);
            this.bt_folder.Name = "bt_folder";
            this.bt_folder.Size = new System.Drawing.Size(25, 19);
            this.bt_folder.TabIndex = 6;
            this.bt_folder.UseVisualStyleBackColor = true;
            this.bt_folder.Click += new System.EventHandler(this.bt_folder_Click);
            // 
            // tB_path
            // 
            this.tB_path.Enabled = false;
            this.tB_path.Location = new System.Drawing.Point(83, 49);
            this.tB_path.Name = "tB_path";
            this.tB_path.Size = new System.Drawing.Size(223, 20);
            this.tB_path.TabIndex = 1;
            // 
            // lb_path
            // 
            this.lb_path.AutoSize = true;
            this.lb_path.Location = new System.Drawing.Point(12, 82);
            this.lb_path.Name = "lb_path";
            this.lb_path.Size = new System.Drawing.Size(51, 13);
            this.lb_path.TabIndex = 5;
            this.lb_path.Text = "File Path:";
            // 
            // bt_load
            // 
            this.bt_load.Location = new System.Drawing.Point(83, 701);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(81, 25);
            this.bt_load.TabIndex = 7;
            this.bt_load.Text = "Load_data";
            this.bt_load.UseVisualStyleBackColor = true;
            this.bt_load.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Report Path:";
            // 
            // tB_currentPath
            // 
            this.tB_currentPath.Enabled = false;
            this.tB_currentPath.Location = new System.Drawing.Point(83, 75);
            this.tB_currentPath.Name = "tB_currentPath";
            this.tB_currentPath.Size = new System.Drawing.Size(223, 20);
            this.tB_currentPath.TabIndex = 1;
            // 
            // bt_print
            // 
            this.bt_print.Location = new System.Drawing.Point(170, 702);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(64, 23);
            this.bt_print.TabIndex = 8;
            this.bt_print.Text = "Print";
            this.bt_print.UseVisualStyleBackColor = true;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // bt_plan
            // 
            this.bt_plan.Location = new System.Drawing.Point(242, 703);
            this.bt_plan.Name = "bt_plan";
            this.bt_plan.Size = new System.Drawing.Size(64, 23);
            this.bt_plan.TabIndex = 8;
            this.bt_plan.Text = "Plan";
            this.bt_plan.UseVisualStyleBackColor = true;
            this.bt_plan.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 737);
            this.Controls.Add(this.bt_plan);
            this.Controls.Add(this.bt_print);
            this.Controls.Add(this.bt_load);
            this.Controls.Add(this.bt_folder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cB_report);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tB_currentPath);
            this.Controls.Add(this.tB_path);
            this.Controls.Add(this.tB_out);
            this.Controls.Add(this.tB_in);
            this.Controls.Add(this.bt_count);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Counter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_count;
        private System.Windows.Forms.TextBox tB_in;
        private System.Windows.Forms.TextBox tB_out;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox cB_report;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_folder;
        private System.Windows.Forms.TextBox tB_path;
        private System.Windows.Forms.Label lb_path;
        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tB_currentPath;
        private System.Windows.Forms.Button bt_print;
        private System.Windows.Forms.Button bt_plan;
    }
}

