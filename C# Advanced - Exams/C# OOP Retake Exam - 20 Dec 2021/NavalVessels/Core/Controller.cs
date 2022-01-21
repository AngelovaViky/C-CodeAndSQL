using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private readonly VesselRepository vessels;
        private readonly ICollection<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            var vessel = this.vessels.FindByName(selectedVesselName);

            if (captain == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain.FullName != "default")
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
            else
            {
                vessel.Captain = captain;
                captain.AddVessel(vessel);
                return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var vesselAttacking = this.vessels.FindByName(attackingVesselName);
            var vesselDedending = this.vessels.FindByName(defendingVesselName);

            if (vesselAttacking == null || vesselDedending == null)
            {
                if (vesselAttacking == null)
                {
                    return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
                }
                else
                {
                    return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
                }
            }

            if (vesselAttacking.ArmorThickness == 0 || vesselDedending.ArmorThickness == 0)
            {
                if (vesselAttacking.ArmorThickness == 0)
                {
                    return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
                }
                else
                {
                    return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
                }
            }

            vesselAttacking.Attack(vesselDedending);
            vesselAttacking.Captain.IncreaseCombatExperience();
            vesselDedending.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, vesselDedending.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            var currCapitain = this.captains.First(c => c.FullName == captainFullName);

            return currCapitain.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);

            if (this.captains.FirstOrDefault(c => c.FullName == fullName) != null)
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            else
            {
                this.captains.Add(captain);
                return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            IVessel vessel;
            if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }

            this.vessels.Add(vessel);

            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            var vesselRepair = this.vessels.FindByName(vesselName);
            if (vesselRepair == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vesselRepair.RepairVessel();

            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == "Battleship")
            {
                Battleship battleshipCast = (Battleship)vessel;
                battleshipCast.ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                Submarine submarineCast = (Submarine)vessel;
                submarineCast.ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }

        }

        public string VesselReport(string vesselName)
        {
            var currVessel = this.vessels.FindByName(vesselName);
            
            return currVessel.ToString();
        }
    }
}

