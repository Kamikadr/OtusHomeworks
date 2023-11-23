using UnityEngine;

namespace ShootEmUp.Game
{
    public sealed class GameManager : MonoBehaviour
    {
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
    }
}