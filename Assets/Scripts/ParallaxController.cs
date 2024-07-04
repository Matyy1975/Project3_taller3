using UnityEngine;
using UnityEngine.UI;

public class ParallaxController : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public RawImage layer;
        public float speed = 1.0f;
        public bool freezeWidth = false;
        public bool freezeHeight = false;
        public bool constantMovement = false;
        [Header("VELOCIDAD CONSTANTE")]
        [Range(0, 4)]public float constantSpeed = 1.0f;
        [Range(0f, 1f)]public float MovementInterval = 0f; // Intervalo en segundos para detener el movimiento constante
        private float timeElapsed = 0.0f; // Tiempo transcurrido desde el último cambio de dirección

        public void ResetTimer()
        {
            timeElapsed = 0.0f;
        }

        public void UpdateTimer(float deltaTime)
        {
            timeElapsed += deltaTime;
        }

        public bool ShouldMoveConstantly()
        {
            return timeElapsed >= MovementInterval;
        }
    }

    public ParallaxLayer[] parallaxLayers;

    Vector3 cameraPreviousPosition;

    void Start()
    {
        cameraPreviousPosition = Camera.main.transform.position;
    }

    void Update()
    {
        Vector3 cameraDelta = Camera.main.transform.position - cameraPreviousPosition;

        foreach (var layer in parallaxLayers)
        {
            if (layer.constantMovement)
            {
                if (!layer.ShouldMoveConstantly())
                {
                    layer.UpdateTimer(Time.deltaTime);
                    continue;
                }

                ConstantParallaxMovement(layer.layer, layer.constantSpeed);
                layer.ResetTimer();
            }
            else
            {
                UpdateParallaxLayer(layer.layer, cameraDelta, layer.speed, layer.freezeWidth, layer.freezeHeight);
            }
        }

        cameraPreviousPosition = Camera.main.transform.position;
    }

    void UpdateParallaxLayer(RawImage layer, Vector3 cameraDelta, float parallaxSpeed, bool freezeWidth, bool freezeHeight)
    {
        Rect uvRect = layer.uvRect;

        if (!freezeWidth)
        {
            uvRect.x += cameraDelta.x * parallaxSpeed * Time.deltaTime;
        }
        if (!freezeHeight)
        {
            uvRect.y += cameraDelta.y * parallaxSpeed * Time.deltaTime;
        }

        layer.uvRect = uvRect;
    }

    void ConstantParallaxMovement(RawImage layer, float constantSpeed)
    {
        Rect uvRect = layer.uvRect;

        uvRect.x += constantSpeed * Time.deltaTime;

        layer.uvRect = uvRect;
    }
}
