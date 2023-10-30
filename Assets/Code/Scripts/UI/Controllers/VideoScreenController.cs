using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ProjectTemplate
{
    public class VideoScreenController : MonoBehaviour, IDataPersistence
    {
        public VideoScreen VideoScreen;

        private Resolution[] _resolutions;
        private List<Resolution> _filteredResolutions;

        private UniversalAdditionalCameraData _additionalCameraData;

        private float _currentRefreshRate;
        private int _currentResolutionIndex = 0;
        private bool _firstLoad = true;

        List<string> options = new List<string>();

        private int _windowedMode;
        private int _fullscreenMode;

        private int _frameCap30;
        private int _frameCap60;
        private int _frameCapUnlimited;

        private int _gfxLow;
        private int _gfxMedium;
        private int _gfxHigh;
        private int _gfxUltra;

        private int _aaOff;
        private int _fxaaOn;
        private int _smaaOn;

        private int _vsyncOn;
        private int _vsyncOff;

        private void Awake()
        {
            _additionalCameraData = Camera.main.GetUniversalAdditionalCameraData();
        }

        private void OnEnable()
        {
            VideoScreen.AudioButtonClicked += Audio;
            VideoScreen.ControlsButtonClicked += Controls;
            VideoScreen.BackButtonClicked += Back;

            VideoScreen.DisplayDefaultResolution += DefaultResolution;
            VideoScreen.PreviousResolutionButtonClicked += PreviousResolution;
            VideoScreen.NextResolutionButtonClicked += NextResolution;

            VideoScreen.WindowedButtonClicked += SetWindowedMode;
            VideoScreen.FullscreenButtonClicked += SetFullscreenMode;

            VideoScreen.ThirtyFrameCapButtonClicked += SetFrameRate30;
            VideoScreen.SixtyFrameCapButtonClicked += SetFrameRate60;
            VideoScreen.UnlimitedFrameCapButtonClicked += SetFrameRateUnlimuted;

            VideoScreen.GFXLowButtonClicked += SetGFXLow;
            VideoScreen.GFXMediumButtonClicked += SetGFXMedium;
            VideoScreen.GFXHighButtonClicked += SetGFXHigh;
            VideoScreen.GFXUltraButtonClicked += SetGFXUltra;

            VideoScreen.AAOffButtonClicked += SetAAOff;
            VideoScreen.FXAAOnButtonClicked += SetFXAAOn;
            VideoScreen.SMAAOnButtonClicked += SetSMAAOn;

            VideoScreen.VsyncOffButtonClicked += SetVsyncOff;
            VideoScreen.VsyncOnButtonClicked += SetVsyncOn;

        }

        #region Navigation Subscriber Logic
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
            MainMenuUIManager.Instance.HomeScreenShown();
        }
        #endregion

        #region Resolution Settings Subscriber Logic
        private void PreviousResolution()
        {
            if (_currentResolutionIndex > 1)
            {
                _currentResolutionIndex--;
                VideoScreen.LabelResolution.text = options[_currentResolutionIndex];
                SetResolution(_currentResolutionIndex);
            }
        }

        private void NextResolution()
        {
            if (_currentResolutionIndex < _filteredResolutions.Count - 1)
            {
                _currentResolutionIndex++;
                VideoScreen.LabelResolution.text = options[_currentResolutionIndex];
                SetResolution(_currentResolutionIndex);
            }
        }

        private void DefaultResolution()
        {
            _resolutions = Screen.resolutions;
            _filteredResolutions = new List<Resolution>();
            _currentRefreshRate = (float)Screen.currentResolution.refreshRateRatio.value;

            if (_firstLoad)
            {
                for (int i = 0; i < _resolutions.Length; i++)
                {
                    if (_resolutions[i].refreshRateRatio.value == _currentRefreshRate)
                    {
                        _filteredResolutions.Add(_resolutions[i]);
                    }
                }

                for (int i = 0; i < _filteredResolutions.Count; i++)
                {
                    string resolutionOption = _filteredResolutions[i].width + "x" + _filteredResolutions[i].height;
                    options.Add(resolutionOption);

                    if (_filteredResolutions[i].width == Screen.width && _filteredResolutions[i].height == Screen.height)
                    {
                        _currentResolutionIndex = i;
                    }
                }

                VideoScreen.LabelResolution.text = options[_currentResolutionIndex];

                _firstLoad = false;
            }
        }

        private void SetResolution(int resolutionIndex)
        {
            Resolution resolution = _filteredResolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, true);
        }
        #endregion

        #region ScreenMode Settings Subscriber Logic
        private void SetWindowedMode()
        {
            FullScreenMode screenMode = FullScreenMode.Windowed;
            Screen.fullScreenMode = screenMode;

            _windowedMode = 1;
            _fullscreenMode = 0;
        }

        private void SetFullscreenMode()
        {
            FullScreenMode screenMode = FullScreenMode.FullScreenWindow;
            Screen.fullScreenMode = screenMode;

            _windowedMode = 0;
            _fullscreenMode = 1;
        }
        #endregion

        #region FrameRate Settings Subscriber Logic
        private void SetFrameRate30()
        {
            Application.targetFrameRate = 30;

            _frameCap30 = 1;
            _frameCap60 = 0;
            _frameCapUnlimited = 0;
        }

        private void SetFrameRate60()
        {
            Application.targetFrameRate = 60;

            _frameCap30 = 0;
            _frameCap60 = 1;
            _frameCapUnlimited = 0;
        }

        private void SetFrameRateUnlimuted()
        {
            // targetFrameRate -1 = unlimited
            Application.targetFrameRate = -1;

            _frameCap30 = 0;
            _frameCap60 = 0;
            _frameCapUnlimited = 1;
        }
        #endregion

        #region Graphics Quality Settings Subscriber Logic
        private void SetGFXLow()
        {
            QualitySettings.SetQualityLevel(1);

            _gfxLow = 1;
            _gfxMedium = 0;
            _gfxHigh = 0;
            _gfxUltra = 0;
        }

        private void SetGFXMedium()
        {
            QualitySettings.SetQualityLevel(2);

            _gfxLow = 0;
            _gfxMedium = 1;
            _gfxHigh = 0;
            _gfxUltra = 0;
        }

        private void SetGFXHigh()
        {
            QualitySettings.SetQualityLevel(3);

            _gfxLow = 0;
            _gfxMedium = 0;
            _gfxHigh = 1;
            _gfxUltra = 0;
        }

        private void SetGFXUltra()
        {
            QualitySettings.SetQualityLevel(4);

            _gfxLow = 0;
            _gfxMedium = 0;
            _gfxHigh = 0;
            _gfxUltra = 1;
        }
        #endregion

        #region Anti-aliasing Settings Subscriber Logic
        private void SetAAOff()
        {
            _additionalCameraData.antialiasing = AntialiasingMode.None;
            _additionalCameraData.renderPostProcessing = false;

            _aaOff = 1;
            _fxaaOn = 0;
            _smaaOn = 0;
        }

        private void SetFXAAOn()
        {
            _additionalCameraData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
            _additionalCameraData.renderPostProcessing = true;

            _aaOff = 0;
            _fxaaOn = 1;
            _smaaOn = 0;
        }

        private void SetSMAAOn()
        {
            _additionalCameraData.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
            _additionalCameraData.renderPostProcessing = true;

            _aaOff = 0;
            _fxaaOn = 0;
            _smaaOn = 1;
        }
        #endregion

        #region Vsync Settings Subscriber Logic
        private void SetVsyncOff()
        {
            QualitySettings.vSyncCount = 0;

            _vsyncOff = 1;
            _vsyncOn = 0;
        }

        private void SetVsyncOn()
        {
            QualitySettings.vSyncCount = 1;

            _vsyncOff = 0;
            _vsyncOn = 1;
        }
        #endregion

        #region Save & Load
        public void LoadData(GameData data)
        {
            this._windowedMode = data.WindowedMode;
            this._fullscreenMode = data.FullscreenMode;

            if (_windowedMode == 1)
            {
                VideoScreen.WindowedButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetWindowedMode();
            }

            if (_fullscreenMode == 1)
            {
                VideoScreen.FullscreenButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetFullscreenMode();
            }
            
            this._frameCap30 = data.FrameCap30;
            this._frameCap60 = data.FrameCap60;
            this._frameCapUnlimited = data.FrameCapUnlimited;

            if (data.FrameCap30 == 1)
            {
                VideoScreen.ThirtyFrameCapButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetFrameRate30();
            }

            if (data.FrameCap60 == 1)
            {
                VideoScreen.SixtyFrameCapButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetFrameRate60();
            }

            if (data.FrameCapUnlimited == 1)
            {
                VideoScreen.UnlimitedFrameCapButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetFrameRateUnlimuted();
            }

            this._gfxLow = data.GFXLow;
            this._gfxMedium = data.GFXMedium;
            this._gfxHigh = data.GFXHigh;
            this._gfxUltra = data.GFXUltra;

            if (data.GFXLow == 1)
            {
                VideoScreen.GFXLowButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetGFXLow();
            }

            if (data.GFXMedium == 1)
            {
                VideoScreen.GFXMediumButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetGFXMedium();
            }

            if (data.GFXHigh == 1)
            {
                VideoScreen.GFXHighButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetGFXHigh();
            }

            if (data.GFXUltra == 1)
            {
                VideoScreen.GFXUltraButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetGFXUltra();
            }

            this._aaOff = data.AAOff;
            this._fxaaOn = data.FXAAOn;
            this._smaaOn = data.SMAAOn;

            if (data.AAOff == 1)
            {
                VideoScreen.AAOffButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetAAOff();
            }

            if (data.FXAAOn == 1)
            {
                VideoScreen.FXAAOnButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetFXAAOn();
            }

            if (data.SMAAOn == 1)
            {
                VideoScreen.SMAAOnButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetSMAAOn();
            }

            this._vsyncOff = data.VsyncOff;
            this._vsyncOn = data.VsyncOn;

            if (data.VsyncOff == 1)
            {
                VideoScreen.VsyncOffButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetVsyncOff();
            }

            if (data.VsyncOn == 1)
            {
                VideoScreen.VsyncOnButton.style.backgroundColor = MainMenuUIManager.SelectedButtonColor;
                SetVsyncOn();
            }
        }

        public void SaveData(ref GameData data)
        {
            data.WindowedMode = this._windowedMode;
            data.FullscreenMode = this._fullscreenMode;

            data.FrameCap30 = this._frameCap30;
            data.FrameCap60 = this._frameCap60;
            data.FrameCapUnlimited = this._frameCapUnlimited;

            data.GFXLow = this._gfxLow;
            data.GFXMedium = this._gfxMedium;
            data.GFXHigh = this._gfxHigh;
            data.GFXUltra = this._gfxUltra;

            data.AAOff = this._aaOff;
            data.FXAAOn = this._fxaaOn;
            data.SMAAOn = this._smaaOn;

            data.VsyncOff = this._vsyncOff;
            data.VsyncOn = this._vsyncOn;

        }
        #endregion
    }
}

