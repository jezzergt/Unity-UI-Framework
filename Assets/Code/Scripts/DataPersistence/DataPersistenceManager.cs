using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace ProjectTemplate
{
    public class DataPersistenceManager : MonoBehaviour
    {
        //public static event Action<GameData> OnSaveTriggered;

        private string _fileName = "preferences.script";

        private GameData _gameData;
        private List<IDataPersistence> _dataPersistencesObjects;
        private FileDataHandler _dataHandler;

        private static DataPersistenceManager _instance;

        public static DataPersistenceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("DataPersistenceManager is null");
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

        private void Start()
        {
            this._dataHandler = new FileDataHandler(Application.persistentDataPath, _fileName);
            this._dataPersistencesObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }

        public void NewGame()
        {
            this._gameData = new GameData();
        }

        public void SaveGame()
        {
            // pass the data to other scripts so they can update it
            foreach (IDataPersistence dataPersistenceObj in _dataPersistencesObjects)
            {
                dataPersistenceObj.SaveData(ref _gameData);
            }

            // save that data to a file using the data handler
            _dataHandler.Save(_gameData);
        }

        public void LoadGame()
        {
            // Load any saved data from a file using the data handler
            this._gameData = _dataHandler.Load();

            // if not data can be loaded, initialise to a new game
            if (this._gameData == null)
            {
                Debug.Log("No data was found. Loading default values");
                NewGame();
            }

            // push the loaded data to all other scripts that need it
            foreach (IDataPersistence dataPersistenceObj in _dataPersistencesObjects)
            {
                dataPersistenceObj.LoadData(_gameData);
            }
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {
            IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
                .OfType<IDataPersistence>();

            return new List<IDataPersistence>(dataPersistenceObjects);
        }

        public GameData RetrieveGameData()
        {
            return _gameData;
        }
    }
}

