using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProjectTemplate
{
    public class AudioScreen : MonoBehaviour
    {
        #region Events
        // Navigation Events
        public static event Action VideoButtonClicked;
        public static event Action ControlsButtonClicked;
        public static event Action BackButtonClicked;

        // Audio Slider Events
        public static event Action<float> MasterSliderValueChanged;
        public static event Action<float> MusicSliderValueChanged;
        public static event Action<float> AmbienceSliderValueChanged;
        public static event Action<float> EffectsSliderValueChanged;
        public static event Action<float> UISliderValueChanged;
        #endregion

        #region Element ID's
        // Navigation ID's
        const string _videoButtonID = "ButtonVideo";
        const string _controlsButtonID = "ButtonControls";
        const string _backButtonID = "ButtonBack";

        // Audio Slider ID's
        [HideInInspector]
        const string _masterSliderID = "SliderMaster";
        const string _musicSliderID = "SliderMusic";
        const string _ambienceSliderID = "SliderAmbience";
        const string _effectsSliderID = "SliderEffects";
        const string _uiSliderID = "SliderUI";
        #endregion

        #region Buttons & Sliders
        // Navigation Buttons
        Button _videoButton;
        Button _controlsButton;
        Button _backButton;

        // Audio Sliders
        public Slider MasterSlider;
        public Slider MusicSlider;
        public Slider AmbienceSlider;
        public Slider EffectsSlider;
        public Slider UISlider;
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
            _controlsButton = Root.Q<Button>(_controlsButtonID);
            _backButton = Root.Q<Button>(_backButtonID);

            MasterSlider = Root.Q<Slider>(_masterSliderID);
            MusicSlider = Root.Q<Slider>(_musicSliderID);
            AmbienceSlider = Root.Q<Slider>(_ambienceSliderID);
            EffectsSlider = Root.Q<Slider>(_effectsSliderID);
            UISlider = Root.Q<Slider>(_uiSliderID);
        }

        private void RegisterButtonCallbacks()
        {
            _videoButton?.RegisterCallback<ClickEvent>(ClickVideoButton);
            _videoButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            _controlsButton?.RegisterCallback<ClickEvent>(ClickControlsButton);
            _controlsButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            _backButton?.RegisterCallback<ClickEvent>(ClickBackButton);
            _backButton?.RegisterCallback<PointerOverEvent>(_evt => AudioManager.Instance.PlayDefaultButtonHover());

            MasterSlider?.RegisterValueChangedCallback(ModifyMasterSlider);
            MasterSlider?.RegisterCallback<PointerDownEvent>(evt => AudioManager.Instance.PlayDefaultButtonClick());

            MusicSlider?.RegisterValueChangedCallback(ModifyMusicSlider);
            MusicSlider?.RegisterCallback<PointerDownEvent>(_evt => AudioManager.Instance.PlayDefaultButtonClick());

            AmbienceSlider?.RegisterValueChangedCallback(ModifyAmbienceSlider);
            AmbienceSlider?.RegisterCallback<PointerDownEvent>(_evt => AudioManager.Instance.PlayDefaultButtonClick());

            EffectsSlider?.RegisterValueChangedCallback(ModifyEffectsSlider);
            EffectsSlider?.RegisterCallback<PointerDownEvent>(_evt => AudioManager.Instance.PlayDefaultButtonClick());

            UISlider?.RegisterValueChangedCallback(ModifyUISlider);
            UISlider?.RegisterCallback<PointerDownEvent>(_evt => AudioManager.Instance.PlayDefaultButtonClick());
        }

        #region Navigation Publishers
        private void ClickVideoButton(ClickEvent evt)
        {
            AudioManager.Instance.PlayDefaultButtonClick();
            VideoButtonClicked?.Invoke();
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

        #region Audio Settings Publishers
        private void ModifyMasterSlider(ChangeEvent<float> evt)
        {
            MasterSliderValueChanged?.Invoke(evt.newValue);
        }

        private void ModifyMusicSlider(ChangeEvent<float> evt)
        {
            MusicSliderValueChanged?.Invoke(evt.newValue);
        }

        private void ModifyAmbienceSlider(ChangeEvent<float> evt)
        {
            AmbienceSliderValueChanged?.Invoke(evt.newValue);
        }

        private void ModifyEffectsSlider(ChangeEvent<float> evt)
        {
            EffectsSliderValueChanged?.Invoke(evt.newValue);
        }

        private void ModifyUISlider(ChangeEvent<float> evt)
        {
            UISliderValueChanged?.Invoke(evt.newValue);
        }
        #endregion
    }
}

