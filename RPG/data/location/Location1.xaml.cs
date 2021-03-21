using System;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;
using RPG.data.hero;
<<<<<<< HEAD
using RPG.data.location;
=======
using System.Windows.Media;
using System.IO;
using RPG.data.location;
using RPG.data.hero.HeroWindows;
>>>>>>> remotes/origin/release-0.01

namespace RPG
{
    public partial class Location1 : Window
    {
<<<<<<< HEAD

        IAbility attacSpell = Player.hero;
        TaskCompletionSource<bool> End = new TaskCompletionSource<bool>();
        int mana = 10;
        int tempManaHero = Player.hero.Mana;
        Enemy enemy = new Enemy()
        {
            Name = "Skelet",
            Level = 1,
            Experience = 20,
            Health = 15,
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



=======
        Enemy enemy = new Enemy(Player.Hero);
        public bool isSpellCast = false;
        private bool _isAttack = false;
        //private bool _isPotionUsed = false;
>>>>>>> remotes/origin/release-0.01
        public Location1()
        {
            InitializeComponent();
            HP_Hero.Text = Player.Hero.Health.ToString();
            Mana_Hero.Text = Player.Hero.Mana.ToString();
            HP_Enemy.Text = enemy.Health.ToString();
            Mana_Enemy.Text = enemy.Mana.ToString();
            Count_Health_Potion.Text = Player.HealthPotions.ToString();
            Count_Mana_Potion.Text = Player.ManaPotions.ToString();
        }
        public void EndFight() 
        {
            if (enemy.Health <= 0 || Player.Hero.Health <=0)
            {
<<<<<<< HEAD
                DamageEnemy();
            }
            if(enemy.Health <= 0)
            {
                Battle.IsEnemyDead(ref enemy);
                ShowStatistics.Items.Add(Player.hero.Experience);
                Player.TempHeroSave(Player.hero);
=======
                var Briefing = new Briefing();
                Briefing.Show();
                Close();
>>>>>>> remotes/origin/release-0.01
            }
        }
        private void Exit_x_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }
        private void RollUp_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Polygon_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Polygon_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Polygon_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Polygon_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Ability_Hero_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isSpellCast)
            {
                MessageBox.Show("Нельзя повторно применить заклинание", "Achtung!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var ChoiceAbilities = new ChoiceAbilities(this, ref enemy);
            ChoiceAbilities.Show();
        }

        private void Attack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_isAttack)
            {
                MessageBox.Show("Нельзя повторно атаковать", "Achtung!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Battle.HeroAttack(ref enemy);
            _isAttack = true;
            EndFight();
            HP_Enemy.Text = enemy.Health.ToString();
            Mana_Enemy.Text = enemy.Mana.ToString();
        }

        private void EndTurn_MouseDown(object sender, MouseButtonEventArgs e)
        {
<<<<<<< HEAD
            Player.hero.Mana -= 10;
            Player.hero.Ability.Find(abil => abil == attackSpell);
            enemy.Health -= attackSpell.AttackAbility(attackSpell);
            ShowStatistics.Items.Add("Mana " + Player.hero.Mana);
=======
            isSpellCast = false;
            _isAttack = false;
            Battle.EnemyAttack(ref enemy);
            HP_Hero.Text = Player.Hero.Health.ToString();
            EndFight();
>>>>>>> remotes/origin/release-0.01
        }
       
        private void UseHealthPotion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Player.UseHealthPotion();
            Count_Health_Potion.Text = Player.HealthPotions.ToString();
            HP_Hero.Text = Player.Hero.Health.ToString();
        }
        private void UseManaPotion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Player.UseManaPotion();
            Count_Mana_Potion.Text = Player.ManaPotions.ToString();
            Mana_Hero.Text = Player.Hero.Mana.ToString();
        }
    }
}
