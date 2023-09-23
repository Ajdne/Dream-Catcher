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
    private void OnEnable()
    {
        EventManager.PlayerDeath += PlayerDeath;
    }
    private void OnDisable()
    {
        EventManager.PlayerDeath -= PlayerDeath;
    }
    public int Sheep;
    // Start is called before the first frame update
    private void Start()
    {
        LoadGame();
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt("Sheep", Sheep);
    }
    private void LoadGame()
    {
        Sheep = PlayerPrefs.GetInt("Sheep", 0);
    }
    private void PlayerDeath()
    {
        Sheep += Player.Instance.Health;
        SaveGame();
    }
}
