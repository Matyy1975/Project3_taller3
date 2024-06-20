using Cinemachine;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CameraShaker : MonoBehaviour
{
    public List<CinemachineVirtualCamera> virtualCameras;
    public float shakeDuration = 0.3f; // Duración de la vibración en segundos
    public float defaultShakeAmplitude = 1.2f; // Amplitud de la vibración predeterminada
    public float defaultShakeFrequency = 2.0f; // Frecuencia de la vibración predeterminada
    public float strongerShakeAmplitude = 2.0f; // Amplitud de la vibración más intensa
    public float strongerShakeFrequency = 3.0f; // Frecuencia de la vibración más intensa

    private List<CinemachineBasicMultiChannelPerlin> noises = new List<CinemachineBasicMultiChannelPerlin>();

    void Start()
    {
        // Asegúrate de tener al menos una virtual camera asignada
        if (virtualCameras == null || virtualCameras.Count == 0)
        {
            Debug.LogError("No Virtual Cameras assigned in CameraShaker.");
            return;
        }

        // Obtener los componentes de ruido de todas las cámaras
        foreach (var camera in virtualCameras)
        {
            var noise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            if (noise != null)
            {
                noises.Add(noise);
            }
        }
    }

    // Función para iniciar la vibración de las cámaras
    public void ShakeCameras()
    {
        Shake(defaultShakeAmplitude, defaultShakeFrequency);
    }

    // Función para iniciar una vibración más intensa de las cámaras
    public void ShakeCamerasStronger()
    {
        Shake(strongerShakeAmplitude, strongerShakeFrequency);
    }

    // Función para iniciar la vibración de las cámaras con una amplitud y frecuencia específicas
    private void Shake(float amplitude, float frequency)
    {
        foreach (var noise in noises)
        {
            if (noise != null)
            {
                // Configurar el ruido para que dure la duración especificada y tenga la amplitud y frecuencia dadas
                noise.m_AmplitudeGain = amplitude;
                noise.m_FrequencyGain = frequency;
            }
        }

        // Iniciar una corutina para detener la vibración después de la duración especificada
        StartCoroutine(StopShaking());
    }

    // Corutina para detener la vibración después de la duración especificada
    private IEnumerator StopShaking()
    {
        yield return new WaitForSeconds(shakeDuration);

        // Detener la vibración
        foreach (var noise in noises)
        {
            if (noise != null)
            {
                noise.m_AmplitudeGain = 0f;
                noise.m_FrequencyGain = 0f;
            }
        }
    }
}
