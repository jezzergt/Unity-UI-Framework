using System;
using System.Collections;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ProjectTemplate
{
    public class ControlScreenController : MonoBehaviour, IDataPersistence
    {
        public ControlScreen ControlScreen;

        private string _backInputPrimary;
        private string _backInputSecondary;

        private string _upInputPrimary;
        private string _upInputSecondary;

        private string _downInputPrimary;  
        private string _downInputSecondary;

        private string _leftInputPrimary;
        private string _leftInputSecondary;

        private string _rightInputPrimary;
        private string _rightInputSecondary;

        private string _awaitingInput = ". . . .";

        private void OnEnable()
        {
            ControlScreen.VideoButtonClicked += Video;
            ControlScreen.AudioButtonClicked += Audio;
            ControlScreen.BackButtonClicked += Back;

            ControlScreen.BackInputPrimaryClicked += SetBackInputPrimary;
            ControlScreen.BackInputSecondaryClicked += SetBackInputSecondary;
            ControlScreen.BackInputResetClicked += SetBackInputReset;

            ControlScreen.UpInputPrimaryClicked += SetUpInputPrimary;
            ControlScreen.UpInputSecondaryClicked += SetUpInputSecondary;
            ControlScreen.UpInputResetClicked += SetUpInputReset;

            ControlScreen.DownInputPrimaryClicked += SetDownInputPrimary;
            ControlScreen.DownInputSecondaryClicked += SetDownInputSecondary;
            ControlScreen.DownInputResetClicked += SetDownInputReset;

            ControlScreen.LeftInputPrimaryClicked += SetLeftInputPrimary;
            ControlScreen.LeftInputSecondaryClicked += SetLeftInputSecondary;
            ControlScreen.LeftInputResetClicked += SetLeftInputReset;

            ControlScreen.RightInputPrimaryClicked += SetRightInputPrimary;
            ControlScreen.RightInputSecondaryClicked += SetRightInputSecondary;
            ControlScreen.RightInputResetClicked += SetRightInputReset;
        }

        #region Navigation Subscriber Logic
        private void Video()
        {
            MainMenuUIManager.Instance.DisableAllScreens();
            MainMenuUIManager.Instance.EnableScreen(MainMenuUIManager.Instance.VideoScreen.Root);
        }

        private void Audio()
        {
            MainMenuUIManager.Instance.DisableAllScreens();
            MainMenuUIManager.Instance.EnableScreen(MainMenuUIManager.Instance.AudioScreen.Root);
        }

        private void Back()
        {
            MainMenuUIManager.Instance.DisableAllScreens();
            MainMenuUIManager.Instance.EnableScreen(MainMenuUIManager.Instance.HomeScreen.Root);
            MainMenuUIManager.Instance.HomeScreenShown();
        }
        #endregion

        #region Back Input Subscribers
        private void SetBackInputPrimary()
        {
            ControlScreen.BackInputPrimaryButton.text = _awaitingInput;

            StartCoroutine(WaitForKeyPress((action) =>
            {
                ControlScreen.BackInputPrimaryButton.text = action;
                _backInputPrimary = action;
            }));

            // We need a way to rebind the InputAction with the passed in string or perhaps a keycode?
            // myAction.ApplyBindingOverride(newBindingPath);
        }

        private void SetBackInputSecondary()
        {
            ControlScreen.BackInputSecondaryButton.text = _awaitingInput;

            StartCoroutine(WaitForKeyPress((action) =>
            {
                ControlScreen.BackInputSecondaryButton.text = action;
                _backInputSecondary = action;
            }));
        }

        private void SetBackInputReset()
        {
            GameData data = DataPersistenceManager.Instance.RetrieveGameData();

            ControlScreen.BackInputPrimaryButton.text = data.BackInputPrimary;
            ControlScreen.BackInputSecondaryButton.text = data.BackInputSecondary;
        }
        #endregion

        #region Up Input Subscribers
        private void SetUpInputPrimary()
        {
            ControlScreen.UpInputPrimaryButton.text = _awaitingInput;

            StartCoroutine(WaitForKeyPress((action) =>
            {
                ControlScreen.UpInputPrimaryButton.text = action;
                _upInputPrimary = action;
            }));
        }

        private void SetUpInputSecondary()
        {
            ControlScreen.UpInputSecondaryButton.text = _awaitingInput;

            StartCoroutine(WaitForKeyPress((action) =>
            {
                ControlScreen.UpInputSecondaryButton.text = action;
                _upInputSecondary = action;
            }));
        }

        private void SetUpInputReset()
        {
            GameData data = DataPersistenceManager.Instance.RetrieveGameData();

            ControlScreen.UpInputPrimaryButton.text = data.UpInputPrimary;
            ControlScreen.UpInputSecondaryButton.text = data.UpInputSecondary;
        }
        #endregion

        #region Down Input Subscribers
        private void SetDownInputPrimary()
        {
            ControlScreen.DownInputPrimaryButton.text = _awaitingInput;

            StartCoroutine(WaitForKeyPress((action) =>
            {
                ControlScreen.DownInputPrimaryButton.text = action;
                _downInputPrimary = action;
            }));
        }

        private void SetDownInputSecondary()
        {
            ControlScreen.DownInputSecondaryButton.text = _awaitingInput;

            StartCoroutine(WaitForKeyPress((action) =>
            {
                ControlScreen.DownInputSecondaryButton.text = action;
                _downInputSecondary = action;
            }));
        }

        private void SetDownInputReset()
        {
            GameData data = DataPersistenceManager.Instance.RetrieveGameData();

            ControlScreen.DownInputPrimaryButton.text = data.DownInputPrimary;
            ControlScreen.DownInputSecondaryButton.text = data.DownInputSecondary;
        }
        #endregion

        #region Left Input Subscribers
        private void SetLeftInputPrimary()
        {
            ControlScreen.LeftInputPrimaryButton.text = _awaitingInput;

            StartCoroutine(WaitForKeyPress((action) =>
            {
                ControlScreen.LeftInputPrimaryButton.text = action;
                _leftInputPrimary = action;
            }));
        }

        private void SetLeftInputSecondary()
        {
            ControlScreen.LeftInputSecondaryButton.text = _awaitingInput;

            StartCoroutine(WaitForKeyPress((action) =>
            {
                ControlScreen.LeftInputSecondaryButton.text = action;
                _leftInputSecondary = action;
            }));

        }

        private void SetLeftInputReset()
        {
            GameData data = DataPersistenceManager.Instance.RetrieveGameData();

            ControlScreen.LeftInputPrimaryButton.text = data.LeftInputPrimary;
            ControlScreen.LeftInputSecondaryButton.text = data.LeftInputSecondary;
        }
        #endregion

        #region Right Input Subscribers
        private void SetRightInputPrimary()
        {
            ControlScreen.RightInputPrimaryButton.text = _awaitingInput;

            StartCoroutine(WaitForKeyPress((action) =>
            {
                ControlScreen.RightInputPrimaryButton.text = action;
                _rightInputPrimary = action;
            }));
        }

        private void SetRightInputSecondary()
        {
            ControlScreen.RightInputSecondaryButton.text = _awaitingInput;

            StartCoroutine(WaitForKeyPress((action) =>
            {
                ControlScreen.RightInputSecondaryButton.text = action;
                _rightInputSecondary = action;
            }));

        }

        private void SetRightInputReset()
        {
            GameData data = DataPersistenceManager.Instance.RetrieveGameData();

            ControlScreen.RightInputPrimaryButton.text = data.RightInputPrimary;
            ControlScreen.RightInputSecondaryButton.text = data.RightInputSecondary;
        }
        #endregion

        #region Reset All Keybindings
        private void ResetAllKeyBindings()
        {

        }
        #endregion

        #region Save & Load
        public void LoadData(GameData data)
        {
            this._backInputPrimary = data.BackInputPrimary;
            this._backInputSecondary = data.BackInputSecondary;

            ControlScreen.BackInputPrimaryButton.text = data.BackInputPrimary.ToString();
            ControlScreen.BackInputSecondaryButton.text = data.BackInputSecondary.ToString();

            this._upInputPrimary = data.UpInputPrimary;
            this._upInputSecondary = data.UpInputSecondary;

            ControlScreen.UpInputPrimaryButton.text = data.UpInputPrimary.ToString();
            ControlScreen.UpInputSecondaryButton.text = data.UpInputSecondary.ToString();

            this._downInputPrimary = data.DownInputPrimary;
            this._downInputSecondary = data.DownInputSecondary;

            ControlScreen.DownInputPrimaryButton.text = data.DownInputPrimary.ToString();
            ControlScreen.DownInputSecondaryButton.text = data.DownInputSecondary.ToString();

            this._leftInputPrimary = data.LeftInputPrimary;
            this._leftInputSecondary = data.LeftInputSecondary;

            ControlScreen.LeftInputPrimaryButton.text = data.LeftInputPrimary.ToString();
            ControlScreen.LeftInputSecondaryButton.text = data.LeftInputSecondary.ToString();

            this._rightInputPrimary = data.RightInputPrimary;
            this._rightInputSecondary = data.RightInputSecondary;

            ControlScreen.RightInputPrimaryButton.text = data.RightInputPrimary.ToString();
            ControlScreen.RightInputSecondaryButton.text = data.RightInputSecondary.ToString();
        }

        public void SaveData(ref GameData data)
        {
            data.BackInputPrimary = this._backInputPrimary;
            data.BackInputSecondary = this._backInputSecondary;
            data.UpInputPrimary = this._upInputPrimary;
            data.UpInputSecondary = this._upInputSecondary;
            data.DownInputPrimary = this._downInputPrimary;
            data.DownInputSecondary = this._downInputSecondary;
            data.LeftInputPrimary = this._leftInputPrimary;
            data.LeftInputSecondary = this._leftInputSecondary;
            data.RightInputPrimary = this._rightInputPrimary;
            data.RightInputSecondary = this._rightInputSecondary;
        }
        #endregion

        #region Coroutines
        public IEnumerator WaitForKeyPress(Action<string> action)
        {
            KeyCode keycode;
            bool done = false;
            while (!done)
            {
                if (Input.anyKeyDown)
                {
                    foreach(var item in Enum.GetValues(typeof(KeyCode)))
                    {
                        var key = (KeyCode)item;
                        if (Input.GetKeyDown(key))
                        {
                            keycode = key;
                            action(keycode.ToString());
                            break;
                        }
                    }
                    done = true;
                }
                yield return action;
            }
        }
        #endregion
    }
}
