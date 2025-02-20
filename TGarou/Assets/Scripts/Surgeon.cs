namespace KarpysDev.TGarou
{
    public class Surgeon : BaseCharacter
    {
        public override void StartTurn()
        {
            GameManager.Instance.AddGameEvent(new SurgeonEvent());
        }
    }
}