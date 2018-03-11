using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private CheckpointManager checkpointManager;

    [SerializeField]
    private int levelIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.checkpointManager.DeleteSave();
        SceneManager.LoadScene(this.levelIndex);
    }
}