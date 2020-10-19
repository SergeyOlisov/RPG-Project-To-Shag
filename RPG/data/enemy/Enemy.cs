using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Enemy : IAbility
    {
        public string Name { set; get; }
        public int Number { set; get; }

        public int Level { set; get; }
        public int Experience { set; get; }

        public int Health { set; get; }
        public int Mana { set; get; }

        public List<Ability> Ability { set; get; } = new List<Ability>();

        public Enemy() { }

        public Enemy(string name, Hero hero) // для тестирования
        {
            Name = name;
            Level = hero.Level;
            Experience = Level * 10000;
            Health = Level * 150;
            Mana = Level * 10;
        }

        public Enemy(string name, int level, int health, int mana, List<Ability> abilities) // для редактора
        {
            Level = level;
            Name = name;
            Health = health;
            Mana = mana;
            Ability = abilities;
            Experience = level * 20 * (Health / 20) * ((Mana * Ability.Count) / 20);
        }

        public int Damage() //тестовый урон
        {
            return Level * 8;
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
            Number++;
            Level++;
            Health = Health * 2;
            Mana = Mana * 2;
            Experience = Level * 50 * 2;

            /*public int AttackSpell(Ability ability)
            {
                return AttackAbility(Ability.Find(s => s == ability));
            }*/
        }

    }
}
