using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorPuzzleManager : MonoBehaviour
{
    public List<Animator> mirrors = new List<Animator>();
    public BoxCollider mirror;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Solved()
    {
        Debug.Log("ggggg");
        GetComponent<itemInteractScript>().enabled = false;
        foreach(Animator anim in mirrors)
        {
            anim.SetTrigger("Fixed");
        }
        mirror.enabled = true;
    }
}
