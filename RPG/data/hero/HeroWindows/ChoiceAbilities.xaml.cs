﻿using RPG.data.ability;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RPG.data.hero;
using RPG.data.location;

namespace RPG
{
    /// <summary>
    /// Логика взаимодействия для ChoiceAbilities.xaml
    /// </summary>
    public partial class ChoiceAbilities : Window
    {
        private readonly Location1 _location1;
        private readonly OnlineBattleServer _onlineBattleServer;
        private Enemy _enemy;
        private Ability _chosenAbility = new Ability();
        public ChoiceAbilities(Location1 location1, ref Enemy enemy)
        {
            InitializeComponent();
            _location1 = location1;
            _enemy = enemy;
            DataContext = new ViewModelAbilities();
        }

        public ChoiceAbilities(OnlineBattleServer onlineBattleServer, ref Enemy enemy)
        {
            InitializeComponent();
            _onlineBattleServer = onlineBattleServer;
            _enemy = enemy;
            DataContext = new ViewModelAbilities();
        }

        private void Applace_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Player.Hero.Mana < Convert.ToInt32(text_abilityMana.Text))
                {
                    MessageBox.Show("Need more mana, bitch");
                    return;
                }
                _chosenAbility.Name = text_abilityName.Text.ToString();
                _chosenAbility.ManaCost = Convert.ToInt32(text_abilityMana.Text);
                _chosenAbility.Level = Convert.ToInt32(text_abilityLevel.Text);
                _chosenAbility.Damage = Convert.ToInt32(text_abilityDamage.Text);
                Battle.HeroSpellCaste(ref _enemy, _chosenAbility);
                _location1.EndFight();
                _location1.HP_Enemy.Text = _enemy.Health.ToString();
                _location1.Mana_Hero.Text = Player.Hero.Mana.ToString();
                _location1.isSpellCast = true;
            }
            catch (Exception exception)
            {
                //в лог закинем эксепшн
                Close();
            }
            Close();
        }

        private void Close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}