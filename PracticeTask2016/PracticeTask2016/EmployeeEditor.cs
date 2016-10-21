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

            this.Text = "Редактирование сотрудников";
            _employee = employee;

            textBox1.Text = employee.lastName;
            textBox2.Text = employee.firstName;
            textBox3.Text = employee.middleName;
            dateTimePicker1.Value = employee.birthday;
            textBox4.Text = employee.phoneNumber;            
            textBox5.Text = employee.address.street;
            textBox6.Text = employee.address.house.ToString();
            textBox7.Text = employee.address.apartment.ToString();           
        }

        private Employee _employee = new Employee();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validateEntity();

                _employee.address.street = textBox5.Text;
                _employee.address.house = Convert.ToByte(textBox6.Text);
                _employee.address.apartment = Convert.ToByte(textBox7.Text);

                _employee.lastName = textBox1.Text;
                _employee.firstName = textBox2.Text;
                _employee.middleName = textBox3.Text;
                _employee.birthday = dateTimePicker1.Value;
                _employee.phoneNumber = textBox4.Text;

                Core.addEmployees(_employee);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validateEntity()
        {
            var message = "Ошибка ввода:";

            if ((textBox1.Text.Trim(' ')).Length < 1)
                message += " Фамилия,";
            if ((textBox2.Text.Trim(' ')).Length < 1)
                message += " Имя,";
            if ((textBox3.Text.Trim(' ')).Length < 1)
                message += " Отчество,";
            if ((textBox4.Text.Trim(' ')).Length < 12)
                message += " Мобильный номер,";
            if ((textBox5.Text.Trim(' ')).Length < 9)
                message += " Улица,";
            if ((textBox6.Text.Trim(' ')).Length < 1)
                message += " Дом,";
            if ((textBox7.Text.Trim(' ')).Length < 1)
                message += " Квартира,";
            if (dateTimePicker1.Value.Ticks > DateTime.Today.AddYears(-14).Ticks ||
                dateTimePicker1.Value.Ticks < DateTime.Today.AddYears(-130).Ticks)
                message += " Дата рождения,";
            if (message.Length > 13)
            {
                message = message.Remove(message.Length - 1);
                throw new Exception(message);
            }
        }
    }
}
