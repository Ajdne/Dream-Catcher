using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instace;
    private void Awake()
    {
        Instace = this;
    }
    [SerializeField] private GameObject _fadePanel;

    [SerializeField] private Text MusicButtonText;
    public void Dream()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void MusicOnOff()
    {
        AudioManager.Instance.MuteUnmuteMusic();
        AudioManager.Instance.MuteUnmuteSFX();

        if (AudioManager.Instance.musicSource.mute)
        {
            MusicButtonText.text = "OFF"; 
        }
        else
        {
            MusicButtonText.text = "ON";
        }
    }
    private void Start()
    {
        SettingsIsClosed = true;
        ShopIsClosed = true;
        duration = 5;
    }
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

    public void Quit()
    {
        Application.Quit();
    }
}