using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproductorSFX : MonoBehaviour
{
    public Libreria_audio libreriaAudio;
    private AudioSource audioSource;

    void Start()
    {
        // Obtén el componente AudioSource adjunto a este GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirAudioAleatorio()
    {
        if (libreriaAudio != null && libreriaAudio.audioclips.Length > 0)
        {
            // Selecciona un índice aleatorio
            int indiceAleatorio = Random.Range(0, libreriaAudio.audioclips.Length);
            // Asigna el AudioClip al AudioSource y lo reproduce
            audioSource.clip = libreriaAudio.audioclips[indiceAleatorio];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("La librería de audio está vacía o no ha sido asignada.");
        }
    }
}
