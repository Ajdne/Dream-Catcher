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
        Image slika = _fadePanel.GetComponent<Image>();
        slika.DOFade(0, 0); //plejsholder
        SceneManager.LoadScene("Gameplay");
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