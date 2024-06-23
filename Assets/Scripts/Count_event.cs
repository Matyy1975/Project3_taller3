using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class Count_event : MonoBehaviour
{

    // Start is called before the first frame update
    public int Contador_Global;
    public int contador_Objetivo;
    public UnityEvent ACTIVAR_EVENTO;
    public TextMeshProUGUI Contador_texto;

    private void Start()
    {
        Contador_texto.text = Contador_Global.ToString() +"/" + contador_Objetivo.ToString();
    }
    public void Restar_Contador()
    {
        Contador_Global--;
        verificar_contador();
    }

    public void verificar_contador()
    {
        Contador_texto.text = Contador_Global.ToString() + "/" + contador_Objetivo.ToString();

        if (Contador_Global <= contador_Objetivo)
        {
            ACTIVAR_EVENTO.Invoke();
        }
    }
}
