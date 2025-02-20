namespace KarpysDev.TGarou
{
    using KarpysUtils;
    using UnityEngine;

    public class ScreenDisplayer : SingletonMonoBehavior<ScreenDisplayer>
    {
        [SerializeField] private GameEvent m_GameEvent = null;
        [SerializeField] private ScreenSimpleCharacterSelector m_VoteScreen = null;
        [SerializeField] private ScreenSimpleCharacterSelector m_PharmacistScreen = null;

        private ScreenDisplay m_CurrentScreen = null;
        public ScreenSimpleCharacterSelector PharmacistScreen => m_PharmacistScreen;
        public ScreenSimpleCharacterSelector VoteScreen => m_VoteScreen;

        private void Display(ScreenDisplay nextScreen)
        {
            if(m_CurrentScreen)
                m_CurrentScreen.Hide();
            nextScreen.Display();
            m_CurrentScreen = nextScreen;
        }
        
        public void DisplayPharmacistScreen(PharmacistEvent pharmacistEvent)
        {
            Display(m_PharmacistScreen);
            //m_PharmacistScreen.AddNextButtonEvent(pharmacistEvent.EndEvent);
        }

        public void DisplayVoteEvent(VoteEvent voteEvent)
        {
            Display(m_VoteScreen);
            //m_VoteScreen.AddNextButtonEvent(voteEvent.EndEvent);
        }
    }
}