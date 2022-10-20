using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Throwable")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
