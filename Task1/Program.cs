using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем пустой список контактов
            var phoneBook = new List<Contact>();

            // Добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 79990000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 79990000014, "innokentii@example.com"));

            // Сортируем контакты по имени, а затем по фамилии
            phoneBook = phoneBook.OrderBy(contact => contact.Name)
                                 .ThenBy(contact => contact.LastName)
                                 .ToList();

            while (true)
            {
                // Читаем введённый с консоли символ
                var input = Console.ReadKey().KeyChar;

                // Проверяем, является ли ввод числом
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                // Если ввод неверный, сообщаем об ошибке
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страница не существует");
                }
                // Если всё правильно, выводим страницу
                else
                {
                    // Пропускаем необходимое количество элементов и берём 2 для отображения на странице
                    var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();

                    // Выводим результаты
                    foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                    Console.WriteLine();
                }
            }
        }
    }

    public class Contact // Модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, string email) // Конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string Name { get; }
        public string LastName { get; }
        public long PhoneNumber { get; }
        public string Email { get; }
    }
}