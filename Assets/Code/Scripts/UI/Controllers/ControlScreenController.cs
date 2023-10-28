using System.Collections;
using UnityEngine;

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

        private void OnEnable()
        {
            ControlScreen.VideoButtonClicked += Video;
            ControlScreen.AudioButtonClicked += Audio;
            ControlScreen.BackButtonClicked += Back;

            ControlScreen.BackInputPrimaryClicked += SetBackInputPrimary;
            ControlScreen.BackInputSecondaryClicked += SetBackInputSecondary;
            ControlScreen.BackInputResetClicked += SetBackInputReset;
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
            // Temp string while awaiting user input
            string temp = ". . . .";

            // Setting temp string to button text
            ControlScreen.BackInputPrimaryButton.text = temp;

            // Scan for user input for a certain time

                // if we detected anyKey save this key into our button text
                // else revert to the previously set key
           
            // save new variable and then update InputManager
        }

        private void SetBackInputSecondary()
        {
            ControlScreen.BackInputPrimaryButton.text = ". . . .";
            // if button is pressed clear the existing variable
            // wait for user input to define the new variable
            // save new variable and then update InputManager
        }

        private void SetBackInputReset()
        {
            // Find a way to revert back to default values
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
            data.DownInputPrimary = this._downInputPrimary;
            data.DownInputSecondary = this._downInputSecondary;
            data.LeftInputPrimary = this._leftInputPrimary;
            data.LeftInputSecondary = this._leftInputSecondary;
            data.RightInputPrimary = this._rightInputPrimary;
            data.RightInputSecondary = this._rightInputSecondary;
        }
        #endregion
    }
}
