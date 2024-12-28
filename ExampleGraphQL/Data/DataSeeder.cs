using Faker;
using HotelGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelGraphQL.Data
{
    public static class DataSeeder
    {
        // Асинхронный метод для загрузки данных
        public static async Task SeedDataAsync(HotelDbContext db)
        {
            // Проверяем, есть ли уже данные в таблице гостей
            if (!await db.Guests.AnyAsync())
            {
                // Создание данных для гостей
                for (int i = 1; i <= 10; i++)
                {
                    var guest = new Guest
                    {
                        Name = Name.FullName(),  // Генерация случайного имени
                        Phone = Phone.Number()   // Генерация случайного телефона
                    };
                    await db.Guests.AddAsync(guest); // Асинхронно добавляем гостя
                }
            }

            // Проверяем, есть ли уже данные в таблице комнат
            if (!await db.Rooms.AnyAsync())
            {
                // Создание данных для комнат
                for (int i = 1; i <= 10; i++)
                {
                    var room = new Room
                    {
                        Number = $"Room-{i}",  // Номер комнаты, например, "Room-1"
                        PricePerNight = 100 + i,
                        Capacity = Faker.RandomNumber.Next(1, 6)
                    };
                    await db.Rooms.AddAsync(room); // Асинхронно добавляем комнату
                }
            }

            // Проверяем, есть ли уже данные в таблице услуг
            if (!await db.Services.AnyAsync())
            {
                // Создание данных для услуг
                for (int i = 1; i <= 5; i++)
                {
                    var service = new Service
                    {
                        Name = Lorem.Sentence(3),  // Случайное название услуги
                        Price = Faker.RandomNumber.Next(50, 200)  // Случайная цена
                    };
                    await db.Services.AddAsync(service); // Асинхронно добавляем услугу
                }
            }

            // Проверяем, есть ли уже данные в таблице проживаний
            if (!await db.Stays.AnyAsync())
            {
                // Создание данных для проживаний
                for (int i = 1; i <= 5; i++)
                {
                    var stay = new Stay
                    {
                        CheckInDate = DateTime.Now.AddDays(i),
                        CheckOutDate = DateTime.Now.AddDays(i + 2),
                        TotalPrice = Faker.RandomNumber.Next(100, 500)
                    };
                    await db.Stays.AddAsync(stay); // Асинхронно добавляем проживание
                }
            }

            // Создаем связи между проживаниями и услугами
            var stays = await db.Stays.ToListAsync();
            var services = await db.Services.ToListAsync();

            await db.SaveChangesAsync();
        }
    }
}



