using UnityEngine;

public class SpawnerCollision : MonoBehaviour
{
    public string targetTag;
    public GameObject objectToInstantiate; // El objeto que quieres instanciar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisión es con el objeto deseado
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Obtiene el punto de colisión
            ContactPoint2D contact = collision.contacts[0];
            Vector2 collisionPoint = contact.point;

            // Instancia el objeto en el punto de colisión
            Instantiate(objectToInstantiate, collisionPoint, Quaternion.identity);
        }
    }
   
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que activó el trigger tiene la etiqueta deseada
        if (other.CompareTag(targetTag))
        {
            // Obtiene el punto de colisión (punto de contacto del trigger)
            Vector2 collisionPoint = other.transform.position;

            // Instancia el objeto en el punto de colisión
            Instantiate(objectToInstantiate, collisionPoint, Quaternion.identity);
        }
    }
    */
    public void SpawnCollision()
    {
        // Este método puede ser usado si deseas instanciar el objeto desde otro lugar
        // por ejemplo, desde un UnityEvent.
        if (objectToInstantiate != null)
        {
            // Suponiendo que quieres instanciar el objeto en la posición actual del SpawnerCollision
            Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("El objeto a instanciar no está asignado.");
        }
    }
}
