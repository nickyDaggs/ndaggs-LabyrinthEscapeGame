using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class colorButtonScript : MonoBehaviour
{
    int num = 0;
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Pressed()
    {
        num++;
        if(num > 9)
        {
            num = 0;
        }
        text.text = "" + num;
    }
}
