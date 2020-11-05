using System;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Core;

using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;

using Sims3.Gameplay.Interactions;
using Sims3.SimIFace;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Objects;
using Sims3.Gameplay.Interfaces;
using System.Collections.Generic;
using NiecMod.Nra;
using NiecMod.KillNiec;
using Sims3.Gameplay.Pools;
using Sims3.Gameplay.ChildAndTeenUpdates;
using Sims3.UI;
using Sims3.Gameplay.EventSystem;
using Sims3.SimIFace.CAS;
using Sims3.Gameplay.PetSystems;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.ThoughtBalloons;
using Sims3.Gameplay.Objects.Gardening;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.Controllers.Niec;
using NiecMod.Interactions;
using Sims3.Gameplay.Scuba;
using Sims3.NiecHelp.Tasks;
using Sims3.NiecModList.Persistable;
using Sims3.Gameplay.NiecRoot;
using Sims3.Gameplay.Objects.Environment;

namespace Sims3.Gameplay.NiecInteractions
{
    public class InteractionOverrideClass
    {


        public class NTunings // NRaas
        {
            public static List<T> CloneList<T>(IEnumerable<T> old)
            {
                if (old == null) return null;

                return new List<T>(old);
            }


            public static InteractionTuning GetTuning<Target, OldType>()
                where Target : IGameObject
                where OldType : InteractionDefinition
            {
                return GetTuning(typeof(OldType), typeof(Target));
            }
            public static InteractionTuning GetTuning(Type oldType, Type target)
            {
                return AutonomyTuning.GetTuning(oldType.FullName, target.FullName);
            }

            public static InteractionTuning Inject<Target, OldType, NewType>(bool clone)
                where Target : IGameObject
                where OldType : InteractionDefinition
                where NewType : InteractionDefinition
            {
                return Inject(typeof(OldType), typeof(Target), typeof(NewType), typeof(Target), clone);
            }
            public static InteractionTuning Inject<OldTarget, OldType, NewTarget, NewType>(bool clone)
                where OldTarget : IGameObject
                where OldType : InteractionDefinition
                where NewTarget : IGameObject
                where NewType : InteractionDefinition
            {
                return Inject(typeof(OldType), typeof(OldTarget), typeof(NewType), typeof(NewTarget), clone);
            }
            protected static InteractionTuning Inject(Type oldType, Type oldTarget, Type newType, Type newTarget, bool clone)
            {
                InteractionTuning tuning = null;
                try
                {
                    tuning = AutonomyTuning.GetTuning(newType.FullName, newTarget.FullName);
                    if (tuning == null)
                    {
                        tuning = AutonomyTuning.GetTuning(oldType, oldType.FullName, oldTarget);
                        if (tuning == null) return null;


                        if (clone)
                        {
                            tuning = CloneTuning(tuning);
                        }

                        AutonomyTuning.AddTuning(newType.FullName, newTarget.FullName, tuning);
                    }

                    InteractionObjectPair.sTuningCache.Remove(new Pair<Type, Type>(newType, newTarget));
                }
                catch
                {}

                return tuning;
            }

            private static Tradeoff CloneTradeoff(Tradeoff old)
            {
                Tradeoff result = new Tradeoff();

                result.mFlags = old.mFlags;
                result.mInputs = CloneList(old.mInputs);
                result.mName = old.mName;
                result.mNumParameters = old.mNumParameters;
                result.mOutputs = CloneList(old.mOutputs);
                result.mVariableRestrictions = old.mVariableRestrictions;
                result.TimeEstimate = old.TimeEstimate;

                return result;
            }

            private static Availability CloneAvailability(Availability old)
            {
                Availability result = new Availability();

                result.mFlags = old.mFlags;
                result.AgeSpeciesAvailabilityFlags = old.AgeSpeciesAvailabilityFlags;
                result.CareerThresholdType = old.CareerThresholdType;
                result.CareerThresholdValue = old.CareerThresholdValue;
                result.ExcludingBuffs = CloneList(old.ExcludingBuffs);
                result.ExcludingTraits = CloneList(old.ExcludingTraits);
                result.MoodThresholdType = old.MoodThresholdType;
                result.MoodThresholdValue = old.MoodThresholdValue;
                result.MotiveThresholdType = old.MotiveThresholdType;
                result.MotiveThresholdValue = old.MotiveThresholdValue;
                result.RequiredBuffs = CloneList(old.RequiredBuffs);
                result.RequiredTraits = CloneList(old.RequiredTraits);
                result.SkillThresholdType = old.SkillThresholdType;
                result.SkillThresholdValue = old.SkillThresholdValue;
                result.WorldRestrictionType = old.WorldRestrictionType;
                result.OccultRestrictions = old.OccultRestrictions;
                result.OccultRestrictionType = old.OccultRestrictionType;
                result.SnowLevelValue = old.SnowLevelValue;

                result.WorldRestrictionWorldNames = CloneList(old.WorldRestrictionWorldNames);
                result.WorldRestrictionWorldTypes = CloneList(old.WorldRestrictionWorldTypes);

                return result;
            }
            private static InteractionTuning CloneTuning(InteractionTuning oldTuning)
            {
                InteractionTuning newTuning = new InteractionTuning();

                newTuning.mFlags = oldTuning.mFlags;
                newTuning.ActionTopic = oldTuning.ActionTopic;
                newTuning.AlwaysChooseBest = oldTuning.AlwaysChooseBest;
                newTuning.Availability = CloneAvailability(oldTuning.Availability);
                newTuning.CodeVersion = oldTuning.CodeVersion;
                newTuning.FullInteractionName = oldTuning.FullInteractionName;
                newTuning.FullObjectName = oldTuning.FullObjectName;
                newTuning.mChecks = CloneList(oldTuning.mChecks);
                newTuning.mTradeoff = CloneTradeoff(oldTuning.mTradeoff);
                newTuning.PosturePreconditions = oldTuning.PosturePreconditions;
                newTuning.ScoringFunction = oldTuning.ScoringFunction;
                newTuning.ScoringFunctionOnlyAppliesToSpecificCommodity = oldTuning.ScoringFunctionOnlyAppliesToSpecificCommodity;
                newTuning.ScoringFunctionString = oldTuning.ScoringFunctionString;
                newTuning.ShortInteractionName = oldTuning.ShortInteractionName;
                newTuning.ShortObjectName = oldTuning.ShortObjectName;

                return newTuning;
            }
        }














        private static bool mInited = false;

        public static bool Inited { get { return mInited; } }

        public static void Init()
        {
            if (mInited)
                return;
            
            BonehildaCoffin.AwakenBonehilda.Singleton = null;
            BonehildaCoffin.AwakenBonehilda.Singleton = new Object_BonehildaCoffin.NAwakenBonehilda.Definition();

            BonehildaCoffin.DismissBonehilda.Singleton = null;
            BonehildaCoffin.DismissBonehilda.Singleton = new Object_BonehildaCoffin.NDismissBonehilda.Definition();

            mInited = true;
        }

        
    }
}
