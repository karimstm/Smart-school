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
    public partial class PaieMensuelGestion : MetroForm
    {
        public PaieMensuelGestion()
        {
            InitializeComponent();
            LoadData();
            GetYear();
            GetFiliere();
        }
        private void GetFiliere()
        {
            DataTable dt = Class_Classes.Ps_GetFiliers();
            cmbFiliere.DisplayMember = "Label";
            cmbFiliere.ValueMember = "idFiliere";
            cmbFiliere.DataSource = dt;
        }

        private void GetYear()
        {
            DataTable dt = Class_Classes.Ps_GetYears();
            cmbYears.ValueMember = "idyear";
            cmbYears.DisplayMember = "SchoolYear";
            cmbYears.DataSource = dt;
        }
        private void LoadData()
        {
            DataTable dt = Class_Fees.usp_SelectFees();
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNum.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtIdFee.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtYear.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtFeeName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtTotal.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtPaid.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtRest.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtNote.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearchID_Click(object sender, EventArgs e)
        {
            int result;

            if (int.TryParse(txtSearchID.Text, out result))
            {
                DataTable dt = Class_Fees.usp_SelectFeesById(result);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("أدخل رقم الوصل بشكل صحيح", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdFee.Text))
                {
                    MessageBox.Show("المرجوا تحديد رقم الوصل", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    Class_Fees.usp_tblFeesUpdate(int.Parse(txtIdFee.Text), decimal.Parse(txtTotal.Text), decimal.Parse(txtPaid.Text), decimal.Parse(txtRest.Text), txtNote.Text);
                    MessageBox.Show("تم التحديث بنجاح", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LoadData();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("حصل خطأ في التحديث", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("عليك أن تحدد الفاتورة المرادة أولا", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("هل تريد حقا حذف هذه الفاتورة", "إشعار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        Class_Fees.usp_tblFeesDelete(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                        MessageBox.Show("تم الحذف بنجاح", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("حدث خلل أثناء الحذف", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    int FeeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    DataSet ds = Class_Fees.usp_getRecu(FeeId);
                    RPT.CrystalReport1 cr = new RPT.CrystalReport1();
                    cr.SetDataSource(ds);
                    RPT.FRM_REPORT frm = new RPT.FRM_REPORT();
                    frm.crystalReportViewer1.ReportSource = cr;
                    frm.ShowDialog();
                    this.Cursor = Cursors.Default;

                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("حصل خطأ في جمع البيانات", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTotal.Text != "" )
                {
                    decimal paid = 0.00M;
                    if (txtPaid.Text == "")
                    {
                        paid = 0.00M;
                    }
                    else
                    {
                        paid = decimal.Parse(txtPaid.Text);
                    }

                    txtRest.Text = ((decimal.Parse(txtTotal.Text)) - (paid)).ToString();
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                new PrompteForm().ShowDialog();
                if (PrompteForm.Year != "")
                {
                    
                    DataSet ds = Class_Fees.usp_PrintAllFees(PrompteForm.Year);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("لا توجد أي بيانات لهذه السنة", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        RPT.FRM_REPORT frm = new RPT.FRM_REPORT();
                        RPT.AllFees cr = new RPT.AllFees();
                        cr.SetDataSource(ds);
                        cr.SetParameterValue("Year", PrompteForm.Year);
                        frm.crystalReportViewer1.ReportSource = cr;
                        frm.ShowDialog();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
                //throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DataTable dt = Class_Fees.usp_SelectFeesByName(textBox1.Text);
                dataGridView1.DataSource = dt;
            }
        }

        private void PaieMensuelGestion_Load(object sender, EventArgs e)
        {

        }

        private void cmbFiliere_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbClass.Enabled = true;
            DataTable dt = Class_student.Ps_GetClassByFiliere(Convert.ToInt32(cmbFiliere.SelectedValue), Convert.ToInt32(cmbYears.SelectedValue));
            cmbClass.DisplayMember = "Label";
            cmbClass.ValueMember = "idClass";
            cmbClass.DataSource = dt;
        }

        private void btnSearchByClass_Click(object sender, EventArgs e)
        {
            if (cmbClass.Text != "")
            {
                DataTable dt = Class_Fees.usp_SelectFeesByClass(Convert.ToInt32(cmbClass.SelectedValue));
                dataGridView1.DataSource = dt;
            }
        }

        private void cmbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFiliere_SelectedIndexChanged(null, null);
        }

        private void txtSearchID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
