using GameEngine;
using Zenject;

namespace DefaultNamespace
{
    public class GameFacade
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