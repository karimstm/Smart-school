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
using System.Data.SqlClient;

namespace SchoolManagment3.PL
{
    public partial class Form_Class : MetroForm
    {
        public Form_Class()
        {
            InitializeComponent();
            GetFilieres();
            GetYear(cmbYear);
            GetYear(cmbSearch);
            Getdata();
        }

        private void GetFilieres()
        {
            DataTable dt = Class_Classes.Ps_GetFiliers();
            cmbFiliere.ValueMember = "idFiliere";
            cmbFiliere.DisplayMember = "label";
            cmbFiliere.DataSource = dt;
            
        }

        private void GetYear(ComboBox com)
        {
            DataTable dt = Class_Classes.Ps_GetYears();
            com.ValueMember = "idyear";
            com.DisplayMember = "SchoolYear";
            com.DataSource = dt;
        }


        private void Getdata()
        {
            DataTable dt = Class_Classes.PS_GetClassesData();
            grdView.DataSource = dt;
            grdView.Columns[0].Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.ReadOnly = false;
            txtId.Clear();
            txtName.Clear();
            btnSave.Enabled = true;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                try
                {
                    if (txtName.Text == "" || cmbFiliere.Text == "" || cmbYear.Text == "")
                    {
                        MessageBox.Show("المرجوا ملئ كل الحقول");
                        return;
                    }
                    Class_Classes.Ps_InsertClasses(txtName.Text, Convert.ToInt32(cmbFiliere.SelectedValue), Convert.ToInt32(cmbYear.SelectedValue));
                    MessageBox.Show("تمت الإضافة بنجاح");
                    Getdata();
                }
                catch (SqlException ex)
                {

                    if (ex.Number == 3609)
                    {
                        MessageBox.Show("هذا القسم موجود");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء أداء هذه العملية");
                }

            }
            else if(txtId.Text != "")
            {
                try
                {
                    if (txtName.Text == "" || cmbFiliere.Text == "" || cmbYear.Text == "")
                    {
                        MessageBox.Show("المرجوا ملئ كل الحقول");
                        return;
                    }
                    Class_Classes.Ps_UpdateClasses(int.Parse(txtId.Text), txtName.Text, Convert.ToInt32(cmbFiliere.SelectedValue), Convert.ToInt32(cmbYear.SelectedValue));
                    MessageBox.Show("تم التعديل بنجاح");
                    Getdata();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 3609)
                    {
                        MessageBox.Show("هذا القسم موجود");
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء أداء هذه العملية");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("المرجو تحديد معرف القسم");
                    return;
                }
                DialogResult dr = MessageBox.Show("هل أنت متأكد من أنك تريد حذف هذا القسم؟", "رسالة إنذار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_Classes.Ps_DeleteClasses(int.Parse(txtId.Text));
                    MessageBox.Show("تم الحذف بنجاح");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء أداء هذه العملية");
            }
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_Classes.PS_GetClassesDataByYear(Convert.ToInt32(cmbSearch.SelectedValue));
            grdView.DataSource = dt;
            grdView.Columns[0].Visible = false;
        }

        private void grdView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = grdView.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = grdView.SelectedRows[0].Cells[1].Value.ToString();
            cmbFiliere.Text = grdView.SelectedRows[0].Cells[2].Value.ToString();
            cmbYear.Text = grdView.SelectedRows[0].Cells[3].Value.ToString();
            btnSave.Enabled = true;
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbFiliere_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
