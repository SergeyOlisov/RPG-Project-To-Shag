using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace RPG.data.helpers
{
    public static class AbilityHelper
    {
        public static List<AttackSpell> GetAttackSpells()
        {
            using (FileStream fs = new FileStream(@"..\resources\spells\AllAttackSpells.json", FileMode.Open))
            {
                var ability = JsonSerializer.DeserializeAsync<List<AttackSpell>>(fs).Result;
                return ability;
            }
        }

        public static List<Buff> GetBuffSpells()
        {
            using (FileStream fs = new FileStream(@"..\resources\spells\AllBuffSpells.json", FileMode.Open))
            {
                var ability = JsonSerializer.DeserializeAsync<List<Buff>>(fs).Result;
                return ability;
            }
        }

        public static List<Ability> GetAllAbilities()
        {
            using (FileStream fs = new FileStream(@"..\resources\spells\AllAbilities.json", FileMode.Open))
            {
                var ability = JsonSerializer.DeserializeAsync<List<Ability>>(fs).Result;
                return ability;
            }
        }
    }
}
