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
            label2.Text = Core.getStrMiddleAge();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var window = new EmployeeEditor();
            window.ShowDialog();
            textBox1_TextChanged(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                    throw new Exception("Не выделен объект для удаления");
                Core.deleteEmployees((Employee)dataGridView1.CurrentRow.DataBoundItem);
                textBox1_TextChanged(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                    throw new Exception("Не выделен объект для редактирования");
                var window = new EmployeeEditor((Employee)dataGridView1.CurrentRow.DataBoundItem);
                window.ShowDialog();
                textBox1_TextChanged(sender, e);
                dataGridView1.Refresh();            
            }             
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {   
            var filtersList = Core.getEmployees();
            if (textBox5.Text.Length > 0)
                filtersList = Core.getEmployeesWithFilter(filtersList, textBox5.Text, "address.street");
            if(radioButton2.Checked)
                filtersList = Core.getHouseEven(filtersList);

            Core.filter = filtersList;
            dataGridView1.DataSource = filtersList;           
            label2.Text = Core.getStrMiddleAge();           
        }
    }
}