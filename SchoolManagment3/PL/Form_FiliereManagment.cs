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
using SchoolManagment3.BL;

namespace SchoolManagment3.PL
{
    public partial class Form_FiliereManagment : MetroForm
    {
        public Form_FiliereManagment()
        {
            InitializeComponent();
            GetData();
            DataTable dt = Class_Filiere.PS_SelectNivau();
            cmbNiv.DisplayMember = "Label";
            cmbNiv.ValueMember = "idNiveau";
            cmbNiv.DataSource = dt;
        }

        private void GetData()
        {
            DataTable dt = Class_Filiere.PS_SelectFiliere();
            grdView.DataSource = dt;
        }

        private void grdView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = grdView.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = grdView.SelectedRows[0].Cells[1].Value.ToString();
            cmbNiv.Text = grdView.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("المرجوا تحديد معرف الشعبة");
                    return;
                }
                if (txtName.Text == "" || cmbNiv.Text == "")
                {
                    MessageBox.Show("المرجوا ملئ جميع الخانات");
                    return;
                }
                Class_Filiere.PS_UpdateFiliere(int.Parse(txtId.Text), txtName.Text, Convert.ToInt32(cmbNiv.SelectedValue));
                MessageBox.Show("تم التعديل بنجاح");
                GetData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("المرجوا تحديد معرف الشعبة");
                    return;
                }
                DialogResult dr = MessageBox.Show("هل أنت متأكد من أنك تريد حذف هذه الشعبة؟", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_Filiere.PS_RemoveFiliere(int.Parse(txtId.Text));
                    MessageBox.Show("تم الحذف بنجاح");
                    txtId.Clear();
                    txtName.Clear();
                    GetData();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
