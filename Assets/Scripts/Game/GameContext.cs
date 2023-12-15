using System.Collections.Generic;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Game
{
    public class GameContext
    {
        private readonly IEnumerable<IGameStartListener> _gameStartListeners;
        private readonly IEnumerable<IGameFinishListener> _gameFinishListeners;
        private readonly IEnumerable<IGamePauseListener> _gamePauseListeners;
        private readonly IEnumerable<IGameResumeListener> _gameResumeListeners;
        private readonly IEnumerable<IUpdateListener> _gameUpdateListeners;
        private readonly IEnumerable<IFixedUpdateListener> _gameFixedUpdateListeners;
        private readonly IEnumerable<ILateUpdateListener> _gameLateUpdateListeners;

        private List<IUpdateListener> _dynamicUpdateListeners = new();
        private List<IFixedUpdateListener> _dynamicFixedUpdateListeners = new();

        public GameContext(IEnumerable<IGameStartListener> gameStartListeners,
            IEnumerable<IGameFinishListener> gameFinishListeners,
            IEnumerable<IGamePauseListener> gamePauseListeners,
            IEnumerable<IGameResumeListener> gameResumeListeners,
            IEnumerable<IUpdateListener> gameUpdateListeners,
            IEnumerable<IFixedUpdateListener> gameFixedUpdateListeners,
            IEnumerable<ILateUpdateListener> gameLateUpdateListeners)
        {
            _gameStartListeners = gameStartListeners;
            _gameFinishListeners = gameFinishListeners;
            _gamePauseListeners = gamePauseListeners;
            _gameResumeListeners = gameResumeListeners;
            _gameUpdateListeners = gameUpdateListeners;
            _gameFixedUpdateListeners = gameFixedUpdateListeners;
            _gameLateUpdateListeners = gameLateUpdateListeners;
        }

        public void AddListener(IUpdateListener listener)
        {
            _dynamicUpdateListeners.Add(listener);
        }
        public void AddListener(IFixedUpdateListener listener)
        {
            _dynamicFixedUpdateListeners.Add(listener);
        }
        public void RemoveListener(IUpdateListener listener)
        {
            _dynamicUpdateListeners.Remove(listener);
        }
        public void RemoveListener(IFixedUpdateListener listener)
        {
            _dynamicFixedUpdateListeners.Remove(listener);
        }
        
        public void Start()
        {
            foreach (var startListener in _gameStartListeners)
            {
                startListener.OnStart();
            }
        }
        public void Finish()
        {
            foreach (var startListener in _gameFinishListeners)
            {
                startListener.OnFinish();
            }
        }
        public void Pause()
        {
            foreach (var startListener in _gamePauseListeners)
            {
                startListener.OnPause();
            }
        }
        public void Resume()
        {
            foreach (var startListener in _gameResumeListeners)
            {
                startListener.OnResume();
            }
        }
        public void Update(float deltaTime)
        {
            foreach (var startListener in _gameUpdateListeners)
            {
                startListener.OnUpdate(deltaTime);
            }

            foreach (var dynamicUpdateListener in _dynamicUpdateListeners)
            {
                dynamicUpdateListener.OnUpdate(deltaTime);
            }
        }
        public void FixedUpdate(float deltaTime)
        {
            foreach (var startListener in _gameFixedUpdateListeners)
            {
                startListener.OnFixedUpdate(deltaTime);
            }
            foreach (var dynamicUpdateListener in _dynamicFixedUpdateListeners)
            {
                dynamicUpdateListener.OnFixedUpdate(deltaTime);
            }
        }
        public void LateUpdate(float deltaTime)
        {
            foreach (var startListener in _gameLateUpdateListeners)
            {
                startListener.OnLateUpdate(deltaTime);
            }
        }



    }

    public interface IGameContextBinder
    {
        void AddListeners(GameObject obj);
        void RemoveListeners(GameObject obj);
    }

    public interface IGameContext : IGameContextBinder
    {
        
    }
}