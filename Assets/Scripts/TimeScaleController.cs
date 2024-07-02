using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class TimeScaleController : MonoBehaviour
{
    // Variables para almacenar el timescale original y el estado de ralentización
   [SerializeField]private float originalTimeScale = 1f;
    private bool isTransitioning = false;

    // Factor de ralentización y duración de la transición
    public float slowDownFactor = 0.1f; // Ajusta este valor para cambiar la cantidad de ralentización
    public float transitionDuration = 1.0f; // Ajusta este valor para cambiar la duración de la transición

    public UnityEvent Tiempo_Ralentizado;
    public UnityEvent tiempo_normal;
    void Start()
    {
        // Guardar el timescale original al inicio
        originalTimeScale = Time.timeScale;
    }

    // Función pública para ralentizar el timescale con transición
    public void SlowDownTime()
    {
        if (!isTransitioning)
        {
            Tiempo_Ralentizado.Invoke();
            StartCoroutine(ChangeTimeScale(slowDownFactor));
        }
    }

    // Función pública para reanudar el timescale original con transición
    public void ResumeTime()
    {
        if (!isTransitioning)
        {
            tiempo_normal.Invoke();
            StartCoroutine(ChangeTimeScale(originalTimeScale));
        }
    }

    // Coroutine para cambiar el timescale con transición
    private IEnumerator ChangeTimeScale(float targetTimeScale)
    {
        isTransitioning = true;
        float start = Time.timeScale;
        float elapsed = 0f;

        while (elapsed < transitionDuration)
        {
            Time.timeScale = Mathf.Lerp(start, targetTimeScale, elapsed / transitionDuration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = targetTimeScale;
        isTransitioning = false;
    }
}
