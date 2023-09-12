using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
}