namespace ShootEmUp.Game.Interfaces.GameCycle
{
    public interface IGamePauseListener: IGameListener
    {
        void OnPause();
    }
}