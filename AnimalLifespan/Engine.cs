using AnimalLifespan.Interfaces;
using AnimalLifespan.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLifespan
{
    public class Engine
    {
        IWriter _writer;
        IReader _reader;
        List<IAnimal> _cows;
        List<IAnimal> _wolves;
        List<IAnimal> _squirrels;
        int counter;
        int _max;
        int _min;
        int avg;

        public Engine(IWriter writer, IReader reader)
        {
            _writer = writer;
            _reader = reader;
            _cows = new List<IAnimal>();
            _wolves = new List<IAnimal>();
            _squirrels = new List<IAnimal>();
            _max = int.MinValue;
            _min = int.MaxValue;
        }

        public void Run(IContainer container)
        {
            try
            {
                FillAnimalsCount(container);
                var cowSb = FeedCows(counter, _max, _min, avg, container);
                var wolvesSb = FeedWolves(counter, _max, _min, avg, container);
                var squirrelsSb = FeedSquirrels(counter, _max, _min, avg, container);
                _writer.WriteLine("Cows:");
                _writer.WriteLine(cowSb.ToString());
                _writer.WriteLine("Wolves:");
                _writer.WriteLine(wolvesSb.ToString());
                _writer.WriteLine("Squirrels:");
                _writer.WriteLine(squirrelsSb.ToString());
            }
            catch
            {
                _writer.WriteLine("Invalid number");
            }
        }
        public void FillAnimalsCount(IContainer container)
        {
            _writer.WriteLine("Enter the amount of cows");
            int cowsCounter = _reader.ReadNumbers();
            if (cowsCounter<0)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < cowsCounter; i++)
            {
                _cows.Add(container.Resolve<Cow>());
            }

            _writer.WriteLine("Enter the amount of wolves");
            int wolvesCounter = _reader.ReadNumbers();
            if (wolvesCounter < 0)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < wolvesCounter; i++)
            {
                _wolves.Add(container.Resolve<Wolf>());
            }

            _writer.WriteLine("Enter the amount of squrrels");
            int squirrelsCounter = _reader.ReadNumbers();
            if (squirrelsCounter < 0)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < squirrelsCounter; i++)
            {
                _squirrels.Add(container.Resolve<Squirrel>());
            }
        }

        public StringBuilder FeedCows(int counter, int max, int min, double avg, IContainer container)
        {
            var sb = container.Resolve<StringBuilder>();
            foreach (IAnimal cow in _cows)
            {
                while (cow.IsAlive)
                {
                    _writer.WriteLine("You are feeding a cow");
                    _writer.WriteLine("0- Grass");
                    _writer.WriteLine("1- Meat");
                    _writer.WriteLine("2- Nut");
                    _writer.WriteLine("Any other number- Without food");
                    cow.Feed((Enums.Foods)_reader.ReadNumbers());
                    counter++;
                }
                if (counter > max)
                {
                    max = counter;
                }
                if (counter < min)
                {
                    min = counter;
                }
                avg += counter;
                counter = 0;
            }
            avg = avg / _cows.Count;
            sb.AppendLine($"Maximum lifespan: {max} feeds");
            sb.AppendLine($"Minimum lifespan: {min} feeds");
            sb.AppendLine($"Average lifepsan: {avg} feeds");

            return sb;
        }
        public StringBuilder FeedWolves(int counter, int max, int min, double avg, IContainer container)
        {
            var sb = container.Resolve<StringBuilder>();
            foreach (IAnimal wolf in _wolves)
            {
                while (wolf.IsAlive)
                {
                    _writer.WriteLine("You are feeding a wolf");
                    _writer.WriteLine("0- Grass");
                    _writer.WriteLine("1- Meat");
                    _writer.WriteLine("2- Nut");
                    _writer.WriteLine("Any other number- Without food");
                    wolf.Feed((Enums.Foods)_reader.ReadNumbers());
                    counter++;
                }
                if (counter > max)
                {
                    max = counter;
                }
                if (counter < min)
                {
                    min = counter;
                }
                avg += counter;
                counter = 0;
            }
            avg = avg / _wolves.Count;
            sb.AppendLine($"Maximum lifespan: {max} feeds");
            sb.AppendLine($"Minimum lifespan: {min} feeds");
            sb.AppendLine($"Average lifepsan: {avg} feeds");

            return sb;
        }
        public StringBuilder FeedSquirrels(int counter, int max, int min, double avg, IContainer container)
        {
            var sb = container.Resolve<StringBuilder>();
            foreach (IAnimal squirrel in _squirrels)
            {
                while (squirrel.IsAlive)
                {
                    _writer.WriteLine("You are feeding a squirrel");
                    _writer.WriteLine("0- Grass");
                    _writer.WriteLine("1- Meat");
                    _writer.WriteLine("2- Nut");
                    _writer.WriteLine("Any other number- Without food");
                    squirrel.Feed((Enums.Foods)_reader.ReadNumbers());
                    counter++;
                }
                if (counter > max)
                {
                    max = counter;
                }
                if (counter < min)
                {
                    min = counter;
                }
                avg += counter;
                counter = 0;
            }
            avg = avg / _squirrels.Count;
            sb.AppendLine($"Maximum lifespan: {max} feeds");
            sb.AppendLine($"Minimum lifespan: {min} feeds");
            sb.AppendLine($"Average lifepsan: {avg} feeds");

            return sb;
        }
    }
}
