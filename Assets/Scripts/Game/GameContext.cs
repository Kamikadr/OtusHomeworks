using System.Collections.Generic;
using ShootEmUp.Game.Interfaces.GameCycle;
using UnityEngine;

namespace ShootEmUp.Game
{
    public class GameContext: IGameContextBinder
    {
        private readonly List<IGameStartListener> _gameStartListeners = new();
        private readonly List<IGameFinishListener> _gameFinishListeners = new();
        private readonly List<IGamePauseListener> _gamePauseListeners = new();
        private readonly List<IGameResumeListener> _gameResumeListeners = new();
        private readonly List<IUpdateListener> _gameUpdateListeners = new();
        private readonly List<IFixedUpdateListener> _gameFixedUpdateListeners = new();


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