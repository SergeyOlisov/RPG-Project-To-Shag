using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Win32;
using RPG.data.helpers;
using System.ComponentModel;
using RPG;

namespace RPG.data.hero
{
    public static class Player
    {
        private const string _tempHeroPath = ObjectHelper.TempHero;
        public static Hero Hero;
        public static int HealthPotions = 2;
        public static int ManaPotions = 2;

        public static void UseHealthPotion()
        {
            if (HealthPotions > 0)
            {
                Hero.Health += Hero.MaxHealth * 30 / 100;
                if (Hero.Health > Hero.MaxHealth)
                {
                    Hero.Health = Hero.MaxHealth;
                }
                HealthPotions -= 1;
            }
        }

        public static void UseManaPotion()
        {
            if (ManaPotions > 0)
            {
                Hero.Mana += Hero.MaxMana * 30 / 100;
                if (Hero.Mana > Hero.MaxMana)
                {
                    Hero.Mana = Hero.MaxMana;
                }
                ManaPotions -= 1;
            }
        }

        public static Hero CreatePlayer()
        {
            return Hero = Editor.HeroCreate();
        }
        public static Hero LoadingPlayer()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.json)|*.json|(*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Hero = Editor.HeroDeserializeAsync(openFileDialog.FileName);
                if(Hero == null)
                {
                    return Hero = Editor.HeroCreate();
                }
            }
            return Hero = Editor.HeroCreate();
        }

        public static void HeroSave()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.json)|*.json|(*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
                Editor.HeroSerialize(Hero, saveFileDialog.FileName);
        }

        public static Hero QuickLoad()
        {
            Hero = Editor.HeroDeserialize(_tempHeroPath);
            return Hero;
        }

        public static void QuickSave(Hero playerHero)
        {
            Editor.HeroSerialize(playerHero, _tempHeroPath);
        }
    }
}
