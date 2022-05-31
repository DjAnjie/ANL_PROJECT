using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class SPRITE_CHANGER : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite hoverSprite;

    [SerializeField] Sprite openSprite;
    [SerializeField] Button button;

    [SerializeField] float minX,minY,minZ;
    [SerializeField] float midX,midY,midZ;
    [SerializeField] float maxX,maxY,maxZ;

    public int delay = 200;

    private bool isOpen = false;

    private string SceneName;

    void Start() {
        SceneName  = SceneManager.GetActiveScene().name;
    }

    public void OnPointerEnter(PointerEventData eventData) {

        if(!isOpen || SceneName == "MAIN_MENU") {
            button.image.sprite = hoverSprite;
        }
        
        
        button.transform.localScale = new Vector3(minX, minY, minZ);
        button.transform.localScale = new Vector3(midX, midY, midZ);
        button.transform.localScale = new Vector3(maxX, maxY, maxZ);
    }
    public void OnPointerExit(PointerEventData eventData) {
        if(!isOpen || SceneName == "MAIN_MENU")
        {
            button.image.sprite = normalSprite;
        }

        button.transform.localScale = new Vector3(maxX, maxY, maxZ);    
        button.transform.localScale = new Vector3(midX, midY, midZ);
        button.transform.localScale = new Vector3(minX, minY, minZ);

    }
    public void OnPointerClick(PointerEventData eventData) {
        if(isOpen && SceneName != "MAIN_MENU") {
            button.image.sprite = normalSprite;
            isOpen = false;
        } else if(!isOpen && SceneName != "MAIN_MENU") {
            button.image.sprite = openSprite;
            isOpen = true;
            button.transform.localScale = new Vector3(maxX, maxY, maxZ);
            button.transform.localScale = new Vector3(midX, midY, midZ);
            button.transform.localScale = new Vector3(minX, minY, minZ);
        }
    }
}
