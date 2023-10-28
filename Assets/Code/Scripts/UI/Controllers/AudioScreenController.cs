using UnityEngine;

namespace ProjectTemplate
{
    public class AudioScreenController : MonoBehaviour, IDataPersistence
    {
        public AudioScreen AudioScreen;

        private float _masterVolume;
        private float _musicVolume;
        private float _ambienceVolume;
        private float _effectsVolume;
        private float _uiVolume;

        private void OnEnable()
        {
            AudioScreen.VideoButtonClicked += Video;
            AudioScreen.ControlsButtonClicked += Controls;
            AudioScreen.BackButtonClicked += Back;

            AudioScreen.MasterSliderValueChanged += SetMasterVolume;
            AudioScreen.MusicSliderValueChanged += SetMusicVolume;
            AudioScreen.AmbienceSliderValueChanged += SetAmbienceVolume;
            AudioScreen.EffectsSliderValueChanged += SetEffectsVolume;
            AudioScreen.UISliderValueChanged += SetUIVolume;
        }

        #region Navigation Subscriber Logic
        private void Video()
        {
            MainMenuUIManager.Instance.DisableAllScreens();
            MainMenuUIManager.Instance.EnableScreen(MainMenuUIManager.Instance.VideoScreen.Root);
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
            MainMenuUIManager.Instance.HomeScreenShown();
        }
        #endregion

        #region Audio Setting Subscribers
        private void SetMasterVolume(float fValue)
        {
            AudioManager.Instance.SetMixerMasterVolume(fValue);
            _masterVolume = fValue;
        }

        private void SetMusicVolume(float fValue)
        {
            AudioManager.Instance.SetMixerMusicVolume(fValue);
            _musicVolume = fValue;
        }

        private void SetAmbienceVolume(float fValue)
        {
            AudioManager.Instance.SetMixerAmbienceVolume(fValue);
            _ambienceVolume = fValue;
        }

        private void SetEffectsVolume(float fValue)
        {
            AudioManager.Instance.SetMixerEffectsVolume(fValue);
            _effectsVolume = fValue;
        }

        private void SetUIVolume(float fValue)
        {
            AudioManager.Instance.SetMixerUIVolume(fValue);
            _uiVolume = fValue;
        }
        #endregion

        #region Save & Load
        public void LoadData(GameData data)
        {
            this._masterVolume = data.MasterVolume;
            AudioScreen.MasterSlider.value = data.MasterVolume;

            this._musicVolume = data.MusicVolume;
            AudioScreen.MusicSlider.value = data.MusicVolume;

            this._ambienceVolume= data.AmbienceVolume;
            AudioScreen.AmbienceSlider.value = data.AmbienceVolume;

            this._effectsVolume = data.EffectsVolume;
            AudioScreen.EffectsSlider.value = data.EffectsVolume;

            this._uiVolume = data.UIVolume;
            AudioScreen.UISlider.value = data.UIVolume;
        }

        public void SaveData(ref GameData data)
        {
            data.MasterVolume = this._masterVolume;
            data.MusicVolume = this._musicVolume;
            data.AmbienceVolume = this._ambienceVolume;
            data.EffectsVolume = this._effectsVolume;
            data.UIVolume = this._uiVolume;
        }
        #endregion
    }

}
