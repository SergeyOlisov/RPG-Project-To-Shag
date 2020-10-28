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
        public static Hero hero;

        public static void CreatePlayer()
        {
            hero = Editor.HeroCreate();
        }
        public static void LoadingPlayer()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.json)|*.json|(*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                hero = Editor.HeroDeserialize(openFileDialog.FileName);
                if(hero == null)
                {
                    hero = Editor.HeroCreate();
                }
            }
            hero = Editor.HeroCreate();
        }

        public static void HeroSave()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.json)|*.json|(*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
                Editor.HeroSerialize(hero, saveFileDialog.FileName);
        }
    }
}
