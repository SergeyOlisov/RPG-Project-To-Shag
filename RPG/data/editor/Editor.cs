using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;

namespace RPG
{
    abstract class Editor
    {

        public static Enemy EnemyCreate(string name, int level, int health, int mana, List<Ability> abilities)
        {
            var enemy = new Enemy(name, level, health, mana, abilities);
            return enemy;
        }

        public static Hero HeroCreate()
        {
            var hero = new Hero();
            return hero;
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

        public static Hero  HeroDeserializeAsync(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var hero = JsonSerializer.DeserializeAsync<Hero>(fs).Result;
                return hero;
            }
        }

        public static Hero HeroDeserialize(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                var hero = JsonSerializer.Deserialize<Hero>(json);
                return hero;
            }
        }

        public static void AttackSpellSerialize(Ability ability)
        {
            using (FileStream fs = new FileStream(ability.Name + ".json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync<Ability>(fs, ability);
            }
        }

        public static Ability AttackSpellDeserialize(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var ability = JsonSerializer.DeserializeAsync<Ability>(fs).Result;
                return ability;
            }
        }

        public static void AttackSpellsSerialize(List<Ability> attackSpells)
        {
            using (FileStream fs = new FileStream("AllAttackSpells" + ".json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync<List<Ability>>(fs, attackSpells);
            }
        }
    }
}
