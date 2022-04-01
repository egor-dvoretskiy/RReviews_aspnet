using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RReviews.Data.Seed
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RReviewsContext(serviceProvider.GetRequiredService<DbContextOptions<RReviewsContext>>()))
            {
                if (context == null || context.Review == null)
                {
                    throw new ArgumentNullException("Null RReviewsContext");
                }

                if (context.Review.Any())
                {
                    return;
                }

                Guid guid = Guid.Parse("389A9445-FD40-4ED3-A202-8DE51F61199F");

                context.Review.Add(
                    new Models.ReviewModel
                    {
                        ImageKey = guid,
                        Title = "В пользовании не без ошибок.",
                        ObjectName = "DJI GL800A",
                        Content = "Пульт от старенькой матрицы шестисотой. Обычный пульт - минимум кнопок, зато настраиваемые.",
                        ReviewRating = 6,
                        ReviewTypeObject = Enum.ReviewObject.Etc,
                        TestingDate = DateTime.Now,
                        Cost = 144
                    });

                context.Image.Add(
                    new Models.ImageModel
                    {
                        Name = guid,
                        formFile = SeedData.GetFormFile(guid),
                        RelativePath = @$"\img\reviews\{guid}.jpg"
                    });

                guid = Guid.Parse("12F56CAA-1886-489D-9EA1-E7057AB5434E");

                context.Review.Add(
                    new Models.ReviewModel
                    {
                        ImageKey = guid,
                        Title = "Ужасная халатность в ресторане Белые Росы.",
                        ObjectName = "Папараць-кветка",
                        Content = "Взял себе котлету 'Папараць-Кветку', а она оказалась внутри еще сырой.",
                        ReviewRating = 2,
                        ReviewTypeObject = Enum.ReviewObject.Food,
                        TestingDate = new DateTime(2022, 8, 4),
                        Cost = 4.9m
                    });

                context.Image.Add(
                    new Models.ImageModel
                    {
                        Name = guid,
                        formFile = SeedData.GetFormFile(guid),
                        RelativePath = @$"\img\reviews\{guid}.jpg"
                    });

                guid = Guid.Parse("EFED748D-A4A3-488A-8DA2-AB138DB47183");

                context.Review.Add(
                    new Models.ReviewModel
                    {
                        ImageKey = guid,
                        Title = "Гарри Поттер все также остается любимой книгой многих.",
                        ObjectName = "Гарри Поттер и Узник Азкобана",
                        Content = "Любимая многими книга.",
                        ReviewRating = 9,
                        ReviewTypeObject = Enum.ReviewObject.Book,
                        TestingDate = new DateTime(2012, 5, 16),
                        Cost = 24.4m
                    });

                context.Image.Add(
                    new Models.ImageModel
                    {
                        Name = guid,
                        formFile = SeedData.GetFormFile(guid),
                        RelativePath = @$"\img\reviews\{guid}.jpg"
                    });

                guid = Guid.Parse("3C33A77E-7C17-4BC2-998C-905C39F92838");

                context.Review.Add(
                    new Models.ReviewModel
                    {
                        ImageKey = guid,
                        Title = "Это была одна из самых первых наших плат.",
                        ObjectName = "Модуль питания и управления.",
                        Content = "Это была первая плата для работы с матрицей, где и не пахло колхозом. УРА! Однако, у нее и своих проблем хватало.",
                        ReviewRating = 7,
                        ReviewTypeObject = Enum.ReviewObject.Etc,
                        TestingDate = new DateTime(2019, 11, 26),
                        Cost = 120m
                    });

                context.Image.Add(
                    new Models.ImageModel
                    {
                        Name = guid,
                        formFile = SeedData.GetFormFile(guid),
                        RelativePath = @$"\img\reviews\{guid}.jpg"
                    });

                context.SaveChanges();
            }
        }

        private static IFormFile GetFormFile(Guid guid)
        {
            FormFile formFile;
            using (var stream = File.OpenRead(@$"wwwroot\img\reviews\{guid}.jpg"))
            {
                formFile = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "image/jpeg"
                };
            }

            return formFile;
        }
    }
}
