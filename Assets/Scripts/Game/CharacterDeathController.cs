using System;
using ShootEmUp.Characters;
using ShootEmUp.Game;

namespace Game
{
    public class CharacterDeathController: IDisposable
    {
        private readonly GameManager _gameManager;
        private readonly CharacterDeathObserver _characterDeathObserver;
        
        public CharacterDeathController(GameManager gameManager, CharacterDeathObserver characterDeathObserver)
        {
            _gameManager = gameManager;
            _characterDeathObserver = characterDeathObserver;

            _characterDeathObserver.OnPlayerDeath += OnPlayerDeathListener;
        }

        private void OnPlayerDeathListener()
        {
            _gameManager.FinishGame();
        }

        public void Dispose()
        {
            _characterDeathObserver.OnPlayerDeath -= OnPlayerDeathListener;
        }
    }
}