
namespace ProjectTemplate
{
    [System.Serializable]
    public class GameData
    {
        // Video Settings
        public int WindowedMode;
        public int FullscreenMode;

        public int FrameCap30;
        public int FrameCap60;
        public int FrameCapUnlimited;

        public int GFXLow;
        public int GFXMedium;
        public int GFXHigh;
        public int GFXUltra;

        public int AAOff;
        public int FXAAOn;
        public int SMAAOn;

        public int VsyncOff;
        public int VsyncOn;
        
        // Audio Settings
        public float MasterVolume;
        public float MusicVolume;
        public float AmbienceVolume;
        public float EffectsVolume;
        public float UIVolume;

        // Control Settings
        public string BackInputPrimary;
        public string BackInputSecondary;

        public string UpInputPrimary;
        public string UpInputSecondary;

        public string DownInputPrimary;
        public string DownInputSecondary;

        public string LeftInputPrimary;
        public string LeftInputSecondary;

        public string RightInputPrimary;
        public string RightInputSecondary;

        // Constructor variables act as the default out of the box values
        public GameData()
        {
            // Video Setting Defaults
            this.WindowedMode = 1;
            this.FullscreenMode = 0;

            this.FrameCap30 = 0;
            this.FrameCap60 = 0;
            this.FrameCapUnlimited = 1;

            this. GFXLow = 0;
            this. GFXMedium = 0;
            this. GFXHigh = 0;
            this. GFXUltra = 1;

            this. AAOff = 0;
            this. FXAAOn = 1;
            this. SMAAOn = 0;

            this. VsyncOff = 1;
            this. VsyncOn = 0;

            // Audio Setting Defaults
            this.MasterVolume = 1.0f;
            this.MusicVolume = 1.0f;
            this.AmbienceVolume = 1.0f; 
            this.EffectsVolume = 1.0f;  
            this.UIVolume = 1.0f;

            // Control Setting Defaults
            this.BackInputPrimary = "Escape";
            this.BackInputSecondary = "Unbound";

            this.UpInputPrimary = "Up Arrow";
            this.UpInputSecondary = "Unbound";

            this.DownInputPrimary = "Down Arrow";
            this.DownInputSecondary = "Unbound";

            this.LeftInputPrimary = "Left Arrow";
            this.LeftInputSecondary = "Unbound";

            this.RightInputPrimary = "Right Arrow";
            this.RightInputSecondary = "Unbound";
        }
    }

}
