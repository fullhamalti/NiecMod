using System;
using System.Collections.Generic;
using System.Text;
using NiecMod.KillNiec;
using Sims3.Gameplay.Actors;
using Sims3.NiecHelp.Tasks;
using Sims3.Gameplay.NiecInteractions;
using Sims3.Gameplay.Autonomy;

namespace Sims3.Gameplay.NiecNonOpenDGS.Interactions
{
    public class NonOpenDGS_InteractionOverrides
    {
        internal static bool mDeveloperOnly = 

#if __My || __DeveloperOnly
            true;
#else
            false;
#endif

        private static bool mInited = false;

        public static bool _IsOpenDGSInstalled = AssemblyCheckByNiec.IsInstalled("OpenDGS");

        public static bool Inited { get { return mInited; } } // dont need =>

        public static void Init()
        {
            if (mInited)
                return;
            if (mDeveloperOnly) {
                Sim.DeathReaction.Singleton = null;
                Sim.DeathReaction.Singleton = new Object_ActorsSim.NDeathReaction.Definition();

                Sim.FollowParent.Singleton = null;
                Sim.FollowParent.Singleton = new Object_ActorsSim.NFollowParent.Definition();
            }

            // Grim Reaper Situation

            Services.GrimReaperSituation.ReapSoul.Singleton = null;
            Services.GrimReaperSituation.ReapSoul.Singleton = new GRSOv.ReapSoul_Definition();

            Services.GrimReaperSituation.ReapPetSoul.PetSingleton = null;
            Services.GrimReaperSituation.ReapPetSoul.PetSingleton = new GRSOv.ReapSoulPet_Definition();

            Services.GrimReaperSituation.ReapSoulDiving.DivingSingleton = null;
            Services.GrimReaperSituation.ReapSoulDiving.DivingSingleton = new GRSOv.ReapSoulDiving_Definition();

            Services.GrimReaperSituation.GrimReaperAppear.Singleton = null;
            Services.GrimReaperSituation.GrimReaperAppear.Singleton = new GRSOv.GrimReaperAppear_Definition();

            //

            Sim.ReadSomethingInInventory.Singleton = null;
            Sim.ReadSomethingInInventory.Singleton = new Object_ActorsSim.NReadSomethingInInventory.Definition();

            try
            {
                InteractionTuning aTuning = InteractionOverrideClass.NTunings.Inject<Sim, Sim.ReadSomethingInInventory.Definition, Object_ActorsSim.NReadSomethingInInventory.Definition>(clone: false);
                if (aTuning != null)
                {
                    aTuning.SetFlags(InteractionTuning.FlagField.DisallowUserDirected, false);
                    aTuning.SetFlags(InteractionTuning.FlagField.DisallowPlayerSim, false);
                    aTuning.SetFlags(InteractionTuning.FlagField.DisallowAutonomous, false);
                    aTuning.Availability.Teens = true;
                    aTuning.Availability.Children = true;
                }
            }
            catch (Exception)
            { }
            

            mInited = true;
        }
    }
}
