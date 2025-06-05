namespace MiniProject.Models;

public class Employee
{
    public string No { get; set; }
    public string FullName { get; set; }
    
    string _position { get; set; }
    public string Position
    {
        get => _position;
        set
        {
            if (value.Length >= 2)
            {
                _position = value;
            }
            throw new Exception("Position must contain more than 2 characters");
        }
    }
    
    private double _salary { get; set; }
    public double Salary
    {
        get=> _salary;

        set
        {
            if (value >= 250)
            {
                _salary = value;
            }
            throw new Exception("Salary must contain more than 250");
        }
    }
    
    public string DepartmentName { get; set; }
}