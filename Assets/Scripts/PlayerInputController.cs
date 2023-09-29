using Assets.Scripts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Player PlayerInstance;
    private SwerveInput swerveInput;
    private void Awake()
    {
        swerveInput = PlayerInstance.GetComponent<SwerveInput>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Environment"))
        {
            Debug.Log(other.gameObject.name);
            StartCoroutine(DisableInput());
        }
    }
    IEnumerator DisableInput()
    {
        swerveInput.enabled = false;
        Debug.Log("Disabled Input");
        yield return new WaitForSecondsRealtime(1);
        swerveInput.enabled = true;
        Debug.Log("Enabled Input");
    }
}
