using UnityEngine;
using UnityEngine.UIElements;

namespace ProjectTemplate
{
    public class FirstFocus : MonoBehaviour
    {
        private Vector2 _targetScale = Vector2.one;

        void Start()
        {
            //FocusFirstElement();
        }

        public void FocusFirstElement()
        {
            Button newGameButton = GetComponent<UIDocument>().rootVisualElement.Q<Button>("ButtonNewGame");
            newGameButton.Focus();
            newGameButton.style.color = MainMenuUIManager.SelectedButtonColor;
        }   
    }
}

