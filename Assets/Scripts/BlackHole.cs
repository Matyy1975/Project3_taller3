using UnityEngine;

public class BlackHole : MonoBehaviour
{
    // Ajusta la velocidad con la que el objeto se moverá hacia el centro
    public float attractionSpeed = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Iniciar la corrutina para mover el objeto al centro del agujero negro
        StartCoroutine(MoveToCenter(other.transform));
    }

    System.Collections.IEnumerator MoveToCenter(Transform obj)
    {
        // Mientras el objeto no esté en el centro exacto
        while (Vector2.Distance(obj.position, transform.position) > 0.1f)
        {
            // Mueve el objeto hacia el centro del agujero negro
            obj.position = Vector2.MoveTowards(obj.position, transform.position, attractionSpeed * Time.deltaTime);

            // Espera al siguiente frame
            yield return null;
        }

        // Asegura que el objeto esté exactamente en el centro al finalizar el movimiento
        obj.position = transform.position;
    }
}
