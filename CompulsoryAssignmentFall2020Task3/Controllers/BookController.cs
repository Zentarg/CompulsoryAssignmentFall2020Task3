using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment1;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompulsoryAssignmentFall2020Task3.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> bookList = new List<Book>()
        {
            new Book{Author = "AuthorTest1", Isbn13 = "1234567890123", PageNumber = 100, Title = "TitleTest1"},
            new Book{Author = "AuthorTest2", Isbn13 = "2345678901234", PageNumber = 100, Title = "TitleTest2"},
            new Book{Author = "AuthorTest3", Isbn13 = "3456789012345", PageNumber = 100, Title = "TitleTest3"},
            new Book{Author = "AuthorTest4", Isbn13 = "4567890123456", PageNumber = 100, Title = "TitleTest4"},
            new Book{Author = "AuthorTest5", Isbn13 = "5678901234567", PageNumber = 100, Title = "TitleTest5"}

        };
        
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookList;
        }

        // GET api/<BookController>/5
        [HttpGet("{isbn13}")]
        public Book Get(string isbn13)
        {
            return bookList.FirstOrDefault(b => b.Isbn13 == isbn13);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            bookList.Add(value);
        }

        // PUT api/<BookController>/5
        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Book value)
        {
            int index = bookList.FindIndex(b => b.Isbn13 == isbn13);
            value.Isbn13 = isbn13;

            bookList[index] = value;
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            bookList.RemoveAll(b => b.Isbn13 == isbn13);
        }
    }
}
