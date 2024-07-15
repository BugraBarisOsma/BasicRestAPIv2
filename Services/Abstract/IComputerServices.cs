using BasicRestAPI.Models;

namespace BasicRestAPI.Services.Abstract;

public interface IComputerServices
{
    public Task<Computer> GetComputerById(int id);
    public Task<List<Computer>> GetAllComputer();
    public Task<List<Computer>> CreateComputer(Computer computer);
    public Task<List<Computer>> DeleteComputer(int id);
    public Task<Computer> UpdateComputer(Computer computer);
    public Task<Computer> PartialUpdateComputer(Computer computer);
    
}