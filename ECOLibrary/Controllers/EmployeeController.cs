using ECOLibrary.BusinessLayer.Services.EmployeeService;
using ECOLibrary.DTOs.Employee.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ECOLibrary.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employeesWithLoanCount = await _employeeService.GetAllEmployeesWithLoanCountAsync();
            return View(employeesWithLoanCount);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Personel eklerken bir hata oluştu. Lütfen bilgileri kontrol edin.";
                return RedirectToAction("Index");
            }

            try
            {
                await _employeeService.AddEmployeeAsync(request);
                TempData["Message"] = "Yeni personel başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> SetInactive(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["Error"] = "Geçersiz personel ID.";
                return RedirectToAction("Index");
            }

            try
            {
                await _employeeService.SetEmployeeInactiveAsync(id);
                TempData["Message"] = "Personel başarıyla pasif hale getirildi.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Index");
        }


    }
}
