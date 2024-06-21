using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class SceneController : MonoBehaviour
{
    public UnityEvent Al_Cambiar_escena;
    public UnityEvent Al_Reiniciar_escena;
    public float delayTime = 2f; // Tiempo de retraso en segundos

    public KeyCode BTN_restart = KeyCode.R;



    public void quitar_BTN()
    {
        BTN_restart = KeyCode.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown(BTN_restart))
        {
            RestartScene();
            BTN_restart = KeyCode.None;
        }
    }
    public void RestartScene()
    {
        // Obtener el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;
        Al_Reiniciar_escena.Invoke();
        // Iniciar la corutina para reiniciar la escena después del retraso
        StartCoroutine(RestartSceneWithDelay(currentSceneName));
        
    }

    public void ChangeScene(string sceneName)
    {
        // Iniciar la corutina para cambiar de escena después del retraso
        Al_Cambiar_escena.Invoke();
        StartCoroutine(ChangeSceneWithDelay(sceneName));
    }


    public void Salir()
    {
        // Salir del juego
        Application.Quit();
    }

    private IEnumerator RestartSceneWithDelay(string sceneName)
    {
        // Esperar el tiempo de retraso
        yield return new WaitForSeconds(delayTime);
        Time.timeScale = 1f;
        // Recargar la escena actual
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator ChangeSceneWithDelay(string sceneName)
    {
        // Esperar el tiempo de retraso
        yield return new WaitForSeconds(delayTime);

        // Cambiar a la nueva escena
        SceneManager.LoadScene(sceneName);
    }
}
