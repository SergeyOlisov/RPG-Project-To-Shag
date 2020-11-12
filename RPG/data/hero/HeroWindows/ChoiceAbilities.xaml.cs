using RPG.data.ability;
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
        public Enemy _enemy;
        public Ability chosenAbility = new Ability();
        public ChoiceAbilities(Location1 location1, ref Enemy enemy)
        {
            InitializeComponent();
            _location1 = location1;
            _enemy = enemy;
            DataContext = new ViewModelAbilities();
        }

        private void button_applyAbility_Click(object sender, RoutedEventArgs e)
        {
            chosenAbility.Name = text_abilityName.Text.ToString();
            chosenAbility.ManaCost = Convert.ToInt32(text_abilityMana.Text);
            chosenAbility.Level = Convert.ToInt32(text_abilityLevel.Text);
            chosenAbility.Damage = Convert.ToInt32(text_abilityDamage.Text);
            Battle.HeroSpellCaste(ref _enemy, chosenAbility);
            _location1.text_block_hp_enemy.Text = _enemy.Health.ToString();
            Close();
        }
    }
}