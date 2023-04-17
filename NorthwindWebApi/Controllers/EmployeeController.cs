﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Dtos;
using Northwind.Application.Repository;
using Northwind.Domain.Entities;

namespace Northwind.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IMapper mapper,IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _employeeRepository.GetAllAsync();
			var employeeData = _mapper.Map<List<CustomerDto>>(data);
			return Ok(employeeData);
			
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _employeeRepository.GetByIdAsync(id);
			var employeeData = _mapper.Map<List<CustomerDto>>(data);
			if (employeeData == null) return Ok();
			return Ok(employeeData);
			
           
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            var data = await _employeeRepository.AddAsync(employee);
			var employeeData = _mapper.Map<List<CustomerDto>>(data);
			return Ok(employeeData);
		}
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _employeeRepository.DeleteAsync(id);
			var employeeData = _mapper.Map<List<CustomerDto>>(data);
			return Ok(employeeData);
		}
        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            var data = await _employeeRepository.UpdateAsync(employee);
			var employeeData = _mapper.Map<List<CustomerDto>>(data);
			return Ok(employeeData);
		}
    }
}
