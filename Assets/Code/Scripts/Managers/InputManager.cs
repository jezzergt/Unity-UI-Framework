using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectTemplate
{
    public class InputManager : MonoBehaviour
    {
        // Action Triggers
        public bool BackInput { get; private set; }
        public bool UpInput { get; private set; }
        public bool DownInput { get; private set; }
        public bool LeftInput { get; private set; }
        public bool RightInput { get; private set; }
        public bool NextInput { get; private set; }

        // Actions
        private InputAction _backAction;
        private InputAction _upAction;
        private InputAction _downAction;
        private InputAction _leftAction;
        private InputAction _rightAction;
        private InputAction _nextAction;

        // Action ID's
        const string _backActionID = "Back";
        const string _upActionID = "Up";
        const string _downActionID = "Down";
        const string _leftActionID = "Left";
        const string _rightActionID = "Right";
        const string _nextActionID = "Next";

        private PlayerInput _playerInput;

        #region Singleton & Awake
        private static InputManager _instance;

        public static InputManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("InputManager is null");
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if ((_instance != null && _instance != this))
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }

            _playerInput = GetComponent<PlayerInput>();

            SetupInputActions();
        }
        #endregion

        private void Update()
        {
            UpdateInputs();
        }

        private void SetupInputActions()
        {
            _backAction = _playerInput.actions[_backActionID];
            _upAction = _playerInput.actions[_upActionID];
            _downAction = _playerInput.actions[_downActionID];
            _leftAction = _playerInput.actions[_leftActionID];
            _rightAction = _playerInput.actions[_rightActionID];
            _nextAction = _playerInput.actions[_nextActionID];
        }

        private void UpdateInputs()
        {
            BackInput = _backAction.WasPressedThisFrame();
            UpInput = _upAction.WasPressedThisFrame();
            DownInput = _downAction.WasPressedThisFrame();
            LeftInput = _leftAction.WasPressedThisFrame();
            RightInput = _rightAction.WasPressedThisFrame();
            NextInput = _nextAction.WasPressedThisFrame();
        }
    }
}

