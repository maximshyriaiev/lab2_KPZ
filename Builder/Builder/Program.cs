using System;
using System.Collections.Generic;

namespace Builder
{
    // Інтерфейс для будівництва персонажів
    interface ICharacterBuilder
    {
        ICharacterBuilder SetHeight(int height);
        ICharacterBuilder SetBuild(string build);
        ICharacterBuilder SetHairColor(string hairColor);
        ICharacterBuilder SetEyeColor(string eyeColor);
        ICharacterBuilder SetClothing(string clothing);
        ICharacterBuilder SetInventory(List<string> inventory);
        Character Build();
    }

    // Клас персонажа
    class Character
    {
        public int Height { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Clothing { get; set; }
        public List<string> Inventory { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Зріст: {Height}, Статура: {Build}, Волосся: {HairColor}, Очі: {EyeColor}, Одяг: {Clothing}");
            Console.WriteLine("Інвентар:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }

    // Клас-директор для будівництва персонажів
    class CharacterDirector
    {
        private ICharacterBuilder _builder;

        public CharacterDirector(ICharacterBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructCharacter()
        {
            _builder.SetHeight(180)
                    .SetBuild("Athletic")
                    .SetHairColor("Brown")
                    .SetEyeColor("Blue")
                    .SetClothing("Armor")
                    .SetInventory(new List<string> { "Sword", "Shield", "Potion" });
        }
    }

    // Клас-білдер для створення героїв
    class HeroBuilder : ICharacterBuilder
    {
        private Character _character = new Character();

        public ICharacterBuilder SetHeight(int height)
        {
            _character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBuild(string build)
        {
            _character.Build = build;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            _character.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            _character.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder SetClothing(string clothing)
        {
            _character.Clothing = clothing;
            return this;
        }

        public ICharacterBuilder SetInventory(List<string> inventory)
        {
            _character.Inventory = inventory;
            return this;
        }

        public Character Build()
        {
            return _character;
        }
    }

    // Клас-білдер для створення ворогів
    class EnemyBuilder : ICharacterBuilder
    {
        private Character _character = new Character();

        public ICharacterBuilder SetHeight(int height)
        {
            _character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBuild(string build)
        {
            _character.Build = build;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            _character.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            _character.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder SetClothing(string clothing)
        {
            _character.Clothing = clothing;
            return this;
        }

        public ICharacterBuilder SetInventory(List<string> inventory)
        {
            _character.Inventory = inventory;
            return this;
        }

        public Character Build()
        {
            return _character;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            // Створюємо білдера для героя
            var heroBuilder = new HeroBuilder();

            // Створюємо директора і викликаємо метод будівництва героя
            var heroDirector = new CharacterDirector(heroBuilder);
            heroDirector.ConstructCharacter();

            // Отримуємо героя
            var hero = heroBuilder.Build();

            // Виводимо інформацію про героя
            Console.WriteLine("Інформація про героя:");
            hero.DisplayInfo();

            // Тепер створимо ворога за допомогою того ж білдера
            var enemyBuilder = new EnemyBuilder();

            // Створюємо директора для ворога і викликаємо метод будівництва
            var enemyDirector = new CharacterDirector(enemyBuilder);
            enemyDirector.ConstructCharacter();

            // Отримуємо ворога
            var enemy = enemyBuilder.Build();

            // Виводимо інформацію про ворога
            Console.WriteLine("\nІнформація про ворога:");
            enemy.DisplayInfo();
        }
    }
}
