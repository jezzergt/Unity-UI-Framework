using UnityEditor;
using UnityEngine;

namespace ProjectTemplate
{
    public class HomeScreenController : MonoBehaviour
    {
        public HomeScreen HomeScreen;

        private void OnEnable()
        {
            HomeScreen.ContinueButtonClicked += Continue;
            HomeScreen.NewGameButtonClicked += NewGame;
            HomeScreen.SettingsButtonClicked += Settings;
            HomeScreen.QuitButtonClicked += Quit;
            HomeScreen.DisplayGameVerion += GameVersion;
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
        }

        private void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif
            Application.Quit();
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
