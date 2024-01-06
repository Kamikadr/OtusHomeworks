using GameEngine;

namespace App
{
    public sealed class GameFacade
    {
        private GameWrapper _gameWrapper;
        public void SetupGameContext(GameWrapper gameWrapper)
        {
            _gameWrapper = gameWrapper;
        }

        public T GetService<T>()
        {
            return _gameWrapper.GetService<T>();
        }

        public void ConstructGame()
        {
            _gameWrapper.ConstructGame();
        }
    }
}