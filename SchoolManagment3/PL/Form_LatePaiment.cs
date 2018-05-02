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
    public partial class Form_LatePaiment : MetroForm
    {
        public Form_LatePaiment()
        {
            InitializeComponent();
            GetYear();
            GetFiliere();
            GetFeeType();
        }

        private void GetFiliere()
        {
            DataTable dt = Class_Classes.Ps_GetFiliers();
            cmbFiliere.DisplayMember = "Label";
            cmbFiliere.ValueMember = "idFiliere";
            cmbFiliere.DataSource = dt;
        }

        public void GetFeeType()
        {

            DataTable dt = Class_Fees.usp_tblFeetypeSelect();
            cmbMonth.DisplayMember = "label";
            cmbMonth.ValueMember = "idfeesType";
            cmbMonth.DataSource = dt;
            cmbMonth2.DisplayMember = "label";
            cmbMonth2.ValueMember = "idfeesType";
            cmbMonth2.DataSource = dt;
        }
        private void GetYear()
        {
            DataTable dt = Class_Classes.Ps_GetYears();
            cmbYears.ValueMember = "idyear";
            cmbYears.DisplayMember = "SchoolYear";
            cmbYears.DataSource = dt;

            cmbYear.ValueMember = "idyear";
            cmbYear.DisplayMember = "SchoolYear";
            cmbYear.DataSource = dt;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void SearchByClass_Click(object sender, EventArgs e)
        {
            DataTable dt = Class_Fees.usp_getLateThismonth(Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbMonth2.SelectedValue));
            dataGridView1.DataSource = dt;
        }

        private void cmbFiliere_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_student.Ps_GetClassByFiliere(Convert.ToInt32(cmbFiliere.SelectedValue), Convert.ToInt32(cmbYear.SelectedValue));
            cmbClass.DisplayMember = "Label";
            cmbClass.ValueMember = "idClass";
            cmbClass.DataSource = dt;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFiliere_SelectedIndexChanged(null, null);
        }

        private void btnSearchByClass_Click(object sender, EventArgs e)
        {
            DataTable dt = Class_Fees.usp_getLateThismonthNoClasses(Convert.ToInt32(cmbYears.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue));
            dataGridView1.DataSource = dt;
        }
    }
}
