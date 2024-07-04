using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PART_SMASH : MonoBehaviour
{
    public string tag;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
