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
    public partial class Form_Priveleges : MetroForm
    {
        public Form_Priveleges()
        {
            InitializeComponent();
            DataTable dt = Class_Users.usp_getNameOfUsers();
            LbUsers.DisplayMember = "username";
            LbUsers.ValueMember = "username";
            LbUsers.DataSource = dt;
        }

        private void LbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_Users.getPriv(LbUsers.SelectedValue.ToString());
            gridUser.DataSource = dt;
            gridUser.Columns[0].Visible = false;
        }

        private void btnCnacel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string userName = LbUsers.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt.Columns.Add("username");
            dt.Columns.Add("idScreen");
            dt.Columns.Add("Prev");

            try
            {
                for (int i = 0; i < gridUser.Rows.Count; i++)
                {
                    int idScreen = Convert.ToInt32(gridUser.Rows[i].Cells[0].Value.ToString());
                    Boolean show = gridUser.Rows[i].Cells[2].Value.Equals(true || false);
                    dt.Rows.Add(userName, idScreen, show);
                }

                Class_Users.usp_UpatePriv(dt);
                MessageBox.Show("تم حفظ الصلاحيات بنجاح");
            }
            catch (Exception ex)
            {

               // throw;
            }
        }
    }
}
