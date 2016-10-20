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
            if (window.getCurrentEmployee() != null)                 
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
            Core.deleteEmployees((Employee)dataGridView1.CurrentRow.DataBoundItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var oldEmployee = (Employee)dataGridView1.CurrentRow.DataBoundItem;
            var window = new EmployeeEditor(oldEmployee);
            this.Hide();
            window.ShowDialog();
            if (window.getCurrentEmployee() != null)
            {
                var newEmployee = window.getCurrentEmployee();

                var arr = (BindingList<Employee>)Core.getEmployees();
                var index = arr.IndexOf(oldEmployee);
                arr[index] = newEmployee;      
            }
            this.Show();
        }
    }
}