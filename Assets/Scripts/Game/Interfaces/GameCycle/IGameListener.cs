namespace ShootEmUp.Game.Interfaces.GameCycle
{
    public interface IGameListener
    {
        
    }
    public interface IGameStartListener: IGameListener
    {
        void OnStart();
    }
    public interface IGameFinishListener: IGameListener
    {
        void OnFinish();
    }
    public interface IGamePauseListener: IGameListener
    {
        void OnPause();
    }
    public interface IGameResumeListener: IGameListener
    {
        void OnResume();
    }
    
    public interface IUpdateListener: IGameListener
    {
        void OnUpdate(float deltaTime);
    }
    public interface IFixedUpdateListener: IGameListener
    {
        void OnFixedUpdate(float deltaTime);
    }
}