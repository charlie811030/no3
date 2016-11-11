using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string currentFileName = "";
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //月曆顯示開始日期和結束日期
            time1.Text = monthCalendar1.SelectionStart.ToString();
            time2.Text = monthCalendar1.SelectionEnd.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            monthCalendar1.ShowWeekNumbers = false;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (radioButton1.Checked == true)
        //        monthCalendar1.ShowWeekNumbers = true;
        //    else
        //        monthCalendar1.ShowWeekNumbers = false;
        //}

        private void 儲存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savefile();
        } 

        private void 新增NToolStripMenuItem_Click(object sender, EventArgs e)
        {
     

            contentTextBox.Text = "";
            currentFileName = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            savefile();
        }

        private void savefile()
        {
            string fileName;
            if (currentFileName == "")
            {
                if (dialogForSaving.ShowDialog() != DialogResult.OK)
                    return;
                fileName = dialogForSaving.FileName;
                currentFileName = fileName;
            }
            else
                fileName = currentFileName;

            StreamWriter w = new StreamWriter(fileName, false);
            w.Write(contentTextBox.Text);
            w.Close();
            contentTextBox.Modified = false;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            //this.Refresh();
            //time1.Clear();
            //time2.Clear();
            //contentTextBox.Clear();
            //this.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            contentTextBox.Text = "";
            currentFileName = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            monthCalendar1.ShowWeekNumbers = true;
        }

        private void 開啟OToolStripMenuItem_Click(object sender, EventArgs e)
        {
      

            dialogForOpening.Filter = "Text File|*.txt|All File|*.*";
            dialogForOpening.InitialDirectory = @"c:\temp";
            if (dialogForOpening.ShowDialog() != DialogResult.OK)
                return;
            string fileName = dialogForOpening.FileName;
            currentFileName = fileName;
            StreamReader r = new StreamReader(fileName, Encoding.GetEncoding("UTF-8"));
            contentTextBox.Text = r.ReadToEnd();
            r.Close();
            contentTextBox.Modified = false;
        }

        private void dialogForOpening_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
    
}
