using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 && bunny.Dyes.Any())
            {
                IDye dye = bunny.Dyes.First();

                while (!egg.IsDone() && bunny.Energy > 0 && !dye.IsFinished())
                {
                    bunny.Work();
                    egg.GetColored();
                    dye.Use();
                }

                if (dye.IsFinished())
                {
                    bunny.Dyes.Remove(dye);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
