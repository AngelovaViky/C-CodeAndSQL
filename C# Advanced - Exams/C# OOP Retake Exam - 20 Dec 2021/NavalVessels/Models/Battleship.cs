
using NavalVessels.Models.Contracts;
using System;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; } 

        public void ToggleSonarMode()
        {
            if (this.SonarMode)
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
            else
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var sonarModeText = this.SonarMode ? "ON" : "OFF";
            sb.AppendLine($" *Sonar mode: {sonarModeText}");
            return base.ToString() + Environment.NewLine + sb.ToString().TrimEnd();
        }

    }
}
