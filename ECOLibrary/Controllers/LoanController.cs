using ECOLibrary.BusinessLayer.Services.BookService;
using ECOLibrary.BusinessLayer.Services.EmployeeService;
using ECOLibrary.BusinessLayer.Services.LoanService;
using ECOLibrary.DTOs.Loan.Requests;
using Microsoft.AspNetCore.Mvc;

public class LoanController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IBookService _bookService;
    private readonly ILoanService _loanService;

    public LoanController(IEmployeeService employeeService, ILoanService loanService, IBookService bookService)
    {
        _employeeService = employeeService;
        _loanService = loanService;
        _bookService = bookService;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var activeLoans = await _loanService.GetActiveLoansAsync();
        return View(activeLoans);
    }
    [HttpGet]
    public async Task<IActionResult> History()
    {
        var returnedLoans = await _loanService.GetReturnedLoansAsync();
        return View(returnedLoans);
    }


    [HttpGet]
    public async Task<IActionResult> CreateLoan(string bookId)
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        ViewBag.Employees = employees;

        var book = await _bookService.GetBookByIdAsync(bookId);
        if (book == null)
        {
            ViewBag.Error = "Kitap bulunamadı.";
            return RedirectToAction("Index", "Book");
        }

        var loanCreateRequest = new LoanCreateRequest
        {
            LoanDate = DateTime.Now
        };

        return View(loanCreateRequest);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLoan(LoanCreateRequest request)
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        ViewBag.Employees = employees;

        if (!ModelState.IsValid)
        {
            return View(request);
        }

        try
        {
            await _loanService.CreateLoanAsync(request);
            ViewBag.Message = "Kitap başarıyla ödünç verildi.";
            return RedirectToAction("Index", "Book");
        }
        catch (InvalidOperationException ex)
        {
            ViewBag.Error = ex.Message;
            return View(request);
        }
    }

    [HttpPost]
    public async Task<IActionResult> ReturnLoan(string loanId)
    {
        try
        {
            await _loanService.ReturnLoanAsync(loanId);
            TempData["Message"] = "Kitap başarıyla geri alındı.";
        }
        catch (InvalidOperationException ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction("Index");
    }



}


