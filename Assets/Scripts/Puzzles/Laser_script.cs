using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Laser_script : MonoBehaviour
{
    public int Entro;
    public UnityEvent AL_ENTRAR_X_PRIMERA_VEZ;
    public UnityEvent EJECUCION_NORMAL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void accion()
    {
        if (Entro == 0)
        {
            AL_ENTRAR_X_PRIMERA_VEZ.Invoke();
            Entro++;
        }
        else if (Entro > 0)
        {
            EJECUCION_NORMAL.Invoke();
            Entro++;
        }
    }

}
