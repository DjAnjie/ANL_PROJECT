using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Object_Click : MonoBehaviour
{
    [SerializeField] Text popupText,holdingItem;
    [SerializeField] Button gBush,gBottle;

    [SerializeField] public Sprite rockSprite,glassSprite,mapBottle;
    [SerializeField] public Sprite mapSprite;

    private string holding = "";

    public bool isBottleDestroyed = false;

    public static string[] inventory = new string[3];

    [SerializeField] Button ButtonOne, ButtonTwo,ButtonThree,backpackButton;


    [SerializeField] Image backgroundImage;

    void Start() {
        ButtonOne.gameObject.SetActive(false);
        ButtonTwo.gameObject.SetActive(false);
        ButtonThree.gameObject.SetActive(false);
    }

    public void OpenBackpack()
    {
        if (backgroundImage.enabled)
        {
            backgroundImage.enabled = false;
            ButtonThree.gameObject.SetActive(false);
            if (inventory[0] != null)
            {
                ButtonOne.gameObject.SetActive(false);
            }
            if (inventory[1] != null)
            {
                ButtonTwo.gameObject.SetActive(false);
            }
        }
        else
        {
            backgroundImage.enabled = true;
            ButtonThree.gameObject.SetActive(true);
            if(inventory[0] != null) {
                ButtonOne.gameObject.SetActive(true);
                ButtonOne.gameObject.SetActive(true);
            }
            if (inventory[1] != null) {
                ButtonTwo.gameObject.SetActive(true);
            } 
            
        }

    }
    public void bushClicked() {
            gBush.gameObject.SetActive(false);
            if(popupText.enabled) {
                popupText.text = "<color=#ffff00ff>Item Found: Rock</color>";
            } else {
                popupText.enabled = true;
                popupText.text = "<color=#ffff00ff>Item Found: Rock</color>";
            }
            if(inventory[0] != "Rock")  {
                ButtonOne.gameObject.name = inventory[0];
            }
            StartCoroutine(removeText("Rock"));
            }

    IEnumerator removeText(string item) {
        if(item == "Unhold your item to pick up the map") {
            popupText.text = "<color=#ffff00ff>Unhold your item to pick up the map</color>";
        }
        if(inventory[0] == null) {
            inventory[0] = item;
            ButtonOne.gameObject.name = inventory[0];
            if(ButtonOne.gameObject.name == item) {
                ButtonOne.image.sprite =  rockSprite;
            } else {
                ButtonOne.image.sprite = glassSprite;
            }
        } else if(inventory[1] == null) {
            inventory[1] = item;
            ButtonTwo.gameObject.name = inventory[1];
            if (ButtonTwo.gameObject.name == item)
            {
                ButtonTwo.image.sprite = glassSprite;
            }
            else
            {
                ButtonTwo.image.sprite = rockSprite;
            }
        } else if(inventory[2] == null) {
            inventory[2] = item;
        }
        yield return new WaitForSecondsRealtime(2);
        popupText.enabled = false;
    }

    IEnumerator removeTextTwo() {
        popupText.enabled = true;
        popupText.text = "<color=#ffff00ff>You need to be holding the rock to smash the bottles</color>";
        yield return new WaitForSecondsRealtime(2);
        popupText.enabled = false;
    }

    public void Inventory() {
        string name = EventSystem.current.currentSelectedGameObject.name;
        if(inventory[0] != null && name == inventory[0]) {
            ButtonOne.gameObject.SetActive(false);
            holding = inventory[0];
        } else if (inventory[1] != null && name == inventory[1]) {
            ButtonTwo.gameObject.SetActive(false);
            holding = inventory[1];
        }
    }

    void Update() {
        if(holding == "") {
            holdingItem.text = "<color=#ffff00ff>Currently Holding: Nothing</color>";
            if(!backgroundImage.enabled) {
                ButtonOne.gameObject.SetActive(false);
                ButtonTwo.gameObject.SetActive(false);
            } else {
                if(inventory[0] != null) {
                    ButtonOne.gameObject.SetActive(true);
                }
                if(inventory[1] != null) {
                    ButtonTwo.gameObject.SetActive(true);
                }
            }

        } else if(holding == "Rock"){ 
            holdingItem.text = "<color=#ffff00ff>Currently Holding: Rock</color>";
            if (inventory[1] != null && backgroundImage.enabled)
            {
                ButtonTwo.gameObject.SetActive(true);
            }
        } else if (holding == "Glass") {
            holdingItem.text = "<color=#ffff00ff>Currently Holding: Glass</color>";
            if (inventory[0] != null && backgroundImage.enabled)
            {
                ButtonOne.gameObject.SetActive(true);
            }
        }
    }
    public void DestroyBottle() {
        if(holding != "Rock") {
            if(gBottle.image.sprite.name != "Map") {
                StartCoroutine("removeTextTwo");
            }
        } else if(holding == "Rock" && !isBottleDestroyed) {
            popupText.enabled=true;
            isBottleDestroyed = true;
            popupText.text = "<color=#ffff00ff>Item Found: Glass</color>";
            if(inventory[0] != null) {
                if (inventory[1] == null) {
                    ButtonTwo.gameObject.name = inventory[1];
                } else {
                    ButtonTwo.gameObject.name = inventory[2];
                }
            } 
            StartCoroutine(removeText("Glass"));
            gBottle.image.sprite = mapSprite;
        }

        if (holding == "" && gBottle.image.sprite == mapSprite)
        {
            Debug.Log("You Win");
            gBottle.image.enabled = false;
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i] = null;
            }

            SceneManager.LoadScene("MAIN_MENU");
        }
        else if (holding != "" && gBottle.image.sprite== mapSprite)
        {
            popupText.enabled = true;
            StartCoroutine(removeText("Unhold your item to pick up the map"));
        }
    }

    public void clearItemHolding() {
        if(holding == "Rock") {
            if(inventory[0] == holding) {
                ButtonOne.gameObject.SetActive(true);
            } else if (inventory[1]== holding) {
                ButtonTwo.gameObject.SetActive(true);
            }

        } else if (holding == "Glass") {
            if (inventory[0] == holding)
            {
                ButtonOne.gameObject.SetActive(true);
            }
            else if (inventory[1] == holding)
            {
                ButtonTwo.gameObject.SetActive(true);
        }
    }
        holding = "";
    }
}
