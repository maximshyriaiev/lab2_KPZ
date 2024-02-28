using System;

namespace AbstractFactory
{
    // Абстрактний клас для різних типів техніки
    abstract class Device
    {
        public abstract void DisplayInfo();
    }

    // Конкретний клас для ноутбука
    class Laptop : Device
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Ноутбук");
        }
    }

    // Конкретний клас для нетбука
    class Netbook : Device
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Нетбук");
        }
    }

    // Конкретний клас для електронної книги
    class EBook : Device
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Електронна книга");
        }
    }

    // Конкретний клас для смартфона
    class Smartphone : Device
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Смартфон");
        }
    }

    // Абстрактний клас фабрики, який визначає методи створення різних пристроїв
    abstract class DeviceFactory
    {
        public abstract Device CreateLaptop();
        public abstract Device CreateNetbook();
        public abstract Device CreateEBook();
        public abstract Device CreateSmartphone();
    }

    // Конкретна фабрика для бренду "IProne"
    class IProneFactory : DeviceFactory
    {
        public override Device CreateLaptop()
        {
            return new Laptop();
        }

        public override Device CreateNetbook()
        {
            return new Netbook();
        }

        public override Device CreateEBook()
        {
            return new EBook();
        }

        public override Device CreateSmartphone()
        {
            return new Smartphone();
        }
    }

    // Конкретна фабрика для бренду "Kiaomi"
    class KiaomiFactory : DeviceFactory
    {
        public override Device CreateLaptop()
        {
            return new Laptop();
        }

        public override Device CreateNetbook()
        {
            return new Netbook();
        }

        public override Device CreateEBook()
        {
            return new EBook();
        }

        public override Device CreateSmartphone()
        {
            return new Smartphone();
        }
    }

    // Конкретна фабрика для бренду "Balaxy"
    class BalaxyFactory : DeviceFactory
    {
        public override Device CreateLaptop()
        {
            return new Laptop();
        }

        public override Device CreateNetbook()
        {
            return new Netbook();
        }

        public override Device CreateEBook()
        {
            return new EBook();
        }

        public override Device CreateSmartphone()
        {
            return new Smartphone();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            // Створення фабрик для різних брендів
            DeviceFactory iProneFactory = new IProneFactory();
            DeviceFactory kiaomiFactory = new KiaomiFactory();
            DeviceFactory balaxyFactory = new BalaxyFactory();

            // Створення різних пристроїв для кожного бренду і виведення інформації про них
            Device device1 = iProneFactory.CreateLaptop();
            device1.DisplayInfo();

            Device device2 = kiaomiFactory.CreateSmartphone();
            device2.DisplayInfo();

            Device device3 = balaxyFactory.CreateEBook();
            device3.DisplayInfo();
        }
    }
}
