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
        private const string tempHeroPath = ObjectHelper.TempHero;
        public static Hero hero;

        public static Hero CreatePlayer()
        {
            return hero = Editor.HeroCreate();
        }
        public static Hero LoadingPlayer()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.json)|*.json|(*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                hero = Editor.HeroDeserializeAsync(openFileDialog.FileName);
                if(hero == null)
                {
                    return hero = Editor.HeroCreate();
                }
            }
            return hero = Editor.HeroCreate();
        }

        public static void HeroSave()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.json)|*.json|(*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
                Editor.HeroSerialize(hero, saveFileDialog.FileName);
        }

        public static Hero QuickLoad()
        {
            hero = Editor.HeroDeserialize(tempHeroPath);
            return hero;
        }

        public static void QuickSave(Hero playerHero)
        {
            Editor.HeroSerialize(playerHero, tempHeroPath);
        }
    }
}
