using System;
using App;
using Game;
using UnityEngine;
using VContainer;

namespace ShootEmUp.Game
{
    
    public sealed class GameManager: MonoBehaviour
    {
        //private readonly GameContext _gameContext;

        private GameState _gameState = GameState.None;

        private GameContext _gameContext;
        
        [Inject]
        public void Construct(GameContext gameContext) 
        {
           _gameContext = gameContext; 
        }


       public void StartGame()
        {
            if (_gameState != GameState.None && _gameState != GameState.Finished)
            {
                return;
            }
            
            _gameContext.Start();
            
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
            
            _gameContext.Finish();
            
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
            
            _gameContext.Pause();
            
            Time.timeScale = 0;
            _gameState = GameState.Paused;
        }
        public void ResumeGame()
        {
            if (_gameState != GameState.Paused)
            {
                return;
            }
            
            _gameContext.Resume();
            Time.timeScale = 1;
            _gameState = GameState.Playing;
        }
        
        private void FixedUpdate()
        {
            if (_gameState != GameState.Playing) return;
            
            _gameContext.FixedUpdate(Time.fixedDeltaTime);
        }

        private void Update()
        {
            if (_gameState != GameState.Playing) return;
            
            _gameContext.Update(Time.deltaTime);
        }
        private void LateUpdate()
        {
            if (_gameState != GameState.Playing) return;
            
            _gameContext.LateUpdate(Time.deltaTime);
        }
    }
}