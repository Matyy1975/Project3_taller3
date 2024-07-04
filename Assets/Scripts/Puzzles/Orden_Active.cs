using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Orden_Active : MonoBehaviour
{
    [Header("PARA SABER DONDE SE VA A SPAWNEAR")]
    public GameObject Imagen_siguiente_TP;
    [Header("PARA EL TP DEL AGUADOR")]
    public UnityEvent CAMBIO_POSICION;
    public GameObject AGUADOR;
    public Transform[] Posicion;
    int index;
    int indexDespues;

    private void Start()
    {
        
        Cambia_posicion();
        Imagen_siguiente_TP.transform.position = Posicion[index].position;
    }
    // Start is called before the first frame update
    [ContextMenu("TEST FUNCION")]
    public void Cambia_posicion()
    {

        /*
        if (index >= Posicion.Length)
        {
            index = 0;
            Imagen_siguiente_TP.transform.position = Posicion[index].position;
            //CAMBIA LE POSICION DEL AGUADOR AL SIGUIENTE TRANSFORM DE LA LISTA AL PRINCIPIO
            AGUADOR.transform.position = Posicion[index].position;
            CAMBIO_POSICION.Invoke();

        }
        */

        //Imagen_siguiente_TP.transform.position = Posicion[index%Posicion.Length].position;
       // AGUADOR.transform.position = Posicion[index % Posicion.Length].position;


        //CAMBIA LA 
        Imagen_siguiente_TP.transform.position = Posicion[(index + 1)% Posicion.Length].position;
        AGUADOR.transform.position = Posicion[index % Posicion.Length].position;
        CAMBIO_POSICION.Invoke();
        index++;
    }
}
