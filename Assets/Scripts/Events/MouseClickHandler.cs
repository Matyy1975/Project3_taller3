using UnityEngine;
using UnityEngine.Events;

public class MouseClickHandler2D : MonoBehaviour
{
    public string[] targetTags; // Arreglo de tags específicos
    public UnityEvent onMouseClick;
    public UnityEvent onMouseRelease;
    public UnityEvent onMouseOverTarget;
    public UnityEvent onMouseExitTarget;

    private bool isClicked = false;
    private bool wasOverTarget = false;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        bool isOverTarget = hit.collider != null && HasTargetTag(hit.collider);

        if (Input.GetMouseButtonDown(0) && isOverTarget)
        {
            isClicked = true;
            onMouseClick.Invoke();
        }

        if (Input.GetMouseButtonUp(0) && isClicked)
        {
            isClicked = false;
            onMouseRelease.Invoke();
        }

        if (isOverTarget && !isClicked)
        {
            onMouseOverTarget.Invoke();
        }
        else if (wasOverTarget && !isClicked)
        {
            onMouseExitTarget.Invoke();
        }

        wasOverTarget = isOverTarget;
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
