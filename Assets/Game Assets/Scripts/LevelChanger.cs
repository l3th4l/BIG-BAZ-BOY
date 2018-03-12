using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private int levelIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(this.levelIndex);
    }
}