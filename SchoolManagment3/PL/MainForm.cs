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
using System.Configuration;
using System.Data.SqlClient;

namespace SchoolManagment3.PL
{
    public partial class MainForm : MetroForm
    {
        public static bool check = false;
        public static int idPre = 0;
        public static string username;
        public MainForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form_AddStudent(false).ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAddSchoolYear_Click(object sender, EventArgs e)
        {
            new Form_SchoolYear().ShowDialog();
        }

        private void btnSchoolYearManagment_Click(object sender, EventArgs e)
        {
            new Form_SchoolYearManagment().ShowDialog();
        }

        private void btnAddFilier_Click(object sender, EventArgs e)
        {
            new Form_addFiliere().ShowDialog();
        }

        private void btnFiliereManagment_Click(object sender, EventArgs e)
        {
            new Form_FiliereManagment().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form_Class().ShowDialog();
        }

        private void btnStudentsManagment_Click(object sender, EventArgs e)
        {
            new Form_studentManagment("New").ShowDialog();
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            new Form_Discount().ShowDialog();

        }

        private void btnOtherFees_Click(object sender, EventArgs e)
        {
            new Form_OtherFees().ShowDialog();
        }

        private void btnAddFacture_Click(object sender, EventArgs e)
        {
            new Form_PaieMensuelManagment().ShowDialog();
        }

        private void LogoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Pbackup_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Prestore_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loginpanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void LogOut_Click(object sender, EventArgs e)
        {

        }

        private void loginpanel_Click(object sender, EventArgs e)
        {
            new Form_Login().ShowDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {

            if (check == false)
            {
                Maintab.DisableTab(metroTabPage1);
            }
            else if (check == true)
            {
                if (idPre == 1)
                {
                    Maintab.EnableTab(metroTabPage1);
                    LogoutPanel.Enabled = true;
                    Pbackup.Enabled = true;
                    foreach (Control c in metroTabPage1.Controls)
                    {
                        if (c is Button)
                        {
                            c.Enabled = true;
                        }
                    }

                }
                else if (idPre == 2)
                {
                    try
                    {
                        
                        DataTable dt = Class_Users.usp_getMyprevilages(username);
                        if (dt.Rows[0][0].ToString() == "False" || dt.Rows[0][0].ToString() == string.Empty)
                            btnAddStudent.Enabled = false;
                        if (dt.Rows[1][0].ToString() == "False" || dt.Rows[1][0].ToString() == string.Empty)
                            btnStudentsManagment.Enabled = false;
                        if (dt.Rows[2][0].ToString() == "False" || dt.Rows[2][0].ToString() == string.Empty)
                            btnAddSchoolYear.Enabled = false;
                        if (dt.Rows[3][0].ToString() == "False" || dt.Rows[3][0].ToString() == string.Empty)
                            btnSchoolYearManagment.Enabled = false;
                        if (dt.Rows[4][0].ToString() == "False" || dt.Rows[4][0].ToString() == string.Empty)
                            btnAddFilier.Enabled = false;
                        if (dt.Rows[5][0].ToString() == "False" || dt.Rows[5][0].ToString() == string.Empty)
                            btnFiliereManagment.Enabled = false;
                        if (dt.Rows[6][0].ToString() == "False" || dt.Rows[6][0].ToString() == string.Empty)
                            btnClasses.Enabled = false;
                        if (dt.Rows[7][0].ToString() == "False" || dt.Rows[7][0].ToString() == string.Empty)
                            btnDiscount.Enabled = false;
                        if (dt.Rows[8][0].ToString() == "False" || dt.Rows[8][0].ToString() == string.Empty)
                            btnOtherFees.Enabled = false;
                        if (dt.Rows[9][0].ToString() == "False" || dt.Rows[9][0].ToString() == string.Empty)
                            btnAddFacture.Enabled = false;
                        if (dt.Rows[10][0].ToString() == "False" || dt.Rows[10][0].ToString() == string.Empty)
                            btnFeesMang.Enabled = false;
                        if (dt.Rows[11][0].ToString() == "False" || dt.Rows[11][0].ToString() == string.Empty)
                            btnFeeStatic.Enabled = false;
                        if (dt.Rows[12][0].ToString() == "False" || dt.Rows[12][0].ToString() == string.Empty)
                            btnLateFees.Enabled = false;
                        if (dt.Rows[13][0].ToString() == "False" || dt.Rows[13][0].ToString() == string.Empty)
                            btnUsersMan.Enabled = false;
                        if (dt.Rows[14][0].ToString() == "False" || dt.Rows[14][0].ToString() == string.Empty)
                            btnPrev.Enabled = false;
                        Maintab.EnableTab(metroTabPage1);
                        LogoutPanel.Enabled = true;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }
                else if (idPre == 0)
                {
                    Maintab.DisableTab(metroTabPage1);
                    LogoutPanel.Enabled = false;
                    Pbackup.Enabled = false;
                    username = null;
                    idPre = 0;
                    check = false;
                }
                
            }
        }

        private void btnFeesMang_Click(object sender, EventArgs e)
        {
            new PaieMensuelGestion().ShowDialog();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFeeStatic_Click(object sender, EventArgs e)
        {
            new Form_FeesStatistic().ShowDialog();
        }

        private void btnLateFees_Click(object sender, EventArgs e)
        {
            new Form_LatePaiment().ShowDialog();
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnUsersMan_Click(object sender, EventArgs e)
        {
            new Form_addNewUsers().ShowDialog();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            new Form_Priveleges().ShowDialog();
        }

        private void LogoutPanel_Click(object sender, EventArgs e)
        {
            Maintab.DisableTab(metroTabPage1);
            LogoutPanel.Enabled = false;
            Pbackup.Enabled = false;
            username = null;
            idPre = 0;
            check = false;

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Server = {0}", txtIp.Text);
            SqlConnectionStringBuilder builder =
            new SqlConnectionStringBuilder(connectionString);

            // Supply the additional values.
            builder.UserID = "sa";
            builder.InitialCatalog = "SchoolManagment2017";
            builder.Password = "M@ut%^k/12#3456";
            sqlHelper help = new sqlHelper(builder.ToString());
            try
            {
                if (help.IsConnection)
                {
                    MessageBox.Show("تم الإتصال بنجاح", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("فشل الإتصال بقاعدة البيانات", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("server = {0}", txtIp.Text);
            SqlConnectionStringBuilder builder =
            new SqlConnectionStringBuilder(connectionString);

            // Supply the additional values.
            builder.UserID = "sa";
            builder.InitialCatalog = "SchoolManagment2017";
            builder.Password = "M@ut%^k/12#3456";
            sqlHelper help = new sqlHelper(builder.ToString());
            try
            {
                if (help.IsConnection)
                {
                    AppSettings setting = new AppSettings();
                    setting.SaveConnectionString("partialConnectString", connectionString);
                    MessageBox.Show("تم حفظ قاعدة البيانات بنجاح", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void Pbackup_Click(object sender, EventArgs e)
        {
            try
            {
                string path = string.Format("{0}\\School-{1}{2}.bak", "C:\\Backup", DateTime.Now.ToShortDateString().Replace('/', '-'), DateTime.Now.ToShortTimeString().Replace(':', '-'));
                Class_Backup.usp_backup(path);
                MessageBox.Show("تم الحفظ بنجاح");
            }
            catch (Exception ex)
            {

                MessageBox.Show("حدث خطأ أثناء الحفظ");
               // MessageBox.Show(ex.Message);
            }
        }
    }
}
