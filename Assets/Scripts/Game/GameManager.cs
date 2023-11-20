using System;
using System.Collections.Generic;
using ShootEmUp.Game.Interfaces;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Game
{
    public sealed class GameManager : MonoBehaviour, IGameManager
    {
        private List<IGameStartListener> _gameStartListeners = new();
        private List<IGameFinishListener> _gameFinishListeners = new();
        private List<IGamePauseListener> _gamePauseListeners = new();
        private List<IGameResumeListener> _gameResumeListeners = new();
        private List<IUpdateListener> _gameUpdateListeners = new();
        private List<IFixedUpdateListener> _gameFixedUpdateListeners = new();
        private void Awake()
        {
            var listeners = GetComponentsInChildren<IGameListener>(true);

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

        


        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }

        public void StartGame()
        {
            Debug.Log("Game start!");
            Time.timeScale = 1;
        }
        
        private void FixedUpdate()
        {
            for (var i = 0; i < _gameFixedUpdateListeners.Count; i++)
            {
                _gameFixedUpdateListeners[i].FixedUpdate();
            }
        }

        private void Update()
        {
            for (var i = 0; i < _gameUpdateListeners.Count; i++)
            {
                _gameUpdateListeners[i].Update();
            }
        }
    }

   
    
    
}