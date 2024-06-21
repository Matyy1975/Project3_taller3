using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Count_event : MonoBehaviour
{
    // Start is called before the first frame update
    public int Contador_Global;
    public UnityEvent ACTIVAR_EVENTO;


    public void Restar_Contador()
    {
        Contador_Global--;
        verificar_contador();
    }

    public void verificar_contador()
    {
        if (Contador_Global == 0)
        {
            ACTIVAR_EVENTO.Invoke();
        }
    }
}
