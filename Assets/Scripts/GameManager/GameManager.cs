using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour, IGameManager
    {
        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }

        public void StartGame()
        {
            Debug.Log("Game start!");
            Time.timeScale = 0;
        }
    }
}