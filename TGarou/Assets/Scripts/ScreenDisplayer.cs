namespace KarpysDev.TGarou
{
    using KarpysUtils;
    using KarpysUtils.TweenCustom;
    using UnityEngine;

    public class ScreenDisplayer : SingletonMonoBehavior<ScreenDisplayer>
    {
        [SerializeField] private GameEvent m_GameEvent = null;
        [SerializeField] private ScreenSimpleCharacterSelector m_SurgeonScreen = null;

        private RectTransform m_CurrentScreen = null;

        private void Display(Transform nextScreen)
        {
            if(m_CurrentScreen)
                m_CurrentScreen.DoUIPosition(new Vector3(-2000, 0, 0), 0.5f).OnComplete(() => m_CurrentScreen.anchoredPosition = new Vector2(2000,0));
            nextScreen.DoUIPosition(new Vector3(0, 0, 0), 0.5f);
            m_CurrentScreen = (RectTransform)nextScreen;
        }
        
        public void DisplaySurgeonScreen(SurgeonEvent surgeonEvent)
        {
            Display(m_SurgeonScreen.transform);
            m_SurgeonScreen.ResetScreen();
            m_SurgeonScreen.AddNextButtonEvent(surgeonEvent.EndEvent);
        }
    }
}