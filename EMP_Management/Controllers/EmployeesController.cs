using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMP_Management.Data;
using EMP_Management.Models;
using System.Text;

namespace EMP_Management.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeesController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            //var employees=await _context.Employee.ToListAsync();
            // if(employees==null)
            // {
            //     return NotFound();  
            // }
            // return View(employees);
            try
            {
                var employees =  _context.Employee
                    .Select(e => new Employees
                    {
                        Id = e.Id,
                        FirstName = e.FirstName ?? "", 
                        LastName = e.LastName ?? "",
                        Email = e.Email ?? "",
                        PhoneNumber = e.PhoneNumber ?? "",
                        Address = e.Address != null ? new Address
                        {
                            addLine1 = e.Address.addLine1 ?? "",
                            addLine2 = e.Address.addLine2 ?? "",
                            City = e.Address.City ?? "",
                            Country = e.Address.Country ?? ""
                        } : new Address(),
                        Designation = e.Designation ?? "",
                        EmployeeId = e.EmployeeId ?? ""
                    })
                    .ToList();

                return View(employees);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var employees = await _context.Employee
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (employees == null)
            //{
            //    return NotFound();
            //}

            //return View(employees);
            var employee = _context.Employee
    .Where(e => e.Id == id)
    .Select(e => new Employees
    {
        Id = e.Id,
        FirstName = e.FirstName ?? "",
        LastName = e.LastName ?? "",
        Email = e.Email ?? "",
        PhoneNumber = e.PhoneNumber ?? "",
        Address = e.Address != null ? new Address
        {
            addLine1 = e.Address.addLine1 ?? "",
            addLine2 = e.Address.addLine2 ?? "",
            City = e.Address.City ?? "",
            Country = e.Address.Country ?? ""
        } : new Address(),
        Designation = e.Designation ?? "",
        EmployeeId = e.EmployeeId ?? ""
    })
    .FirstOrDefault();

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,Designation,EmployeeId,Address")] Employees employees)
        {
            string empIdString = "EMP";
            int PreviousEmpId;
            var empdetails = _context.Employee.OrderBy(m => m.Id);
            var PreviousId = empdetails.LastOrDefault();
          






            if (ModelState.IsValid)
            {
                if (PreviousId == null)
                {
                    employees.EmployeeId = "EMP001";
                 }
                else
                {
                     PreviousEmpId = PreviousId.Id + 1;

                    employees.EmployeeId = empIdString + PreviousEmpId.ToString("D3");
                }
                

                _context.Add(employees);
                //await _context.SaveChangesAsync();
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var employees = await _context.Employee.FindAsync(id);
            var employees = _context.Employee
    .Where(e => e.Id == id)
    .Select(e => new Employees
    {
        Id = e.Id,
        FirstName = e.FirstName ?? "",
        LastName = e.LastName ?? "",
        Email = e.Email ?? "",
        PhoneNumber = e.PhoneNumber ?? "",
        Address = e.Address != null ? new Address
        {
            addLine1 = e.Address.addLine1 ?? "",
            addLine2 = e.Address.addLine2 ?? "",
            City = e.Address.City ?? "",
            Country = e.Address.Country ?? ""
        } : new Address(),
        Designation = e.Designation ?? "",
        EmployeeId = e.EmployeeId ?? ""
    })
    .FirstOrDefault();
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Designation,EmployeeId,Address")] Employees employees)
        {
            if (id != employees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(employees.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employees = await _context.Employee.FindAsync(id);
            if (employees != null)
            {
                _context.Employee.Remove(employees);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
        public async Task<IActionResult> FilterByDesignation(List<string> designationFilter)
        {
            IQueryable<EMP_Management.Models.Employees> employeesQuery = _context.Employee;
            //var allEmployees= employeesQuery.ToList();
            if (!string.IsNullOrEmpty(designationFilter[0]))
            {
                employeesQuery = employeesQuery.Where(e => e.Designation == designationFilter[0]);
            }

            //var filteredEmp= employeesQuery.ToList();
            //var viewModel = new EMP_Management.Models.EmpViewModel
            //{
            //    Employees = filteredEmp,
            //    Designations =  allEmployees.Select(e => e.Designation).Distinct().ToList(),
            //    SelectedDesignation = designationFilter
            //};

            var employees =  employeesQuery.ToList();

            return View("Index", employees);
        }
        public IActionResult ExportCsv()
        {
            var employees = _context.Employee.ToList();

            var sb = new StringBuilder();
            sb.AppendLine("FirstName,LastName,Email,PhoneNumber,Designation,EmployeeId");
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName},{employee.LastName},{employee.Email},{employee.PhoneNumber},{employee.Designation},{employee.EmployeeId}");
            }

            
            byte[] data = Encoding.UTF8.GetBytes(sb.ToString());
            return File(data, "text/csv", "employees.csv");
        }

    }
}
