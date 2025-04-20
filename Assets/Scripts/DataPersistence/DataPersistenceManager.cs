using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    public static DataPersistenceManager instance { get; private set; }
    public GameData gameData;

    

    public List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler fileDataHandler;

    [SerializeField] internal bool grassCompleted = false;
    [SerializeField] internal bool lavaCompleted = false;
    [SerializeField] internal bool waterCompleted = false;

    public Dictionary<string, bool> crystalDict;

    internal bool gameCompleted = false;

    private bool saveData;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one persistence manager, destroyed new one");
            Destroy(this.gameObject);
            return;
        }


        instance = this;
        DontDestroyOnLoad(this.gameObject);

        crystalDict = new Dictionary<string, bool>()
        {
            {"Crystal1_1", false},
            {"Crystal1_2", false},
            {"Crystal1_3", false},
            {"Crystal2_1", false},
            {"Crystal2_2", false},
            {"Crystal2_3", false},
            {"Crystal3_1", false},
            {"Crystal3_2", false},
            {"Crystal3_3", false},
        };

        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        WinGame();
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    
    public void NewGame()
    {
        this.gameData = new GameData();

        grassCompleted = false;
        lavaCompleted = false;
        waterCompleted = false;

        crystalDict = new Dictionary<string, bool>()
        {
            {"Crystal1_1", false},
            {"Crystal1_2", false},
            {"Crystal1_3", false},
            {"Crystal2_1", false},
            {"Crystal2_2", false},
            {"Crystal2_3", false},
            {"Crystal3_1", false},
            {"Crystal3_2", false},
            {"Crystal3_3", false},
        };
    }

    public void LoadGame()
    {

        this.gameData = fileDataHandler.Load();
        

        if(this.gameData == null)
        {
            return;
        }

        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        if(this.gameData == null)
        {
            return;
        }


        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }

        fileDataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public  List<IDataPersistence> FindAllDataPersistenceObjects(){

        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);

    }

    public bool HasGameData()
    {
        return gameData != null;
    }

    private void WinGame()
    {
        if(waterCompleted == true && lavaCompleted == true && grassCompleted == true)
        {
            gameCompleted = true;
        }
    }
}
