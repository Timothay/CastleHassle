using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Throwable")
        {
            Application.Quit();
            
        }
        Debug.Log("Quit");
    }
}