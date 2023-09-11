using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Placeholder");
    }

    public void OnOptionsButtonClick()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}