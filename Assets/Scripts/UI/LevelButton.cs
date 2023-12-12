using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelButton:MonoBehaviour
    {
        [SerializeField] private Sprite activeSprite;
        [SerializeField] private Sprite inactiveSprite;
        [SerializeField] private Image image;
        [SerializeField] private Button button;
        public Button Button => button;

        public void SetInteractable(bool value)
        {
            button.interactable = value;
            image.sprite = value ? activeSprite : inactiveSprite;
        }
    }
}