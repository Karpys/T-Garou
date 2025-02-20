namespace KarpysDev.TGarou
{
    using System;
    using KarpysUtils;

    public class GameEvent : SingletonMonoBehavior<GameEvent>
    {
        public Action<BaseCharacter> OnCharacterSelect = null;
    }
}