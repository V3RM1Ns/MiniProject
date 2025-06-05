using MiniProject.Models;

namespace MiniProject.Interfaces;

public interface IHumanResourceManager
{
    
    void AddDepartment(Department department);
    List<Department> GetAllDepartments();
    void EditDepartment(string oldName, string newName);
    void RemoveDepartment(string name);
    
    
    void AddEmployee(string no,string position,double salary,string departmentName);
    void RemoveEmployee(string no,string departmentName);
    void EditEmployee(string no,double salary,string position);
    List<Employee> Search(string name);
}

public class HumanResourceManager : IHumanResourceManager
{
    private List<Department> _departments = new List<Department>();

    public void AddDepartment(Department department)
    {
        _departments.Add(department);
    }

    public List<Department> GetAllDepartments()
    {
        return _departments;
    }

    public void EditDepartment(string oldName, string newName)
    {
        Department department = _departments.FirstOrDefault(d => d.Name == oldName);
        if (department != null)
        {
            department.Name = newName;
        }
    }

    public void RemoveDepartment(string name)
    {
        Department department = _departments.FirstOrDefault(d => d.Name == name);
        if (department != null)
        {
            _departments.Remove(department);
        }
    }

    public void AddEmployee(string no,string position,double salary,string departmentName)
    {
        Department department = _departments.FirstOrDefault(d => d.Name == departmentName);
        if (department != null)
        {
            Employee employee = new Employee()
            {
                No = no,
                Position = position,
                Salary = salary,
            };
            department.Employees.Add(employee);
        }
    }

    public void RemoveEmployee(string no, string departmentName)
    {
        Department department = _departments.FirstOrDefault(d => d.Name == departmentName);
        if (department != null)
        {
            Employee employee = department.Employees.FirstOrDefault(e => e.No == no);
            if (employee != null)
            {
                department.Employees.Remove(employee);
            }
        }
    }

    public void EditEmployee(string no, double salary, string position)
    {
        foreach (var department in _departments)
        {
            var employee = department.Employees.FirstOrDefault(e => e.No == no);
            if (employee != null)
            {
                employee.Salary = salary;
                employee.Position = position;
                return;
            }
        }
    }

    public List<Employee> Search(string value)
    {
        List<Employee> results = new List<Employee>();
        foreach (var department in _departments)
        {
            results.AddRange(department.Employees.Where(e =>
                e.FullName.Contains(value, StringComparison.OrdinalIgnoreCase) ||
                e.Position.Contains(value, StringComparison.OrdinalIgnoreCase)));
        }
        return results;
    }
}