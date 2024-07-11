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
    public float transitionDuration = 1.0f; // Duración de la transición en segundos
    int index;

    private void Start()
    {
        Cambia_posicion();
        Imagen_siguiente_TP.transform.position = Posicion[(index + 1) % Posicion.Length].position;
    }

    // Start is called before the first frame update
    [ContextMenu("TEST FUNCION")]
    public void Cambia_posicion()
    {
        StartCoroutine(TransitionToNextPosition());
    }

    private IEnumerator TransitionToNextPosition()
    {
        Vector3 startPosition = AGUADOR.transform.position;
        Vector3 endPosition = Posicion[index % Posicion.Length].position;

        float elapsedTime = 0f;

        // Move Imagen_siguiente_TP instantly to the next position
        Imagen_siguiente_TP.transform.position = Posicion[(index + 1) % Posicion.Length].position;

        // Smoothly transition AGUADOR to the next position
        while (elapsedTime < transitionDuration)
        {
            AGUADOR.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        AGUADOR.transform.position = endPosition;

        CAMBIO_POSICION.Invoke();
        index++;
    }
}
