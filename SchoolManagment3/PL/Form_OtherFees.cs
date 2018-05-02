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
    public partial class Form_OtherFees : MetroForm
    {
        public Form_OtherFees()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            DataTable dt = Class_OtherFees.usp_tblOtherFeesSelect();
            grdView.DataSource = dt;
            grdView.Columns[0].Visible = false;
        }

        private void Clean()
        {
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtPrice.Text == "")
                {
                    MessageBox.Show("المرجوا مراجعة الحقول");
                    return;
                }
                Class_OtherFees.usp_tblOtherFeesInsert(txtName.Text, decimal.Parse(txtPrice.Text));
                MessageBox.Show("تمت إضافة الرسوم بنجاح");
                GetData();
                Clean();
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    MessageBox.Show("هذا الرسم موجود مسبقا");
                }

                MessageBox.Show(ex.Message + ex.Number);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void grdView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = grdView.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = grdView.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = grdView.CurrentRow.Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("اضغطت مرتين على الرسم لتحديد المعرف");
                    return;
                }
                Class_OtherFees.usp_tblOtherFeesUpdate(int.Parse(txtID.Text), txtName.Text, decimal.Parse(txtPrice.Text));
                MessageBox.Show("تم تعديل الرسوم بنجاح");
                GetData();
                Clean();
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    MessageBox.Show("هذا الرسم موجود مسبقا");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("اضغطت مرتين على الرسم لتحديد المعرف");
                    return;
                }
                DialogResult dr = MessageBox.Show("هل تريد حقاً إزالة هذا الرسم", "رسالة تحذيرية", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_OtherFees.usp_tblOtherFeesDelete(int.Parse(txtID.Text));
                    MessageBox.Show("تم الحذف بنجاح");
                    GetData();
                    Clean();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
