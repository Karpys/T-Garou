namespace KarpysDev.TGarou
{
    using KarpysUtils.TweenCustom;
    using UnityEngine;

    public class ScreenDisplay : MonoBehaviour
    {
        [SerializeField] private RectTransform m_Transform = null;
        public virtual void Display()
        {
            m_Transform.DoUIPosition(new Vector3(0, 0, 0), 0.5f);
        }
        
        public virtual void Hide()
        {
            m_Transform.DoUIPosition(new Vector3(-2000, 0, 0), 0.5f).OnComplete(() => m_Transform.anchoredPosition = new Vector2(2000,0));
        }
    }
}