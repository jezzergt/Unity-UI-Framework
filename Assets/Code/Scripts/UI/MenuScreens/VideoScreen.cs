using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProjectTemplate
{
    public class VideoScreen : MonoBehaviour
    {
        [HideInInspector]
        public static bool ScreenShown = false;

        #region Events
        // Navigation Events
        public static event Action AudioButtonClicked;
        public static event Action ControlsButtonClicked;
        public static event Action BackButtonClicked;

        // Resolution Events
        public static event Action PreviousResolutionButtonClicked;
        public static event Action NextResolutionButtonClicked;
        public static event Action DisplayDefaultResolution;

        // Screen Mode Events
        public static event Action WindowedButtonClicked;
        public static event Action FullscreenButtonClicked;

        // Frame Rate Events
        public static event Action ThirtyFrameCapButtonClicked;
        public static event Action SixtyFrameCapButtonClicked;
        public static event Action UnlimitedFrameCapButtonClicked;

        // Graphics Quality Events
        public static event Action GFXLowButtonClicked;
        public static event Action GFXMediumButtonClicked;
        public static event Action GFXHighButtonClicked;
        public static event Action GFXUltraButtonClicked;

        // Anti-aliasing Events
        public static event Action AAOffButtonClicked;
        public static event Action FXAAOnButtonClicked;
        public static event Action SMAAOnButtonClicked;

        // V-sync Events
        public static event Action VsyncOffButtonClicked;
        public static event Action VsyncOnButtonClicked;
        #endregion

        #region Element ID's
        // Navigation ID's
        const string _videoButtonID = "ButtonVideo";
        const string _audioButtonID = "ButtonAudio";
        const string _controlsButtonID = "ButtonControls";
        const string _backButtonID = "ButtonBack";

        // Resolution Button ID's
        const string _prevResolutionButtonID = "ButtonPrevious";
        const string _nextResolutionButtonID = "ButtonNext";

        // Screen Mode Button ID's
        const string _windowButtonID = "ButtonWindowed";
        const string _fullscreenButtonID = "ButtonFullscreen";

        // Frame Rate Button ID's
        const string _thirtyFrameCapButtonID = "Button30";
        const string _sixtyFrameCapButtonID = "Button60";
        const string _unlimitedFrameCapButtonID = "ButtonUnlimited";

        // Graphics Quality Button ID's
        const string _gfxLowButtonID = "ButtonGFXLow";
        const string _gfxMediumButtonID = "ButtonGFXMedium";
        const string _gfxHighButtonID = "ButtonGFXHigh";
        const string _gfxUltraButtonID = "ButtonGFXUltra";

        // Anti-aliasing Button ID's
        const string _aaOffButtonID = "ButtonAAOff";
        const string _fxaaOnButtonID = "ButtonFXAAOn";
        const string _smaaOnButtonID = "ButtonSMAAOn";

        // V-sync Button ID's
        const string _vsyncOffButtonID = "ButtonVsyncOff";
        const string _vsyncOnButtonID = "ButtonVsyncOn";

        // 
        public const string CurrentResolutionLabelID = "LabelCurrentResolution";
        #endregion

        #region Buttons & Labels
        // Navigation Buttons
        public Button VideoButton;
        public Button AudioButton;
        public Button ControlsButton;
        public Button BackButton;

        // Resolution Buttons
        Button _prevButton;
        Button _nextButton;

        // Screen Mode Buttons
        public Button WindowedButton;
        public Button FullscreenButton;

        // Frame Rate Buttons
        public Button ThirtyFrameCapButton;
        public Button SixtyFrameCapButton;
        public Button UnlimitedFrameCapButton;

        // Graphics Quality Buttons
        public Button GFXLowButton;
        public Button GFXMediumButton;
        public Button GFXHighButton;
        public Button GFXUltraButton;

        // Anti-aliasing Buttons
        public Button AAOffButton;
        public Button FXAAOnButton;
        public Button SMAAOnButton;

        // V-sync Buttons
        public Button VsyncOffButton;
        public Button VsyncOnButton;

        public Label LabelResolution;
        #endregion

        public UIDocument ControllerDocument;
        public VisualElement Root;

        private void Awake()
        {
            SetVisualElements();
            RegisterButtonCallbacks();
        }

        private void OnEnable()
        {
            ShowCurrentScreenResolution();
        }

        private void SetVisualElements()
        {
            Root = ControllerDocument.rootVisualElement;

            VideoButton = Root.Q<Button>(_videoButtonID);
            AudioButton = Root.Q<Button>(_audioButtonID);
            ControlsButton = Root.Q<Button>(_controlsButtonID);
            BackButton = Root.Q<Button>(_backButtonID);

            _prevButton = Root.Q<Button>(_prevResolutionButtonID);
            _nextButton = Root.Q<Button>(_nextResolutionButtonID);

            WindowedButton = Root.Q<Button>(_windowButtonID);
            FullscreenButton = Root.Q<Button>(_fullscreenButtonID);

            ThirtyFrameCapButton = Root.Q<Button>(_thirtyFrameCapButtonID);
            SixtyFrameCapButton = Root.Q<Button>(_sixtyFrameCapButtonID);
            UnlimitedFrameCapButton = Root.Q<Button>(_unlimitedFrameCapButtonID);

            GFXLowButton = Root.Q<Button>(_gfxLowButtonID);
            GFXMediumButton = Root.Q<Button>(_gfxMediumButtonID);
            GFXHighButton = Root.Q<Button>(_gfxHighButtonID);
            GFXUltraButton = Root.Q<Button>(_gfxUltraButtonID);

            AAOffButton = Root.Q<Button>(_aaOffButtonID);
            FXAAOnButton = Root.Q<Button>(_fxaaOnButtonID);
            SMAAOnButton = Root.Q<Button>(_smaaOnButtonID);

            VsyncOffButton = Root.Q<Button>(_vsyncOffButtonID);
            VsyncOnButton = Root.Q<Button>(_vsyncOnButtonID);

            LabelResolution = Root.Q<Label>(CurrentResolutionLabelID);
        }

        public void FocusFirstElement()
        {
            VideoButton.Focus();
            VideoButton.style.color = MainMenuUIManager.SelectedButtonColor;
            VideoButton.transform.scale = new Vector2(1.2f, 1.2f);
        }

        private void RegisterButtonCallbacks()
        {
            AudioButton?.RegisterCallback<ClickEvent>(ClickAudioButton);
            AudioButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            ControlsButton?.RegisterCallback<ClickEvent>(ClickControlsButton);
            ControlsButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            BackButton?.RegisterCallback<ClickEvent>(ClickBackButton);
            BackButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            _prevButton?.RegisterCallback<ClickEvent>(ClickPreviousResolutionButton);
            _nextButton?.RegisterCallback<ClickEvent>(ClickNextResolutionButton);

            WindowedButton?.RegisterCallback<ClickEvent>(ClickWindowedButton);
            FullscreenButton?.RegisterCallback<ClickEvent>(ClickFullscreenButton);

            ThirtyFrameCapButton?.RegisterCallback<ClickEvent>(ClickThirtyFrameCapButton);
            SixtyFrameCapButton?.RegisterCallback<ClickEvent>(ClickSixtyFrameCapButton);
            UnlimitedFrameCapButton?.RegisterCallback<ClickEvent>(ClickUnlimitedFrameCapButton);

            GFXLowButton?.RegisterCallback<ClickEvent>(ClickGFXLowButton);
            GFXMediumButton?.RegisterCallback<ClickEvent>(ClickGFXMediumButton);
            GFXHighButton?.RegisterCallback<ClickEvent>(ClickGFXHighButton);
            GFXUltraButton?.RegisterCallback<ClickEvent>(ClickGFXUltraButton);

            AAOffButton?.RegisterCallback<ClickEvent>(ClickAAOffButton);
            FXAAOnButton?.RegisterCallback<ClickEvent>(ClickFXAAOnButton);
            SMAAOnButton?.RegisterCallback<ClickEvent>(ClickSMAAOnButton);

            VsyncOffButton?.RegisterCallback<ClickEvent>(ClickVsyncOffButton);
            VsyncOnButton?.RegisterCallback<ClickEvent>(ClickVsyncOnButton);
        }

        #region Navigation Publishers
        private void ClickAudioButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            AudioButtonClicked?.Invoke();
        }

        private void ClickControlsButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            ControlsButtonClicked?.Invoke();
        }

        private void ClickBackButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultBackButtonClick();
            BackButtonClicked?.Invoke();
        }
        #endregion

        #region Keyboard & Gampad Navigation Logic
        public void NavigateDownToAudio()
        {
            VideoButton.style.color = MainMenuUIManager.DefaultButtonColor;
            VideoButton.transform.scale = new Vector2(1f, 1f);
            VideoButton.Blur();

            AudioButton.Focus();
            AudioButton.style.color = MainMenuUIManager.SelectedButtonColor;
            AudioButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateDownToControls()
        {
            AudioButton.style.color = MainMenuUIManager.DefaultButtonColor;
            AudioButton.transform.scale = new Vector2(1f, 1f);
            AudioButton.Blur();

            ControlsButton.Focus();
            ControlsButton.style.color = MainMenuUIManager.SelectedButtonColor;
            ControlsButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateDownToBack()
        {
            ControlsButton.style.color = MainMenuUIManager.DefaultButtonColor;
            ControlsButton.transform.scale = new Vector2(1f, 1f);
            ControlsButton.Blur();

            BackButton.Focus();
            BackButton.style.color = MainMenuUIManager.SelectedButtonColor;
            BackButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateDownToVideo()
        {
            BackButton.style.color = MainMenuUIManager.DefaultButtonColor;
            BackButton.transform.scale = new Vector2(1f, 1f);
            BackButton.Blur();

            VideoButton.Focus();
            VideoButton.style.color = MainMenuUIManager.SelectedButtonColor;
            VideoButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateUpToVideo()
        {
            AudioButton.style.color = MainMenuUIManager.DefaultButtonColor;
            AudioButton.transform.scale = new Vector2(1f, 1f);
            AudioButton.Blur();

            VideoButton.Focus();
            VideoButton.style.color = MainMenuUIManager.SelectedButtonColor;
            VideoButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateUpToBack()
        {
            VideoButton.style.color = MainMenuUIManager.DefaultButtonColor;
            VideoButton.transform.scale = new Vector2(1f, 1f);
            VideoButton.Blur();

            BackButton.Focus();
            BackButton.style.color = MainMenuUIManager.SelectedButtonColor;
            BackButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateUpToControls()
        {
            BackButton.style.color = MainMenuUIManager.DefaultButtonColor;
            BackButton.transform.scale = new Vector2(1f, 1f);
            BackButton.Blur();

            ControlsButton.Focus();
            ControlsButton.style.color = MainMenuUIManager.SelectedButtonColor;
            ControlsButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }

        public void NavigateUpToAudio()
        {
            ControlsButton.style.color = MainMenuUIManager.DefaultButtonColor;
            ControlsButton.transform.scale = new Vector2(1f, 1f);
            ControlsButton.Blur();

            AudioButton.Focus();
            AudioButton.style.color = MainMenuUIManager.SelectedButtonColor;
            AudioButton.transform.scale = new Vector2(1.2f, 1.2f);
            AudioManager.Instance.PlayDefaultButtonHover();
        }
        #endregion

        #region Resolution Settings Publishers
        private void ClickPreviousResolutionButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            PreviousResolutionButtonClicked?.Invoke();
        }

        private void ClickNextResolutionButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            NextResolutionButtonClicked?.Invoke();
        }

        private void ShowCurrentScreenResolution()
        {
            DisplayDefaultResolution?.Invoke();
        }
        #endregion

        #region ScreenMode Settings Publishers
        private void ClickWindowedButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            WindowedButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
            FullscreenButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;

            WindowedButtonClicked?.Invoke();
        }

        private void ClickFullscreenButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            
            WindowedButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            FullscreenButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;

            FullscreenButtonClicked?.Invoke();
        }
        #endregion

        #region FrameRate Settings Publishers
        private void ClickThirtyFrameCapButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            ThirtyFrameCapButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
            SixtyFrameCapButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            UnlimitedFrameCapButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;

            ThirtyFrameCapButtonClicked?.Invoke();
        }

        private void ClickSixtyFrameCapButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            ThirtyFrameCapButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            SixtyFrameCapButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
            UnlimitedFrameCapButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;

            SixtyFrameCapButtonClicked?.Invoke();
        }

        private void ClickUnlimitedFrameCapButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            ThirtyFrameCapButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            SixtyFrameCapButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            UnlimitedFrameCapButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;

            UnlimitedFrameCapButtonClicked?.Invoke();
        }
        #endregion

        #region Graphic Quality Settings Publishers
        private void ClickGFXLowButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            GFXLowButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
            GFXMediumButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            GFXHighButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            GFXUltraButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;

            GFXLowButtonClicked?.Invoke();
        }

        private void ClickGFXMediumButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            GFXLowButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            GFXMediumButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
            GFXHighButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            GFXUltraButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;

            GFXMediumButtonClicked?.Invoke();
        }

        private void ClickGFXHighButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            GFXLowButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            GFXMediumButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            GFXHighButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
            GFXUltraButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;

            GFXHighButtonClicked?.Invoke();
        }

        private void ClickGFXUltraButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            GFXLowButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            GFXMediumButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            GFXHighButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            GFXUltraButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;

            GFXUltraButtonClicked?.Invoke();
        }
        #endregion

        #region Anti-aliasing Settings Publishers
        private void ClickAAOffButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            AAOffButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
            FXAAOnButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            SMAAOnButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;

            AAOffButtonClicked?.Invoke();
        }

        private void ClickFXAAOnButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            AAOffButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            FXAAOnButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
            SMAAOnButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;

            FXAAOnButtonClicked?.Invoke();
        }

        private void ClickSMAAOnButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            AAOffButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            FXAAOnButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            SMAAOnButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;

            SMAAOnButtonClicked?.Invoke();
        }
        #endregion

        #region Vsync Settings Publishers
        private void ClickVsyncOffButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();

            VsyncOffButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
            VsyncOnButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;

            VsyncOffButtonClicked?.Invoke();
        }

        private void ClickVsyncOnButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            
            VsyncOffButton.style.backgroundColor = MainMenuUIManager.NonSelectedButtonColor;
            VsyncOnButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;

            VsyncOnButtonClicked?.Invoke();
        }
        #endregion
    }
}
