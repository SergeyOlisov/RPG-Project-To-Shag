using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Ability
    {

        public string Name { set; get; }
        public int ManaCoast { set; get; } //расход маны на абилку
        public int Level { set; get; } //требуемый уровень

        public Ability() { }

        public Ability(string name, int manaCoast)
        {
            Name = name;
            ManaCoast = manaCoast;
        }
    }

    public class Buff : Ability
    {
        public int Value { set; get; }
    }

    public class AttackSpell : Ability
    {
        public int Value { set; get; }
    }
}

