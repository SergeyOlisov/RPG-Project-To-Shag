using RPG.data.hero;
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

namespace RPG
{
    /// <summary>
    /// Логика взаимодействия для WindowStaticHero.xaml
    /// </summary>
    public partial class WindowStaticHero : Window
    {
        Hero hero = Player.GetHero();
        int strenght;
        int agility;
        int intellect;
        int vitality;
        int statPoints;
        public WindowStaticHero()
        {
            strenght = hero.Strength;
            agility = hero.Agility;
            intellect = hero.Intellect;
            vitality = hero.Vitality;
            statPoints = hero.StatPoints;
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            TextBloc_Hero_Level.Text = hero.Level.ToString();
            TextBloc_Hero_Name.Text = hero.Name;
            TextBloc_Hero_Agility.Text = hero.Agility.ToString();
            TextBloc_Hero_Intelect.Text = hero.Intellect.ToString();
            TextBloc_Hero_Strenght.Text = hero.Strength.ToString();
            TextBloc_Hero_Vitality.Text = hero.Vitality.ToString();
            TextBloc_Hero_Stat_Points.Text = hero.StatPoints.ToString();
            TextBloc_Hero_Experience.Text = hero.Experience.ToString();
        }

        private void Button_Strenght_Down_Click(object sender, RoutedEventArgs e)
        {
            if(strenght > hero.Strength)
            {
                strenght--;
                statPoints++;
            }
            TextBloc_Hero_Strenght.Text = strenght.ToString();
            TextBloc_Hero_Stat_Points.Text = statPoints.ToString();
        }

        private void Button_Strenght_Up_Click(object sender, RoutedEventArgs e)
        {
            if(statPoints > 0)
            {
                strenght++;
                statPoints--;
            }
            TextBloc_Hero_Strenght.Text = strenght.ToString();
            TextBloc_Hero_Stat_Points.Text = statPoints.ToString();
        }

        private void Button_Agility_Down_Click(object sender, RoutedEventArgs e)
        {
            if (agility > hero.Agility)
            {
                agility--;
                statPoints++;
            }
            TextBloc_Hero_Agility.Text = agility.ToString();
            TextBloc_Hero_Stat_Points.Text = statPoints.ToString();
        }

        private void Button_Agility_Up_Click(object sender, RoutedEventArgs e)
        {
            if (statPoints > 0)
            {
                agility++;
                statPoints--;
            }
            TextBloc_Hero_Agility.Text = agility.ToString();
            TextBloc_Hero_Stat_Points.Text = statPoints.ToString();
        }

        private void Button_Intelect_Down_Click(object sender, RoutedEventArgs e)
        {
            if (intellect > hero.Intellect)
            {
                intellect--;
                statPoints++;
            }
            TextBloc_Hero_Intelect.Text = intellect.ToString();
            TextBloc_Hero_Stat_Points.Text = statPoints.ToString();
        }

        private void Button_Intelect_Up_Click(object sender, RoutedEventArgs e)
        {
            if (statPoints > 0)
            {
                intellect++;
                statPoints--;
            }
            TextBloc_Hero_Intelect.Text = intellect.ToString();
            TextBloc_Hero_Stat_Points.Text = statPoints.ToString();
        }

        private void Button_Vitality_Down_Click(object sender, RoutedEventArgs e)
        {
            if (vitality > hero.Vitality)
            {
                vitality--;
                statPoints++;
            }
            TextBloc_Hero_Vitality.Text = vitality.ToString();
            TextBloc_Hero_Stat_Points.Text = statPoints.ToString();
        }

        private void Button_Vitality_Up_Click(object sender, RoutedEventArgs e)
        {
            if (statPoints > 0)
            {
                vitality++;
                statPoints--;
            }
            TextBloc_Hero_Vitality.Text = vitality.ToString();
            TextBloc_Hero_Stat_Points.Text = statPoints.ToString();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            var heroStrenght = hero.Strength;
            var heroAgility = hero.Agility;
            var heroIntellect = hero.Intellect;
            var heroVitality = hero.Vitality;

            for (int i = 0; i < strenght - heroStrenght; i++)
            {
                hero.StrengthUp();
            }

            for (int i = 0; i < vitality - heroVitality; i++)
            {
                hero.VitalityUp();
            }

            for (int i = 0; i < intellect - heroIntellect; i++)
            {
                hero.IntellectUp();
            }

            for (int i = 0; i < agility - heroAgility; i++)
            {
                hero.AgilityUp();
            }

            Player.TempHeroSave(hero);
        }
    }
}
