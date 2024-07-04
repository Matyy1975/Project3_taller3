using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambio_switch_mario : MonoBehaviour
{
    public GameObject[] PATRON;
    // Start is called before the first frame update
    [ContextMenu("ACTIVAR PATRON")]
    public void ACTIVAR_PATRON()
    {
        for (int i = 0; i < PATRON.Length; i++)
        {
            PATRON[i].SetActive(true);
        }    
    }
    [ContextMenu("DESACTIVAR PATRON")]
    public void DESACTIVAR_PATRON()
    {
        for (int i = 0; i < PATRON.Length; i++)
        {
            PATRON[i].SetActive(false);
        }
    }
}
