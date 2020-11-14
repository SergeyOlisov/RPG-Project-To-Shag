using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace RPG.data.helpers
{
    public static class AbilityHelper
    {
        public static List<Ability> GetAttackSpells()
        {
            using (FileStream fs = new FileStream(@"..\resources\spells\AllAttackSpells.json", FileMode.Open))
            {
                var ability = JsonSerializer.DeserializeAsync<List<Ability>>(fs).Result;
                return ability;
            }
        }

        public static Ability GetFirstAbility()
        {
            return new Ability("Fire Ball", 12,1,5);
        }
    }
}
