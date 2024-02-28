using System;
using System.Collections.Generic;

namespace FabrichniMethod
{

    // Абстрактний клас для представлення підписок
    public abstract class Subscription
    {
        public decimal MonthlyPrice { get; protected set; } // щомісячна оплата
        public int MinSubscriptionMonths { get; protected set; } // мінімальний термін підписки в місяцях
        public List<string> IncludedChannels { get; protected set; } // список включених каналів

        // Конструктор класу Subscription
        public Subscription(decimal monthlyPrice, int minSubscriptionMonths, List<string> includedChannels)
        {
            MonthlyPrice = monthlyPrice;
            MinSubscriptionMonths = minSubscriptionMonths;
            IncludedChannels = includedChannels;
        }
    }

    // Конкретний клас для підписки на вітчизняні канали
    public class DomesticSubscription : Subscription
    {
        // Конструктор класу DomesticSubscription
        public DomesticSubscription() : base(10m, 1, new List<string> { "Вітчизняний канал 1", "Вітчизняний канал 2" }) { }
    }

    // Конкретний клас для освітньої підписки
    public class EducationalSubscription : Subscription
    {
        // Конструктор класу EducationalSubscription
        public EducationalSubscription() : base(15m, 3, new List<string> { "Освітній канал 1", "Освітній канал 2" }) { }
    }

    // Конкретний клас для преміальної підписки
    public class PremiumSubscription : Subscription
    {
        // Конструктор класу PremiumSubscription
        public PremiumSubscription() : base(25m, 6, new List<string> { "Преміум канал 1", "Преміум канал 2", "Преміум канал 3" }) { }
    }

    // Інтерфейс для фабричного методу створення підписок
    public interface ISubscriptionFactory
    {
        Subscription CreateSubscription();
    }

    // Реалізація фабрики для створення підписок через веб-сайт
    public class WebSite : ISubscriptionFactory
    {
        public Subscription CreateSubscription()
        {
            return new DomesticSubscription(); // Тимчасово повертаємо DomesticSubscription
        }
    }

    // Реалізація фабрики для створення підписок через мобільний додаток
    public class MobileApp : ISubscriptionFactory
    {
        public Subscription CreateSubscription()
        {
            return new EducationalSubscription(); // Тимчасово повертаємо EducationalSubscription
        }
    }

    // Реалізація фабрики для створення підписок через дзвінок менеджеру
    public class ManagerCall : ISubscriptionFactory
    {
        public Subscription CreateSubscription()
        {
            return new PremiumSubscription(); // Тимчасово повертаємо PremiumSubscription
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            // Приклад використання фабричного методу для створення підписок
            // Створення підписки через веб-сайт
            ISubscriptionFactory website = new WebSite();
            Subscription websiteSubscription = website.CreateSubscription();
            Console.WriteLine("Підписка створена через веб-сайт:");
            DisplaySubscriptionDetails(websiteSubscription);

            // Створення підписки через мобільний додаток
            ISubscriptionFactory mobileApp = new MobileApp();
            Subscription mobileAppSubscription = mobileApp.CreateSubscription();
            Console.WriteLine("\nПідписка створена через мобільний додаток:");
            DisplaySubscriptionDetails(mobileAppSubscription);

            // Створення підписки через дзвінок менеджеру
            ISubscriptionFactory managerCall = new ManagerCall();
            Subscription managerCallSubscription = managerCall.CreateSubscription();
            Console.WriteLine("\nПідписка створена через дзвінок менеджеру:");
            DisplaySubscriptionDetails(managerCallSubscription);
        }

        // Метод для виведення деталей підписки на екран
        public static void DisplaySubscriptionDetails(Subscription subscription)
        {
            Console.WriteLine($"Щомісячна оплата: {subscription.MonthlyPrice}$");
            Console.WriteLine($"Мінімальний термін підписки: {subscription.MinSubscriptionMonths} місяців");
            Console.WriteLine("Включені канали:");
            foreach (var channel in subscription.IncludedChannels)
            {
                Console.WriteLine($"- {channel}");
            }
        }
    }
}
