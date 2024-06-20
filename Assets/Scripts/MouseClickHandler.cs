using UnityEngine;
using UnityEngine.Events;

public class MouseClickHandler2D : MonoBehaviour
{
    public string[] targetTags; // Arreglo de tags específicos
    public UnityEvent onMouseClick;
    public UnityEvent onMouseRelease;

    private bool isClicked = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPos, Vector2.zero);

            if (hit.collider != null && HasTargetTag(hit.collider))
            {
                isClicked = true;
                onMouseClick.Invoke();
            }
        }

        if (Input.GetMouseButtonUp(0) && isClicked)
        {
            isClicked = false;
            onMouseRelease.Invoke();
        }
    }

    bool HasTargetTag(Collider2D collider)
    {
        foreach (string tag in targetTags)
        {
            if (collider.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }
}
