namespace ShootEmUp.Game.Interfaces.GameCycle
{
    public interface IFixedUpdateListener: IGameListener
    {
        void OnFixedUpdate(float deltaTime);
    }
}