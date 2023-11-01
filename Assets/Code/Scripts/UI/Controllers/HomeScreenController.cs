using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

namespace ProjectTemplate
{
    public class HomeScreenController : MonoBehaviour
    {
        public HomeScreen HomeScreen;
        public UIControls UIControls;

        private VisualElement _root;

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;

            UIControls = new UIControls();
            UIControls.MainMenu.Enable();
        }

        private void OnEnable()
        {
            // Click Event Subscribers
            HomeScreen.ContinueButtonClicked += Continue;
            HomeScreen.NewGameButtonClicked += NewGame;
            HomeScreen.SettingsButtonClicked += Settings;
            HomeScreen.QuitButtonClicked += Quit;

            // Misc Event Subscriber
            HomeScreen.DisplayGameVerion += GameVersion;

            // Input System Keyboard & Gamepad Subscribers W.I.P
            //UIControls.MainMenu.Down.performed += Down_performed;
            //UIControls.MainMenu.Up.performed += Up_performed;
            //UIControls.MainMenu.Submit.performed += Submit_performed;
        }

        #region Navigation Subscriber Logic
        private void Continue()
        {
            Debug.Log("Continue Button Clicked");
        }

        private void NewGame()
        {
            LevelManager.Instance.LoadNextScene();
        }

        private void Settings()
        {
            MainMenuUIManager.Instance.DisableAllScreens();
            MainMenuUIManager.Instance.EnableScreen(MainMenuUIManager.Instance.VideoScreen.Root);
            
            MainMenuUIManager.Instance.HomeScreenHidden();
            MainMenuUIManager.Instance.VideoScreenShown();
        }

        private void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif
            Application.Quit();
        }
        #endregion

        #region Keyboard & Gamepad Navigation Subscriber Logic
        private void Down_performed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                //Debug.Log(_root.panel.focusController.focusedElement);

                if (_root.panel.focusController.focusedElement == HomeScreen.NewGameButton)
                {
                    HomeScreen.NavigateDownToSettings();
                    return;
                }

                if (_root.panel.focusController.focusedElement == HomeScreen.SettingsButton)
                {
                    HomeScreen.NavigateDownToQuit();
                    return;
                }

                if (_root.panel.focusController.focusedElement == HomeScreen.QuitButton)
                {
                    HomeScreen.NavigateDownToNewGame();
                    return;
                }
            }
        }

        private void Up_performed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                //Debug.Log(_root.panel.focusController.focusedElement);

                if (_root.panel.focusController.focusedElement == HomeScreen.NewGameButton)
                {
                    HomeScreen.NavigateUpToQuit();
                    return;
                }

                if (_root.panel.focusController.focusedElement == HomeScreen.QuitButton)
                {
                    HomeScreen.NavigateUpToSettings();
                    return;
                }

                if (_root.panel.focusController.focusedElement == HomeScreen.SettingsButton)
                {
                    HomeScreen.NavigateUpToNewGame();
                    return;
                }
            }
        }

        private void Submit_performed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (_root.panel.focusController.focusedElement == HomeScreen.NewGameButton)
                {
                    AudioManager.Instance.PlayDefaultButtonClick();
                    NewGame();
                }

                if (_root.panel.focusController.focusedElement == HomeScreen.SettingsButton)
                {
                    HomeScreen.SettingsButton.Blur();

                    AudioManager.Instance.PlayDefaultButtonClick();
                    Settings();
                }

                if (_root.panel.focusController.focusedElement == HomeScreen.QuitButton)
                {
                    AudioManager.Instance.PlayDefaultButtonClick();
                    Quit();
                }
            }
        }
        #endregion

        #region Misc Subscribers
        private void GameVersion()
        {
            HomeScreen.GameVersionLabel.text = "Version " + Application.version;
        }
        #endregion
    }
}
