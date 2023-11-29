using System.Collections.Generic;
using App;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Game
{
    
    public sealed class GameManager : MonoBehaviour
    {
        private readonly List<IGameStartListener> _gameStartListeners = new();
        private readonly List<IGameFinishListener> _gameFinishListeners = new();
        private readonly List<IGamePauseListener> _gamePauseListeners = new();
        private readonly List<IGameResumeListener> _gameResumeListeners = new();
        private readonly List<IUpdateListener> _gameUpdateListeners = new();
        private readonly List<IFixedUpdateListener> _gameFixedUpdateListeners = new();

        private GameState _gameState;
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
            if (_gameState != GameState.None && _gameState != GameState.Finished)
            {
                return;
            }
            
            for (var i = 0; i < _gameStartListeners.Count; i++)
            {
                _gameStartListeners[i].OnStart();
            }
            
            Debug.Log("Game start!");
            Time.timeScale = 1;
            _gameState = GameState.Playing;
        }
        public void FinishGame()
        {
            if (_gameState != GameState.Playing)
            {
                return;
            }
            
            for (var i = 0; i < _gameFinishListeners.Count; i++)
            {
                _gameFinishListeners[i].OnFinish();
            }
            
            Debug.Log("Game over!");
            Time.timeScale = 0;
            _gameState = GameState.Finished;
        }
        public void PauseGame()
        {
            if (_gameState != GameState.Playing)
            {
                return;
            }
            
            for (var i = 0; i < _gamePauseListeners.Count; i++)
            {
                _gamePauseListeners[i].OnPause();
            }
            Time.timeScale = 0;
            _gameState = GameState.Paused;
        }
        public void ResumeGame()
        {
            if (_gameState != GameState.Paused)
            {
                return;
            }
            
            for (var i = 0; i < _gameResumeListeners.Count; i++)
            {
                _gameResumeListeners[i].OnResume();
            }
            Time.timeScale = 1;
            _gameState = GameState.Playing;
        }
        
        private void FixedUpdate()
        {
            if (_gameState != GameState.Playing) return;
            
            for (var i = 0; i < _gameFixedUpdateListeners.Count; i++)
            {
                _gameFixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }

        private void Update()
        {
            if (_gameState != GameState.Playing) return;
            
            for (var i = 0; i < _gameUpdateListeners.Count; i++)
            {
                _gameUpdateListeners[i].OnUpdate(Time.deltaTime);
            }
        }
    }
}