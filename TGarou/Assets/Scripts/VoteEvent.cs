namespace KarpysDev.TGarou
{
    using UnityEngine;

    public class VoteEvent : IGameEvent
    {
        private ICharacterSelector m_CharacterSelector = null;
        public VoteEvent(ICharacterSelector characterSelector)
        {
            m_CharacterSelector = characterSelector;
        }
        public void StartEvent()
        {
            ScreenDisplayer.Instance.DisplayVoteEvent(this);
        }

        public void EndEvent()
        {
            m_CharacterSelector.CharacterSelected.Quarantine();
        }
    }
}