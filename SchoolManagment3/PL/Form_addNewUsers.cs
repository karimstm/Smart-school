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
    public partial class Form_addNewUsers : MetroForm
    {
        public Form_addNewUsers()
        {
            InitializeComponent();
        }
        string user;
        private void loadData()
        {
            DataTable dt = Class_Users.usp_tblUsersSelect();
            dataGridView1.DataSource = dt;
        }

        private void Clear()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }
        private void Permission()
        {
            DataTable dt = Class_Users.GetPermission();
            cmbPerm.DisplayMember = "PermLabel";
            cmbPerm.ValueMember = "idPermission";
            cmbPerm.DataSource = dt;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form_addNewUsers_Load(object sender, EventArgs e)
        {
            loadData();
            Permission();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    if (c == txtEmail)
                    {
                        continue;
                    }
                    if (c.Text == "")
                    {
                        MessageBox.Show("المرجوا ملئ جميع الخانات", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
            }

            try
            {
                if (txtPassword.Text != txtPasswordConfirm.Text)
                {
                    MessageBox.Show("كلمة المرور غير متطابقة");
                    txtPasswordConfirm.Clear();
                    return;
                }

                Class_Users.usp_tblUsersInsert(txtUsername.Text, txtFullName.Text, txtPassword.Text, txtEmail.Text, Convert.ToInt32(cmbPerm.SelectedValue));
                MessageBox.Show("تمت الإضافة بنجاح", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لا يمكن إضافة هذا المستخدم، قد يكون موجوداً", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    if (c == txtEmail)
                    {
                        continue;
                    }
                    if (c.Text == "")
                    {
                        MessageBox.Show("المرجوا ملئ جميع الخانات", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
            }

            try
            {
                if (txtPassword.Text != txtPasswordConfirm.Text)
                {
                    MessageBox.Show("كلمة المرور غير متطابقة");
                    txtPasswordConfirm.Clear();
                    return;
                }
                if (txtUsername.Text.ToLower() == "administrateur" && cmbPerm.Text.ToLower() == "admin")
                {
                    MessageBox.Show("لا يمكن تنزيل رتبة المدير", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                Class_Users.usp_tblUsersUpdate(txtUsername.Text, txtFullName.Text, txtPassword.Text, txtEmail.Text, Convert.ToInt32(cmbPerm.SelectedValue));
                MessageBox.Show("تم التعديل بنجاح");
                loadData();
                Clear();
            }
            catch (Exception ex)
            {

                //
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string username = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (username == "Administrateur")
                {
                    MessageBox.Show("لا يمكن حذف هذا المستخدم", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult dr = MessageBox.Show("هل تريد حقا حذف هذا المتسخدم", "إشعار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_Users.usp_tblUsersDelete(username);
                    MessageBox.Show("تم الحذف بنجاح");
                    loadData();
                    Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("يتعذر حذف هذا المستخدم");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = Class_Users.usp_searchUsr(txtSearch.Text);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsername.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            user = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtFullName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtPassword.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtPasswordConfirm.Text = txtFullName.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cmbPerm.Text = txtFullName.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void cmbPerm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
