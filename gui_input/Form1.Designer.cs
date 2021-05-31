
namespace Memory_Managment
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbMem_Size = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNo_holes = new System.Windows.Forms.TextBox();
            this.tbNo_processes = new System.Windows.Forms.TextBox();
            this.Sub_initial = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Memory Size";
            // 
            // tbMem_Size
            // 
            this.tbMem_Size.Location = new System.Drawing.Point(315, 44);
            this.tbMem_Size.Name = "tbMem_Size";
            this.tbMem_Size.Size = new System.Drawing.Size(100, 20);
            this.tbMem_Size.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of holes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Number of processes";
            // 
            // tbNo_holes
            // 
            this.tbNo_holes.Location = new System.Drawing.Point(315, 90);
            this.tbNo_holes.Name = "tbNo_holes";
            this.tbNo_holes.Size = new System.Drawing.Size(100, 20);
            this.tbNo_holes.TabIndex = 4;
            // 
            // tbNo_processes
            // 
            this.tbNo_processes.Location = new System.Drawing.Point(315, 141);
            this.tbNo_processes.Name = "tbNo_processes";
            this.tbNo_processes.Size = new System.Drawing.Size(100, 20);
            this.tbNo_processes.TabIndex = 5;
            // 
            // Sub_initial
            // 
            this.Sub_initial.Location = new System.Drawing.Point(223, 259);
            this.Sub_initial.Name = "Sub_initial";
            this.Sub_initial.Size = new System.Drawing.Size(187, 23);
            this.Sub_initial.TabIndex = 6;
            this.Sub_initial.Text = "Submit";
            this.Sub_initial.UseVisualStyleBackColor = true;
            this.Sub_initial.Click += new System.EventHandler(this.Sub_initial_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(315, 185);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Allocation method";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 308);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Sub_initial);
            this.Controls.Add(this.tbNo_processes);
            this.Controls.Add(this.tbNo_holes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMem_Size);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMem_Size;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNo_holes;
        private System.Windows.Forms.TextBox tbNo_processes;
        private System.Windows.Forms.Button Sub_initial;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}

