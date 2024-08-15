using Microsoft.EntityFrameworkCore;

namespace bookStoreApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {

                if (context.Books.Any())
                    return;

                context.Books.AddRange(
                    new Book
                    {
                       // Id = 1,
                        Title = "Kuyucaklı Yusuf",
                        GenreId = 3, // Roman
                        PageCount = 172,
                        PublishDate = DateTime.Now
                    },
                    new Book
                    {
                       // Id = 2,
                        Title = "Araba Sevdası",
                        GenreId = 3, // Roman
                        PageCount = 230,
                        PublishDate = new DateTime(2000, 12, 23)
                    },
                    new Book
                    {
                       // Id = 3,
                        Title = "Game Theory",
                        GenreId = 2, // Bilim
                        PageCount = 412,
                        PublishDate = new DateTime(2005, 8, 14)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}