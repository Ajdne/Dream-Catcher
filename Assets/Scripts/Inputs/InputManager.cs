using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public bool InputType = true;
    public GameObject TapScript;
    public GameObject SwerveInput;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeInput()
    {
        if (InputType) 
        {
            TapScript.SetActive(true);
            SwerveInput.SetActive(false);
            InputType = false;
        }
        else 
        {
            SwerveInput.SetActive(true);
            TapScript.SetActive(false);
            InputType = true;
        }
    } 
}
