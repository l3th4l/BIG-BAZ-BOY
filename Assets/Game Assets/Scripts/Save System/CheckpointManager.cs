using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ScriptableObjectUtility.Variables;
using UnityEngine;

internal sealed class CheckpointManager : MonoBehaviour
{
    private IFormatter formatter = new BinaryFormatter();

    [SerializeField]
    private FloatVariable playerHealth;

    [SerializeField]
    private FloatReference playerMaxHealth;

    private Saveable[] saveables;

    private string saveName = @"\test.save";

    private string SavePath
    {
        get { return Application.persistentDataPath + this.saveName; }
    }

    public void DeleteSave()
    {
        File.Delete(this.SavePath);
    }

    public void Load()
    {
        using (var sr = new FileStream(this.SavePath, FileMode.Open))
        {
            var entityStates = (EntityState[])this.formatter.Deserialize(sr);

            for (int i = 0; i < this.saveables.Length; i++)
            {
                this.saveables[i].Load(entityStates[i]);
            }
        }

        this.playerHealth.Value = this.playerMaxHealth;
    }

    public void Save()
    {
        using (var sw = new FileStream(this.SavePath, FileMode.Create))
        {
            this.formatter.Serialize(sw, this.saveables.Select(c => c.Save()).ToArray());
        }
    }

    private void Start()
    {
        this.saveables = CheckpointManager.FindObjectsOfType<Saveable>();

        if (File.Exists(this.SavePath))
        {
            this.Load();
        }
        else
        {
            this.Save();
            this.Load();
        }
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
}