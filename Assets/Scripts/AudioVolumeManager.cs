using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioVolumeManager : MonoBehaviour
{
    public List<AudioSource> audioSources; // Asignar manualmente en el Inspector
    private Dictionary<AudioSource, float> originalVolumes = new Dictionary<AudioSource, float>();
    public float volumeChangeSpeed = 0.5f; // Velocidad de cambio de volumen

    void Start()
    {
        // Guardar los volúmenes originales
        foreach (AudioSource source in audioSources)
        {
            float volume = source.volume;
            originalVolumes[source] = volume;
            PlayerPrefs.SetFloat(source.gameObject.name + "_volume", volume); // Guardar en PlayerPrefs
        }
    }

    public void ReduceVolume()
    {
        StopAllCoroutines(); // Detener cualquier ajuste de volumen en curso
        StartCoroutine(ChangeVolume(0f)); // Reducir volumen a 0
    }

    public void RestoreVolume()
    {
        StopAllCoroutines(); // Detener cualquier ajuste de volumen en curso
        StartCoroutine(RestoreOriginalVolumes()); // Restaurar volúmenes originales
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        bool volumeAdjusted = false;

        while (!volumeAdjusted)
        {
            volumeAdjusted = true;
            foreach (AudioSource source in audioSources)
            {
                if (source.volume != targetVolume)
                {
                    volumeAdjusted = false;
                    source.volume = Mathf.MoveTowards(source.volume, targetVolume, volumeChangeSpeed * Time.deltaTime);
                }
            }
            yield return null;
        }
    }

    private IEnumerator RestoreOriginalVolumes()
    {
        bool volumeAdjusted = false;

        while (!volumeAdjusted)
        {
            volumeAdjusted = true;
            foreach (AudioSource source in audioSources)
            {
                float originalVolume = PlayerPrefs.GetFloat(source.gameObject.name + "_volume", originalVolumes[source]);
                if (source.volume != originalVolume)
                {
                    volumeAdjusted = false;
                    source.volume = Mathf.MoveTowards(source.volume, originalVolume, volumeChangeSpeed * Time.deltaTime);
                }
            }
            yield return null;
        }
    }
}
