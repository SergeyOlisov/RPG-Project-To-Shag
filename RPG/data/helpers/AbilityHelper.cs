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
            using (FileStream fs = new FileStream(@"D:\Курсяк\RPG-Project-To-Shag\RPG\resources\spells\AllAttackSpells.json", FileMode.Open))
            {
                var ability = JsonSerializer.DeserializeAsync<List<AttackSpell>>(fs).Result;
                return ability;
            }
        }

        public static List<Buff> GetBuffSpells()
        {
            using (FileStream fs = new FileStream(@"D:\Курсяк\RPG-Project-To-Shag\RPG\resources\spells\AllBuffSpells.json", FileMode.Open))
            {
                var ability = JsonSerializer.DeserializeAsync<List<Buff>>(fs).Result;
                return ability;
            }
        }
    }
}
