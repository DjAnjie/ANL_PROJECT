using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SPRITE_CHANGER : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite hoverSprite;
    [SerializeField] Button button;

    [SerializeField] float minX,minY,minZ;
    [SerializeField] float midX,midY,midZ;
    [SerializeField] float maxX,maxY,maxZ;

    public int delay = 200;

    public void OnPointerEnter(PointerEventData eventData) {
        button.image.sprite = hoverSprite;
        
        button.transform.localScale = new Vector3(minX, minY, minZ);
        button.transform.localScale = new Vector3(midX, midY, midZ);
        button.transform.localScale = new Vector3(maxX, maxY, maxZ);
    }
    public void OnPointerExit(PointerEventData eventData) {
        button.image.sprite = normalSprite;

        button.transform.localScale = new Vector3(maxX, maxY, maxZ);    
        button.transform.localScale = new Vector3(midX, midY, midZ);
        button.transform.localScale = new Vector3(minX, minY, minZ);

    }
}
