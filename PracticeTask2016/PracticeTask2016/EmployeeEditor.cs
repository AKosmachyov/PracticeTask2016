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

        public EmployeeEditor(Employee employee)
        {
            InitializeComponent();

            textBox1.Text = employee.lastName;
            textBox2.Text = employee.firstName;
            textBox3.Text = employee.middleName;
            dateTimePicker1.Value = employee.birthday;
            textBox4.Text = employee.phoneNumber;            
            textBox5.Text = employee.address.street;
            textBox6.Text = employee.address.house;
            textBox7.Text = employee.address.apartment;           
        }

        public Employee _employee;

        public Employee getCurrentEmployee()
        {
            return _employee;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _employee = new Employee();
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
