using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Método para cargar la escena del menú principal
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("menu"); 
    }
}
