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
    public partial class Form_PaieMensuelManagment : MetroForm
    {
        public Form_PaieMensuelManagment()
        {
            InitializeComponent();

        }

        public void GetFeeType()
        {
            
            DataTable dt = Class_Fees.usp_tblFeetypeSelect();
            comboBox1.DisplayMember = "label";
            comboBox1.ValueMember = "idfeesType";
            comboBox1.DataSource = dt;
        }
        
        public void GetOtherFees()
        {
            listView1.Items.Clear();
            DataTable dt = Class_OtherFees.usp_tblOtherFeesSelect();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                listView1.Items.Add(item);
                listView1.Columns[0].Width = 0;
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        decimal price = 0.00M;
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        decimal M = 0.00M;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new Form_studentManagment("Fees").ShowDialog();
                txtNum.Text = Form_studentManagment.ID;
                txtName.Text = Form_studentManagment.SName;
                txtYear.Text = Form_studentManagment.Year;
                txtMonthlyPrice.Text = Form_studentManagment.MonthlyPrice;
                txtInscPrice.Text = Form_studentManagment.InscriptionPrice;
                txtFiliere.Text = Form_studentManagment.Filiers;
                txtClass.Text = Form_studentManagment.Classe;
                if (txtMonthlyPrice.Text != "" && txtInscPrice.Text != "")
                {
                    DataTable dt = Class_Fees.usp_getmylatDue(txtNum.Text);
                    txtM.Text = dt.Rows[0][0].ToString();
                    M = decimal.Parse(txtM.Text);
                    GetFeeType();

                }
            }
            catch (Exception)
            {

                //throw;
            }
           




        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.CurrentValue == CheckState.Unchecked)
                {
                    price += decimal.Parse(
                        this.listView1.Items[e.Index].SubItems[2].Text);
                }
                else if ((e.CurrentValue == CheckState.Checked))
                {
                    price -= decimal.Parse(
                        this.listView1.Items[e.Index].SubItems[2].Text);
                }
                // Output the price to TextBox1.
                txtTotal.Text = (price + M).ToString();
            }
            catch (Exception ex)
            {

               //
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal Total = 0.00M;
                if (txtTotal.Text != "" && txtPaid.Text != "")
                {
                    Total += decimal.Parse(txtTotal.Text);
                    txtRest.Text = (Total - decimal.Parse(txtPaid.Text)).ToString();
                }
            }
            catch (Exception ex)
            {

                //
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            textBox8_TextChanged(null, null);
        }

        
        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception ex)
            {

                //throw;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "رسوم التسجيل والتأمين")
                {
                    price = decimal.Parse(txtInscPrice.Text);
                    listView1.Items.Clear();
                    txtDiscount.Text = 0.ToString();
                }
                else
                {
                    price = decimal.Parse(txtMonthlyPrice.Text);
                    decimal discount = Class_Fees.usp_getMyDiscoutn(txtNum.Text);
                    if (discount == null)
                    {
                        txtDiscount.Text = 0.ToString();
                    }
                    else
                    {
                        txtDiscount.Text = discount.ToString();
                        price -= discount;
                        GetOtherFees();
                    }

                }

                txtTotal.Text = (price + M).ToString();
            }
            catch (Exception EX)
            {

                //
            }

            
        }

        int FeeId = 0;

        private void Clear()
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

            //comboBox1.Items.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(txtPaid.Text) <= 0)
            {
                MessageBox.Show("لا ينبغي للمبلغ المدفوع أن يكون صفراً");
                return;
            }
            if (decimal.Parse(txtRest.Text) < 0)
            {
                MessageBox.Show("المبلغ المتبقي أصغر من صفر، تأكد مما أدخلته", "رسالة إشعارية", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            try
            {
                DataTable dtPaimentDetail = new DataTable();
                dtPaimentDetail.Columns.Add("idMonth");
                dtPaimentDetail.Columns.Add("NumInscription");
                dtPaimentDetail.Columns.Add("idOtherFees");

                foreach (ListViewItem it in listView1.Items)
                {
                    if (it.Checked)
                    {
                        dtPaimentDetail.Rows.Add(Convert.ToInt32(comboBox1.SelectedValue), txtNum.Text, Convert.ToInt32(it.SubItems[0].Text));
                    }
                }
                if (dtPaimentDetail.Rows.Count == 0)
                {
                    dtPaimentDetail.Rows.Add(Convert.ToInt32(comboBox1.SelectedValue), txtNum.Text, null);
                }

                Class_Fees.usp_tblFeesInsert(txtYear.Text, Convert.ToDecimal(txtTotal.Text), Convert.ToDecimal(txtPaid.Text), Convert.ToDecimal(txtRest.Text), dateTimePicker1.Value, dtPaimentDetail, txtNote.Text);
                MessageBox.Show("تم الحفظ بنجاح");
                FeeId = Class_Fees.usp_getLastFees();
                Clear();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (FeeId > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
