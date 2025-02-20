namespace KarpysDev.TGarou
{
    using KarpysUtils;
    using UnityEngine;
    using UnityEngine.UI;

    public abstract class BaseCharacter : MonoBehaviour
    {
        [SerializeField] private CharacterInformations m_CharacterInformations = null;
        [SerializeField] private Image m_CharacterImage = null;

        private bool m_IsInfected = false;
        private int m_InfectedCount = 0;
        private bool m_IsIsolated = false;

        
        //Reset every day
        private bool m_IsProtected = false;
        
        public CharacterInformations CharacterInformations => m_CharacterInformations;
        private void Awake()
        {
            m_CharacterImage.sprite = m_CharacterInformations.Icon;
            m_IsInfected = m_CharacterInformations.IsInfected;
            m_InfectedCount = m_CharacterInformations.InfectedCount;
        }
        public abstract void StartTurn();

        private void DayReset()
        {
            m_IsIsolated = false;
            m_IsProtected = false;
        }

        public void ApplyInfection(int infectionCount)
        {
            //Patient zero case
            if(m_InfectedCount == -1)
                return;

            m_IsInfected = true;
            m_InfectedCount = infectionCount;
        }

        public void Heal()
        {
            m_IsInfected = false;
            m_InfectedCount = 0;
        }

        public void Protect()
        {
            m_IsProtected = true;
        }

        public void OnSelect()
        {
            GameEvent.Instance.OnCharacterSelect?.Invoke(this);
        }

        public void Quarantine()
        {
            m_IsIsolated = true;
        }
    }
}