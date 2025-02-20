namespace KarpysDev.TGarou
{
    public class Pharmacist : BaseCharacter
    {
        public override void StartTurn()
        {
            GameManager.Instance.AddGameEvent(new PharmacistEvent(ScreenDisplayer.Instance.PharmacistScreen));
        }
    }
}