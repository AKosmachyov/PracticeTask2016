using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeTask2016.Entity;
using System.ComponentModel;

namespace PracticeTask2016.Core
{
    static public class Core
    {
       static private BindingList<Employee> _employees = new BindingList<Employee>();

       static public BindingList<Employee> getEmployees()
       {
            return _employees;
       }
       static public void addEmployees(Employee employee)
       {
            _employees.Add(employee);
       }
    }
}
