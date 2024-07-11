using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suitch : MonoBehaviour
{
    public GameObject[] ObjSwitch;
    [SerializeField] bool activado = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Active_switch()
    {
        if (!activado)
        {
            for (int i = 0; i < ObjSwitch.Length; i++)
            {
                ObjSwitch[i].SetActive(true);
                activado = true;
            }
        }
        else
        {
            for (int i = 0; i < ObjSwitch.Length; i++)
            {
                ObjSwitch[i].SetActive(false);
                activado = false;
            }
        }
    }
}
