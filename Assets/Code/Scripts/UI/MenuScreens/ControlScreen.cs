using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProjectTemplate
{
    public class ControlScreen : MonoBehaviour
    {
        #region Events
        // Navigation Events
        public static event Action VideoButtonClicked;
        public static event Action AudioButtonClicked;
        public static event Action BackButtonClicked;

        // Back Input Events
        public static event Action BackInputPrimaryClicked;
        public static event Action BackInputSecondaryClicked;
        public static event Action BackInputResetClicked;

        // Up Input Events
        public static event Action UpInputPrimaryClicked;
        public static event Action UpInputSecondaryClicked;
        public static event Action UpInputResetClicked;

        // Down Input Events
        public static event Action DownInputPrimaryClicked;
        public static event Action DownInputSecondaryClicked;
        public static event Action DownInputResetClicked;

        // Left Input Events
        public static event Action LeftInputPrimaryClicked;
        public static event Action LeftInputSecondaryClicked;
        public static event Action LeftInputResetClicked;

        // Right Input Events
        public static event Action RightInputPrimaryClicked;
        public static event Action RightInputSecondaryClicked;
        public static event Action RightInputResetClicked;
        #endregion

        #region Element ID's
        // Navigation ID's
        const string _videoButtonID = "ButtonVideo";
        const string _audioButtonID = "ButtonAudio";
        const string _backButtonID = "ButtonBack";

        // Back Input ID's
        const string _backInputbuttonPrimaryID = "ButtonInputOnePrimary";
        const string _backInputbuttonSecondaryID = "ButtonInputOneSecondary";
        const string _backInputbuttonResetID = "ButtonInputOneClear";

        // Up Input ID's
        const string _upInputbuttonPrimaryID = "ButtonInputTwoPrimary";
        const string _upInputbuttonSecondaryID = "ButtonInputTwoSecondary";
        const string _upInputbuttonResetID = "ButtonInputTwoClear";

        // Down Input ID's
        const string _downInputbuttonPrimaryID = "ButtonInputThreePrimary";
        const string _downInputbuttonSecondaryID = "ButtonInputThreeSecondary";
        const string _downInputbuttonResetID = "ButtonInputThreeClear";

        // Left Input ID's
        const string _leftInputbuttonPrimaryID = "ButtonInputFourPrimary";
        const string _leftInputbuttonSecondaryID = "ButtonInputFourSecondary";
        const string _leftInputbuttonResetID = "ButtonInputFourClear";

        // Right Input ID's
        const string _rightInputbuttonPrimaryID = "ButtonInputFivePrimary";
        const string _rightInputbuttonSecondaryID = "ButtonInputFiveSecondary";
        const string _rightInputbuttonResetID = "ButtonInputFiveClear";
        #endregion

        #region Buttons
        // Navigation Buttons
        Button _videoButton;
        Button _audioButton;
        Button _backButton;

        // Back Input Buttons
        public Button BackInputPrimaryButton;
        public Button BackInputSecondaryButton;
        public Button BackInputResetButton;

        // Up Input Buttons
        public Button UpInputPrimaryButton;
        public Button UpInputSecondaryButton;
        public Button UpInputResetButton;

        // Down Input Buttons
        public Button DownInputPrimaryButton;
        public Button DownInputSecondaryButton;
        public Button DownInputResetButton;

        // Left Input Buttons
        public Button LeftInputPrimaryButton;
        public Button LeftInputSecondaryButton;
        public Button LeftInputResetButton;

        // Right Input Buttons
        public Button RightInputPrimaryButton;
        public Button RightInputSecondaryButton;
        public Button RightInputResetButton;
        #endregion

        [Tooltip("Screen Controller")] public UIDocument ControllerDocument;
        public VisualElement Root;

        private void Awake()
        {
            SetVisualElements();
            RegisterButtonCallbacks();
        }

        private void SetVisualElements()
        {
            Root = ControllerDocument.rootVisualElement;

            _videoButton = Root.Q<Button>(_videoButtonID);
            _audioButton = Root.Q<Button>(_audioButtonID);
            _backButton = Root.Q<Button>(_backButtonID);

            BackInputPrimaryButton = Root.Q<Button>(_backInputbuttonPrimaryID);
            BackInputSecondaryButton = Root.Q<Button>(_backInputbuttonSecondaryID);
            BackInputResetButton = Root.Q<Button>(_backInputbuttonResetID);

            UpInputPrimaryButton = Root.Q<Button>(_upInputbuttonPrimaryID);
            UpInputSecondaryButton = Root.Q<Button>(_upInputbuttonSecondaryID);
            UpInputResetButton = Root.Q<Button>(_upInputbuttonResetID);

            DownInputPrimaryButton = Root.Q<Button>(_downInputbuttonPrimaryID);
            DownInputSecondaryButton = Root.Q<Button>(_downInputbuttonSecondaryID);
            DownInputResetButton = Root.Q<Button>(_downInputbuttonResetID);

            LeftInputPrimaryButton = Root.Q<Button>(_leftInputbuttonPrimaryID);
            LeftInputSecondaryButton = Root.Q<Button>(_leftInputbuttonSecondaryID);
            LeftInputResetButton = Root.Q<Button>(_leftInputbuttonResetID);

            RightInputPrimaryButton = Root.Q<Button>(_rightInputbuttonPrimaryID);
            RightInputSecondaryButton = Root.Q<Button>(_rightInputbuttonSecondaryID);
            RightInputResetButton = Root.Q<Button>(_rightInputbuttonResetID);
        }

        private void RegisterButtonCallbacks()
        {
            _videoButton?.RegisterCallback<ClickEvent>(ClickVideoButton);
            _videoButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            _audioButton?.RegisterCallback<ClickEvent>(ClickAudioButton);
            _audioButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            _backButton?.RegisterCallback<ClickEvent>(ClickBackButton);
            _backButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            BackInputPrimaryButton?.RegisterCallback<ClickEvent>(ClickBackInputPrimaryButton);
            BackInputSecondaryButton?.RegisterCallback<ClickEvent>(ClickBackInputSecondaryButton);
            BackInputResetButton?.RegisterCallback<ClickEvent>(ClickBackInputResetButton);

            UpInputPrimaryButton?.RegisterCallback<ClickEvent>(ClickUpInputPrimaryButton);
            UpInputSecondaryButton?.RegisterCallback<ClickEvent>(ClickUpInputSecondaryButton);
            UpInputResetButton?.RegisterCallback<ClickEvent>(ClickUpInputResetButton);

            DownInputPrimaryButton?.RegisterCallback<ClickEvent>(ClickDownInputPrimaryButton);
            DownInputSecondaryButton?.RegisterCallback<ClickEvent>(ClickDownInputSecondaryButton);
            DownInputResetButton?.RegisterCallback<ClickEvent>(ClickDownInputResetButton);

            LeftInputPrimaryButton?.RegisterCallback<ClickEvent>(ClickLeftInputPrimaryButton);
            LeftInputSecondaryButton?.RegisterCallback<ClickEvent>(ClickLeftInputSecondaryButton);
            LeftInputResetButton?.RegisterCallback<ClickEvent>(ClickLeftInputResetButton);

            RightInputPrimaryButton?.RegisterCallback<ClickEvent>(ClickRightInputPrimaryButton);
            RightInputSecondaryButton?.RegisterCallback<ClickEvent>(ClickRightInputSecondaryButton);
            RightInputResetButton?.RegisterCallback<ClickEvent>(ClickRightInputResetButton);
        }

        #region Navigation Publishers
        private void ClickVideoButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            VideoButtonClicked?.Invoke();
        }

        private void ClickAudioButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            AudioButtonClicked?.Invoke();
        }

        private void ClickBackButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultBackButtonClick();
            BackButtonClicked?.Invoke();
        }
        #endregion

        #region Back Input Config Publishers
        private void ClickBackInputPrimaryButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            BackInputPrimaryClicked?.Invoke();
        }

        private void ClickBackInputSecondaryButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            BackInputSecondaryClicked?.Invoke();
        }

        private void ClickBackInputResetButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            BackInputResetClicked?.Invoke();
        }
        #endregion

        #region Up Input Config Publishers
        private void ClickUpInputPrimaryButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            UpInputPrimaryClicked?.Invoke();
        }

        private void ClickUpInputSecondaryButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            UpInputSecondaryClicked?.Invoke();
        }

        private void ClickUpInputResetButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            UpInputResetClicked?.Invoke();
        }
        #endregion

        #region Down Input Config Publishers
        private void ClickDownInputPrimaryButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            DownInputPrimaryClicked?.Invoke();
        }

        private void ClickDownInputSecondaryButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            DownInputSecondaryClicked?.Invoke();
        }

        private void ClickDownInputResetButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            DownInputResetClicked?.Invoke();
        }
        #endregion

        #region Left Input Config Publishers
        private void ClickLeftInputPrimaryButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            LeftInputPrimaryClicked?.Invoke();
        }

        private void ClickLeftInputSecondaryButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            LeftInputSecondaryClicked?.Invoke();
        }

        private void ClickLeftInputResetButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            LeftInputResetClicked?.Invoke();
        }
        #endregion

        #region Right Input Config Publishers
        private void ClickRightInputPrimaryButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            RightInputPrimaryClicked?.Invoke();
        }

        private void ClickRightInputSecondaryButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            RightInputSecondaryClicked?.Invoke();
        }

        private void ClickRightInputResetButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            RightInputResetClicked?.Invoke();
        }
        #endregion
    }
}
