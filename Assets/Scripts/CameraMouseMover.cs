using UnityEngine;

public class CameraMouseMover : MonoBehaviour
{
    public float moveAmount = 0.1f; // Cantidad de movimiento de la cámara en función del movimiento del mouse
    private Vector3 initialPosition;

    void Start()
    {
        // Guardar la posición inicial de la cámara
        initialPosition = transform.position;
    }

    void Update()
    {
        // Obtener la posición del mouse
        float mouseX = Input.mousePosition.x / Screen.width - 0.5f;
        float mouseY = Input.mousePosition.y / Screen.height - 0.5f;

        // Calcular la nueva posición de la cámara en función del movimiento del mouse
        Vector3 newPosition = initialPosition + new Vector3(mouseX * moveAmount, mouseY * moveAmount, 0);

        // Mover la cámara a la nueva posición
        transform.position = newPosition;
    }
}
