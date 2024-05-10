using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInteractScript : MonoBehaviour
{
    public InventoryItem solution;
    public Animator finish;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Check(InventoryItem used, PlayerMovement player)
    {
        if(used == solution)
        {
            finish.SetTrigger("Solve");
        }
    }
}
