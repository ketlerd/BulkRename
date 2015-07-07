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

namespace BulkRename
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Please enter an action to perform.");
                return;
            }

            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Please select a folder.");
                return;
            }

            if (MessageBox.Show("Process " + textBox3.Text + "?","", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (textBox1.Text.Trim() != "")
                {


                    string path = textBox3.Text;
                    string[] fileEntries = Directory.GetFiles(path);

                    foreach (string file in fileEntries)
                    {
                        if (Path.GetFileName(file) == "BulkRename.exe")
                            continue;
                        Console.WriteLine(file);

                        File.Move(file, Path.GetFullPath(file).ToString().Trim(Path.GetFileName(file).ToCharArray()) + Path.GetFileName(file).ToString().Substring(Int32.Parse(textBox1.Text.ToString()), Int32.Parse((Path.GetFileName(file).Length - Int32.Parse(textBox1.Text.ToString())).ToString())));
                    }
                }
                else if (textBox2.Text.Trim() != "")
                {
                    string path = textBox3.Text;
                    string[] fileEntries = Directory.GetFiles(path);

                    foreach (string file in fileEntries)
                    {
                        if (Path.GetFileName(file) == "BulkRename.exe")
                            continue;
                        Console.WriteLine(file);

                        File.Move(file, Path.GetFullPath(file).ToString().Trim(Path.GetFileName(file).ToCharArray()) + Path.GetFileName(file).Trim(textBox2.Text.ToCharArray()));
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            textBox3.Text = fbd.SelectedPath.ToString();
        }//button_click
    }
}
