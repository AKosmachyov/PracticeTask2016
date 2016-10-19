using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracticeTask2016.Core;

namespace PracticeTask2016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Core.Core.getEmployees();
        }
                
        private void button1_Click(object sender, EventArgs e)
        {           
            var window = new EmployeeEditor();
            this.Hide();            
            window.ShowDialog();                       
            Core.Core.addEmployees(window.getCurrentEmployee());            
            this.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }
    }
}
