using System;
using System.Windows.Forms;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var window = new EmployeeEditor();
            this.Hide();
            window.ShowDialog();
            textBox1_TextChanged(sender, e);
            this.Show();
            textBox1_TextChanged(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Core.deleteEmployees((Employee)dataGridView1.CurrentRow.DataBoundItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var window = new EmployeeEditor((Employee)dataGridView1.CurrentRow.DataBoundItem);
            this.Hide();
            window.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {   
            var filtersList = Core.getEmployees();
            if (textBox5.Text.Length > 0)
                filtersList = Core.getEmployeesWithFilter(filtersList, textBox5.Text, "address.street");
            if(radioButton2.Checked)
                filtersList = Core.getHouseEven(filtersList);

            int temp = 0;
            for(var i = 0; filtersList.Count > i; i++)
            {
                temp += DateTime.Now.Year - filtersList[i].birthday.Year;
            }
            if (temp != 0)
                label2.Text = (temp / filtersList.Count) + " лет";
            var t = filtersList.Count;
            Core.filter = filtersList;
            dataGridView1.DataSource = filtersList;           
        }
    }
}