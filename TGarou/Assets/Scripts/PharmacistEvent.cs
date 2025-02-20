namespace KarpysDev.TGarou
{
    public class 
        PharmacistEvent : IGameEvent
    {
        private ICharacterSelector m_CharacterSelector = null;

        public PharmacistEvent(ICharacterSelector characterSelector)
        {
            m_CharacterSelector = characterSelector;
        }
        public void StartEvent()
        {
            ScreenDisplayer.Instance.DisplayPharmacistScreen(this);
        }

        public void EndEvent()
        {
            if(!CanEndEvent())
                return;
            m_CharacterSelector.CharacterSelected.Protect();
            GameManager.Instance.NextCharacter();
        }

        private bool CanEndEvent()
        {
            return m_CharacterSelector.CharacterSelected != null;
        }
    }
}