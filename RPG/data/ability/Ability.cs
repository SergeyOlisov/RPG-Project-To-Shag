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
<<<<<<< Updated upstream
        public int Mana { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Ability() { }

        public Ability(string name, int manaCoast)
        {
            Name = name;
            ManaCoast = manaCoast;
        }

        public int AttackAbility(Ability ability)
        {
            {
                if (Mana >= ability.ManaCoast)
                {
                    if (ability is AttackSpell spell)
                    {
                        Mana -= spell.ManaCoast;
                        return spell.Value;
                    }
                }

                return 0;
            }
        }

        public int Buff(Ability ability)
        {
            if (Mana >= ability.ManaCoast)
            {
                if (ability is Buff spell)
                {
                    Mana -= spell.ManaCoast;
                    return spell.Value;
                }
            }
            return 0;
        }
    }

    public class Buff : Ability
    {
    }

    public class AttackSpell : Ability
    {
    }
}

