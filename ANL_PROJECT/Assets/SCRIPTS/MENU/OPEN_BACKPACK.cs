using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OPEN_BACKPACK : MonoBehaviour
{
    [SerializeField] Image backgroundImage;

    public void OpenBackpack() {
        if(backgroundImage.enabled) {
            backgroundImage.enabled = false;
        } else {
            backgroundImage.enabled = true;
        }
        
    }
}
