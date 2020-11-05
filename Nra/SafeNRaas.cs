using System;
using System.Collections.Generic;
using System.Text;
using Sims3.Gameplay.CAS;
using NiecMod.KillNiec;
using NRaas.CommonSpace.Helpers;
using NiecMod.Helpers;
using Sims3.NiecHelp.Tasks;
using Sims3.SimIFace.CAS;
namespace NiecMod.Nra
{
    public static class SafeNRaas
    {
        public static bool isnraasloaded = AssemblyCheckByNiec.IsInstalled("NRaasMasterController");

        public static void NRCASParts_RemoveOutfits(SimDescriptionCore sim, OutfitCategories category, bool alternate)
        {
            if (!isnraasloaded) { sim.RemoveOutfits(category, true); return; }
            NiecNraTask.NraFunction temp = delegate
            {
                NRaas.CommonSpace.Helpers.CASParts.RemoveOutfits(sim, category, alternate);
            };
            temp();
        }
        public static void NRUrnstones_CreateGrave(SimDescription me, SimDescription.DeathType deathType, bool ignoreExisting, bool report)
        {
            if (!isnraasloaded) { NFinalizeDeath.GetKillNPCSimToGhost(me.CreatedSim, deathType); return; }
            NiecNraTask.NraFunction temp = delegate {
                Urnstones.CreateGrave(me, deathType, ignoreExisting, report);
            };
           // Delegate sdfsde = temp as Delegate;
            //Delegate.Remove(temp, sdfsde);
            temp();
        }
    }
}
