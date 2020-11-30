using System;
using System.Collections.Generic;
using System.Text;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Objects.RabbitHoles;
using Sims3.Gameplay.Actors;
using Sims3.SimIFace;
using Sims3.Gameplay.Autonomy;
using Sims3.NiecHelp.Tasks;
using Sims3.Gameplay.Abstracts;

namespace NiecMod.Interactions.Objects
{
    public class NRCODImmediateInteraction : ImmediateInteraction<Sim, GameObject>
    {
        [DoesntRequireTuning]
        public class Definition : ImmediateInteractionDefinition<Sim, GameObject, NRCODImmediateInteraction>
        {
            public override string GetInteractionName(Sim actor, GameObject target, InteractionObjectPair iop)
            {
                return "Run Command Console Dialog";
            }

            public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
               return InteractionTestResult.Pass;
            }

            public override bool Test(Sim actor, GameObject target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                return true;
            }

            public override string[] GetPath(bool isFemale)
            {
                return new string[] {
				    "NiecMod"
			    };
            }
        }

        public static readonly InteractionDefinition Singleton = new Definition();

        public override void Cleanup()
        { }

        public override bool RunFromInventory()
        {
            return Run();
        }

        public override bool Run()
        {
            NiecTask.Perform(() => {
                Nra.NFinalizeDeath.CheatWindowPro_internal();
            });
            return true;
        }
    }
}
