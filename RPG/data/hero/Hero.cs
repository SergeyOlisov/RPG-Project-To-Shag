using System;
using System.Collections.Generic;
using System.Text;
using RPG.data.helpers;

namespace RPG
{
    public class Hero
    {
        public string Name { set; get; }
        
        public int Level { set; get; }
        public int Experience { set; get; }
        public int ExperienceToNextLevel { set; get; }

        public int SkillPoints { set; get; }
        public int StatPoints { set; get; }

        public int Health { set; get; }
        public int MaxHealth { set; get; }
        public int Mana { set; get; }
        public int MaxMana { set; get; }
        
        public int Strength { set; get; }
        public int Agility { set; get; }
        public int Intellect { set; get; }
        public int Vitality { set; get; }

        //public List<Ability> Ability;
        public List<Ability> Ability { set; get; } = new List<Ability>();

        public Hero() 
        {
            Name = "Wanderer";
            Level = 1; 
            Experience = 0;
            Strength = 15;
            Agility = 15;
            Intellect = 15;
            Vitality = 15;
            Ability.Add(AbilityHelper.GetFirstAbility());
            UpdateHero();
            Mana = MaxMana;
            Health = MaxHealth;
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
            Ability.Add(AbilityHelper.GetFirstAbility());
            UpdateHero();
            Mana = MaxMana;
            Health = MaxHealth;
        }

        public void LevelUp(int experience)
        {
            if (experience >= ExperienceToNextLevel - Experience)
            {
                experience -= ExperienceToNextLevel - Experience;
                Experience = 0;
                Level++;
                SkillPoints += 1;
                StatPoints += 10;
                UpdateHero();
                LevelUp(experience);
            }
            
            Experience += experience;
        }
        
        public int Damage()
        {
            return Strength;
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

        public int Dodge()
        {
            return Agility / 5;
        }

        public void UpdateHero()
        {
            MaxHealth = Vitality * 5;
            MaxMana = Intellect * 2;
            ExperienceToNextLevel = Level * 100;
            // TO-DO подумать над остальным
        }
    }
}
