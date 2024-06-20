using UnityEngine;
using UnityEngine.Events;

public class TaggedObjectInteraction : MonoBehaviour
{
    public string targetTag = "YourTag"; // Tag específico que deseas detectar
    public UnityEvent onActivation; // Evento que se activará

    void Update()
    {
        // Verificar si se hizo clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag(targetTag))
                {
                    // Activar el evento
                    onActivation.Invoke();
                }
            }
        }
    }
}
