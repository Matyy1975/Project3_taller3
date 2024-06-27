using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    private LevelManager levelManager;
    public int currentLevelIndex;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void OnLevelCompleted()
    {
        // Desbloquear el siguiente nivel
        levelManager.UnlockLevel(currentLevelIndex + 1);

        // Aquí puedes añadir lógica adicional como cargar una pantalla de victoria
    }
}
