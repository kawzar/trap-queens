using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Queens.Systems.Events
{
    public class NotificationCenter
    {
        #region Properties
        /// <summary>
        /// The dictionary "key" (string) represents a notificationName property to be observed
        /// The dictionary "value" (SenderTable) maps between sender and observer sub tables
        /// </summary>
        private Dictionary<string, Dictionary<object, List<Action<object, object>>>> _notificationTable = new Dictionary<string, Dictionary<object, List<Action<object, object>>>>();
        private HashSet<List<Action<object, object>>> _invoking = new HashSet<List<Action<object, object>>>();
        #endregion

        #region Singleton Pattern
        public readonly static NotificationCenter instance = new NotificationCenter();
        private NotificationCenter() { }
        #endregion

        #region Public
        public void AddObserver(Action<object, object> handler, string notificationName)
        {
            AddObserver(handler, notificationName, null);
        }

        public void AddObserver(Action<object, object> handler, string notificationName, System.Object sender)
        {
            if (handler == null)
            {
                Debug.LogError("Can't add a null event handler for notification, " + notificationName);
                return;
            }

            if (string.IsNullOrEmpty(notificationName))
            {
                Debug.LogError("Can't observe an unnamed notification");
                return;
            }
            if (!_notificationTable.ContainsKey(notificationName))
                _notificationTable.Add(notificationName, new Dictionary<object, List<Action<object, object>>>());
            Dictionary<object, List<Action<object, object>>> subTable = _notificationTable[notificationName];
            System.Object key = (sender != null) ? sender : this;
            if (!subTable.ContainsKey(key))
                subTable.Add(key, new List<Action<object, object>>());
            List<Action<object, object>> list = subTable[key];
            if (!list.Contains(handler))
            {
                if (_invoking.Contains(list))
                    subTable[key] = list = new List<Action<object, object>>(list);
                list.Add(handler);
            }
        }

        public void RemoveObserver(Action<object, object> handler, string notificationName)
        {
            RemoveObserver(handler, notificationName, null);
        }

        public void RemoveObserver(Action<object, object> handler, string notificationName, System.Object sender)
        {
            if (handler == null)
            {
                Debug.LogError("Can't remove a null event handler for notification, " + notificationName);
                return;
            }
            if (string.IsNullOrEmpty(notificationName))
            {
                Debug.LogError("A notification name is required to stop observation");
                return;
            }

            // No need to take action if we dont monitor this notification
            if (!_notificationTable.ContainsKey(notificationName))
                return;

            Dictionary<object, List<Action<object, object>>> subTable = _notificationTable[notificationName];
            System.Object key = (sender != null) ? sender : this;
            if (!subTable.ContainsKey(key))
                return;
            List<Action<object, object>> list = subTable[key];
            int index = list.IndexOf(handler);
            if (index != -1)
            {
                if (_invoking.Contains(list))
                    subTable[key] = list = new List<Action<object, object>>(list);
                list.RemoveAt(index);
            }
        }
        public void Clean()
        {
            string[] notKeys = new string[_notificationTable.Keys.Count];
            _notificationTable.Keys.CopyTo(notKeys, 0);
            for (int i = notKeys.Length - 1; i >= 0; --i)
            {
                string notificationName = notKeys[i];
                Dictionary<object, List<Action<object, object>>> senderTable = _notificationTable[notificationName];
                object[] senKeys = new object[senderTable.Keys.Count];
                senderTable.Keys.CopyTo(senKeys, 0);
                for (int j = senKeys.Length - 1; j >= 0; --j)
                {
                    object sender = senKeys[j];
                    List<Action<object, object>> handlers = senderTable[sender];
                    if (handlers.Count == 0)
                        senderTable.Remove(sender);
                }
                if (senderTable.Count == 0)
                    _notificationTable.Remove(notificationName);
            }
        }

        public void PostNotification(string notificationName)
        {
            PostNotification(notificationName, null);
        }

        public void PostNotification(string notificationName, System.Object sender)
        {
            PostNotification(notificationName, sender, null);
        }

        public void PostNotification(string notificationName, System.Object sender, System.Object e)
        {
            if (string.IsNullOrEmpty(notificationName))
            {
                Debug.LogError("A notification name is required");
                return;
            }

            // No need to take action if we dont monitor this notification
            if (!_notificationTable.ContainsKey(notificationName))
                return;

            // Post to subscribers who specified a sender to observe
            Dictionary<object, List<Action<object, object>>> subTable = _notificationTable[notificationName];
            if (sender != null && subTable.ContainsKey(sender))
            {
                List<Action<object, object>> handlers = subTable[sender];
                _invoking.Add(handlers);
                for (int i = 0; i < handlers.Count; ++i)
                    handlers[i](sender, e);
                _invoking.Remove(handlers);
            }

            // Post to subscribers who did not specify a sender to observe
            if (subTable.ContainsKey(this))
            {
                List<Action<object, object>> handlers = subTable[this];
                _invoking.Add(handlers);
                for (int i = 0; i < handlers.Count; ++i)
                    handlers[i](sender, e);
                _invoking.Remove(handlers);
            }
        }
        #endregion
    }

    public enum NotificationCode
    {
        Invalid,
        ActionInput, AllyInput, ConfigInput, WorldInput, EnemyInput, ExitInput, BusStopRequest, ChestCollision,
        BattleEnd, BattleSetup, BattleStart,
        BossTriggered,
        Cancel,
        CancelTargeting,
        ChoosingMove,
        CriticalHit,
        DialogueStarted, DialogueEnded, SendBattleDialogue,
        EnemyTurnStart,
        Defeat,
        DoorCollision,
        EffectInflicted,
        TickEffect,
        EffectRemoved,
        ExploreEnter,
        ExploreExit,
        IgnoreInput,
        ItemMenuToggle, ItemSelected,
        LevelEnter, LevelExit,
        LabEnter, LabExit,
        MainMenuEntered, MenuExit,
        MoveWasSelected, MoveInput, MoveResult,
        Pause, UnPause,
        PickupInput, PickupAcquired,
        PlayerTurnStart,
        PlayerActing,
        RoomEntry,
        RoomExit,
        SaveCollision,
        SetPartyState,
        UnitDamaged,
        UnitHealed,
        UnitMoved,
        UnitCollision,
        UnitDefeated,
        ValueUpdate,
        MenuEntered,
        SwitchScene,
        SuccessfulBlock,
        UnitRevived,
        Victory,
    };
}