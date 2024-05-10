using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class characterDialogue : MonoBehaviour
{
    public string name;
    public string dialogue;
    public Animator textAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TalkInteract()
    {
        textAnimator.GetComponent<TextMeshProUGUI>().text = name + ":\n" + dialogue;
        textAnimator.SetTrigger("Talk");
    }
}
