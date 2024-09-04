using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Temporizador : MonoBehaviour
{
    [Tooltip("Tiempo en segundos para el temporizador")]
    public float tiempoEnSegundos = 10f;
    [Tooltip("Evento que se activa cuando el temporizador llega a 0")]
    public UnityEvent onTiempoCompleto;

    private float tiempoRestante;
    [SerializeField] private bool temporizadorActivo;

    void Start()
    {
        // Inicializa el temporizador
        tiempoRestante = tiempoEnSegundos;
        //temporizadorActivo = true;
    }

    void Update()
    {
        if (temporizadorActivo)
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante <= 0)
            {
                temporizadorActivo = false;
                tiempoRestante = 0;
                onTiempoCompleto.Invoke(); // Llama al evento cuando el tiempo se complete
            }
        }
    }

    public void IniciarTemporizador()
    {
        tiempoRestante = tiempoEnSegundos;
        temporizadorActivo = true;
    }

    public void DetenerTemporizador()
    {
        temporizadorActivo = false;
    }

    public void ReiniciarTemporizador()
    {
        tiempoRestante = tiempoEnSegundos;
        temporizadorActivo = true;
    }

    public float ObtenerTiempoRestante()
    {
        return tiempoRestante;
    }

    public bool EstaActivo()
    {
        return temporizadorActivo;
    }
}
