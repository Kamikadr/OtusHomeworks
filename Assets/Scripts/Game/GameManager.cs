using System.Collections.Generic;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Game
{
    [DefaultExecutionOrder(-1)]
    public sealed class GameManager : MonoBehaviour
    {
        private readonly List<IGameStartListener> _gameStartListeners = new();
        private readonly List<IGameFinishListener> _gameFinishListeners = new();
        private readonly List<IGamePauseListener> _gamePauseListeners = new();
        private readonly List<IGameResumeListener> _gameResumeListeners = new();
        private readonly List<IUpdateListener> _gameUpdateListeners = new();
        private readonly List<IFixedUpdateListener> _gameFixedUpdateListeners = new();

        private bool _needUpdate;

        private void Awake()
        {
            AddListeners(gameObject);
        }

        public void AddListeners(GameObject obj)
        {
            var listeners = obj.GetComponentsInChildren<IGameListener>(true);
            foreach (var listener in listeners)
            {
                if (listener is IGameStartListener gameStartListener)
                {
                    _gameStartListeners.Add(gameStartListener);
                }

                if (listener is IGamePauseListener gamePauseListener)
                {
                    _gamePauseListeners.Add(gamePauseListener);
                }

                if (listener is IGameResumeListener gameResumeListener)
                {
                    _gameResumeListeners.Add(gameResumeListener);
                }

                if (listener is IGameFinishListener gameFinishListener)
                {
                    _gameFinishListeners.Add(gameFinishListener);
                }

                if (listener is IFixedUpdateListener gameFixedUpdateListener)
                {
                    _gameFixedUpdateListeners.Add(gameFixedUpdateListener);
                }

                if (listener is IUpdateListener gameUpdateListener)
                {
                    _gameUpdateListeners.Add(gameUpdateListener);
                }
            }
        }
        public void RemoveListeners(GameObject obj)
        {
            var listeners = obj.GetComponentsInChildren<IGameListener>(true);
            
            foreach (var listener in listeners)
            {
                if (listener is IGameStartListener gameStartListener)
                {
                    _gameStartListeners.Remove(gameStartListener);
                }

                if (listener is IGamePauseListener gamePauseListener)
                {
                    _gamePauseListeners.Remove(gamePauseListener);
                }

                if (listener is IGameResumeListener gameResumeListener)
                {
                    _gameResumeListeners.Remove(gameResumeListener);
                }

                if (listener is IGameFinishListener gameFinishListener)
                {
                    _gameFinishListeners.Remove(gameFinishListener);
                }

                if (listener is IFixedUpdateListener gameFixedUpdateListener)
                {
                    _gameFixedUpdateListeners.Remove(gameFixedUpdateListener);
                }

                if (listener is IUpdateListener gameUpdateListener)
                {
                    _gameUpdateListeners.Remove(gameUpdateListener);
                }
            }
        }



        public void StartGame()
        {
            for (var i = 0; i < _gameStartListeners.Count; i++)
            {
                _gameStartListeners[i].OnStart();
            }
            
            Debug.Log("Game start!");
            Time.timeScale = 1;
            _needUpdate = true;
        }
        public void FinishGame()
        {
            for (var i = 0; i < _gameFinishListeners.Count; i++)
            {
                _gameFinishListeners[i].Finish();
            }
            
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
        public void PauseGame()
        {
            for (var i = 0; i < _gamePauseListeners.Count; i++)
            {
                _gamePauseListeners[i].Pause();
            }
            Time.timeScale = 0;
            _needUpdate = false;
        }
        public void ResumeGame()
        {
            for (var i = 0; i < _gameResumeListeners.Count; i++)
            {
                _gameResumeListeners[i].Resume();
            }
            Time.timeScale = 1;
            _needUpdate = true;
        }
        
        private void FixedUpdate()
        {
            if (!_needUpdate) return;
            
            for (var i = 0; i < _gameFixedUpdateListeners.Count; i++)
            {
                _gameFixedUpdateListeners[i].OnFixedUpdate();
            }
        }

        private void Update()
        {
            if (!_needUpdate) return;
            
            for (var i = 0; i < _gameUpdateListeners.Count; i++)
            {
                _gameUpdateListeners[i].OnUpdate();
            }
        }
    }
}