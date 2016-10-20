using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeTask2016.Entity;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PracticeTask2016
{
    static public class Core
    {
        static private BindingList<Employee> _employees = new BindingList<Employee>();

        static public BindingList<Employee> getEmployees()
        {
            return new BindingList<Employee>(_employees);
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
        }

        static public void deleteEmployees(Employee employee)
        {
            _employees.Remove(employee);            
        }
    }
}
