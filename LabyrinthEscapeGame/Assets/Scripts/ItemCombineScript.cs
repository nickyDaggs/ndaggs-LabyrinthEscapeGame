using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCombineScript : MonoBehaviour
{
    public InventoryItem correct;
    public InventoryItem newItem;

    public bool incorrectResult;
    public string keyword;
    public InventoryItem wrongItem;

    public Animator anim;
    public bool trigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Check(int item, InventoryManager manager)
    {
        if(manager.inventory[item] == correct)
        {
            manager.inventory[item] = newItem;
            if(trigger)
            {
                anim.SetTrigger("Next");
            }
        } else
        {
            if(incorrectResult && manager.inventory[item].itemName.Contains(keyword))
            {
                manager.inventory[item] = wrongItem;
            }
        }
    }

    public void animate()
    {
        
    }
}
