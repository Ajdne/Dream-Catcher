using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    [SerializeField]
    private TMP_Text PlayerScore;
    [SerializeField]
    private TMP_Text FinalScore;

    [SerializeField]
    private TMP_Text LaneDistance;
    [SerializeField]
    private List<GameObject> Clouds;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerScore.text = "0";
        foreach (GameObject go in Clouds)
        {
            go.transform.DOShakePosition(15, 5, 1,90,false,false,ShakeRandomnessMode.Harmonic).SetLoops(-1);
        }
    }
    public void PauseGame()
    {
        transform.Find("InGameUI").gameObject.SetActive(false);
        transform.Find("GamePausePanel").gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void UnpauseGame()
    {
        transform.Find("InGameUI").gameObject.SetActive(true);
        transform.Find("GamePausePanel").gameObject.SetActive(false);
        Time.timeScale = 1.0f;
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
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayAgain()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Gameplay");
    }
    public void PlayerDeath()
    {
        transform.Find("InGameUI").gameObject.SetActive(false);
        transform.Find("DeathPanel").gameObject.SetActive(true);
        FinalScore.text = ""+Player.Instance.Score.ToString();
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
    private void HeartsController()
    {
        if(Player.Instance.Health == 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
        if (Player.Instance.Health == 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
        }
        if (Player.Instance.Health == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }
    }
    private void ScoreController()
    {
        PlayerScore.text = "" + Player.Instance.Score.ToString();
    }
    private void OnEnable()
    {
        EventManager.PlayerDeath += PlayerDeath;
        EventManager.UpdateGUI += HeartsController;
        EventManager.UpdateGUI += ScoreController;
    }
    private void OnDisable()
    {
        EventManager.PlayerDeath -= PlayerDeath;
        EventManager.UpdateGUI -= HeartsController;
        EventManager.UpdateGUI -= ScoreController;
    }
}
