using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject RulesWindow;
    public GameObject MenuWindow;

    public void SwapWindows()
    { 
        MenuWindow.SetActive(!MenuWindow.activeInHierarchy);
        RulesWindow.SetActive(!RulesWindow.activeInHierarchy);

    }
    public void Startgame()
    {
        SceneManager.LoadScene("Game");
    }
}
