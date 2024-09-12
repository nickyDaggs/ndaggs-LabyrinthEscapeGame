using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrambleManager : MonoBehaviour
{
    public List<WordPanelScript> panelList;
    public List<int> correctNum;

    public bool on = false;

    public Animator Safe;
    // Start is called before the first frame update
    void Start()
    {
        if(on)
        {
            TurnOn();
        }
    }

    public void TurnOn()
    {
        for (int i = 0; i < panelList.Count; i++)
        {
            panelList[i].enabled = true;
        }
    }

    // Update is called once per frame
    public void Check()
    {
        int correct = 0;
        for(int i = 0; i < panelList.Count; i++)
        {
            if(panelList[i].curSprite == correctNum[i])
            {
                correct++;
            }
        }

        if(correct >= 6)
        {
            for (int i = 0; i < panelList.Count; i++)
            {
                panelList[i].off = true;
            }
            Safe.SetTrigger("Open");
        }
    }
}
