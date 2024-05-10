using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PiecesManager : MonoBehaviour
{
    public List<GameObject> pieces;
    public List<InventoryItem> piecesToEnter;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    public void Check(InventoryItem entered)
    {
        pieces[piecesToEnter.IndexOf(entered)].SetActive(true);

        if(pieces.All(x => x.activeSelf))
        {
            wall.SetActive(false);
        }
    }
}
