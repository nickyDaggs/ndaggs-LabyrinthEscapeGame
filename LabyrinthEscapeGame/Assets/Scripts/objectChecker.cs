using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectChecker : MonoBehaviour
{
    public GameObject solver;
    public bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == solver)
        {
            on = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == solver)
        {
            on = false;
        }
    }
}
