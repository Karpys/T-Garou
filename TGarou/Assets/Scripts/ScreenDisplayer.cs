namespace KarpysDev.TGarou
{
    using KarpysUtils;
    using UnityEngine;

    public class ScreenDisplayer : SingletonMonoBehavior<ScreenDisplayer>
    {
        [SerializeField] private GameEvent m_GameEvent = null;
        [SerializeField] private ScreenSimpleCharacterSelector m_SurgeonScreen = null;

        private ScreenDisplay m_CurrentScreen = null;

        private void Display(ScreenDisplay nextScreen)
        {
            if(m_CurrentScreen)
                m_CurrentScreen.Hide();
            nextScreen.Display();
            m_CurrentScreen = nextScreen;
        }
        
        public void DisplaySurgeonScreen(SurgeonEvent surgeonEvent)
        {
            Display(m_SurgeonScreen);
            m_SurgeonScreen.AddNextButtonEvent(surgeonEvent.EndEvent);
        }
    }
}