using RPG.data.hero;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RPG
{
    public class Ability : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private int _manaCost;
        private int _level;
        private int _damage;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public int ManaCost  //расход маны на абилку
        {
            get { return _manaCost; }
            set
            {
                _manaCost = value;
                OnPropertyChanged("ManaCost");
            }
        }
        public int Level  //требуемый уровень
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }
        public int Damage //значение урона
        {
            get { return _damage; }
            set
            {
                _damage = value;
                OnPropertyChanged("Value");
            }
        }

        public Ability() { }

        public Ability(string name, int manaCost, int level, int value)
        {
            Name = name;
            ManaCost = manaCost;
            Level = level;
            Damage = value;
        }

        public int AttackAbility(Ability ability)
        {
            if (Player.hero.Mana >= ability.ManaCost)
            {
                Player.hero.Mana -= ability.ManaCost;
                return ability.Damage;
            }

            return 0;
        }
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

