﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookShopOnline.Data;
using BookShopOnline.Models;

namespace BookShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)
        {
            _context = context;

            if (!_context.Books.Any())
            {
                _context.Books.Add(new Book { Name = "Origin", Author = "Dan Brown", Price = 200, ImageUrl = "https://i.grenka.ua/shop/1/7/151/dzherelo_f1b.png" });
                _context.Books.Add(new Book { Name = "Witcher: The Last Wish", Author = "Andrzej Sapkowski", Price = 150, ImageUrl = "https://images.ua.prom.st/780654541_w0_h430_vidmak-ostannye-bazhannya.jpg" });
                _context.Books.Add(new Book { Name = "Clean Code: A Handbook of Agile Software Craftsmanship", Author = "Robert C. Martin", Price = 800, ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41jEbK-jG%2BL.jpg" });
                _context.Books.Add(new Book { Name = "Fight Club", Author = "Chuck Palahniuk", Price = 75, ImageUrl = "https://www.bookclub.ua/images/db/goods/38368_57777.jpg" });
                _context.SaveChanges();
            }
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody]Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBook", new { id = book.Id }, book);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
