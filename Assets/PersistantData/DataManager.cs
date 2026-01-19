using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    public static DataManager instance { get; private set; }


    private GameData gameData;
    private FileDataHandler dataHandler;
    private List<IDataPersistence> dataPersistenceObjects;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance != null)
        {
            Debug.LogError("Found multiple data manager in this scene");
        }
        instance = this;
    }
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // you gotta try these dr pepper brownies (load the save data from a file using data handler)
        this.gameData = dataHandler.Load();


        // if theres nothing to load, creat a new game
        if (this.gameData == null)
        {
            Debug.Log("no data found, setting to default");
            NewGame();
        }
        // give the data to the scripts that ask kindly enough
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        // pass data to other scripts
        // save the data to a file using its handler to not upset agent 47

        // recieve the data
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        dataHandler.save(gameData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        // creates a list of every monobehaviour with data persistence.
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
