using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using System.Text;
using Microsoft.Extensions.Logging;

namespace BookStore.Pages.Books
{
    public class IndexModel : PageModel
    {
        const string SUBJECT = "List of Books - Example";
        private readonly BookStore.Models.BookStoreContext _context;
        private readonly BookStore.Services.IEmailService _emailService;
        

        public IndexModel(BookStore.Models.BookStoreContext context, BookStore.Services.IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;           
        }

        public IList<Book> Books { get;set; }        

        public async Task OnGetAsync()
        {
            Books = await _context.Book.ToListAsync();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var body = GetEmailBody(Customer.CustomerName);
            await _emailService.SendMail(SUBJECT, Customer.CustomerEmail, body);

            return RedirectToPage("./Index");
        }

        private string GetEmailBody(string customerName)
        {
            StringBuilder body = new StringBuilder();

            body.AppendLine(string.Format("Dear {0}:", customerName));
            body.AppendLine("We are sending you the list of books in our store.");

            var books = _context.Book.ToList();

            foreach (Book book in books)
            {
                body.AppendLine().AppendFormat("* Book Name: {0} - Author: {1}", book.Name, book.Author);
            }

            return body.ToString();
        }
    }
}
