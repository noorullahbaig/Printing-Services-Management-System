﻿namespace OopFinalProject
{
    partial class CustomerProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerProfile));
            this.panel2 = new System.Windows.Forms.Panel();
            this.MinBtn = new System.Windows.Forms.PictureBox();
            this.CrossBtn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DashBtn = new System.Windows.Forms.Button();
            this.ProfileBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SignOutBtn = new System.Windows.Forms.PictureBox();
            this.ReqStatusBtn = new System.Windows.Forms.Button();
            this.NewReqBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.customer_password = new System.Windows.Forms.TextBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.customer_number = new System.Windows.Forms.TextBox();
            this.customer_fullname = new System.Windows.Forms.TextBox();
            this.user_password = new System.Windows.Forms.TextBox();
            this.customer_username = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CrossBtn)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SignOutBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel2.Controls.Add(this.MinBtn);
            this.panel2.Controls.Add(this.CrossBtn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1346, 50);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // MinBtn
            // 
            this.MinBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinBtn.Image = ((System.Drawing.Image)(resources.GetObject("MinBtn.Image")));
            this.MinBtn.Location = new System.Drawing.Point(1282, 0);
            this.MinBtn.Name = "MinBtn";
            this.MinBtn.Size = new System.Drawing.Size(29, 30);
            this.MinBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MinBtn.TabIndex = 5;
            this.MinBtn.TabStop = false;
            this.MinBtn.Click += new System.EventHandler(this.MinBtn_Click);
            // 
            // CrossBtn
            // 
            this.CrossBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CrossBtn.Image = ((System.Drawing.Image)(resources.GetObject("CrossBtn.Image")));
            this.CrossBtn.Location = new System.Drawing.Point(1317, 0);
            this.CrossBtn.Name = "CrossBtn";
            this.CrossBtn.Size = new System.Drawing.Size(26, 28);
            this.CrossBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CrossBtn.TabIndex = 4;
            this.CrossBtn.TabStop = false;
            this.CrossBtn.Click += new System.EventHandler(this.CrossBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "APU Printing Services Management System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.DashBtn);
            this.panel1.Controls.Add(this.ProfileBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.SignOutBtn);
            this.panel1.Controls.Add(this.ReqStatusBtn);
            this.panel1.Controls.Add(this.NewReqBtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 761);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // DashBtn
            // 
            this.DashBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.DashBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DashBtn.FlatAppearance.BorderSize = 2;
            this.DashBtn.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashBtn.ForeColor = System.Drawing.Color.White;
            this.DashBtn.Image = ((System.Drawing.Image)(resources.GetObject("DashBtn.Image")));
            this.DashBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashBtn.Location = new System.Drawing.Point(27, 315);
            this.DashBtn.Name = "DashBtn";
            this.DashBtn.Size = new System.Drawing.Size(225, 71);
            this.DashBtn.TabIndex = 11;
            this.DashBtn.Text = "DashBoard";
            this.DashBtn.UseVisualStyleBackColor = false;
            this.DashBtn.Click += new System.EventHandler(this.DashBtn_Click);
            // 
            // ProfileBtn
            // 
            this.ProfileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ProfileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProfileBtn.FlatAppearance.BorderSize = 2;
            this.ProfileBtn.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileBtn.ForeColor = System.Drawing.Color.White;
            this.ProfileBtn.Image = ((System.Drawing.Image)(resources.GetObject("ProfileBtn.Image")));
            this.ProfileBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProfileBtn.Location = new System.Drawing.Point(27, 580);
            this.ProfileBtn.Name = "ProfileBtn";
            this.ProfileBtn.Size = new System.Drawing.Size(225, 71);
            this.ProfileBtn.TabIndex = 10;
            this.ProfileBtn.Text = "Profile";
            this.ProfileBtn.UseVisualStyleBackColor = false;
            this.ProfileBtn.Click += new System.EventHandler(this.ProfileBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(74, 712);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sign Out";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // SignOutBtn
            // 
            this.SignOutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignOutBtn.Image = ((System.Drawing.Image)(resources.GetObject("SignOutBtn.Image")));
            this.SignOutBtn.Location = new System.Drawing.Point(12, 699);
            this.SignOutBtn.Name = "SignOutBtn";
            this.SignOutBtn.Size = new System.Drawing.Size(56, 50);
            this.SignOutBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SignOutBtn.TabIndex = 9;
            this.SignOutBtn.TabStop = false;
            this.SignOutBtn.Click += new System.EventHandler(this.SignOutBtn_Click);
            // 
            // ReqStatusBtn
            // 
            this.ReqStatusBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ReqStatusBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReqStatusBtn.FlatAppearance.BorderSize = 2;
            this.ReqStatusBtn.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReqStatusBtn.ForeColor = System.Drawing.Color.White;
            this.ReqStatusBtn.Image = ((System.Drawing.Image)(resources.GetObject("ReqStatusBtn.Image")));
            this.ReqStatusBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReqStatusBtn.Location = new System.Drawing.Point(27, 494);
            this.ReqStatusBtn.Name = "ReqStatusBtn";
            this.ReqStatusBtn.Size = new System.Drawing.Size(225, 71);
            this.ReqStatusBtn.TabIndex = 8;
            this.ReqStatusBtn.Text = "Request Status";
            this.ReqStatusBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ReqStatusBtn.UseVisualStyleBackColor = false;
            this.ReqStatusBtn.Click += new System.EventHandler(this.ReqStatusBtn_Click);
            // 
            // NewReqBtn
            // 
            this.NewReqBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.NewReqBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewReqBtn.FlatAppearance.BorderSize = 2;
            this.NewReqBtn.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewReqBtn.ForeColor = System.Drawing.Color.White;
            this.NewReqBtn.Image = ((System.Drawing.Image)(resources.GetObject("NewReqBtn.Image")));
            this.NewReqBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewReqBtn.Location = new System.Drawing.Point(27, 403);
            this.NewReqBtn.Name = "NewReqBtn";
            this.NewReqBtn.Size = new System.Drawing.Size(225, 71);
            this.NewReqBtn.TabIndex = 7;
            this.NewReqBtn.Text = "New Request";
            this.NewReqBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NewReqBtn.UseVisualStyleBackColor = false;
            this.NewReqBtn.Click += new System.EventHandler(this.NewReqBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 231);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(302, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1021, 334);
            this.panel3.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1001, 288);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Profile Data";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.RefreshBtn);
            this.panel4.Controls.Add(this.customer_password);
            this.panel4.Controls.Add(this.ClearBtn);
            this.panel4.Controls.Add(this.UpdateBtn);
            this.panel4.Controls.Add(this.customer_number);
            this.panel4.Controls.Add(this.customer_fullname);
            this.panel4.Controls.Add(this.user_password);
            this.panel4.Controls.Add(this.customer_username);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(302, 421);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1021, 369);
            this.panel4.TabIndex = 12;
            // 
            // customer_password
            // 
            this.customer_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customer_password.Location = new System.Drawing.Point(121, 146);
            this.customer_password.Name = "customer_password";
            this.customer_password.Size = new System.Drawing.Size(259, 22);
            this.customer_password.TabIndex = 28;
            this.customer_password.TextChanged += new System.EventHandler(this.customer_password_TextChanged);
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearBtn.FlatAppearance.BorderSize = 0;
            this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBtn.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.White;
            this.ClearBtn.Location = new System.Drawing.Point(606, 270);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(129, 62);
            this.ClearBtn.TabIndex = 27;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.UpdateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateBtn.FlatAppearance.BorderSize = 0;
            this.UpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateBtn.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBtn.ForeColor = System.Drawing.Color.White;
            this.UpdateBtn.Location = new System.Drawing.Point(311, 270);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(129, 62);
            this.UpdateBtn.TabIndex = 25;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = false;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // customer_number
            // 
            this.customer_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customer_number.Location = new System.Drawing.Point(709, 33);
            this.customer_number.Name = "customer_number";
            this.customer_number.Size = new System.Drawing.Size(259, 22);
            this.customer_number.TabIndex = 23;
            this.customer_number.TextChanged += new System.EventHandler(this.customer_number_TextChanged);
            // 
            // customer_fullname
            // 
            this.customer_fullname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customer_fullname.Location = new System.Drawing.Point(709, 147);
            this.customer_fullname.Name = "customer_fullname";
            this.customer_fullname.Size = new System.Drawing.Size(259, 22);
            this.customer_fullname.TabIndex = 22;
            this.customer_fullname.TextChanged += new System.EventHandler(this.customer_fullname_TextChanged);
            // 
            // user_password
            // 
            this.user_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.user_password.Location = new System.Drawing.Point(121, 147);
            this.user_password.Name = "user_password";
            this.user_password.Size = new System.Drawing.Size(0, 22);
            this.user_password.TabIndex = 21;
            // 
            // customer_username
            // 
            this.customer_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customer_username.Location = new System.Drawing.Point(121, 31);
            this.customer_username.Name = "customer_username";
            this.customer_username.Size = new System.Drawing.Size(259, 22);
            this.customer_username.TabIndex = 20;
            this.customer_username.TextChanged += new System.EventHandler(this.customer_username_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(563, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 23);
            this.label11.TabIndex = 18;
            this.label11.Text = "Phone Number :";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(563, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 23);
            this.label10.TabIndex = 17;
            this.label10.Text = "Full Name :";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(18, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Password :";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(18, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Username :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.RefreshBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshBtn.FlatAppearance.BorderSize = 0;
            this.RefreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshBtn.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshBtn.ForeColor = System.Drawing.Color.White;
            this.RefreshBtn.Location = new System.Drawing.Point(460, 270);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(129, 62);
            this.RefreshBtn.TabIndex = 29;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = false;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // CustomerProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1346, 811);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerProfile";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CrossBtn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SignOutBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox MinBtn;
        private System.Windows.Forms.PictureBox CrossBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DashBtn;
        private System.Windows.Forms.Button ProfileBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox SignOutBtn;
        private System.Windows.Forms.Button ReqStatusBtn;
        private System.Windows.Forms.Button NewReqBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.TextBox customer_number;
        private System.Windows.Forms.TextBox customer_fullname;
        private System.Windows.Forms.TextBox user_password;
        private System.Windows.Forms.TextBox customer_username;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox customer_password;
        private System.Windows.Forms.Button RefreshBtn;
    }
}