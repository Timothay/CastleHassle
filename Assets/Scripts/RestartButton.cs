using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Throwable")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Restart : " + SceneManager.GetActiveScene().name);
        }
    }
}
