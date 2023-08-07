using CRUD_MongoDB.Models;

namespace CRUD_MongoDB.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetById(string id);
        Task CreateAsync(Employee employee);
        Task Update(string id, Employee employee);
        Task DeleteAsync(string id);
    }
}
