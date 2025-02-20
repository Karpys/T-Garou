namespace KarpysDev.TGarou
{
    using System;
    using System.Collections.Generic;
    using KarpysUtils;
    using UnityEngine;

    public class GameManager : SingletonMonoBehavior<GameManager>
    {
        [SerializeField] private BaseCharacter[] m_Characters = null;
        
        private List<IGameEvent> m_GameEvents = new List<IGameEvent>();
        private IGameEvent m_CurrentGameEvent = null;
        private int m_CurrentCharacter = 0;

        private void Awake()
        {
            NextCharacter();
        }

        public void AddGameEvent(IGameEvent gameEvent)
        {
            m_GameEvents.Add(gameEvent);
        }

        public void StartCurrentEvent()
        {
            m_CurrentGameEvent = m_GameEvents[0];
            m_CurrentGameEvent.StartEvent();
        }

        public void EndCurrentEvent()
        {
            m_CurrentGameEvent.EndEvent();
            m_GameEvents.Remove(m_CurrentGameEvent);
            m_CurrentGameEvent = m_GameEvents[0];
            m_CurrentGameEvent.StartEvent();
        }

        public void NextCharacter()
        {
            m_Characters[m_CurrentCharacter].StartTurn();
            StartCurrentEvent();
        }
    }

    public interface IGameEvent
    {
        public void StartEvent();
        public void EndEvent();
    }
}