using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RPG
{
    public class Ability : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private int _manaCoast;
        private int _level;
        private int _value;
        //private string _imagepath;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public int ManaCoast  //расход маны на абилку
        {
            get { return _manaCoast; }
            set
            {
                _manaCoast = value;
                OnPropertyChanged("ManaCoast");
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
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        //public string ImagePath
        //{
        //    get { return _imagepath; }
        //    set
        //    {
        //        _imagepath = value;
        //        OnPropertyChanged("ImagePath");
        //    }
        //}


        public Ability() { }

        public Ability(string name, int manaCoast, int level, int value)
        {
            Name = name;
            ManaCoast = manaCoast;
            Level = level;
            Value = value;
        }
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }

    public class Buff : Ability
    {
        
    }

    public class AttackSpell : Ability
    {

    }
}

