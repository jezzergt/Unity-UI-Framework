using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProjectTemplate
{
    public class SettingScreen : MonoBehaviour
    {
        #region Events
        // Navigation Events
        public static event Action VideoButtonClicked;
        public static event Action AudioButtonClicked;
        public static event Action ControlsButtonClicked;
        public static event Action BackButtonClicked;
        #endregion

        #region Element ID's
        // Navigation Strings
        const string _videoButtonID = "ButtonVideo";
        const string _audioButtonID = "ButtonAudio";
        const string _controlsButtonID = "ButtonControls";
        const string _backButtonID = "ButtonBack";
        #endregion

        #region Buttons
        // Navigation Buttons
        Button _videoButton;
        Button _audioButton;
        Button _controlsButton;
        Button _backButton;
        #endregion

        [Tooltip("Screen Controller")] public UIDocument ControllerDocument;
        public VisualElement Root;

        public void SetVisualElements()
        {
            Root = ControllerDocument.rootVisualElement;

            _videoButton = Root.Q<Button>(_videoButtonID);
            _audioButton = Root.Q<Button>(_audioButtonID);
            _controlsButton = Root.Q<Button>(_controlsButtonID);
            _backButton = Root.Q<Button>(_backButtonID);
        }

        public void RegisterButtonCallbacks()
        {
            _videoButton?.RegisterCallback<ClickEvent>(ClickVideoButton);
            _videoButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            _audioButton?.RegisterCallback<ClickEvent>(ClickAudioButton);
            _audioButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            _controlsButton?.RegisterCallback<ClickEvent>(ClickControlsButton);
            _controlsButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            _backButton?.RegisterCallback<ClickEvent>(ClickBackButton);
            _backButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());
        }

        #region Navigation Publishers
        void ClickVideoButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            VideoButtonClicked?.Invoke();
        }

        void ClickAudioButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            AudioButtonClicked?.Invoke();
        }

        void ClickControlsButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            ControlsButtonClicked?.Invoke();
        }

        void ClickBackButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultBackButtonClick();
            BackButtonClicked?.Invoke();
        }
        #endregion
    }
}

