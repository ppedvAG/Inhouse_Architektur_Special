using NSubstitute;

namespace BooksManager.Tests
{
    public class BooksManagerTests
    {
        [Fact]
        public void GetAuthorWithMostPages_two_authors_fred_wins()
        {
            var bm = new BooksManager(new TestBookService());

            var result = bm.GetAuthorWithMostPages();

            Assert.Equal("Fred", result);
        }

        [Fact]
        public void GetAuthorWithMostPages_3_authors_fred_wins_NSUB()
        {
            var bookService = Substitute.For<IBooksService>();
            var books = new List<Book>
            {
                new Book() { Author = "Wilma", PageCount = 500 },
                new Book() { Author = "Fred", PageCount = 300 },
                new Book() { Author = "Barney", PageCount = 200 },
                new Book() { Author = "Fred", PageCount = 300 }
            };
            bookService.GetBooks().Returns(books);
            var bm = new BooksManager(bookService);

            var result = bm.GetAuthorWithMostPages();

            Assert.Equal("Fred", result);

            bookService.Received(1).GetBooks();
        }


    }

    public class TestBookService : IBooksService
    {
        public IEnumerable<Book> GetBooks()
        {
            yield return new Book() { Author = "Wilma", PageCount = 500 };
            yield return new Book() { Author = "Fred", PageCount = 300 };
            yield return new Book() { Author = "Barney", PageCount = 200 };
            yield return new Book() { Author = "Fred", PageCount = 300 };
        }
    }
}