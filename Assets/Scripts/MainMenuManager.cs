using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _fadePanel;

    [SerializeField] private Text MusicButtonText;
    public void Dream()
    {
        _fadePanel.SetActive(true);
        _fadePanel.transform.DOShakeScale(1.3f).OnComplete(() => SceneManager.LoadScene("Gameplay"));
    }

    public void ChangeInput()
    {
        //menja player pref za input
        //input menager cita koja je vrednost na pocetku
    }

    public void MusicOnOff()
    {
        AudioManager.Instance.MuteUnmuteMusic();
        AudioManager.Instance.MuteUnmuteSFX();

        if (AudioManager.Instance.musicSource.mute)
        {
            MusicButtonText.text = "Music OFF"; 
        }
        else
        {
            MusicButtonText.text = "Music ON";
        }
    }
}