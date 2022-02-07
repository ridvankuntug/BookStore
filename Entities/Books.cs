using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entities
{
    public class Books
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }

        public int GenreId { get; set; }
        public Genres Genre { get; set; }

        public int PageCount { get; set; }
        public DateTime PublisDate { get; set; }
    }
}
