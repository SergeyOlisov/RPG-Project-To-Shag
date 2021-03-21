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
<<<<<<< HEAD
        public string Name { set; get; }
        public int ManaCoast { set; get; } //расход маны на абилку
        public int Level { set; get; } //требуемый уровень
<<<<<<< Updated upstream
        public int Mana { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Value { set; get; }
=======
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
                OnPropertyChanged("Damage");
            }
        }
>>>>>>> remotes/origin/release-0.01

        public Ability() { }

        public Ability(string name, int manaCost, int level, int damage)
        {
            Name = name;
            ManaCost = manaCost;
            Level = level;
            Damage = damage;
        }
<<<<<<< HEAD

        public int AttackAbility(Ability ability)
        {
            {
                if (Mana >= ability.ManaCoast)
                {
                    if (ability is AttackSpell spell)
                    {
                        Mana -= spell.ManaCoast;
                        return spell.Value;
                    }
                }

                return 0;
            }
        }

        public int Buff(Ability ability)
        {
            if (Mana >= ability.ManaCoast)
            {
                if (ability is Buff spell)
                {
                    Mana -= spell.ManaCoast;
                    return spell.Value;
                }
            }
            return 0;
        }
    }

    public class Buff : Ability
    {
    }

    public class AttackSpell : Ability
    {
=======

        public int AttackAbility(Ability ability)
        {
            if (Player.Hero.Mana >= ability.ManaCost)
            {
                Player.Hero.Mana -= ability.ManaCost;
                return ability.Damage;
            }

            return 0;
        }
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
>>>>>>> remotes/origin/release-0.01
    }
}

