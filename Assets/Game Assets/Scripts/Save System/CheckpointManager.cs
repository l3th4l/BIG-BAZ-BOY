using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

internal sealed class CheckpointManager : MonoBehaviour
{
    private IFormatter formatter = new BinaryFormatter();

    private Saveable[] saveables;

    private string saveName = @"\test.save";

    private string SavePath
    {
        get { return Application.persistentDataPath + this.saveName; }
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