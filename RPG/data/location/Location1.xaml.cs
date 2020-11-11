using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Win32;
using RPG.data.helpers;
using System.ComponentModel;
using RPG.data.hero;
using RPG.data.location;

namespace RPG
{
    /// <summary>
    /// Логика взаимодействия для Location1.xaml
    /// </summary>
    public partial class Location1 : Window
    {

        IAbility AttacSpell = Player.hero;
        TaskCompletionSource<bool> End = new TaskCompletionSource<bool>();
        int mana = 10;
        int tempManaHero = Player.hero.Mana;
        //Ability _choice = new Ability() 
        //{
        //    Name = "Fire Ball",
        //    ManaCoast = 5,
        //    Level = 1,
        //    Value = 8
        //};
        Enemy enemy = new Enemy()
        {
            Name = "Skelet",
            Level = 1,
            Experience = 20,
            Health = 1500,
            Mana = 15
        };
        IAbility temp2 = Player.hero;

        void ShowStaticHero()
        {
            ShowStatistics.Items.Add("");
            ShowStatistics.Items.Add("Static Hero");
            ShowStatistics.Items.Add("Name " + Player.hero.Name);
            ShowStatistics.Items.Add("Health " + Player.hero.Health);
            ShowStatistics.Items.Add("Mana " + Player.hero.Mana);
            ShowStatistics.Items.Add("Level: " + Player.hero.Level);
            ShowStatistics.Items.Add("Experience: " + Player.hero.Experience);
            ShowStatistics.Items.Add("Strength: " + Player.hero.Strength);
            ShowStatistics.Items.Add("Agility " + Player.hero.Agility);
            ShowStatistics.Items.Add("Intellect: " + Player.hero.Intellect);
            ShowStatistics.Items.Add("Vitality: " + Player.hero.Vitality);
            ShowStatistics.Items.Add("");
        }

        AttackSpell attackSpell = new AttackSpell()
        {
            Name = "test",
            Value = 10,
            ManaCoast = 5
        };

        Buff buffSpell = new Buff()
        {
            Name = "test Buff",
            Value = 5,
            ManaCoast = 5
        };



        public Location1()
        {
            InitializeComponent();
            EndBattle();
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            ShowStatistics.Items.Add("");
            Battle.Attack(ref enemy);
            //enemy.Health -= Player.hero.Damage();
            ShowStatistics.Items.Add("Hero deals damage: " + Player.hero.Damage());
            ShowStatistics.Items.Add("Enemy Health: " + enemy.Health);
            ShowStatistics.Items.Add("");
            if (!CheckHP())
            {
                DamageEnemy();
            }
            if(enemy.Health <= 0)
            {
                Player.hero.LevelUp(enemy.Dead());
                ShowStatistics.Items.Add(Player.hero.Experience);
                Player.TempHeroSave(Player.hero);
            }
        }

        private void DamageEnemy()
        {
            Player.hero.Health -= enemy.Damage();
            ShowStatistics.Items.Add("Enemy deals damage: " + enemy.Damage());
            ShowStatistics.Items.Add("Health Hero: " + Player.hero.Health);
            ShowStatistics.Items.Add("");
            CheckHP();
        }
        private bool CheckHP()
        {
            if (Player.hero.Health <= 0 || enemy.Health <= 0)
            {
                End.SetResult(true);
                return true;
                //дополнить 
                //закрытие окна или невозможность нажать на атаку
            }
            return false;
        }
        private async void EndBattle()
        {
            await End.Task;
            ShowStatistics.Items.Add("Finish");
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
                Editor.HeroSerialize(Player.hero, saveFileDialog.FileName);
        }
        private void Loading_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.json)|*.json|(*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ShowStatistics.Items.Add("File downloaded");
                Player.hero = Editor.HeroDeserializeAsync(openFileDialog.FileName);
            }
            else
            {
                ShowStatistics.Items.Add("File not uploaded");
            }
        }


        private void Ability_Click(object sender, RoutedEventArgs e)
        {

            var ChoiceAbilities = new ChoiceAbilities(this, ref enemy);
            //Battle.SpellCaste(ref enemy, _choice);
            //ShowStatistics.Items.Add("Enemy Health: " + enemy.Health);
            //ShowStatistics.Items.Add("");
            ChoiceAbilities.Show(); 
            //ChoiceAbilities.Check += value => label.Content = value;

        }

        private void StaticHero_Click(object sender, RoutedEventArgs e)
        {
            var WindowStaticHero = new WindowStaticHero();
            WindowStaticHero.Show();
        }



        private void Mana_Hero_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
    }
}
