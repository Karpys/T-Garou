namespace KarpysDev.TGarou
{
    public class SurgeonEvent : IGameEvent
    {
        private ICharacterSelector m_CharacterSelector = null;

        public SurgeonEvent(ICharacterSelector characterSelector)
        {
            m_CharacterSelector = characterSelector;
        }
        public void StartEvent()
        {
            ScreenDisplayer.Instance.DisplaySurgeonScreen(this);
        }

        public void EndEvent()
        {
            if(!CanEndEvent())
                return;
            m_CharacterSelector.CharacterSelected.Protect();
        }

        private bool CanEndEvent()
        {
            return m_CharacterSelector.CharacterSelected != null;
        }
    }
}