using NavalVessels.Models.Contracts;
using System;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 200)
        {
            this.SubmergeMode = false;
        } 

        public bool SubmergeMode { get; private set; }
       
        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
            else
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var submergeModeText = this.SubmergeMode ? "ON" : "OFF";
            sb.AppendLine($" *Submerge mode: {submergeModeText}");
            return base.ToString() + Environment.NewLine + sb.ToString().TrimEnd();
        }
    }

}

