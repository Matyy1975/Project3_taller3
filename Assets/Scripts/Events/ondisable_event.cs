using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ondisable_event : MonoBehaviour
{
    public UnityEvent AL_DESACTIVAR_OBJETO;
    private void OnDisable()
    {
        AL_DESACTIVAR_OBJETO.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
