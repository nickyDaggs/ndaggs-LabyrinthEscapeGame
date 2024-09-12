using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPanelScript : MonoBehaviour
{
    public int curSprite;

    public List<Sprite> images;

    public bool off = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(curSprite >= images.Count)
        {
            curSprite = 0;
            GetComponent<SpriteRenderer>().sprite = images[curSprite];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = images[curSprite];
        }
    }
}
