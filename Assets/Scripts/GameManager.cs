using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public int Sheep;
    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }
    public void SaveGame(int sheep)
    {
        PlayerPrefs.SetInt("Sheep", Sheep+sheep);
    }
    private void LoadGame()
    {
        Sheep = PlayerPrefs.GetInt("Sheep", 0);
    }
}
