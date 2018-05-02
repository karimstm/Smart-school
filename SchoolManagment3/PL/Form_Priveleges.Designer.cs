namespace SchoolManagment3.PL
{
    partial class Form_Priveleges
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LbUsers = new System.Windows.Forms.ListBox();
            this.gridUser = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCnacel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            this.SuspendLayout();
            // 
            // LbUsers
            // 
            this.LbUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbUsers.FormattingEnabled = true;
            this.LbUsers.ItemHeight = 24;
            this.LbUsers.Location = new System.Drawing.Point(23, 85);
            this.LbUsers.Name = "LbUsers";
            this.LbUsers.Size = new System.Drawing.Size(187, 316);
            this.LbUsers.TabIndex = 0;
            this.LbUsers.SelectedIndexChanged += new System.EventHandler(this.LbUsers_SelectedIndexChanged);
            // 
            // gridUser
            // 
            this.gridUser.AllowUserToAddRows = false;
            this.gridUser.AllowUserToDeleteRows = false;
            this.gridUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridUser.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridUser.ColumnHeadersHeight = 30;
            this.gridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridUser.EnableHeadersVisualStyles = false;
            this.gridUser.Location = new System.Drawing.Point(216, 85);
            this.gridUser.MultiSelect = false;
            this.gridUser.Name = "gridUser";
            this.gridUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridUser.RowHeadersVisible = false;
            this.gridUser.RowTemplate.Height = 30;
            this.gridUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUser.Size = new System.Drawing.Size(475, 316);
            this.gridUser.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(38, 419);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(140, 36);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "إعطاء الصلاحيات";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCnacel
            // 
            this.btnCnacel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCnacel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCnacel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCnacel.ForeColor = System.Drawing.Color.White;
            this.btnCnacel.Location = new System.Drawing.Point(184, 419);
            this.btnCnacel.Name = "btnCnacel";
            this.btnCnacel.Size = new System.Drawing.Size(104, 36);
            this.btnCnacel.TabIndex = 3;
            this.btnCnacel.Text = "إلغاء";
            this.btnCnacel.UseVisualStyleBackColor = false;
            this.btnCnacel.Click += new System.EventHandler(this.btnCnacel_Click);
            // 
            // Form_Priveleges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 483);
            this.Controls.Add(this.btnCnacel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gridUser);
            this.Controls.Add(this.LbUsers);
            this.MaximizeBox = false;
            this.Name = "Form_Priveleges";
            this.Resizable = false;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إدارة الصلاحيات";
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbUsers;
        private System.Windows.Forms.DataGridView gridUser;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCnacel;
    }
}