namespace ShootEmUp.Game.Interfaces.GameCycle
{
    public interface IGameFinishListener: IGameListener
    {
        void OnFinish();
    }
}