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
using System.IO;

namespace SchoolManagment3.PL
{
    public partial class Form_AddStudent : MetroForm
    {
        bool _check;
        public Form_AddStudent(bool check)
        {
            InitializeComponent();
            GetYear();
            GetNivau();
            cmbFilier_SelectedIndexChanged(null, null);
            if (check == true)
            {
                _check = true;
                this.Text = "تعديل بيانات طالب";
                Readonly(false);
                btnsave.Enabled = true;
                DataTable dt = Class_student.usp_GetStudentByID(Form_studentManagment.ID);
                foreach (DataRow dr in dt.Rows)
                {
                    txtid.Text = dr["NumInscription"].ToString();
                    txtFullNameAR.Text = dr["FullNameAr"].ToString();
                    txtFullNameFr.Text = dr["FullNameFr"].ToString();
                    cmbGender.Text = dr["Gender"].ToString();
                    dtpBirthday.Text = dr["birthday"].ToString();
                    txtBirthPlace.Text = dr["birthPlace"].ToString();
                    txtNationalite.Text = dr["Nationalite"].ToString();
                    txtAdress.Text = dr["adress"].ToString();
                    dtpInscriptionDate.Text = dr["InscriptionDate"].ToString();
                    cmbYearSchool.Text = dr["SchoolYear"].ToString();
                    cmbniveau.Text = dr["niveau"].ToString();
                    cmbFilier.Text = dr["filier"].ToString();
                    cmbClass.Text = dr["class"].ToString();
                    txtInscriptionFees.Text = dr["Registrationfees"].ToString();
                    txtMonthlyFees.Text = dr["Monthlyfees"].ToString();
                    txtFatherName.Text = dr["fatherName"].ToString();
                    txtFatherJob.Text = dr["fatherJob"].ToString();
                    txtHandphone.Text = dr["handphone"].ToString();
                    txtHomePhone.Text = dr["homephone"].ToString();

                    byte[] Arr = (byte[])dr["photo"];
                    MemoryStream ms = new MemoryStream(Arr);
                    imgStudent.Image = Image.FromStream(ms);

                }
            }
            else
            {
                _check = false;
                this.Text = "إضافة طالب";
                Readonly(true);
            }
            
        }

        private void Readonly(bool state)
        {
            txtid.ReadOnly = txtFullNameAR.ReadOnly = txtFullNameFr.ReadOnly = state;
        }
        private void GetYear()
        {
            DataTable dt = Class_Classes.Ps_GetYears();
            if (dt.Rows.Count > 0)
            {
                cmbYearSchool.ValueMember = "idyear";
                cmbYearSchool.DisplayMember = "SchoolYear";
                cmbYearSchool.DataSource = dt;
                cmbYearSchool.Text = dt.Rows[dt.Rows.Count - 1][1].ToString();
            }

        }

        private void GetNivau()
        {
            DataTable dt = Class_Filiere.PS_SelectNivau();
            if (dt.Rows.Count > 0)
            {
                cmbniveau.ValueMember = "idNiveau";
                cmbniveau.DisplayMember = "Label";
                cmbniveau.DataSource = dt;
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            if (_check == false)
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is TextBox || c is ComboBox)
                    {
                        if (c == txtNationalite || c == txtAdress)
                        {
                            continue;
                        }
                        if (c.Text == "")
                        {
                            
                            MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية");
                            return;
                            break;
                        }
                    }
                }

                foreach (Control c in groupBox2.Controls)
                {
                    if (c is TextBox || c is ComboBox)
                    {
                        if (c.Text == "")
                        {
                            MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية");
                            return;
                            break;
                        }
                    }
                }

                try
                {
                    MemoryStream ms = new MemoryStream();
                    imgStudent.Image.Save(ms, imgStudent.Image.RawFormat);
                    byte[] arr = ms.ToArray();

                    Class_student.PS_addStudent(txtid.Text, txtFullNameAR.Text, txtFullNameFr.Text,
                        cmbGender.Text, dtpBirthday.Value, txtBirthPlace.Text, txtNationalite.Text, txtFatherName.Text, txtFatherJob.Text,
                       txtAdress.Text, txtHandphone.Text, txtHomePhone.Text, arr, true, dtpInscriptionDate.Value, Convert.ToDecimal(txtInscriptionFees.Text), Convert.ToDecimal(txtMonthlyFees.Text), Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbYearSchool.SelectedValue));
                    MessageBox.Show("تمت الإضافة بنجاح");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("رقم التسجيل هذا موجود مسبقاً");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حصل خطأ أثناء إضافة الطالب");
                }
            }
            else
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is TextBox || c is ComboBox)
                    {
                        if (c.Text == "")
                        {
                            MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية");
                            return;
                            break;
                        }
                    }
                }

                foreach (Control c in groupBox2.Controls)
                {
                    if (c is TextBox || c is ComboBox)
                    {
                        if (c.Text == "")
                        {
                            MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية");
                            return;
                            break;
                        }
                    }
                }

                try
                {
                    MemoryStream ms = new MemoryStream();
                    imgStudent.Image.Save(ms, imgStudent.Image.RawFormat);
                    byte[] arr = ms.ToArray();

                    Class_student.usp_tblStudentUpdate(txtid.Text, txtFullNameAR.Text, txtFullNameFr.Text,
                        cmbGender.Text, dtpBirthday.Value, txtBirthPlace.Text, txtNationalite.Text, txtFatherName.Text, txtFatherJob.Text,
                       txtAdress.Text, txtHandphone.Text, txtHomePhone.Text, arr, true, dtpInscriptionDate.Value, Convert.ToDecimal(txtInscriptionFees.Text), Convert.ToDecimal(txtMonthlyFees.Text), Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbYearSchool.SelectedValue));
                    MessageBox.Show("تم تعديل المعلومات بنجاح");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حصل خطأ أثناء تديل الطالب");
                }
            }
            
        }

        private void btnEdite_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Readonly(false);
            btnsave.Enabled = true;
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

            foreach (Control c in groupBox3.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            button2_Click(null, null);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All Files |*.*|JPG|*.jpg|PNG|*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgStudent.Image = Image.FromFile(ofd.FileName);
                }
                else
                {
                    Console.Write("");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("حدث خطأ ما، يمكنك تجاهل هذه الرسالة");
            }
        }

        private void txtInscriptionFees_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbniveau_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_student.Ps_GetFilierByNivau(Convert.ToInt32(cmbniveau.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                cmbFilier.DisplayMember = "label";
                cmbFilier.ValueMember = "idFiliere";
                cmbFilier.DataSource = dt;
            }
            cmbFilier_SelectedIndexChanged(null, null);
        }

        private void cmbFilier_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_student.Ps_GetClassByFiliere(Convert.ToInt32(cmbFilier.SelectedValue), Convert.ToInt32(cmbYearSchool.SelectedValue));
                cmbClass.DisplayMember = "Label";
                cmbClass.ValueMember = "idClass";
                cmbClass.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imgStudent.Image = SchoolManagment3.Properties.Resources.student;
        }

        private void cmbYearSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbniveau_SelectedIndexChanged(null, null);
            cmbFilier_SelectedIndexChanged(null, null);
        }

        private void txtHandphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHomePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
