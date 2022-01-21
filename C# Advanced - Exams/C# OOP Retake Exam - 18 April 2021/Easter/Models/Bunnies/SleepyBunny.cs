
namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int CurEnergy = 50;
        private const int WorkEnergyDecrement = 5;

        public SleepyBunny(string name) : base(name, CurEnergy)
        {

        }

        public override void Work()
        {
            base.Work();
            this.Energy -= WorkEnergyDecrement;
        }
    }
}
