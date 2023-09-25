using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instace;

    [SerializeField] private TextMeshProUGUI TotalSheepText;
    [SerializeField] private TextMeshProUGUI MostSheepText;
    [SerializeField] private TextMeshProUGUI TotalDreamsText;
    [SerializeField] private TextMeshProUGUI TotalDreamTimeText;
    [SerializeField] private TextMeshProUGUI LongestDreamText;
    [SerializeField] private TextMeshProUGUI ObstaclesHitText;

    [SerializeField] private GameObject AchievementsPanel;
    [SerializeField] private GameObject StatsPanel;
    bool panel = false;

    GameManager GM;

    private void Awake()
    {
        Instace = this;
    }

    private void Start()
    {
        SettingsIsClosed = true;
        ShopIsClosed = true;
        duration = 5;
        GM = GameManager.Instance;
        UpdatePlayerStats();
    }

    #region Phone
    public void SwitchPanel() 
    {
        panel = !panel;
        AchievementsPanel.SetActive(!panel);
        StatsPanel.SetActive(panel);
    }
    #endregion

    #region PlayerStats
    public void UpdatePlayerStats()
    {
        TotalSheepText.text = "Total Sheep Count: " + GM.TotalSheep.ToString();
        MostSheepText.text = "Most Sheep Collecetd: " + GM.MostSheepCollected.ToString();
        TotalDreamsText.text = "Total Dream Count: " + GM.TotalDreams.ToString();
        ObstaclesHitText.text = "Obstacle Hit Count: " + GM.ObstaclesHit.ToString();

        int hours, minutes, seconds;

        hours = GM.TotalDreamTime / 360; 
        minutes = (GM.TotalDreamTime % 360) / 60 ;
        seconds = (GM.TotalDreamTime % 360) % 60;
        TotalDreamTimeText.text = "Total Dream Time: \n" + hours + "h " + minutes + "m " + seconds + "s";

        minutes = (GM.LongestDream % 360) / 60;
        seconds = (GM.LongestDream % 360) % 60;
        LongestDreamText.text = "Longest Dream Time: \n" + minutes + "m " + seconds + "s";
    }
    #endregion

    #region Dream
    public void Dream()
    {
        SceneManager.LoadScene("Gameplay");
    }
    #endregion

    #region WingMover

    [SerializeField] private GameObject SettingsLeftWing;
    [SerializeField] private GameObject SettingsRightWing;
    [SerializeField] private GameObject ShopLeftWing;
    [SerializeField] private GameObject ShopRightWing;
    private bool SettingsIsClosed;
    private bool ShopIsClosed;
    public float duration;

    public void MoveWingsSettings()
    {
        if (SettingsIsClosed)
        {
            SettingsLeftWing.transform.DOComplete();
            SettingsRightWing.transform.DOComplete();
            SettingsLeftWing.transform.DOMoveZ(SettingsLeftWing.transform.position.z - 0.77f, duration); //-10.12 -> 10.99
            SettingsRightWing.transform.DOMoveZ(SettingsRightWing.transform.position.z + 0.77f, duration); //-9.12 -> -8.24
            SettingsIsClosed = false;
        }
        else
        {
            SettingsLeftWing.transform.DOComplete();
            SettingsRightWing.transform.DOComplete();
            SettingsLeftWing.transform.DOMoveZ(SettingsLeftWing.transform.position.z + 0.77f, duration); //-10.99 -> 10.12
            SettingsRightWing.transform.DOMoveZ(SettingsRightWing.transform.position.z - 0.77f, duration); //-8.24 -> -9.12
            SettingsIsClosed = true;
        }
    }

    public void MoveWingsShop()
    {
        if (ShopIsClosed)
        {
            ShopLeftWing.transform.DOComplete();
            ShopRightWing.transform.DOComplete();
            ShopLeftWing.transform.DOMoveZ(ShopLeftWing.transform.position.z - 0.77f, duration); //-10.12 -> 10.99
            ShopRightWing.transform.DOMoveZ(ShopRightWing.transform.position.z + 0.77f, duration); //-9.12 -> -8.24
            ShopIsClosed = false;
        }
        else
        {
            ShopLeftWing.transform.DOComplete();
            ShopRightWing.transform.DOComplete();
            ShopLeftWing.transform.DOMoveZ(ShopLeftWing.transform.position.z + 0.77f, duration); //-10.99 -> 10.12
            ShopRightWing.transform.DOMoveZ(ShopRightWing.transform.position.z - 0.77f, duration); //-8.24 -> -9.12
            ShopIsClosed = true;
        }
    }

    #endregion

    #region MusicControl
    public void MusicOnOff()
    {
        AudioManager.Instance.MuteUnmuteMusic();
        AudioManager.Instance.MuteUnmuteSFX();
    }
    #endregion

    public void Quit()
    {
        Application.Quit();
    }
}