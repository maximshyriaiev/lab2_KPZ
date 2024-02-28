using System;
using System.Collections.Generic;

namespace Prototype
{
    // Клас вірусу
    class Virus : ICloneable
    {
        public int Weight { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public List<Virus> Children { get; set; }

        // Конструктор
        public Virus(int weight, int age, string name, string species)
        {
            Weight = weight;
            Age = age;
            Name = name;
            Species = species;
            Children = new List<Virus>();
        }

        // Метод для додавання дитини
        public void AddChild(Virus child)
        {
            Children.Add(child);
        }

        // Метод клонування
        public object Clone()
        {
            // Клонуємо основний об'єкт
            Virus clone = new Virus(Weight, Age, Name, Species);

            // Клонуємо дітей
            foreach (var child in Children)
            {
                clone.AddChild((Virus)child.Clone());
            }

            return clone;
        }

        // Метод для виведення інформації про вірус
        public void DisplayInfo()
        {
            Console.WriteLine($"Ім'я: {Name}, Вік: {Age}, Вага: {Weight}, Вид: {Species}");
            foreach (var child in Children)
            {
                child.DisplayInfo();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            // Створюємо віруси
            Virus grandParentVirus = new Virus(100, 3, "GrandParent", "COVID-19");
            Virus parentVirus = new Virus(90, 2, "Parent", "Delta");
            Virus childVirus1 = new Virus(80, 1, "Child1", "Omicron");
            Virus childVirus2 = new Virus(70, 1, "Child2", "Lambda");

            // Додаємо дітей до вірусів
            grandParentVirus.AddChild(parentVirus);
            parentVirus.AddChild(childVirus1);
            parentVirus.AddChild(childVirus2);

            // Клонуємо віруси
            Virus clonedGrandParentVirus = (Virus)grandParentVirus.Clone();

            // Виводимо інформацію про клонований вірус
            Console.WriteLine("Клонований вірус:");
            clonedGrandParentVirus.DisplayInfo();
        }
    }
}
