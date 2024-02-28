using System;

namespace Loner
{
    // Клас, який гарантує єдиний екземпляр
    class Authenticator
    {
        // Приватний статичний екземпляр класу
        private static Authenticator? instance;

        // Приватний конструктор, щоб заборонити створення екземплярів ззовні класу
        private Authenticator()
        {
            Console.WriteLine("Екземпляр Authenticator був створений.");
        }

        // Публічний метод для отримання єдиного екземпляру класу
        public static Authenticator GetInstance()
        {
            // Перевірка, чи екземпляр вже був створений
            if (instance == null)
            {
                // Якщо екземпляр ще не існує, створюємо новий
                instance = new Authenticator();
            }
            // Повертаємо єдиний екземпляр
            return instance;
        }

        // Метод для автентифікації користувача
        public void Authenticate(string username, string password)
        {
            Console.WriteLine("Користувач {0} був автентифікований.", username);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            // Спроба отримати єдиний екземпляр Authenticator з різних місць програми
            Authenticator authenticator1 = Authenticator.GetInstance();
            Authenticator authenticator2 = Authenticator.GetInstance();

            // Перевірка на те, що отримані об'єкти є тим самим екземпляром
            Console.WriteLine("authenticator1 та authenticator2 є тим самим екземпляром: " + (authenticator1 == authenticator2));

            // Перевірка роботи методу автентифікації
            authenticator1.Authenticate("user1", "password1");
        }
    }
}
