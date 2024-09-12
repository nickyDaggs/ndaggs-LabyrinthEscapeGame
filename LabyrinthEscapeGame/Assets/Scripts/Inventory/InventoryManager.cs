using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public InventoryItem[] inventory = new InventoryItem[9];
    int inventoryLim = 9;
    int curIndex = 0;
    public Transform inventoryParent;
    public int selectedItem = 0;
    public RectTransform pointer;
    public float[] pointerLocations = new float[9];
    public Sprite transparent;

    private void Update()
    {
        if(Input.mouseScrollDelta.y > 0f)
        {
            if(selectedItem >= 8)
            {
                selectedItem = 0;
            } else
            {
                selectedItem++;
            }
            pointer.anchoredPosition = new Vector2(pointerLocations[selectedItem], pointer.anchoredPosition.y);

            //Debug.Log(selectedItem);
        }
        else if(Input.mouseScrollDelta.y < 0f)
        {
            if (selectedItem <= 0)
            {
                selectedItem = 8;
            }
            else
            {
                selectedItem--;
            }

            pointer.anchoredPosition = new Vector2(pointerLocations[selectedItem], pointer.anchoredPosition.y);
            //Debug.Log(selectedItem);
        }

    }

    // Update is called once per frame
    public void UpdateUI()
    {
        for(int i = 0; i < inventoryLim; i++)
        {
            if(inventory[i] != null)
            {
                inventoryParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = inventory[i].itemSprite;

            }
            else
            {
                inventoryParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparent;
                if(curIndex > i)
                {
                    curIndex = i;
                }
            }
        }
    }

    public void AddItem(InventoryItem item)
    {
        int realIndex = 0;
        for (int i = 0; i < inventoryLim; i++)
        {
            if (inventory[i] != null && i == realIndex)
            {
                realIndex++;
            }
            
        }
        if (curIndex < inventoryLim)
        {
            inventory.SetValue(item, realIndex);
            UpdateUI();
            //curIndex++;
        }
    }
}
