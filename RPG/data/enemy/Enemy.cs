using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Enemy
    {
        public string Name { set; get; }

        public int Level { set; get; }
        public int Experience { set; get; }

        public int Health { set; get; }
        public int Mana { set; get; }

        public List<Ability> Ability { set; get; } = new List<Ability>();

        public Enemy() 
        {
            Level = 1;
            Name = "Skelet";
            Health = 150;
            Mana = 20;
            //Ability = abilities;
            Experience = 100;
        }

        public Enemy(Hero hero) // для тестирования
        {
            Name = "Рабочее название";
            Level = hero.Level;
            Experience = Level * 75 + 25;
            Health = Level * 125;
            Mana = Level * 10;
        }

        public Enemy(string name, int level, int health, int mana, List<Ability> abilities) // для редактора
        {
            Level = level;
            Name = name;
            Health = health;
            Mana = mana;
            Ability = abilities;
            Experience = level * 20 * (Health / 20) * ((Mana) / 20);
        }
        public Enemy(string name, int level, int health, int mana) // для редактора
        {
            Level = level;
            Name = name;
            Health = health;
            Mana = mana;
            Experience = level * 20 * (Health / 20) * ((Mana) / 20);
        }

        public int Damage() //тестовый урон
        {
            var random = new Random();
            return Level * random.Next(8,15);
        }

        public int Dead()
        {
            if (Health <= 0)
            {
                return Experience;
            }

            return 0;
        }
        public void LevelUpEnemy()
        {
            UpdateEnemy();
        }

        public void UpdateEnemy()
        {
            Level++;
            Health = Health * 2;
            Mana = Mana * 2;
            Experience = Level * 5;
        }
    }
}
