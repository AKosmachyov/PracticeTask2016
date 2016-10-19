using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using PracticeTask2016.Entity;

namespace PracticeTask2016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Core.getEmployees();
        }
                
        private void button1_Click(object sender, EventArgs e)
        {           
            var window = new EmployeeEditor();
            this.Hide();            
            window.ShowDialog();                       
            Core.addEmployees(window.getCurrentEmployee());            
            this.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Core.saveFile(saveFileDialog1.FileName);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Core.openFile(openFileDialog1.FileName);
            dataGridView1.DataSource = Core.getEmployees();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Core.deleteEmployees(dataGridView1.CurrentCell.RowIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var employee = Core.getEmployees()[dataGridView1.CurrentCell.RowIndex];
            var window = new EmployeeEditor(employee);
            window.ShowDialog();
            if (window.getCurrentEmployee() == null)
                return;
            Core.getEmployees()[dataGridView1.CurrentCell.RowIndex] = window.getCurrentEmployee();
        }
    }
}