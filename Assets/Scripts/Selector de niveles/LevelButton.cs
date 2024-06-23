using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    private Button button;
    private LevelManager levelManager;

    private void Start()
    {
        button = GetComponent<Button>();
        levelManager = FindObjectOfType<LevelManager>();

        // Deshabilitar el botón si el nivel está bloqueado
        if (!levelManager.IsLevelUnlocked(levelIndex))
        {
            button.interactable = false;
        }
    }

    public void OnLevelButtonPressed()
    {
        // Aquí puedes cargar el nivel correspondiente
        // Por ejemplo: SceneManager.LoadScene("Level" + levelIndex);
    }
}
