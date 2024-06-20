using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity_directional : MonoBehaviour
{
    public int Force;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("Derecha")]
    public void Right()
    {
        if (rb2D != null)
        {
            rb2D.AddForce(Vector2.right * Force, ForceMode2D.Impulse);
        }
        
    }
    [ContextMenu("Izquierda")]
    public void Left()
    {
        if (rb2D != null)
        {
            rb2D.AddForce(Vector2.left * Force, ForceMode2D.Impulse);
        }
    }
    [ContextMenu("Arriba")]
    public void Up()
    {
        if (rb2D != null)
        {
            rb2D.AddForce(Vector2.up * Force, ForceMode2D.Impulse);
        }
    }
    [ContextMenu("Abajo")]
    public void Down()
    {
        if (rb2D != null)
        {
            rb2D.AddForce(Vector2.down * Force, ForceMode2D.Impulse);
        }
    }

    public void Quieto()
    {
        rb2D.velocity = Vector2.zero;
        rb2D.angularVelocity = 0f;
    }
}
