using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combolist_Maker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            MaximumSize = Size;
            MinimumSize = Size;
        }
        
        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                Thread t = new Thread(() => combineLists(File.ReadAllLines(tbUser.Text), File.ReadAllLines(tbPass.Text)));
                t.IsBackground = true;
                t.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void combineLists(String[] list1, String[] list2)
        {
            List<String> toReturn = new List<String>();
            foreach (String user in list1)
            {
                foreach (String pass in list2)
                {
                    toReturn.Add(String.Format("{0}:{1}", user, pass));
                }
            }
            File.AppendAllLines(Environment.CurrentDirectory + @"\Combined.txt", toReturn);
            MessageBox.Show("Success!");
        }

        private void tbUser_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbUser.Text = ofd.FileName;
                }
            }

        }

        private void tbPass_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbPass.Text = ofd.FileName;
                }
            }

        }
    }
}
