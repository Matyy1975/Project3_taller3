using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    // Método para iniciar el juego
    public void PlayGame()
    {
        // Cambiar a la escena del juego
        SceneManager.LoadScene("GameScene");
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true); // Activar el menú de opciones
    }
    public void off_main_menu()
    {
        this.gameObject.SetActive(false);
    }


    public void on_Main_Menu()
    {
        this.gameObject.SetActive(true);
    }
    // Método para cerrar el menú de opciones
    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false); // Desactivar el menú de opciones
    }

    // Método para salir del juego
    public void QuitGame()
    {
        // Si estamos en el editor de Unity, detener el juego
        //UnityEditor.EditorApplication.isPlaying = false;
        // Si estamos en una compilación, salir de la aplicación
        Application.Quit();
    }

    // Método para salir del juego al presionar "Escape"
    void Update()
    {
        
    }
}
