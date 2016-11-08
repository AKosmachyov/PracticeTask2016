using System;
using System.Linq;
using PracticeTask2016.Entity;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace PracticeTask2016
{
    static public class Core
    {
        static private BindingList<Employee> _employees = new BindingList<Employee>();
        static public BindingList<Employee> filter = new BindingList<Employee>();

        static public BindingList<Employee> getEmployees()
        {
            return _employees;
        }

        static public void addEmployees(Employee employee)
        {
            _employees.Add(employee);
        }

        static public void saveFile(string path)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, _employees);
                fStream.Close();
            }
        }

        static public void openFile(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter binFormat = new BinaryFormatter();
                _employees.Clear();
                var fileEmployees = (BindingList<Employee>)binFormat.Deserialize(fs);
                foreach (var obj in fileEmployees)
                {
                    obj.createDate = DateTime.Now;
                    _employees.Add(obj);
                }
                fs.Close();
                filter = _employees;                         
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка открытия файла");
            }
        }

        static public void deleteEmployees(Employee employee)
        {
            _employees.Remove(employee);            
            filter.Remove(employee);         
        }

        static public BindingList<Employee> getEmployeesWithFilter(BindingList<Employee> list, string query, string field)
        {
            query = query.ToUpper();
            return new BindingList<Employee>(list.Where(x => x.address.street.ToUpper().Contains(query)).ToList());           
        }
        static public BindingList<Employee> getHouseEven(BindingList<Employee> list)
        {
            return new BindingList<Employee>(list.Where(x => x.address.house % 2 == 0).ToList());
        }

        static public string getStrMiddleAge()
        {
            int temp = 0;
            for (var i = 0; filter.Count > i; i++)
            {
                temp += DateTime.Now.Year - filter[i].birthday.Year;
            }
            if (temp != 0)
            {
                return (temp / filter.Count) + " лет";
            }
            else
            {
                return "-";
            }
        }
    }
}
