using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoManager : MonoBehaviour
{
    public GameObject picTwo;
    public GameObject picThree;
    public GameObject picFour;

    public objectChecker check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(picTwo != null)
        {
            if(check.on)
            {
                picTwo.SetActive(true);
            }
        }
    }
}
