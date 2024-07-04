using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeekOneHomework.Models;

namespace WeekOneHomework.Services
{
    public class ComputerService
    {
        
        private readonly List<Computer> computers;
        public ComputerService() {
          computers = new List<Computer> 
            {
             new Computer {Id=1,Brand="Asus" , Model ="XK790",Price=28930},
             new Computer {Id=2,Brand="Casper" , Model ="TK114",Price=25768},
             new Computer {Id=3,Brand="MSI" , Model ="ALP178",Price=32443}
            
            };
        }    

        public async Task<List<Computer>> GetAllComputer()
        {
            return computers;
        }
        public async Task<Computer> GetComputerById(int id)
        {
            Computer computer = computers.FirstOrDefault(x => x.Id == id);
            return computer;
        }
        public async Task<List<Computer>> CreateComputer(Computer computer)
        {
            if (computer == null) 
            {
                throw new ArgumentNullException();
            }

            computers.Add(computer);
            return computers;
        }
        public async Task<List<Computer>> DeleteComputer(int id)
        {
            if (computers.Find(x => x.Id == id) == null)
            {
                throw new NullReferenceException();
            }
            computers.RemoveAll(x => x.Id == id);
            return computers;
        }

        public async Task<Computer> UpdateComputer(Computer computer)
        {
            var existingComputer = computers.FirstOrDefault(x=>x.Id==computer.Id);
            if (existingComputer == null)
            {
                throw new NullReferenceException();
            }
            existingComputer.Id = computer.Id;  
            existingComputer.Model = computer.Model;
            existingComputer.Price = computer.Price;
            existingComputer.Brand = computer.Brand;    

            return existingComputer;

        } 
        public async Task<Computer> PartialUpdateComputer(Computer computer)
        {
            var existingComputer = computers.FirstOrDefault(x => x.Id == computer.Id);
            if (existingComputer == null)
            {
                 throw new NullReferenceException();
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

            return existingComputer;
        }


    }
}
