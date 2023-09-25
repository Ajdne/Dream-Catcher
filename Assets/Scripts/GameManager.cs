using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnEnable()
    {
        EventManager.PlayerDeath += PlayerDeath;
    }
    private void OnDisable()
    {
        EventManager.PlayerDeath -= PlayerDeath;
    }
    // ukupno sakupljenih ovaca
    public int TotalSheep;
    // max skupljenih u jednom run-u
    public int MostSheepCollected;
    // ukupno odigranih partija
    public int TotalDreams;
    // ukupno provedeno vreme u snovima
    public int TotalDreamTime;
    // longest run
    public int LongestDream;
    // ukupno udarenih obstacla
    public int ObstaclesHit;

    private void Start()
    {
        LoadGame();
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt("TotalSheep", TotalSheep);
        PlayerPrefs.SetInt("MostSheepCollected", MostSheepCollected);
        PlayerPrefs.SetInt("TotalDreams", TotalDreams);
        PlayerPrefs.SetInt("TotalDreamTime", TotalDreamTime);
        PlayerPrefs.SetInt("LongestDream", LongestDream);
        PlayerPrefs.SetInt("ObstaclesHit", ObstaclesHit);
    }
    private void LoadGame()
    {
        TotalSheep = PlayerPrefs.GetInt("TotalSheep", 0);
        MostSheepCollected = PlayerPrefs.GetInt("MostSheepCollected", 0);
        TotalDreams = PlayerPrefs.GetInt("TotalDreams", 0);
        TotalDreamTime = PlayerPrefs.GetInt("TotalDreamTime", 0);
        LongestDream = PlayerPrefs.GetInt("LongestDream", 0);
        ObstaclesHit = PlayerPrefs.GetInt("ObstaclesHit", 0);
    }
    private void PlayerDeath()
    {
        if(LongestDream < LevelGenerator.Instance.GameTime)
        {
            LongestDream = LevelGenerator.Instance.GameTime;
        }
        TotalDreamTime += LevelGenerator.Instance.GameTime;
        TotalDreams += 1;
        TotalSheep += Player.Instance.Score;
        if(MostSheepCollected < Player.Instance.Score)
        {
            MostSheepCollected = Player.Instance.Score;
        }
        ObstaclesHit += Player.Instance.ObstaclesHit;
        SaveGame();
    }
}
