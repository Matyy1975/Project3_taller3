using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    public UnityEvent Al_Completar_Nivel; // Evento que se invoca al completar el nivel
    public float delayTime = 2f; // Tiempo de retraso en segundos

    // Método para completar el nivel y cambiar de escena
    public void CompleteLevel(string nextSceneName)
    {
        // Invocar el evento Al_Completar_Nivel
        Al_Completar_Nivel.Invoke();
        // Iniciar la corutina para cambiar la escena después del retraso
        StartCoroutine(ChangeSceneWithDelay(nextSceneName));
    }

    private IEnumerator ChangeSceneWithDelay(string sceneName)
    {
        // Esperar el tiempo de retraso
        yield return new WaitForSeconds(delayTime);
        // Cambiar a la siguiente escena
        SceneManager.LoadScene(sceneName);
    }
}
