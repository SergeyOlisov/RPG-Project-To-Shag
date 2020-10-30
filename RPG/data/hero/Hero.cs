using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Hero : IAbility
    {
        public string Name { set; get; }
        
        public int Level { set; get; }
        public int Experience { set; get; }
        public int ExperienceToNextLevel { set; get; }

        public int SkillPoints;
        public int StatPoints;

        public int Health { set; get; }
        public int Mana { set; get; }
        
        public int Strength { set; get; }
        public int Agility { set; get; }
        public int Intellect { set; get; }
        public int Vitality { set; get; }

        //public List<Ability> Ability;
        public List<Ability> Ability { set; get; } = new List<Ability>();

        public Hero() 
        {
            Name = "Wanderer";
            Level = 2; //нужен 1 лвл, 2 для теста
            Experience = 0;
            Strength = 15;
            Agility = 15;
            Intellect = 15;
            Vitality = 15;
            StatPoints = 5; // для теста
            SkillPoints = 1; // для теста
            UpdateHero();
        }
        public Hero(string name)
        {
            Name = name;
            Level = 1;
            Experience = 0;
            Strength = 15;
            Agility = 15;
            Intellect = 15;
            Vitality = 15;
            UpdateHero();
        }

        public void LevelUp(int experience)
        {
            UpdateHero();
            if (experience >= ExperienceToNextLevel - Experience)
            {
                experience -= ExperienceToNextLevel - Experience;
                Experience = 0;
                Level++;
                SkillPoints += 1;
                StatPoints += 5;
                LevelUp(experience);
            }

            Experience = experience;
        }
        
        public int Damage()
        {
            return Strength * 5;
        }

        public void StrengthUp()
        {
            if (StatPoints > 0)
            {
                StatPoints--;
                Strength++;
                UpdateHero();
            }
        }

        public void AgilityUp()
        {
            if (StatPoints > 0)
            {
                StatPoints--;
                Agility++;
                UpdateHero();
            }
        }

        public void IntellectUp()
        {
            if (StatPoints > 0)
            {
                StatPoints--;
                Intellect++;
                UpdateHero();
            }
        }

        public void VitalityUp()
        {
            if (StatPoints > 0)
            {
                StatPoints--;
                Vitality++;
                UpdateHero();
            }
        }

        public void StudyAbility(Ability ability)
        {
            if (SkillPoints > 0 && ability.Level <= Level)
            {
                var abilityCheck = Ability.Find(abil => abil.Name == ability.Name);
                if (abilityCheck != null)
                {
                    return;
                }

                SkillPoints--;
                Ability.Add(ability);
            }
        }

        public void UpdateHero()
        {
            Health = Vitality * 5;
            Mana = Intellect * 5;
            ExperienceToNextLevel = Level * 100;
            // TO-DO подумать над остальным
        }
    }
}
