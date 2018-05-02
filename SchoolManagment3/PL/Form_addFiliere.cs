using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data.SqlClient;
using SchoolManagment3.BL;

namespace SchoolManagment3.PL
{
    public partial class Form_addFiliere : MetroForm
    {
        public Form_addFiliere()
        {
            InitializeComponent();
            DataTable dt = Class_Filiere.PS_SelectNivau();
            cmbNivau.DisplayMember = "Label";
            cmbNivau.ValueMember = "idNiveau";
            cmbNivau.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(cmbNivau.Text))
                {
                    MessageBox.Show("يرجى ملئ جميع الحقول");
                    return;
                }

                Class_Filiere.PS_InsertFiliere(txtName.Text, Convert.ToInt32(cmbNivau.SelectedValue));
                MessageBox.Show("تم إضافة الشعبة بنجاح");
                txtName.Clear();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
