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
    public partial class Form_FeesStatistic : MetroForm
    {
        public Form_FeesStatistic()
        {
            InitializeComponent();
        }

        private void GetFiliere()
        {
            DataTable dt = Class_Classes.Ps_GetFiliers();
            cmbFiliere.DisplayMember = "Label";
            cmbFiliere.ValueMember = "idFiliere";
            cmbFiliere.DataSource = dt;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Form_FeesStatistic_Load(object sender, EventArgs e)
        {
            GetFiliere();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Class_Fees.usp_GetNombreOfFees(txtYear.Text, Convert.ToInt32(cmbFiliere.SelectedValue));
                dataGridView1.DataSource = dt;
                txtNombreRecu.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchByDate_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string year = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            string num = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            DataTable dt = Class_Fees.usp_getMu(year, num);
            txtTotal.Text = dt.Rows[0][0].ToString();
            txtREst.Text = dt.Rows[0][1].ToString();
        }

        private void btnSearchByDate_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Class_Fees.usp_GetFeesByDate(dateTimePicker1.Value.Date);
                dataGridView1.DataSource = dt;
                txtNombreRecu.Text = dt.Rows.Count.ToString();
                decimal daily = 0.00M;
                foreach (DataRow dr in dt.Rows)
                {
                    daily += Convert.ToDecimal(dr[6]);
                }
                txtDaily.Text = daily.ToString();
            }
            catch (Exception ex)
            {

               // throw;
            }
        }
    }
}
