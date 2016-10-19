using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracticeTask2016.Entity;

namespace PracticeTask2016
{
    public partial class EmployeeEditor : Form
    {
        public EmployeeEditor()
        {
            InitializeComponent();
        }

        public Employee _employee = new Employee();

        public Employee getCurrentEmployee()
        {
            return _employee;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            var address = new Address();
            address.street = textBox5.Text;
            address.house = textBox6.Text;
            address.apartment = textBox7.Text;
                        

            _employee.lastName = textBox1.Text;
            _employee.firstName = textBox2.Text;
            _employee.middleName = textBox3.Text;
            _employee.birthday = dateTimePicker1.Value;
            _employee.phoneNumber = textBox4.Text;
            _employee.address = address;
            this.Close();
        }
    }
}
