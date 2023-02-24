


using Bogus;
using Newtonsoft.Json;

GenerateFakeEmployeeData();

static void GenerateFakeEmployeeData()
{
    var departments = new [] { "Manufacturing", "Stores", "BackOffice", "Billing", "Insurance"};
    var fakeEmployees = new Faker<Employee>();
    fakeEmployees.RuleFor(x => x.FirstName, f => f.Name.FirstName());
    fakeEmployees.RuleFor(x => x.LastName, f => f.Name.LastName());
    fakeEmployees.RuleFor(x => x.EmployeeId, f => f.Random.Int(10000,20000));
    fakeEmployees.RuleFor(x => x.Department, f => f.PickRandom(departments));
    fakeEmployees.RuleFor(x => x.DateOfBirth, f => f.Date.Past(50).ToString("MM/dd/yyyy"));
    var fakeEmployeeData= fakeEmployees.Generate(3);
    Console.WriteLine(JsonConvert.SerializeObject(fakeEmployeeData));
    Console.ReadLine();
}


public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string Department { get; set; }

}
