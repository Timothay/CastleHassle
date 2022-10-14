using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Default")
    {
      Invoke("ChangeTag", 1f);
      Invoke("DestroyObject", 10f);
    }
  }

  private void ChangeTag()
  {
    gameObject.tag = "Default";
  }

  private void DestroyObject()
  {
    Destroy(this.gameObject);
  }
}