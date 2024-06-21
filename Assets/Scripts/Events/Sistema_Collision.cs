using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sistema_Collision : MonoBehaviour
{
    public string tag;
    public UnityEvent onCollisionEnter2D, onCollisionStay2D, onCollisionExit2D;

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.CompareTag(tag))
            {
                onCollisionEnter2D.Invoke();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            onCollisionStay2D.Invoke();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            onCollisionExit2D.Invoke();
        }
    }

   
}
