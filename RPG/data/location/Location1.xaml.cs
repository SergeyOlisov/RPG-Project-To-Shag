using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Collections.Generic;
using RPG.data.helpers;

namespace RPG
{
    /// <summary>
    /// Логика взаимодействия для Location1.xaml
    /// </summary>
    public partial class Location1 : Window
    {
        RadioButton ChoiceAbility;
        List<AttackSpell> attackSpells = new List<AttackSpell>();
        static Hero hero = new Hero("Test Hero");
        TaskCompletionSource<bool> End = new TaskCompletionSource<bool>();
        Enemy enemy = new Enemy()
        {
            Name = "Skelet",
            Level = 1,
            Experience = 20,
            Health = 15,
            Mana = 15
        };
        IAbility TempEnemy = new Enemy();
        IAbility TempHero = hero;

        void ShowStaticHero()
        {
            ShowStatistics.Items.Add("");
            ShowStatistics.Items.Add("Static Hero");
            ShowStatistics.Items.Add("Name " + hero.Name);
            ShowStatistics.Items.Add("Health " + hero.Health);
            ShowStatistics.Items.Add("Mana " + hero.Mana);
            ShowStatistics.Items.Add("Level: " + hero.Level);
            ShowStatistics.Items.Add("Experience: " + hero.Experience);
            ShowStatistics.Items.Add("Strength: " + hero.Strength);
            ShowStatistics.Items.Add("Agility " + hero.Agility);
            ShowStatistics.Items.Add("Intellect: " + hero.Intellect);
            ShowStatistics.Items.Add("Vitality: " + hero.Vitality);
            ShowStatistics.Items.Add("");
        }

        public Location1()
        {
            //attackSpells = AbilityHelper.GetAttackSpells();
            InitializeComponent();
            EndBattle();
        }
        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            ShowStatistics.Items.Add("");
            enemy.Health -= hero.Damage();
            ShowStatistics.Items.Add("Hero deals damage: " + hero.Damage());
            ShowStatistics.Items.Add("Enemy Health: " + enemy.Health);
            ShowStatistics.Items.Add("");
            if (!CheckHP())
            {
                DamageEnemy();
            }
        }
        private void DamageEnemy()
        {
            hero.Health -= enemy.Damage();
            ShowStatistics.Items.Add("Enemy deals damage: " + enemy.Damage());
            ShowStatistics.Items.Add("Health Hero: " + hero.Health);
            ShowStatistics.Items.Add("");
            CheckHP();
        }
        private bool CheckHP()
        {
            if (hero.Health <= 0 || enemy.Health <= 0)
            {
                End.SetResult(true);
                return true;
            }
            return false;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.json)|*.json|(*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
                Editor.HeroSerialize(hero, saveFileDialog.FileName);
        }
        private void Loading_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.json)|*.json|(*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ShowStatistics.Items.Add("File downloaded");
                hero = Editor.HeroDeserialize(openFileDialog.FileName);
            }
            else
            {
                ShowStatistics.Items.Add("File not uploaded");
            }
        }
        private async void EndBattle()
        {
            await End.Task;
            ShowStatistics.Items.Add("Finish");
        }
        private void Ability_Click(object sender, RoutedEventArgs e)
        {
            ShowStatistics.Items.Add("You clicked " + ChoiceAbility.Content.ToString() + ".");
            attackSpells = Editor.AttackSpellDeserialize(@"D:\Курсяк\RPG-Project-To-Shag\RPG\resources\spells\AllAttackSpells.json");
            //ShowStatistics.Items.Add(attackSpells.Da);
            //ShowStatistics.Items.Add("You clicked " + li.Content.ToString() + ".") ;
            //enemy.Health -= attackSpells;
            //ShowStatistics.Items.Add(enemy.Health);
            //ShowStatistics.Items.Add("имя"+attackSpells.Name);
            //ShowStatistics.Items.Add("исп маны"+attackSpells.ManaCoast);
            //ShowStatistics.Items.Add("Урон"+attackSpells.Damage);
        }

        private void RadioButton_Checked_Lightning(object sender, RoutedEventArgs e)
        {
            ChoiceAbility = (RadioButton)sender;
            
        }
    }
}

//hero.Health += temp2.Buff(hero.Ability.Find(s => s == buffSpell));
