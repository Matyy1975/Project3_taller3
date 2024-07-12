using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzar : MonoBehaviour
{
    public Animator laser_animator;
    public GameObject Chilldren;
    int id_switch;
    // Start is called before the first frame update
    void Start()
    {
        laser_animator = GetComponent<Animator>();
    }

    public void Activar_laser()
    {
        Chilldren.SetActive(true);
        laser_animator.Play("LASER_ACTIVE");
    }

    public void desactivar_laser()
    {
        laser_animator.StopPlayback(); // Detener la animación
        laser_animator.Play("Idle");   // Reproducir la animación de inicio (Idle)
        Chilldren.SetActive(false);
    }

    public void switch_laser()
    {
        if (id_switch == 0)
        {
            Activar_laser();
            id_switch = 1;
        }
        if (id_switch == 1)
        {
            desactivar_laser();
            id_switch = 0;
        }
    }
}
