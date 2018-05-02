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
using System.Text.RegularExpressions;
using SchoolManagment3.BL;

namespace SchoolManagment3.PL
{
    public partial class Form_SchoolYearManagment : MetroForm
    {
        public Form_SchoolYearManagment()
        {
            InitializeComponent();
            GetData();

        }

        public void GetData()
        {
            DataTable dt = Class_SchoolYear.PS_SelectSchoolYear();
            grdView.DataSource = dt;
            grdView.Columns[0].Visible = false;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string pattern = "/[0-9]{4}-[0-9]{4}/";
            Regex reg = new Regex(pattern);
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("حدد السنة المطلوبة أولا");
                    return;
                }

                if (txtYear.Text == "" || !reg.IsMatch(txtYear.Text))
                {
                    MessageBox.Show("ما أدخلته لا يتوافق مع النمط المطلوب");
                    return;
                }

                Class_SchoolYear.PS_UpdateSchoolYear(int.Parse(txtId.Text), txtYear.Text);
                MessageBox.Show("تم تعديل السنة بنجاح", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtYear.Clear();
                txtId.Clear();
                GetData();
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("حدد السنة المطلوبة أولا");
                    return;
                }
                DialogResult dr = MessageBox.Show("هل أنت متأكد من أنك تريد حذف السنة الدراسية؟","رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_SchoolYear.PS_DeleteSchoolYear(int.Parse(txtId.Text));
                    MessageBox.Show("تم الحذف بنجاح");
                    txtYear.Clear();
                    txtId.Clear();
                    GetData();
                }
                

            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = grdView.SelectedRows[0].Cells[0].Value.ToString();
            txtYear.Text = grdView.SelectedRows[0].Cells[1].Value.ToString();
        }
    }
}
