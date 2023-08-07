using CRUD_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using static CRUD_MongoDB.Services.EmployeeService;

namespace CRUD_MongoDB.Services
{
    public class EmployeeService : IEmployeeService
    {
            private readonly IMongoCollection<Employee> _employeeCollection;
            public IOptions<Settings> _dbSettings;
            public EmployeeService(IOptions<Settings> dbSettings)
            {
                _dbSettings = dbSettings;
                var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
                var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.Database);
                _employeeCollection = mongoDatabase.GetCollection<Employee>(dbSettings.Value.CollectionName);
            }

            public async Task<IEnumerable<Employee>> GetAllAsync()
            {
                var emp = await _employeeCollection.Find(_ => true).ToListAsync();

                return emp;
            }

            public async Task<Employee> GetById(string id)
            {
                var emp = await _employeeCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

                return emp;
            }

            public async Task CreateAsync(Employee emp)
            {
                await _employeeCollection.InsertOneAsync(emp);
            }

            public async Task Update(string id, Employee emp)
            {
                await _employeeCollection.ReplaceOneAsync(a => a.Id == id, emp);
            }

            public async Task DeleteAsync(string id)
            {
                await _employeeCollection.DeleteOneAsync(a => a.Id == id);
            }
        }
    }

