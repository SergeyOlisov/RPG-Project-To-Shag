using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;

namespace RPG
{
    class Editor
    {

        public static Enemy EnemyCreate(string name, int level, int health, int mana, List<Ability> abilities)
        {
            var enemy = new Enemy(name, level, health, mana, abilities);
            return enemy;
        }

        public static void EnemySerialize(Enemy enemy)
        {
            using (FileStream fs = new FileStream(enemy.Name + ".json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync<Enemy>(fs, enemy);
            }
        }
        public static void HeroSerialize(Hero hero, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync<Hero>(fs, hero);
            }
        }

        public  static Enemy EnemyDeserialize(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var enemy = JsonSerializer.DeserializeAsync<Enemy>(fs).Result;
                return enemy;
            }
        }

        public static Hero  HeroDeserialize(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var hero = JsonSerializer.DeserializeAsync<Hero>(fs).Result;
                return hero;
            }
        }

        public static void AttackSpellSerialize(AttackSpell ability)
        {
            using (FileStream fs = new FileStream(ability.Name + ".json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync<AttackSpell>(fs, ability);
            }
        }

        public static Ability AttackSpellDeserialize(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var ability = JsonSerializer.DeserializeAsync<AttackSpell>(fs).Result;
                return ability;
            }
        }

        public static void AttackSpellsSerialize(List<AttackSpell> attackSpells)
        {
            using (FileStream fs = new FileStream("AllAttackSpells" + ".json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync<List<AttackSpell>>(fs, attackSpells);
            }
        }

        public static void BuffSpellsSerialize(List<Buff> buffSpells)
        {
            using (FileStream fs = new FileStream("AllAttackSpells" + ".json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync<List<Buff>>(fs, buffSpells);
            }
        }
    }
}
