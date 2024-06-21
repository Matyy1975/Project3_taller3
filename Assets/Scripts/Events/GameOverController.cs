using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public UnityEvent Al_Reiniciar_Level;
    public float delayTime = 2f; // Tiempo de retraso en segundos

    public void RestartLevel()
    {
        // Obtener el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;
        Al_Reiniciar_Level.Invoke();
        // Iniciar la corutina para reiniciar la escena después del retraso
        StartCoroutine(RestartLevelWithDelay(currentSceneName));

    }

    private IEnumerator RestartLevelWithDelay(string sceneName)
    {
        // Esperar el tiempo de retraso
        yield return new WaitForSeconds(delayTime);
        Time.timeScale = 1f;
        // Recargar la escena actual
        SceneManager.LoadScene(sceneName);
    }
}
