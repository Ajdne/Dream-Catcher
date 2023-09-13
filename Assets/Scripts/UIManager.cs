using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text PlayerHealth;
    [SerializeField]
    private TMP_Text PlayerScore;
    [SerializeField]
    private TMP_Text GameSpeedScale;
    [SerializeField]
    private TMP_Text GameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.text = "Health: "+Player.Instance.Health.ToString();
        PlayerScore.text = "Score: "+Player.Instance.Score.ToString();
        GameSpeedScale.text = "Time scale: " + Time.timeScale.ToString();
        GameSpeed.text = "Game speed: " + LevelGenerator.gameSpeed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealth.text = "Health: " + Player.Instance.Health.ToString();
        PlayerScore.text = "Score: " + Player.Instance.Score.ToString();
        GameSpeedScale.text = "Time scale: " + Time.timeScale.ToString();
        GameSpeed.text = "Game speed: " + LevelGenerator.gameSpeed.ToString();
    }
    private int lastTimeScale;
    public void PauseGame()
    {
        transform.Find("InGameUI").gameObject.SetActive(false);
        transform.Find("GamePausePanel").gameObject.SetActive(true);
        lastTimeScale = (int)Time.timeScale;
        Time.timeScale = 0;
    }
    public void UnpauseGame()
    {
        transform.Find("InGameUI").gameObject.SetActive(true);
        transform.Find("GamePausePanel").gameObject.SetActive(false);
        Time.timeScale = lastTimeScale;
    }

}
