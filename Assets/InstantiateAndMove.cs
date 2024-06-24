using UnityEngine;
using System.Collections;

public class InstantiateAndMove : MonoBehaviour
{
    public GameObject prefab; // El prefab que quieres instanciar
    public Transform spawnPoint; // Punto de inicio
    public Transform targetPoint; // Punto destino
    public float speed = 5f; // Velocidad de movimiento
    public float minInterval = 2f; // Intervalo mínimo de tiempo para instanciar
    public float maxInterval = 5f; // Intervalo máximo de tiempo para instanciar

    private GameObject instantiatedObject;
    private bool isMoving = false;

    void Start()
    {
        StartCoroutine(InstantiateAtRandomIntervals());
    }

    void Update()
    {
        // Si el objeto se ha instanciado, moverlo hacia el punto destino
        if (isMoving && instantiatedObject != null)
        {
            MoveObject();
        }
    }

    IEnumerator InstantiateAtRandomIntervals()
    {
        while (true)
        {
            float interval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(interval);
            InstantiateObject();
        }
    }

    void InstantiateObject()
    {
        if (instantiatedObject == null)
        {
            instantiatedObject = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            isMoving = true;
        }
    }

    void MoveObject()
    {
        // Mover el objeto hacia el punto destino
        float step = speed * Time.deltaTime;
        instantiatedObject.transform.position = Vector3.MoveTowards(instantiatedObject.transform.position, targetPoint.position, step);


    }
}
