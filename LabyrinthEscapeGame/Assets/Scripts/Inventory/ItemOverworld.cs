using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemOverworld : MonoBehaviour
{
    public InventoryItem itemToGive;
    public Animator textAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TextUpdate()
    {
        textAnimator.GetComponent<TextMeshProUGUI>().text = "Obtained: " + itemToGive.itemName + "\n" + itemToGive.itemDescription;
        if(textAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Idle"))
        {
            textAnimator.SetTrigger("Talk");
        }
        
    }
}
