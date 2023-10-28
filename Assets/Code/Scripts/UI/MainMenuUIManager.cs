using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        }
        #endregion

        private void OnEnable()
        {
            HomeScreenShown();
        }

        private void Update()
        {
            if (HomeScreen.ScreenShown == false)
            {
                if (InputManager.Instance.BackInput)
                {
                    AudioManager.Instance.PlayDefaultBackButtonClick();
                    DisableAllScreens();
                    EnableScreen(HomeScreen.Root);
                    HomeScreenShown();
                }
            }
        }

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

        public void HomeScreenShown()
        {
            HomeScreen.ScreenShown = true;
        }

        public void HomeScreenHidden()
        {
            HomeScreen.ScreenShown = false;
        }
    }
}
