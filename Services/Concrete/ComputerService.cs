using BasicRestAPI.Contexts;
using BasicRestAPI.Extensions;
using BasicRestAPI.Models;
using BasicRestAPI.Services.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicRestAPI.Services
{
    public class ComputerService : IComputerServices
    {
        private readonly PostgreDbContext _context;
        private readonly IHttpContextAccessor _response;
        public ComputerService(PostgreDbContext context,  IHttpContextAccessor response)
        {
            _context = context;
            _response = response;
        }    

        public async Task<List<Computer>> GetAllComputer()
        {
           return _context.Computers.ToList();   
            
        }
        public async Task<Computer> GetComputerById(int id)
        {
            Computer computer = await _context.Computers.FirstOrDefaultAsync(x => x.Id == id);
            if (computer == null)
            {
                _response.HttpContext.Response.WriteJsonErrorAsync(404, "Computer not found");
                
            }
            return computer;
        }
        public async Task<List<Computer>> CreateComputer(Computer computer)
        {
            if (computer == null) 
            {
                _response.HttpContext.Response.WriteJsonErrorAsync(404, "Computer not found");
            }

            _context.Computers.AddAsync(computer);
            _context.SaveChangesAsync();
            return await _context.Computers.ToListAsync();
        }
        public async Task<List<Computer>> DeleteComputer(int id)
        {
            Computer computer = await _context.Computers.FirstOrDefaultAsync(x => x.Id == id);
            if (computer == null)
            {
                _response.HttpContext.Response.WriteJsonErrorAsync(404, "Computer not found");
            }
            
            _context.Computers.Remove(computer);
           await _context.SaveChangesAsync();
           return await _context.Computers.ToListAsync();
        }

        public async Task<Computer> UpdateComputer(Computer computer)
        {
            var existingComputer = await _context.Computers.FirstOrDefaultAsync(x=>x.Id==computer.Id);
            if (existingComputer == null)
            {
                _response.HttpContext.Response.WriteJsonErrorAsync(404, "Computer not found");
            }
            existingComputer.Id = computer.Id;  
            existingComputer.Model = computer.Model;
            existingComputer.Price = computer.Price;
            existingComputer.Brand = computer.Brand;

           
            await _context.SaveChangesAsync();
            return existingComputer;

        } 
        public async Task<Computer> PartialUpdateComputer(Computer computer)
        {
            var existingComputer = await _context.Computers.FirstOrDefaultAsync(x=>x.Id==computer.Id);
            if (existingComputer == null)
            {
                _response.HttpContext.Response.WriteJsonErrorAsync(404, "Computer not found");
            }

            if (!string.IsNullOrEmpty(computer.Brand))
            {
                existingComputer.Brand = computer.Brand;
            }

            if (computer.Price != null)
            {
                existingComputer.Price = computer.Price;
            }

            if (!string.IsNullOrEmpty(computer.Model))
            {
                existingComputer.Model = computer.Model;
            }

            await _context.SaveChangesAsync();
            return existingComputer;
        }


    }
}
