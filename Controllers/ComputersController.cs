using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicRestAPI.Models;
using BasicRestAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController(ComputerService _computerService) : ControllerBase
    {

        /// <summary>
        /// Get all computers.
        /// </summary>
        /// <param name="name">Optional name to filter products by name.</param>
        /// <returns>A list of products.</returns>
        [HttpGet]
        public async Task<List<Computer>> GetAllComputer()
        {
            return await _computerService.GetAllComputer();
        }

        /// <summary>
        /// Get a computer by Id.
        /// </summary>
        /// <param name="name">Optional name to filter products by name.</param>
        /// <returns>A list of products.</returns>
        [HttpGet("{id}")]
        public async Task<Computer> GetComputerById(int id)
        {
          return await _computerService.GetComputerById(id);
        }

        /// <summary>
        /// Add a new computer.
        /// </summary>
        /// <param name="name">Optional name to filter products by name.</param>
        /// <returns>A list of products.</returns>
        [HttpPost]
        public async Task<List<Computer>> AddComputer([FromBody] Computer computer)
        {
            return await _computerService.CreateComputer(computer);
        }

        /// <summary>
        /// Delete a computer by Id.
        /// </summary>
        /// <param name="name">Optional name to filter products by name.</param>
        /// <returns>A list of products.</returns>
        [HttpDelete("{id}")]
        public async Task<List<Computer>> DeleteComputer(int id)
        {
            return await _computerService.DeleteComputer(id); 
        }

        /// <summary>
        /// Update a computer
        /// </summary>
        /// <param name="name">Optional name to filter products by name.</param>
        /// <returns>A list of products.</returns>
        [HttpPut("{id}")]
        public async Task<Computer> UpdateComputer(int id, [FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Model state is not valid");  
            }

            var updatedComputer = _computerService.UpdateComputer(computer);
            return await updatedComputer; 
        }

        /// <summary>
        /// Update a computer (partial).
        /// </summary>
        /// <param name="name">Optional name to filter products by name.</param>
        /// <returns>A list of products.</returns>
        [HttpPatch("{id}")]
        public async Task<Computer> PartialUpdateComputer(int id, [FromBody] Computer computer)
        {
            return await _computerService.PartialUpdateComputer(computer);
        }


    }
}
