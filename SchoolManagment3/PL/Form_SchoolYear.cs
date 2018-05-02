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
using System.Text.RegularExpressions;

namespace SchoolManagment3.PL
{
    public partial class Form_SchoolYear : MetroForm
    {
        public Form_SchoolYear()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtYear.Text == "____-____")
            {
                txtYear.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string pattern = "^[0-9]{4}-[0-9]{4}$";
            Regex reg = new Regex(pattern);
            try 
            {
                if (txtYear.Text == "" || !reg.IsMatch(txtYear.Text) )
                {
                    MessageBox.Show("ما أدخلته لا يتوافق مع النمط المطلوب");
                    return;
                }

                Class_SchoolYear.PS_addSchoolYear(txtYear.Text);
                MessageBox.Show("تمت إضافة السنة بنجاح", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtYear.Text = "____ - ____";
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }
    }
}
