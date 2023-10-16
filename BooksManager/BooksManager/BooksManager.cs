﻿
namespace BooksManager
{
    public class BooksManager
    {
        private readonly IBooksService bookService;

        public BooksManager(IBooksService bookService) 
        {
            this.bookService = bookService;
        }

        public string? GetAuthorWithMostPages()
        {
            IEnumerable<Book> books = bookService.GetBooks();

            var authorPageCounts = books
                .GroupBy(book => book.Authors)
                .Select(group => new
                {
                    Author = group.Key,
                    TotalPages = group.Sum(book => book.PageCount)
                })
                .OrderByDescending(item => item.TotalPages)
                .FirstOrDefault();

            return authorPageCounts?.Author;
        }

    }



}
