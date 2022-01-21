using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;

        protected Bunny()
        {
            this.Dyes = new List<IDye>();
        }

        protected Bunny(string name, int energy) : this()
        {
            this.Name = name;
            this.Energy = energy;
           
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set => this.energy = value > 0 ? value : 0;
        }

        public ICollection<IDye> Dyes { get; }

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }

        public virtual void Work()
        {
            this.Energy -= 10;
        }
        
    }
}
