using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("Juego");
    }

public void GoToMenu()
{
    Time.timeScale = 1f; // Reanuda el tiempo [cite: 2026-03-03]
    
    // Si el GameManager existe, lo borramos para que al volver a jugar 
    // se cree uno nuevo con 3 vidas y 0 puntos [cite: 2026-03-03]
    if (GameManager.instance != null) 
    {
        Destroy(GameManager.instance.gameObject); 
    }
    
    UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
}
}


