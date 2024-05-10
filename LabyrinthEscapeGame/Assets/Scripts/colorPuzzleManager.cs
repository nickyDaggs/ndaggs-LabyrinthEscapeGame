using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorPuzzleManager : MonoBehaviour
{
    public List<colorButtonScript> buttons = new List<colorButtonScript>();
    public List<int> correctValues = new List<int>();

    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Check()
    {
        int right = 0;
        for (int i = 0; i < buttons.Count; i++)
        {
            int num = int.Parse(buttons[i].text.text);
            if (num == correctValues[i])
            {
                right++;
            }
        }

        if(right == buttons.Count)
        {
            door.SetActive(false);
        }
    }
}
