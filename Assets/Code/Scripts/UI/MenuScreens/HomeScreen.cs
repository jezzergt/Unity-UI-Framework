using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
using UnityEngine.EventSystems;

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
        Button _continueButton;
        Button _newGameButton;
        Button _settingsButton;
        Button _quitButton;

        // Labels
        public Label GameVersionLabel;
        #endregion

        [Tooltip("Screen Controller")] public UIDocument ControllerDocument;
        public VisualElement Root;

        private void Awake()
        {
            SetVisualElements();
            RegisterButtonCallbacks();
            ShowGameVersionInfo();
        }

        private void SetVisualElements()
        {
            Root = ControllerDocument.rootVisualElement;

            _continueButton = Root.Q<Button>(_continueButtonID);
            _newGameButton = Root.Q<Button>(_newGameButtonID);
            _settingsButton = Root.Q<Button>(_settingsButtonID);
            _quitButton = Root.Q<Button>(_quitButtonID);

            GameVersionLabel = Root.Q<Label>(_gameVersionLabelID);
        }

        private void RegisterButtonCallbacks()
        {
            _continueButton?.RegisterCallback<ClickEvent>(ClickContinueButton);

            _newGameButton?.RegisterCallback<ClickEvent>(ClickNewGameButton);
            _newGameButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            _settingsButton?.RegisterCallback<ClickEvent>(ClickSettingsButton);
            _settingsButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            _quitButton?.RegisterCallback<ClickEvent>(ClickQuitButton);
            _quitButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());
        }

        #region Navigation Publishers
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
