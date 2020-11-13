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
using RPG.data.ability;
using RPG.data.helpers;

namespace RPG.data.hero.HeroWindows
{
    /// <summary>
    /// Логика взаимодействия для StudyAbilities.xaml
    /// </summary>
    public partial class StudyAbilities : Window
    {
        private readonly Location1 _location1;  
        private Ability _chosenAbility = new Ability();
        private List<Ability> _allAbilities = AbilityHelper.GetAttackSpells();
        public StudyAbilities(Location1 location1)
        {
            InitializeComponent();
            _location1 = location1;
            DataContext = new ViewModelAbilities(_allAbilities);
            text_skillPoints.Text = Player.hero.SkillPoints.ToString();
        }

        private void button_studyAbil_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _chosenAbility.Name = text_abilityName.Text;
                _chosenAbility.ManaCost = Convert.ToInt32(text_abilityMana.Text);
                _chosenAbility.Level = Convert.ToInt32(text_abilityLevel.Text);
                _chosenAbility.Damage = Convert.ToInt32(text_abilityDamage.Text);
                if (Player.hero.SkillPoints == 0)
                {
                    MessageBox.Show("Недостаточно очков учений");
                    return;
                }
                Player.hero.StudyAbility(_chosenAbility);
                text_skillPoints.Text = Player.hero.SkillPoints.ToString();
                if (Player.hero.Level < Convert.ToInt32(text_abilityLevel.Text))
                {
                    MessageBox.Show("Недостаточно высокий уровень персонажа");
                }
                Close();
            }
            catch (Exception exception)
            {
                //в лог закинем эксепшн
                Close();
            }
        }

        private void button_closeAbil_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
