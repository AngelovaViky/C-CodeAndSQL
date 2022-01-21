using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private const int BunnyEnergy = 50;

        private readonly BunnyRepository bunnies;
        private readonly EggRepository eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }

            if(bunnyType == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);

        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var curBunny = this.bunnies.FindByName(bunnyName);

            if (curBunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);

            curBunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IWorkshop work = new Workshop();

            IEgg egg = this.eggs.FindByName(eggName);
            ICollection<IBunny> bunnys = this.bunnies.Models.Where(b => b.Energy >= BunnyEnergy)
                .OrderByDescending(b => b.Energy).ToList();

            if (!bunnys.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            while (bunnys.Any())
            {
                IBunny curBunny = bunnys.First();
                work.Color(egg, curBunny);

                if (!curBunny.Dyes.Any())
                {
                    bunnys.Remove(curBunny);
                }

                if (curBunny.Energy == 0)
                {
                    bunnys.Remove(curBunny);
                    this.bunnies.Remove(curBunny);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            return string.Format(egg.IsDone() ? OutputMessages.EggIsDone : OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            int countColoredEggs = this.eggs.Models.Count(e => e.IsDone());
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{countColoredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (IBunny bunny in this.bunnies.Models)
            {
                int countDyeIsntFinished = bunny.Dyes.Count(c => !c.IsFinished());

                sb.AppendLine($"Name: {bunny.Name}")
                  .AppendLine($"Energy: {bunny.Energy}")
                  .AppendLine($"Dyes: {countDyeIsntFinished} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
