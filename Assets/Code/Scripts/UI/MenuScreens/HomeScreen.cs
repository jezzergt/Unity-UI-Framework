using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProjectTemplate
{
    public class HomeScreen : MonoBehaviour
    {
        [HideInInspector]
        public static bool ScreenShown = true;

        #region Events
        // Navigation Events
        public static event Action ContinueButtonClicked;
        public static event Action NewGameButtonClicked;
        public static event Action SettingsButtonClicked;
        public static event Action QuitButtonClicked;

        // Misc Events
        public static event Action DisplayGameVerion;
        #endregion

        #region Element ID's
        // Navigation ID's
        const string _continueButtonID = "ButtonContinueGame";
        const string _newGameButtonID = "ButtonNewGame";
        const string _settingsButtonID = "ButtonSettings";
        const string _quitButtonID = "ButtonQuit";

        // Label ID's
        const string _gameVersionLabelID = "LabelGameVersion";
        #endregion

        #region Buttons & Labels
        // Navigation Buttons
        public Button ContinueButton;
        public Button NewGameButton;
        public Button SettingsButton;
        public Button QuitButton;

        // Labels
        public Label GameVersionLabel;
        #endregion

        [Tooltip("Screen Controller")] public UIDocument ControllerDocument;
        public VisualElement Root;

        private void Awake()
        {
            SetVisualElements();
            //FocusFirstElement();
            RegisterButtonCallbacks();
            ShowGameVersionInfo();
        }

        private void SetVisualElements()
        {
            Root = ControllerDocument.rootVisualElement;

            ContinueButton = Root.Q<Button>(_continueButtonID);
            NewGameButton = Root.Q<Button>(_newGameButtonID);
            SettingsButton = Root.Q<Button>(_settingsButtonID);
            QuitButton = Root.Q<Button>(_quitButtonID);

            GameVersionLabel = Root.Q<Label>(_gameVersionLabelID);
        }

        public void FocusFirstElement()
        {
            NewGameButton.Focus();
            NewGameButton.style.color = MainMenuUIManager.SelectedButtonColor;
            NewGameButton.transform.scale = new Vector2(1.2f, 1.2f);
        }

        public void FocusReturnElement()
        {
            SettingsButton.Focus();
            SettingsButton.style.color = MainMenuUIManager.SelectedButtonColor;
            SettingsButton.transform.scale = new Vector2(1.2f, 1.2f);
        }

        private void RegisterButtonCallbacks()
        {
            ContinueButton?.RegisterCallback<ClickEvent>(ClickContinueButton);

            NewGameButton?.RegisterCallback<ClickEvent>(ClickNewGameButton);
            NewGameButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            SettingsButton?.RegisterCallback<ClickEvent>(ClickSettingsButton);
            SettingsButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            QuitButton?.RegisterCallback<ClickEvent>(ClickQuitButton);
            QuitButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());
        }

        #region Mouse Navigation Publishers
        void ClickContinueButton(ClickEvent evt)
        {
            ContinueButtonClicked?.Invoke();
        }

        void ClickNewGameButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            NewGameButtonClicked?.Invoke();
        }

        void ClickSettingsButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            SettingsButtonClicked?.Invoke();
        }

        void ClickQuitButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            QuitButtonClicked?.Invoke();
        }
        #endregion

        #region Keyboard & Gampad Navigation Logic
        public void NavigateDownToSettings()
        {
            NewGameButton.style.color = MainMenuUIManager.DefaultButtonColor;
            NewGameButton.transform.scale = new Vector2(1f, 1f);
            NewGameButton.Blur();

            SettingsButton.Focus();
            SettingsButton.style.color = MainMenuUIManager.SelectedButtonColor;
            SettingsButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateDownToQuit()
        {
            SettingsButton.style.color = MainMenuUIManager.DefaultButtonColor;
            SettingsButton.transform.scale = new Vector2(1f, 1f);
            SettingsButton.Blur();

            QuitButton.Focus();
            QuitButton.style.color = MainMenuUIManager.SelectedButtonColor;
            QuitButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateDownToNewGame()
        {
            QuitButton.style.color = MainMenuUIManager.DefaultButtonColor;
            QuitButton.transform.scale = new Vector2(1f, 1f);
            QuitButton.Blur();

            NewGameButton.Focus();
            NewGameButton.style.color = MainMenuUIManager.SelectedButtonColor;
            NewGameButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateUpToSettings()
        {
            QuitButton.style.color = MainMenuUIManager.DefaultButtonColor;
            QuitButton.transform.scale = new Vector2(1f, 1f);
            QuitButton.Blur();

            SettingsButton.Focus();
            SettingsButton.style.color = MainMenuUIManager.SelectedButtonColor;
            SettingsButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateUpToQuit()
        {
            NewGameButton.style.color = MainMenuUIManager.DefaultButtonColor;
            NewGameButton.transform.scale = new Vector2(1f, 1f);
            NewGameButton.Blur();

            QuitButton.Focus();
            QuitButton.style.color = MainMenuUIManager.SelectedButtonColor;
            QuitButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateUpToNewGame()
        {
            SettingsButton.style.color = MainMenuUIManager.DefaultButtonColor;
            SettingsButton.transform.scale = new Vector2(1f, 1f);
            SettingsButton.Blur();

            NewGameButton.Focus();
            NewGameButton.style.color = MainMenuUIManager.SelectedButtonColor;
            NewGameButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }
        #endregion

        #region Misc Publishers
        public void ShowGameVersionInfo()
        {
            GameVersionLabel.text = "Version " + Application.version;

            // Why doesn't this get called?
            //DisplayGameVerion?.Invoke();
        }
        #endregion
    }
}
