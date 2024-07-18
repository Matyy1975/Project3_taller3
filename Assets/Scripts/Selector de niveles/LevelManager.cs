using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Singleton instance
    public static LevelManager Instance { get; private set; }

    public bool[] levelsUnlocked;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste el objeto entre escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta
            return;
        }

        // Inicializa los niveles; el primer nivel est� desbloqueado por defecto
        //levelsUnlocked = new bool[7];
        levelsUnlocked[0] = true;

        // Cargar el progreso del jugador
        LoadProgress();
    }

    // M�todo para desbloquear un nivel espec�fico
    public void UnlockLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelsUnlocked.Length)
        {
            levelsUnlocked[levelIndex] = true;
            SaveProgress();
        }
    }

    // M�todo para desbloquear todos los niveles
    public void UnlockAllLevels()
    {
        for (int i = 0; i < levelsUnlocked.Length; i++)
        {
            levelsUnlocked[i] = true;
        }
        SaveProgress();
    }

    // M�todo para guardar el progreso del jugador
    private void SaveProgress()
    {
        for (int i = 0; i < levelsUnlocked.Length; i++)
        {
            PlayerPrefs.SetInt("Level" + i, levelsUnlocked[i] ? 1 : 0);
        }
    }

    // M�todo para cargar el progreso del jugador
    private void LoadProgress()
    {
        for (int i = 0; i < levelsUnlocked.Length; i++)
        {
            levelsUnlocked[i] = PlayerPrefs.GetInt("Level" + i, i == 0 ? 1 : 0) == 1;
        }
    }

    // M�todo para verificar si un nivel est� desbloqueado
    public bool IsLevelUnlocked(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelsUnlocked.Length)
        {
            return levelsUnlocked[levelIndex];
        }
        return false;
    }

    // M�todo para borrar todo el progreso de niveles (New Game)
    public void ResetProgress()
    {
        // Reinicia todos los niveles, bloqueando todos excepto el primero
        for (int i = 0; i < levelsUnlocked.Length; i++)
        {
            levelsUnlocked[i] = i == 0; // Solo el primer nivel est� desbloqueado inicialmente
        }

        SaveProgress(); // Guarda el nuevo estado de progreso
    }
}
