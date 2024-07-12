using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElLaser : MonoBehaviour
{
    public Animator anim;
    public LineRenderer lr;
    public LayerMask layerObstaculo;
    [ContextMenu("Disparar")]
    public void Disparar()
    {
        anim.Play("disparar");

        RaycastHit2D hit2d = Physics2D.Raycast(transform.position, -transform.up, 100, layerObstaculo);
        if(hit2d.collider!= null)
        {
            lr.widthMultiplier = 1;
            Vector3 lugarDondeChoco = hit2d.point;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, lugarDondeChoco);

            if(hit2d.transform.GetComponent<SpawnerSimple>())
            {
                hit2d.transform.GetComponent<SpawnerSimple>().Spawnear();
                Destroy(hit2d.transform.gameObject);
                StartCoroutine(ApagarLaser(lugarDondeChoco, transform.position,1));
            }
        }

    }

    IEnumerator ApagarLaser(Vector3 desde, Vector3 hacia, float duracion)
    {
        float t = 0;
        while(t< duracion)
        {
            t+= Time.deltaTime;
            float p = t/duracion;
            lr.widthMultiplier = Mathf.Lerp(1,0,p);
            yield return null;
        }
    }
}
