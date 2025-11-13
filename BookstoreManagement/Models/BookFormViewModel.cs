using System.Collections.Generic;

namespace OnlineBookstoreManagement.Models
{
    public class BookFormViewModel
    {
        public BookViewModel Book { get; set; } = new BookViewModel();
        public IEnumerable<AuthorViewModel> Authors { get; set; } = new List<AuthorViewModel>();
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}