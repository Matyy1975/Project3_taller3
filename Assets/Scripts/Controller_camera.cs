using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Controller_camera : MonoBehaviour
{
    public GameObject camara;

    private CinemachineVirtualCamera vcam;

    void Start()
    {
        // Obtener el componente CinemachineVirtualCamera de la cámara
        vcam = camara.GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Activar la cámara y establecer su prioridad
           // camara.SetActive(true);
            vcam.Priority = 10; // Prioridad alta (cualquier número mayor que otras cámaras activas)
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Desactivar la cámara
            //camara.SetActive(false);
            vcam.Priority = 0; // Restablecer la prioridad a su valor predeterminado
        }
    }
}
