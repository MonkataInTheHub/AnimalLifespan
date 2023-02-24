using AnimalLifespan.Enums;
using AnimalLifespan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLifespan.Models
{
    public class Cow : IAnimal
    {
        private int _currentEnergy;
        private Foods _food;
        private bool _isAlive;
        private IWriter _writer;
        public Cow(IWriter writer)
        {
            _food = Diet;
            _currentEnergy = MaxEnergy;
            _isAlive = true;
            _writer = writer;
        }

        public bool IsAlive { get => _isAlive; }
        public int MaxEnergy { get => 4; }
        public Foods Diet { get => Foods.Grass; }
        public int CurrentEnergy { get => _currentEnergy; }

        public void Feed(Foods food)
        {
            if (food == _food)
            {
                if (_currentEnergy < MaxEnergy)
                {
                    _currentEnergy++;
                }
            }
            else
            {
                if (_currentEnergy > 0)
                {
                    _currentEnergy--;
                }
                if (_currentEnergy == 0)
                {
                    _isAlive = false;
                }
            }
        }
    }
}
