using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU_NAV : MonoBehaviour
{
    public void MAIN_GAME() {
        SceneManager.LoadScene("MAIN_LEVEL");
    }

    public void SETTINGS() {
        SceneManager.LoadScene("SETTINGS");
    }

    public void QUIT() {
        Application.Quit();
    }
}
