using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ScriptableObjectUtility.Variables;
using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class CheckpointManager : MonoBehaviour
{
    private const string SaveName = @"\currentlvl.save";
    private IFormatter formatter = new BinaryFormatter();

    [SerializeField]
    private int level1Index = 1;

    private SaveData levelData;

    [SerializeField]
    private FloatVariable playerHealth;

    [SerializeField]
    private FloatReference playerMaxHealth;

    public static bool HasSave
    {
        get { return File.Exists(SavePath); }
    }

    public static CheckpointManager Instance { get; private set; }

    private static string SavePath
    {
        get { return Application.persistentDataPath + SaveName; }
    }

    public static void DeleteSave()
    {
        File.Delete(SavePath);
    }

    public void Load()
    {
        using (var sr = new FileStream(SavePath, FileMode.Open))
        {
            this.levelData = (SaveData)this.formatter.Deserialize(sr);
        }

        if (this.levelData.LevelIndex == SceneManager.GetActiveScene().buildIndex)
        {
            print("Load level data");
            this.LoadLevelData();
        }
        else
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(this.levelData.LevelIndex);
            op.completed += this.OnLevelLoaded;
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(this.level1Index);
    }

    public void Save()
    {
        var saveables = CheckpointManager.FindObjectsOfType<Saveable>();

        using (var sw = new FileStream(SavePath, FileMode.Create))
        {
            SaveData saveData = new SaveData
            {
                EntityStates = saveables.Select(c => c.Save()).ToArray(),
                LevelIndex = SceneManager.GetActiveScene().buildIndex
            };

            this.formatter.Serialize(sw, saveData);
        }
    }

    private void LoadLevelData()
    {
        var saveables = CheckpointManager.FindObjectsOfType<Saveable>();
        for (int i = 0; i < saveables.Length; i++)
        {
            saveables[i].Load(this.levelData.EntityStates[i]);
        }

        this.playerHealth.Value = this.playerMaxHealth;
    }

    private void OnLevelLoaded(AsyncOperation op)
    {
        print("Load level data after scene load");
        this.LoadLevelData();
    }

    private void Start()
    {
        CheckpointManager.DontDestroyOnLoad(this.gameObject);

        Debug.Assert(Instance == null, "More than one CheckpointManager");

        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.Save();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            this.Load();
        }
    }

    [Serializable]
    private struct SaveData
    {
        public EntityState[] EntityStates;
        public int LevelIndex;
    }
}