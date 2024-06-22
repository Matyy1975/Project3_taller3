using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class AudioControl
{
    public string audioName; // Nombre identificador del AudioSource
    public AudioSource audioSource; // Referencia al AudioSource
    public Slider volumeSlider; // Referencia al slider para ajustar el volumen
    public Button increaseVolumeButton; // Botón para aumentar el volumen
    public Button decreaseVolumeButton; // Botón para disminuir el volumen
    public AudioClip volumeAdjustSound; // Sonido que se reproduce al ajustar el volumen
}

public class AudioManager : MonoBehaviour
{
    public List<AudioControl> audioControls = new List<AudioControl>(); // Lista de controles de audio
    public float fadeDuration = 1.0f; // Duración del fade in/out

    void Start()
    {
        // Configurar cada control de audio
        foreach (var audioControl in audioControls)
        {
            // Cargar el volumen guardado o establecer el valor predeterminado
            float savedVolume = PlayerPrefs.GetFloat(audioControl.audioName + "_Volume", audioControl.audioSource.volume);
            audioControl.volumeSlider.value = savedVolume;
            audioControl.audioSource.volume = savedVolume;

            // Agregar un listener al slider para guardar el volumen cuando cambie
            audioControl.volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(audioControl); });

            // Agregar listener para aumentar el volumen si el botón está presente
            if (audioControl.increaseVolumeButton != null)
            {
                audioControl.increaseVolumeButton.onClick.AddListener(delegate { IncreaseVolume(audioControl); });
            }

            // Agregar listener para disminuir el volumen si el botón está presente
            if (audioControl.decreaseVolumeButton != null)
            {
                audioControl.decreaseVolumeButton.onClick.AddListener(delegate { DecreaseVolume(audioControl); });
            }
        }
    }

    // Método para cambiar el volumen de un AudioSource
    public void ChangeVolume(AudioControl audioControl)
    {
        audioControl.audioSource.volume = audioControl.volumeSlider.value;
        PlayerPrefs.SetFloat(audioControl.audioName + "_Volume", audioControl.volumeSlider.value); // Guardar el volumen
    }

    // Método para aumentar el volumen de un AudioSource
    public void IncreaseVolume(AudioControl audioControl)
    {
        audioControl.volumeSlider.value = Mathf.Min(audioControl.volumeSlider.value + 0.1f, 1.0f);
        ChangeVolume(audioControl); // Guardar el volumen después de ajustarlo

        // Reproducir sonido de ajuste de volumen si está configurado
        if (audioControl.volumeAdjustSound != null)
        {
            audioControl.audioSource.PlayOneShot(audioControl.volumeAdjustSound);
        }
    }

    // Método para disminuir el volumen de un AudioSource
    public void DecreaseVolume(AudioControl audioControl)
    {
        audioControl.volumeSlider.value = Mathf.Max(audioControl.volumeSlider.value - 0.1f, 0.0f);
        ChangeVolume(audioControl); // Guardar el volumen después de ajustarlo

        // Reproducir sonido de ajuste de volumen si está configurado
        if (audioControl.volumeAdjustSound != null)
        {
            audioControl.audioSource.PlayOneShot(audioControl.volumeAdjustSound);
        }
    }

    // Nueva función para reproducir el sonido de ajuste de volumen
    public void PlayVolumeAdjustSound()
    {
        foreach (var audioControl in audioControls)
        {
            // Reproducir sonido de ajuste de volumen si está configurado
            if (audioControl.volumeAdjustSound != null)
            {
                audioControl.audioSource.PlayOneShot(audioControl.volumeAdjustSound);
            }
        }
    }

    // Función para hacer fade out
    public void FadeOut(AudioControl audioControl)
    {
        StartCoroutine(FadeOutCoroutine(audioControl));
    }

    // Coroutine para hacer fade out
    private IEnumerator FadeOutCoroutine(AudioControl audioControl)
    {
        float startVolume = audioControl.audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioControl.audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        audioControl.audioSource.volume = 0;
    }

    // Función para hacer fade in
    public void FadeIn(AudioControl audioControl)
    {
        StartCoroutine(FadeInCoroutine(audioControl));
    }

    // Coroutine para hacer fade in
    private IEnumerator FadeInCoroutine(AudioControl audioControl)
    {
        float startVolume = 0;
        float targetVolume = PlayerPrefs.GetFloat(audioControl.audioName + "_Volume", audioControl.audioSource.volume);

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioControl.audioSource.volume = Mathf.Lerp(startVolume, targetVolume, t / fadeDuration);
            yield return null;
        }

        audioControl.audioSource.volume = targetVolume;
    }

    // Función pública para hacer fade out sin parámetros
    public void FadeOut()
    {
        if (audioControls.Count > 0)
        {
            FadeOut(audioControls[0]); // Aplica el fade out al primer AudioControl en la lista
        }
    }

    // Función pública para hacer fade in sin parámetros
    public void FadeIn()
    {
        if (audioControls.Count > 0)
        {
            FadeIn(audioControls[0]); // Aplica el fade in al primer AudioControl en la lista
        }
    }
}
