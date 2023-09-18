using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _fadePanel;
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
        //TODO
    }
}