using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Ability
    {

        public string Name { set; get; }
        public int ManaCoast { set; get; } //расход маны на абилку

        public Ability() { }

        public Ability(string name, int value, int manaCoast)
        {
            Name = name;
            ManaCoast = manaCoast;
        }
    }

    public class Buff : Ability
    {
        public int BuffValue { set; get; }
    }

    public class AttackSpell : Ability
    {
        public int Damage { set; get; }
    }
}

