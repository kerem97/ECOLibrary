using ECOLibrary.BusinessLayer.Services.BookService;
using ECOLibrary.DTOs.Book.Requests;
using ECOLibrary.DTOs.Book.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ECOLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksWithCopiesAsync();
            return View(books);
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            try
            {
                await _bookService.AddBookAsync(request);
                ViewBag.Message = "Kitap başarıyla eklendi veya kopyası oluşturuldu.";
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Error = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
