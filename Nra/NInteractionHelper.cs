using System;
using System.Collections.Generic;
using System.Text;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Objects.RabbitHoles;
using Sims3.Gameplay.Abstracts;
using Sims3.SimIFace;
using Sims3.Gameplay.Objects.Electronics;
using Sims3.Gameplay.Actors;

namespace NiecMod.Nra
{
    public class NInteractionHelper // Gamefreak130 user fail
    {
        internal static void InitInjection()
        {
            var o0 = NFinalizeDeath.SC_GetObjects<Sim>();
            for (int i = 0; i < o0.Length; i++)
            {
                Instantiator.AddInteractions(o0[i]);
            }

            var o1 = NFinalizeDeath.SC_GetObjects<CityHall>();
            for (int i = 0; i < o1.Length; i++)
            {
                NFinalizeDeath.GO_AddInteraction(o1[i], NiecMod.Interactions.Objects.NRCODImmediateInteraction.Singleton, true);
            }

            var o2 = NFinalizeDeath.SC_GetObjects<Computer>();
            for (int i = 0; i < o2.Length; i++)
            {
                NFinalizeDeath.GO_AddInteraction(o2[i], NiecMod.Interactions.Objects.NRCODImmediateInteraction.Singleton, true);
            }

            if (EventTracker.Instance != null)
            {
                EventTracker.AddListener(EventTypeId.kSimInstantiated, OnSimInstantiated);

                EventTracker.AddListener(EventTypeId.kInventoryObjectAdded, OnObjectChanged);
                EventTracker.AddListener(EventTypeId.kObjectStateChanged, OnObjectChanged);

                EventTracker.AddListener(EventTypeId.kBoughtObject, OnNewObject);
                EventTracker.AddListener(EventTypeId.kBoughtObjectAtRabbithole, OnNewObject);
                EventTracker.AddListener(EventTypeId.kBoughtConcessionsStandFood, OnNewObject);
            }

            World.OnObjectPlacedInLotEventHandler += OnObjectPlacedInLot;
        }

        private static ListenerAction OnSimInstantiated(Event e)
        {
            Sim sim = e.TargetObject as Sim;
            if (sim != null)
            {
                Instantiator.AddInteractions(sim);
            }
            return ListenerAction.Keep;
        }

        private static ListenerAction OnObjectChanged(Event e)
        {
            var o = e.TargetObject;
            if (o is Computer || o is CityHall)
            {
                NFinalizeDeath.GO_AddInteraction(o as GameObject, NiecMod.Interactions.Objects.NRCODImmediateInteraction.Singleton, true);
            }
            return ListenerAction.Keep;
        }

        private static void OnObjectPlacedInLot(object sender, EventArgs e)
        {
            var args = e as World.OnObjectPlacedInLotEventArgs;
            if (args != null)
            {
                var gameObject = NFinalizeDeath.GetObject_internalFast(args.ObjectId.mValue);
                if (gameObject is Computer || gameObject is CityHall)
                {
                    NFinalizeDeath.GO_AddInteraction(gameObject, NiecMod.Interactions.Objects.NRCODImmediateInteraction.Singleton, true);
                }
            }
        }

        private static ListenerAction OnNewObject(Event e)
        {
            var gameObject = e.TargetObject as GameObject;

            if (gameObject is Computer || gameObject is CityHall)
            {
                NFinalizeDeath.GO_AddInteraction(gameObject, NiecMod.Interactions.Objects.NRCODImmediateInteraction.Singleton, true);
            }

            return ListenerAction.Keep;
        }
    }
}
