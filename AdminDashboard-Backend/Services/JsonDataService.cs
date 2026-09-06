using System.Text.Json;
using AdminDashboardAPI.Models;

namespace AdminDashboardAPI.Services;

public class JsonDataService
{
    private readonly string _dataPath;
    private readonly IWebHostEnvironment _env;
    private readonly object _lock = new object();
    private readonly Random _random = new Random();

    public JsonDataService(IWebHostEnvironment env)
    {
        _env = env;
        _dataPath = Path.Combine(_env.ContentRootPath, "Data", "database.json");
        EnsureDataFileExists();
    }

    private void EnsureDataFileExists()
    {
        var directory = Path.GetDirectoryName(_dataPath);
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory!);

        if (!File.Exists(_dataPath))
        {
            var initialData = GenerateMockData();
            var json = JsonSerializer.Serialize(initialData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_dataPath, json);
        }
    }

    private DatabaseData GenerateMockData()
    {
        var users = GenerateUsers(50);
        var contacts = GenerateContacts(100);
        var invoices = GenerateInvoices(80);
        var tasks = GenerateTasks(60);

        return new DatabaseData
        {
            Users = users,
            Contacts = contacts,
            Invoices = invoices,
            Tasks = tasks
        };
    }

    #region Generate Users - English Data
    private List<User> GenerateUsers(int count)
    {
        var users = new List<User>();
        var firstNames = new[] { "James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Thomas", "Charles",
                                 "Mary", "Patricia", "Jennifer", "Linda", "Barbara", "Elizabeth", "Susan", "Jessica", "Sarah", "Karen",
                                 "Daniel", "Matthew", "Anthony", "Donald", "Mark", "Paul", "Steven", "Andrew", "Kenneth", "Joshua",
                                 "George", "Kevin", "Brian", "Edward", "Ronald", "Timothy", "Jason", "Jeffrey", "Ryan", "Jacob",
                                 "Gary", "Nicholas", "Eric", "Jonathan", "Stephen", "Larry", "Justin", "Scott", "Brandon", "Benjamin" };
        
        var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
                               "Hernandez", "Lopez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Lee",
                               "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson", "Walker",
                               "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores", "Green",
                               "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts", "Turner" };
        
        var cities = new[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", 
                            "Dallas", "San Jose", "Austin", "Jacksonville", "Fort Worth", "Columbus", "Charlotte", "San Francisco",
                            "Indianapolis", "Seattle", "Denver", "Washington", "Boston", "El Paso", "Nashville", "Detroit", "Oklahoma City",
                            "Portland", "Las Vegas", "Memphis", "Louisville", "Baltimore", "Milwaukee", "Albuquerque", "Tucson", "Fresno",
                            "Sacramento", "Mesa", "Atlanta", "Kansas City", "Colorado Springs", "Omaha", "Raleigh", "Miami", "Oakland",
                            "Minneapolis", "Tulsa", "Wichita", "New Orleans", "Arlington", "Cleveland", "Bakersfield" };
        
        var accessLevels = new[] { "Admin", "User", "Manager", "Supervisor", "Editor", "Viewer" };

        for (int i = 1; i <= count; i++)
        {
            var firstName = firstNames[_random.Next(firstNames.Length)];
            var lastName = lastNames[_random.Next(lastNames.Length)];
            var fullName = $"{firstName} {lastName}";
            
            var user = new User
            {
                Id = i,
                Name = fullName,
                Email = $"{firstName.ToLower()}.{lastName.ToLower()}{_random.Next(100, 999)}@example.com",
                Age = _random.Next(18, 65),
                Phone = $"+1{_random.Next(200, 999)}{_random.Next(1000000, 9999999)}",
                Access = accessLevels[_random.Next(accessLevels.Length)],
                CreatedAt = DateTime.Now.AddDays(-_random.Next(0, 365))
            };
            users.Add(user);
        }
        return users;
    }
    #endregion

    #region Generate Contacts - English Data
    private List<Contact> GenerateContacts(int count)
    {
        var contacts = new List<Contact>();
        var firstNames = new[] { "James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Thomas", "Charles",
                                 "Mary", "Patricia", "Jennifer", "Linda", "Barbara", "Elizabeth", "Susan", "Jessica", "Sarah", "Karen",
                                 "Daniel", "Matthew", "Anthony", "Donald", "Mark", "Paul", "Steven", "Andrew", "Kenneth", "Joshua",
                                 "George", "Kevin", "Brian", "Edward", "Ronald", "Timothy", "Jason", "Jeffrey", "Ryan", "Jacob",
                                 "Emma", "Olivia", "Ava", "Isabella", "Sophia", "Mia", "Charlotte", "Amelia", "Evelyn", "Abigail" };
        
        var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
                               "Hernandez", "Lopez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Lee",
                               "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson", "Walker",
                               "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores", "Green" };
        
        var cities = new[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", 
                            "Dallas", "San Jose", "Austin", "Jacksonville", "Fort Worth", "Columbus", "Charlotte", "San Francisco",
                            "Indianapolis", "Seattle", "Denver", "Washington", "Boston", "El Paso", "Nashville", "Detroit", "Oklahoma City",
                            "Portland", "Las Vegas", "Memphis", "Louisville", "Baltimore", "Milwaukee", "Albuquerque", "Tucson", "Fresno",
                            "Sacramento", "Mesa", "Atlanta", "Kansas City", "Colorado Springs", "Omaha", "Raleigh", "Miami", "Oakland" };
        
        var streets = new[] { "Main Street", "Oak Avenue", "Maple Drive", "Cedar Lane", "Elm Street", "Pine Road", "Lake View Drive",
                             "Hillcrest Avenue", "Sunset Boulevard", "Park Avenue", "Broadway", "Fifth Avenue", "Madison Avenue",
                             "Wall Street", "Michigan Avenue", "Las Vegas Boulevard", "Bourbon Street", "Lombard Street",
                             "Pennsylvania Avenue", "Hollywood Boulevard", "Ocean Drive", "Lincoln Road", "Wilshire Boulevard",
                             "Rodeo Drive", "Santa Monica Boulevard" };

        for (int i = 1; i <= count; i++)
        {
            var firstName = firstNames[_random.Next(firstNames.Length)];
            var lastName = lastNames[_random.Next(lastNames.Length)];
            var fullName = $"{firstName} {lastName}";
            var city = cities[_random.Next(cities.Length)];
            var streetNumber = _random.Next(100, 9999);
            
            var contact = new Contact
            {
                Id = i,
                Name = fullName,
                Email = $"{firstName.ToLower()}.{lastName.ToLower()}{_random.Next(100, 999)}@company.com",
                Age = _random.Next(20, 70),
                Phone = $"+1{_random.Next(200, 999)}{_random.Next(1000000, 9999999)}",
                Address = $"{streetNumber} {streets[_random.Next(streets.Length)]}, {city}",
                City = city,
                ZipCode = $"{_random.Next(10000, 99999)}",
                RegistrarId = _random.Next(1, 20),
                CreatedAt = DateTime.Now.AddDays(-_random.Next(0, 730))
            };
            contacts.Add(contact);
        }
        return contacts;
    }
    #endregion

    #region Generate Invoices - English Data
    private List<Invoice> GenerateInvoices(int count)
    {
        var invoices = new List<Invoice>();
        var companyNames = new[] { "TechCorp Inc.", "Global Solutions", "Digital Works", "Innovation Labs", "Cloud Systems",
                                  "DataFlow Technologies", "SecureNet", "Smart Solutions", "Future Systems", "Quantum Tech",
                                  "Apex Digital", "Nova Innovations", "Stellar Systems", "Zenith Technologies", "Pulse Solutions",
                                  "Core Networks", "Vanguard Systems", "Elite Technologies", "Prime Solutions", "Summit Systems",
                                  "Titan Industries", "Horizon Technologies", "Optimus Solutions", "Nexus Systems", "Eclipse Tech" };
        
        var firstNames = new[] { "James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Thomas", "Charles",
                                 "Mary", "Patricia", "Jennifer", "Linda", "Barbara", "Elizabeth", "Susan", "Jessica", "Sarah", "Karen",
                                 "Daniel", "Matthew", "Anthony", "Donald", "Mark", "Paul", "Steven", "Andrew", "Kenneth", "Joshua" };
        
        var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
                               "Hernandez", "Lopez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Lee" };

        for (int i = 1; i <= count; i++)
        {
            var company = companyNames[_random.Next(companyNames.Length)];
            var firstName = firstNames[_random.Next(firstNames.Length)];
            var lastName = lastNames[_random.Next(lastNames.Length)];
            
            var invoice = new Invoice
            {
                Id = i,
                Name = $"Invoice {company} - #{_random.Next(1000, 9999)}",
                Email = $"{firstName.ToLower()}.{lastName.ToLower()}{_random.Next(10, 99)}@business.com",
                Phone = $"+1{_random.Next(200, 999)}{_random.Next(1000000, 9999999)}",
                Cost = Math.Round((decimal)(_random.NextDouble() * 50000 + 1000), 2),
                Date = DateTime.Now.AddDays(-_random.Next(0, 180)),
                CreatedAt = DateTime.Now.AddDays(-_random.Next(0, 730))
            };
            invoices.Add(invoice);
        }
        return invoices;
    }
    #endregion

    #region Generate Tasks - English Data
    private List<Models.Task> GenerateTasks(int count)
    {
        var tasks = new List<Models.Task>();
        var taskTitles = new[] { "Prepare Financial Report", "Review Contracts", "Develop Website", "Data Analysis",
                                "Create Presentation", "Employee Training", "System Update", "Performance Review",
                                "Budget Planning", "Strategic Planning", "Project Implementation", "Quality Control",
                                "Process Improvement", "Application Development", "Team Management", "Digital Marketing",
                                "Content Management", "Market Analysis", "Client Communication", "Report Preparation" };
        
        var descriptions = new[] { "Urgent task requiring completion within 3 days", "Monthly routine task", "Task requiring coordination with team",
                                  "High priority strategic task", "Development task to improve performance", "Organizational and administrative task",
                                  "Technical task requiring specialized expertise", "Marketing task for new product launch", "Financial task for reporting",
                                  "Training task to improve employee skills", "Research and analysis task", "Executive task for major project" };

        for (int i = 1; i <= count; i++)
        {
            var title = taskTitles[_random.Next(taskTitles.Length)];
            var desc = descriptions[_random.Next(descriptions.Length)];
            var status = _random.Next(0, 3); // 0=New, 1=In Progress, 2=Completed
            
            var task = new Models.Task
            {
                Id = i,
                Title = $"{title} - #{_random.Next(1, 100)}",
                Description = $"{desc} (Created on {DateTime.Now.AddDays(-_random.Next(0, 90)):MM/dd/yyyy})",
                Status = status,
                DueDate = status < 2 ? DateTime.Now.AddDays(_random.Next(1, 30)) : DateTime.Now.AddDays(-_random.Next(1, 10)),
                CreatedAt = DateTime.Now.AddDays(-_random.Next(0, 365))
            };
            tasks.Add(task);
        }
        return tasks;
    }
    #endregion

    // ==================== Load & Save Methods ====================

    private DatabaseData LoadData()
    {
        lock (_lock)
        {
            var json = File.ReadAllText(_dataPath);
            return JsonSerializer.Deserialize<DatabaseData>(json) ?? new DatabaseData();
        }
    }

    private void SaveData(DatabaseData data)
    {
        lock (_lock)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_dataPath, json);
        }
    }

    // ==================== Get Methods ====================

    // Users
    public List<User> GetUsers() => LoadData().Users;
    public User? GetUserById(int id) => LoadData().Users.FirstOrDefault(u => u.Id == id);

    // Contacts
    public List<Contact> GetContacts() => LoadData().Contacts;
    public Contact? GetContactById(int id) => LoadData().Contacts.FirstOrDefault(c => c.Id == id);

    // Invoices
    public List<Invoice> GetInvoices() => LoadData().Invoices;
    public Invoice? GetInvoiceById(int id) => LoadData().Invoices.FirstOrDefault(i => i.Id == id);

    // Tasks
    public List<Models.Task> GetTasks() => LoadData().Tasks;
    public Models.Task? GetTaskById(int id) => LoadData().Tasks.FirstOrDefault(t => t.Id == id);

    // ==================== Add Methods ====================
    
    public void AddUser(User user)
    {
        var data = LoadData();
        user.Id = data.Users.Count > 0 ? data.Users.Max(u => u.Id) + 1 : 1;
        data.Users.Add(user);
        SaveData(data);
    }

    public void AddContact(Contact contact)
    {
        var data = LoadData();
        contact.Id = data.Contacts.Count > 0 ? data.Contacts.Max(c => c.Id) + 1 : 1;
        data.Contacts.Add(contact);
        SaveData(data);
    }

    public void AddInvoice(Invoice invoice)
    {
        var data = LoadData();
        invoice.Id = data.Invoices.Count > 0 ? data.Invoices.Max(i => i.Id) + 1 : 1;
        data.Invoices.Add(invoice);
        SaveData(data);
    }

    public void AddTask(Models.Task task)
    {
        var data = LoadData();
        task.Id = data.Tasks.Count > 0 ? data.Tasks.Max(t => t.Id) + 1 : 1;
        data.Tasks.Add(task);
        SaveData(data);
    }
}

public class DatabaseData
{
    public List<User> Users { get; set; } = new();
    public List<Contact> Contacts { get; set; } = new();
    public List<Invoice> Invoices { get; set; } = new();
    public List<Models.Task> Tasks { get; set; } = new();
}