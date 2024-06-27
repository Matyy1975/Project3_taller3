using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RestantMovement : MonoBehaviour
{
    public int Movimiento_restante = 3;
    public TextMesh Text_movimiento;
    public UnityEvent movimientos_acabados;
    
    void Start()
    {
        Text_movimiento.text = Movimiento_restante.ToString();
    }
  
    public void movimiento_menos()
    {
        Movimiento_restante -=1;
        actualizar_texto();
        if (Movimiento_restante <= 0)
        {
            movimientos_acabados.Invoke();
        }
    }
    public void actualizar_texto()
    {
        Text_movimiento.text = Movimiento_restante.ToString();
    }
}
