using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MENU_NAV : MonoBehaviour
{
    [SerializeField] Canvas settings;
    [SerializeField] Canvas mainMenu;

    [SerializeField] Canvas MainGameUI;

    public void MAIN_GAME() {
        SceneManager.LoadScene("MAIN_LEVEL");
    }

    public void SETTINGS() {
        if (settings.enabled)
        {
            settings.enabled = false;
            mainMenu.enabled = true;
        }
        else
        {
            settings.enabled = true;
            mainMenu.enabled = false;
        }
    }


    public void QUIT() {
        Application.Quit();
    }

    public void PAUSE() {
        if(Time.timeScale == 1f) {
            Time.timeScale = 0f;
            MainGameUI.enabled = false;
            MainGameUI.gameObject.SetActive(false);
            mainMenu.enabled = true;
            AudioListener.pause = true;
        } else {
            Time.timeScale = 1f ;
            AudioListener.pause = false;
            MainGameUI.enabled = true;
            MainGameUI.gameObject.SetActive(true);
            mainMenu.enabled = false;
        }
    }
}
