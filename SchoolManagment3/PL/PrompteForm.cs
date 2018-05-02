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
using System.Text.RegularExpressions;

namespace SchoolManagment3.PL
{
    public partial class PrompteForm : MetroForm
    {
        public PrompteForm()
        {
            InitializeComponent();
        }

        public static string Year;
        private void btnYes_Click(object sender, EventArgs e)
        { 
            string pattern = "^[0-9]{4}-[0-9]{4}$";
            Regex reg = new Regex(pattern);
            try
            {
                if (textBox1.Text == "" || !reg.IsMatch(textBox1.Text))
                {
                    MessageBox.Show("ما أدخلته لا يتوافق مع النمط المطلوب");
                    return;
                }
                else
                {
                    Year = textBox1.Text;
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
                
          } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
