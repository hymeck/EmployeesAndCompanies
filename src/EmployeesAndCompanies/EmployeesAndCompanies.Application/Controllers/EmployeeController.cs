﻿using System.Threading.Tasks;
using EmployeesAndCompanies.Application.Other;
using EmployeesAndCompanies.Application.ViewModels;
using EmployeesAndCompanies.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAndCompanies.Application.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICompanyService _companyService;

        public EmployeeController(IEmployeeService employeeService, ICompanyService companyService) =>
            (_employeeService, _companyService) = (employeeService, companyService);

        [HttpGet]
        public async Task<IActionResult> Index() =>
            View(await _employeeService.GetAllAsync());


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewData["companies"] = (await _companyService.GetNamesAsync()).ToSelectList();
            
            return View("Employee", EmployeeViewModel.Empty);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel vm)
        {
            // todo: adding logic
            // return View("Employee", EmployeeViewModel.Empty);
            return await Add();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["companies"] = (await _companyService.GetNamesAsync()).ToSelectList();
            
            var entity = await _employeeService.GetAsync(id);
            var vm = EmployeeViewModel.From(entity);
            return View("Employee", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel vm)
        {
            ViewData["companies"] = (await _companyService.GetNamesAsync()).ToSelectList();
            // todo: editing logic
            // if all is ok -> RedirectToAction("Index");
            return View("Employee", vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            // todo: deleting logic
            return RedirectToAction("Index");
        }

        public IActionResult RemoveCompany(int id, string companyName)
        {
            throw new System.NotImplementedException();
        }
    }
}