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
            m_GameEvents.Remove(m_CurrentGameEvent);
        }

        public void EndCurrentEvent()
        {
            m_CurrentGameEvent.EndEvent();

            if (m_GameEvents.Count > 0)
            {
                m_CurrentGameEvent.StartEvent();
                m_CurrentGameEvent = m_GameEvents[0];
            }
        }

        public void NextCharacter()
        {
            if (m_CurrentCharacter == m_Characters.Length)
            {
                //Display Vote screen
                AddGameEvent(new VoteEvent(ScreenDisplayer.Instance.VoteScreen));
                StartCurrentEvent();
                return;
            }
            
            m_Characters[m_CurrentCharacter].StartTurn();
            StartCurrentEvent();
            m_CurrentCharacter++;
        }
    }

    public interface IGameEvent
    {
        public void StartEvent();
        public void EndEvent();
    }
}