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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.SqlClient;

namespace SchoolManagment3.PL
{
    public partial class Form_studentManagment : MetroForm
    {
        public static string ID;
        public static string SName;
        public static string Year;
        public static string Filiers;
        public static string Classe;
        public static string MonthlyPrice;
        public static string InscriptionPrice;

        string _check;
        public Form_studentManagment(string check)
        {
            _check = check;
            InitializeComponent();
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
        private void GetData()
        {
            DataTable dt = Class_student.usp_tblStudentSelect();
            dataGridView1.DataSource = dt;
        }
        private void Form_studentManagment_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_student.usp_tblStudentSelectByName(txtName.Text);
            dataGridView1.DataSource = dt;
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_student.usp_tblStudentSelectByNumber(txtNum.Text);
            dataGridView1.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbClass.Text != "")
            {
                DataTable dt = Class_student.Usp_SearchStudentbyClass(Convert.ToInt32(cmbClass.SelectedValue));
                dataGridView1.DataSource = dt;
            }
        }

        private void cmbFiliere_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbClass.Enabled = true;
            DataTable dt = Class_student.Ps_GetClassByFiliere(Convert.ToInt32(cmbFiliere.SelectedValue), Convert.ToInt32(cmbYears.SelectedValue));
            cmbClass.DisplayMember = "Label";
            cmbClass.ValueMember = "idClass";
            cmbClass.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = Class_student.Usp_SearchStudentbyDate(dateTimePicker1.Value, dateTimePicker2.Value);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }
        private void copyAlltoClipboard()
        {
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد أي بيانات");
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("حصل خطأ ما");
            }
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                new Form_AddStudent(true).ShowDialog();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_check == "Discount")
            {
                ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                SName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.Close();
            }else if(_check == "Fees")
            {
                ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                SName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Year = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                Filiers = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                Classe = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
                MonthlyPrice = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                InscriptionPrice = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                this.Close();
            }
        }

        private void cmbYears_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            

            try
            {
                string num = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dr = MessageBox.Show("هل حقا تريد حذف هذا الطالب؟", "إشعار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_student.usp_tblStudentDelete(num);
                    MessageBox.Show("تم الحذف ينجاح");
                    GetData();
                }
            }
            catch (SqlException ex)
            {

                //MessageBox.Show(ex.Message + ex.Number);
            }
            catch (Exception ex)
            {
                //
            }
            
        }

        private void btnMu_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = Class_student.ups_getMofStudent(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[15].Value.ToString());
                RPT.FRM_REPORT frm = new RPT.FRM_REPORT();
                RPT.CR_MUPaper rapport = new RPT.CR_MUPaper();
                rapport.SetDataSource(ds);
                frm.crystalReportViewer1.ReportSource = rapport;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }
    }
}


#region MyRegion
//DataTable dt = Class_student.ups_getMofStudent(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
//var application = new Microsoft.Office.Interop.Word.Application();
//var document = new Microsoft.Office.Interop.Word.Document();

//document = application.Documents.Add(Template: "C:\\Template.docx");
//application.Visible = true;

//foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
//{
//    if (field.Code.Text.Contains("FullNameAr"))
//    {
//        field.Select();
//        if (dt.Rows[0][2].ToString() == "" || dt.Rows[0][2].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][2].ToString());
//        }

//    }else if (field.Code.Text.Contains("FullNameFr"))
//    {
//        field.Select();
//        if (dt.Rows[0][3].ToString() == "" || dt.Rows[0][3].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][3].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("FatherName"))
//    {
//        field.Select();
//        if (dt.Rows[0][8].ToString() == "" || dt.Rows[0][8].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][8].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("FatherJob"))
//    {
//        field.Select();
//        if (dt.Rows[0][9].ToString() == "" || dt.Rows[0][9].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][9].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("Address"))
//    {
//        field.Select();
//        if (dt.Rows[0][10].ToString() == "" || dt.Rows[0][10].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][10].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("NumInscr"))
//    {
//        field.Select();
//        if (dt.Rows[0][1].ToString() == "" || dt.Rows[0][1].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][1].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("HandPhone"))
//    {
//        field.Select();
//        if (dt.Rows[0][1].ToString() == "" || dt.Rows[0][1].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][1].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("HomePhone"))
//    {
//        field.Select();
//        if (dt.Rows[0][12].ToString() == "" || dt.Rows[0][12].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][12].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("InscripDate"))
//    {
//        field.Select();
//        if (dt.Rows[0][15].ToString() == "" || dt.Rows[0][15].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][15].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("Classe"))
//    {
//        field.Select();
//        if (dt.Rows[0][20].ToString() == "" || dt.Rows[0][20].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][20].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("SchoolYear"))
//    {
//        field.Select();
//        if (dt.Rows[0][28].ToString() == "" || dt.Rows[0][28].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][28].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("Discount"))
//    {
//        field.Select();
//        if (dt.Rows[0][23].ToString() == "" || dt.Rows[0][23].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][23].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("Price"))
//    {
//        field.Select();
//        if (dt.Rows[0][21].ToString() == "" || dt.Rows[0][21].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][21].ToString());
//        }
//    }
//    else if (field.Code.Text.Contains("Reason"))
//    {
//        field.Select();
//        if (dt.Rows[0][22].ToString() == "" || dt.Rows[0][22].ToString() == null)
//        {
//            application.Selection.TypeText(" ");
//        }
//        else
//        {
//            application.Selection.TypeText(dt.Rows[0][22].ToString());
//        }
//    } 
//}

//application.Quit();
#endregion