using RPG.data.hero;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Ability
    {

        public string Name { set; get; }
        public int ManaCast { set; get; } //расход маны на абилку
        public int Level { set; get; } //требуемый уровень

        public int Value { set; get; }

        public Ability() { }

        public Ability(string name, int manaCast)
        {
            Name = name;
            ManaCast = manaCast;
        }

        public int AttackAbility(Ability ability)
        {
            {
                if (Player.hero.Mana >= ability.ManaCast)
                {
                    if (ability is AttackSpell spell)
                    {
                        Player.hero.Mana -= spell.ManaCast;
                        return spell.Value;
                    }
                }

                return 0;
            }
        }

        public int Buff(Ability ability)
        {
            if (Player.hero.Mana >= ability.ManaCast)
            {
                if (ability is Buff spell)
                {
                    Player.hero.Mana -= spell.ManaCast;
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

