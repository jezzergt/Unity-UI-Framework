using UnityEngine;

namespace ProjectTemplate
{
    public class SettingScreenController : MonoBehaviour
    {
        public SettingScreen SettingScreen;

        private void OnEnable()
        {
            SettingScreen.VideoButtonClicked += Video;
            SettingScreen.AudioButtonClicked += Audio;
            SettingScreen.ControlsButtonClicked += Controls;
            SettingScreen.BackButtonClicked += Back;
        }

        #region Navigation Subscriber Logic
        private void Video()
        {
            MainMenuUIManager.Instance.DisableAllScreens();
            MainMenuUIManager.Instance.EnableScreen(MainMenuUIManager.Instance.VideoScreen.Root);
        }

        private void Audio()
        {
            MainMenuUIManager.Instance.DisableAllScreens();
            MainMenuUIManager.Instance.EnableScreen(MainMenuUIManager.Instance.AudioScreen.Root);
        }

        private void Controls()
        {
            MainMenuUIManager.Instance.DisableAllScreens();
            MainMenuUIManager.Instance.EnableScreen(MainMenuUIManager.Instance.ControlScreen.Root);
        }

        private void Back()
        {
            MainMenuUIManager.Instance.DisableAllScreens();
            MainMenuUIManager.Instance.EnableScreen(MainMenuUIManager.Instance.HomeScreen.Root);
        }
        #endregion
    }
}