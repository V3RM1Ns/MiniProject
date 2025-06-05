namespace MiniProject.Models;

public class Department
{
    string _name { get; set; }
    public string Name
    {
        get => _name;
        set
        {
            if (value.Length >= 2)
            {
               _name=value;
            }
            throw new Exception("Department must contain more than 2 characters");
        }
    }
    
    int _workerLimit { get; set; }
    public int WorkerLimit
    {
        get => _workerLimit;
        set
        {
            if (value >= 1)
            {
                _workerLimit=value;
            }
            throw new Exception("Worker limit must be greater than 1");
        }
    }
    
    
    double _salaryLimit { get; set; }
    public double SalaryLimit
    {
        get=> _salaryLimit;
        set
        {
            if (value >= 250)
            {
                _salaryLimit=value;
            }
            throw new Exception("Salary limit must be greater than 250");
        }
    }
    
    
    public List<Employee> Employees { get; set; }
    
    public void CalcSalaryAvarage()
    {

    }
}