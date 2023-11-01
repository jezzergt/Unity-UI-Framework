using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

namespace ProjectTemplate
{
    public class MainMenuUIManager : MonoBehaviour
    {
        [Header("Screen Objects")]
        public HomeScreen HomeScreen;
        public VideoScreen VideoScreen;
        public AudioScreen AudioScreen;
        public ControlScreen ControlScreen;

        [HideInInspector]
        public static Color SelectedButtonColor = new Color(1f, 0.8156f, 0.4862f, 1f);
        public static Color NonSelectedButtonColor = new Color(1f, 0.8156f, 0.4862f, 0f);
        public static Color DefaultButtonColor = new Color(1f, 1f, 1f, 1f);

        #region Singleton & Awake
        private static MainMenuUIManager _instance;

        public static MainMenuUIManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("MainMenuUIManager is null");
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
            }

            UIControls uiControls = new UIControls();
            uiControls.MainMenu.Enable();

            uiControls.MainMenu.Back.performed += Back_performed;  
        }
        #endregion

        private void OnEnable()
        {
            HomeScreenShown();
        }

        #region Enable & Disable Screen Functions
        public void DisableAllScreens()
        {
            HomeScreen.Root.style.display = DisplayStyle.None;
            VideoScreen.Root.style.display = DisplayStyle.None;
            AudioScreen.Root.style.display = DisplayStyle.None;
            ControlScreen.Root.style.display = DisplayStyle.None;
        }

        public void DisableScreen(VisualElement visualElement)
        {
            visualElement.style.display = DisplayStyle.None;
        }

        public void EnableScreen(VisualElement visualElement)
        {
            visualElement.style.display = DisplayStyle.Flex;
        }
        #endregion

        #region ScreenShown & Hidden Functions
        public void HomeScreenShown()
        {
            HomeScreen.ScreenShown = true;
        }

        public void HomeScreenHidden()
        {
            HomeScreen.ScreenShown = false;
        }

        public void VideoScreenShown()
        {
            VideoScreen.ScreenShown = true;
            //VideoScreen.FocusFirstElement();
        }

        public void VideoScreenHidden()
        {
            VideoScreen.ScreenShown = false;
        }
        #endregion

        #region Input Action Subscribers
        private void Back_performed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (HomeScreen.ScreenShown == false)
                {
                    ReturnToHomeScreen();
                }
            }
        }
        #endregion

        public void ReturnToHomeScreen()
        {
            AudioManager.Instance.PlayDefaultBackButtonClick();
            DisableAllScreens();
            EnableScreen(HomeScreen.Root);
            //HomeScreen.FocusReturnElement();
            HomeScreenShown();
        }
    }
}
