using UnityEngine;
using UnityEngine.Audio;

namespace ProjectTemplate
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Mixers")]
        [SerializeField] private AudioMixer _masterMixer;

        [Header("Master Audio Sources")]
        [SerializeField] private AudioSource _masterSource;
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _effectsSource;
        [SerializeField] private AudioSource _ambienceSource;
        [SerializeField] private AudioSource _uiSource;

        [Header("UI Sounds")]
        [SerializeField] private AudioClip _defaultButtonSound;
        [SerializeField] private AudioClip _defaultButtonHoverSound;
        [SerializeField] private AudioClip _defaultBackButtonSound;

        #region Singleton & Awake
        private static AudioManager _instance;

        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("AudioManager is null");
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
                DontDestroyOnLoad(this);
            }
        }
        #endregion

        #region Mixer Functions
        public void SetMixerMasterVolume(float value)
        {
            _masterMixer.SetFloat("MasterVol", Mathf.Log10(value) * 20);
        }

        public void SetMixerMusicVolume(float value)
        {
            _masterMixer.SetFloat("MusicVol", Mathf.Log10(value) * 20);
        }

        public void SetMixerAmbienceVolume(float value)
        {
            _masterMixer.SetFloat("AmbienceVol", Mathf.Log10(value) * 20);
        }

        public void SetMixerEffectsVolume(float value)
        {
            _masterMixer.SetFloat("EffectsVol", Mathf.Log10(value) * 20);
        }

        public void SetMixerUIVolume(float value)
        {
            _masterMixer.SetFloat("UIVol", Mathf.Log10(value) * 20);
        }
        #endregion

        #region AudioManager Functions
        public void PlayMusicAudio(AudioClip clip)
        {
            _musicSource.clip = clip;
            _musicSource.loop = true;
            _musicSource.Play();
        }

        public void PlayAmbienceAudio(AudioClip clip)
        {
            _ambienceSource.clip = clip;
            _ambienceSource.PlayOneShot(clip);
        }

        public void PlayEffectsAudio(AudioClip clip)
        {
            _effectsSource.clip = clip;
            _effectsSource.PlayOneShot(clip);
        }

        public void PlayUIAudio(AudioClip clip)
        {
            _uiSource.clip = clip;
            _uiSource.PlayOneShot(clip);
        }

        public void PlayDefaultButtonClick()
        {
            _uiSource.PlayOneShot(_defaultButtonSound);
        }

        public void PlayDefaultBackButtonClick()
        {
            _uiSource.PlayOneShot(_defaultBackButtonSound);
        }

        public void PlayDefaultButtonHover()
        {
            _uiSource.PlayOneShot(_defaultButtonHoverSound);
        }
        #endregion
    }
}

