using AnimalLifespan.Enums;

namespace AnimalLifespan.Interfaces
{
    public interface IAnimal
    {
        int CurrentEnergy { get; }
        Foods Diet { get; }
        bool IsAlive { get; }
        int MaxEnergy { get; }

        void Feed(Foods food);
    }
}