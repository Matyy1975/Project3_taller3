using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Event_start : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent AL_COMENZAR_ESCENA;
    void Start()
    {
        AL_COMENZAR_ESCENA.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
