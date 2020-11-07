using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    interface IAbility
    {
        public int Mana { set; get; }


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
}

