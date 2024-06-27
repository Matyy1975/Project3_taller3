using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LeftClickReleaseDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button targetButton; // El botón que queremos detectar
    public UnityEvent onLeftClickRelease; // El evento que queremos activar

    private bool isPointerOverButton = false;
    private bool wasPointerOverButton = false;

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // 0 es el botón izquierdo del mouse
        {
            if (wasPointerOverButton)
            {
                onLeftClickRelease.Invoke();
                wasPointerOverButton = false; // Para asegurarnos de que el evento solo se dispare una vez
            }
        }

        if (isPointerOverButton)
        {
            wasPointerOverButton = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter == targetButton.gameObject)
        {
            isPointerOverButton = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter == targetButton.gameObject)
        {
            isPointerOverButton = false;
        }
    }
}
