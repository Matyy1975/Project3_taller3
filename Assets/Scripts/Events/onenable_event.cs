using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class onenable_event : MonoBehaviour
{
    public UnityEvent AL_ACTIVAR_GAMEOBJECT;

    private void OnEnable()
    {
        AL_ACTIVAR_GAMEOBJECT.Invoke();
    }
}
