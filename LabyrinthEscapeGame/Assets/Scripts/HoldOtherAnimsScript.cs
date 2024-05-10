using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldOtherAnimsScript : MonoBehaviour
{
    public List<SpriteRenderer> sprites;
    // Start is called before the first frame update
    public void StartGrayScale()
    {
        StartCoroutine(grayScaleTransition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator grayScaleTransition()
    {
        //yield return new WaitForSeconds(3f);
        //yield return new WaitForSeconds(3f);
        for (int i = 0; i < sprites.Count; i++)
        {
            while(sprites[i].color.a > 0)
            {
                sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, sprites[i].color.a - .05f);
                yield return new WaitForSeconds(.1f);
            }
        }
        
    }
}
