using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace ProjectTemplate
{
    public class InputManager : MonoBehaviour
    {
        private UIControls _uiControls;

        #region Singleton & Awake
        private static InputManager _instance;

        public static InputManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("InputManager is null");
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if ((_instance != null && _instance != this))
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }

            //_uiControls = new UIControls();
            //UIControls.MainMenu.Enable();

        }
        #endregion
    }
}

