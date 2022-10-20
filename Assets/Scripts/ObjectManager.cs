using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Rigidbody rb;
  private void OnCollisionEnter(Collision collision)
  {
    
    if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Default" || collision.gameObject.tag == "Untagged")
    {
      Invoke("ChangeTag", 1f);
      Invoke("DestroyObject", 10f);
      SoundManager.soundManager.PlayHurtSound();
    }
    if(collision.gameObject.tag == "LeftHand" || collision.gameObject.tag == "RightHand")
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
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