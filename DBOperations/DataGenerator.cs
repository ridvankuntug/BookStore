using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                else
                {
                    context.Genres.AddRange(
                        new Genres
                        {
                            GenreName = "Fantastic"
                        },
                        new Genres
                        {
                            GenreName = "Science Fiction"
                        },
                        new Genres
                        {
                            GenreName = "Novel"
                        }
                    );

                    context.Books.AddRange(
                        new Books
                        {
                            Title = "Lord of The Rings",
                            GenreId = 1,//Fantastic
                            PageCount = 900,
                            PublisDate = new DateTime(1965, 04, 12)
                        },
                        new Books
                        {
                            Title = "I Robot",
                            GenreId = 2,//Sci-Fi
                            PageCount = 150,
                            PublisDate = new DateTime(1979, 09, 23)
                        },
                        new Books
                        {
                            Title = "Hobbit",
                            GenreId = 1,//Fantastic
                            PageCount = 300,
                            PublisDate = new DateTime(1962, 03, 18)
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
