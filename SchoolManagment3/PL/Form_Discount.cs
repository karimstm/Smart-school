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
    public partial class Form_Discount : MetroForm
    {
        public Form_Discount()
        {
            InitializeComponent();
            GetData();
        }
        
        private void GetData()
        {
            DataTable dt = Class_Discount.usp_tblDiscountSelect();
            grdView.DataSource = dt;
        }

        private void Clean()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new Form_studentManagment("Discount").ShowDialog();
            txtNum.Text = Form_studentManagment.ID;
            txtName.Text = Form_studentManagment.SName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNum.Text == "" || txtPrice.Text == "")
                {
                    MessageBox.Show("المرجوا مراجعة الحقول");
                    return;
                }
                Class_Discount.usp_tblDiscountInsert(decimal.Parse(txtPrice.Text), txtDesc.Text, txtNum.Text);
                MessageBox.Show("تمت إضافة التخفيض بنجاح");
                GetData();
                Clean();
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    MessageBox.Show("سبق وعمل تخفيض لهذا الطالب");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("تحديد المعرف بالضغط مرتين على التخفيض");
                    return;
                }
                Class_Discount.usp_tblDiscountUpdate(int.Parse(txtID.Text), decimal.Parse(txtPrice.Text), txtDesc.Text, txtNum.Text);
                MessageBox.Show("تم التعديل بنجاح");
                GetData();
                Clean();
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    MessageBox.Show("سبق وعمل تخفيض لهذا الطالب");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("تحديد المعرف بالضغط مرتين على التخفيض");
                    return;
                }
                DialogResult dr = MessageBox.Show("هل تريد حقاً إزالة هذا التخفيض", "رسالة تحذيرية", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_Discount.usp_tblDiscountDelete(int.Parse(txtID.Text));
                    MessageBox.Show("تم الحذف بنجاح");
                    GetData();
                    Clean();
                }
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    MessageBox.Show("سبق وعمل تخفيض لهذا الطالب");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNum.Text = grdView.CurrentRow.Cells[3].Value.ToString();
            txtID.Text = grdView.CurrentRow.Cells[0].Value.ToString();
            txtPrice.Text = grdView.CurrentRow.Cells[1].Value.ToString();
            txtDesc.Text = grdView.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
