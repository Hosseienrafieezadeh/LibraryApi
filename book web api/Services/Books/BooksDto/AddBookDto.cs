using System.ComponentModel.DataAnnotations;

namespace book_web_api.Services.Books.BooksDto
{
    public class AddBookDto
    {
     
        public string Name { get; set; }
       
        public DateTime DateOfRelease { get; set; }
       
        public int Inventory { get; set; }
       
        public int WriterId { get; set; }
       
        public int ShelfId { get; set; }
    }
}
