using Assets.Scripts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public Button LeftButton;
    public Button RightButton;

    public bool InputType;
    public TapInput tapInput;
    public SwerveInput SwerveInput;
    public SwerveMovement SwerveMovement;

    private void Awake()
    {
        Instance = this;
    
    }
    private void Start()
    {
        InputType = false;
        tapInput = Player.Instance.GetComponent<TapInput>();
        SwerveInput = Player.Instance.GetComponent<SwerveInput>();
        SwerveMovement = Player.Instance.GetComponent<SwerveMovement>();
    }
    public void ChangeInput()
    {
        if (InputType) 
        {
            Debug.Log("Tap Input");
            tapInput.enabled = true;
            SwerveInput.enabled = false;
            SwerveMovement.enabled = false;

            LeftButton.gameObject.SetActive(true);
            RightButton.gameObject.SetActive(true);
            InputType = false;
        }
        else 
        {
            Debug.Log("Swerve Input");
            tapInput.enabled = false;
            SwerveInput.enabled = true;
            SwerveMovement.enabled = true;

            LeftButton.gameObject.SetActive(false);
            RightButton.gameObject.SetActive(false);
            InputType = true;
        }
    } 
}
