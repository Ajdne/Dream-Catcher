using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField]
    private TMP_Text PlayerHealth;
    [SerializeField]
    private TMP_Text PlayerScore;
    [SerializeField]
    private TMP_Text GameSpeed;
    [SerializeField]
    private TMP_Text FinalScore;
    [SerializeField]
    private TMP_Text LaneDistance;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.text = "Hearts: "+Player.Instance.Health.ToString();
        PlayerScore.text = "Score: "+Player.Instance.Score.ToString();
        GameSpeed.text = "Speed: " + LevelGenerator.gameSpeed.ToString("F1");
        LaneDistance.text = "LaneDistance: " + TapInput.LANE_DISTANCE;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealth.text = "Hearts: " + Player.Instance.Health.ToString();
        PlayerScore.text = "Sheep: " + Player.Instance.Score.ToString();
        GameSpeed.text = "Speed: " + LevelGenerator.gameSpeed.ToString("F1")+"%";
    }
    public void PauseGame()
    {
        transform.Find("InGameUI").gameObject.SetActive(false);
        transform.Find("GamePausePanel").gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void UnpauseGame()
    {
        transform.Find("InGameUI").gameObject.SetActive(true);
        transform.Find("GamePausePanel").gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Settings()
    {
        transform.Find("MainMenuPanel").gameObject.SetActive(false);
        transform.Find("SettingsPanel").gameObject.SetActive(true);
    }
    public void SettingsBackButton()
    {
        transform.Find("SettingsPanel").gameObject.SetActive(false);
        transform.Find("MainMenuPanel").gameObject.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void PlayerDeath()
    {
        transform.Find("InGameUI").gameObject.SetActive(false);
        transform.Find("DeathPanel").gameObject.SetActive(true);
        FinalScore.text = "Sheep counted: " + Player.Instance.Score.ToString();
    }

    public void PlusDistance()
    {
        TapInput.LANE_DISTANCE += 0.5f;
        LaneDistance.text = "Lane Distance: " + TapInput.LANE_DISTANCE;
        Debug.Log(TapInput.LANE_DISTANCE);
    }
    public void MinusDistance()
    {
        TapInput.LANE_DISTANCE -= 0.5f;
        LaneDistance.text = "Lane Distance: " + TapInput.LANE_DISTANCE;
        Debug.Log(TapInput.LANE_DISTANCE);
    }
    private void OnEnable()
    {
        EventManager.PlayerDeath += PlayerDeath;
    }
    private void OnDisable()
    {
        EventManager.PlayerDeath -= PlayerDeath;
    }
}
