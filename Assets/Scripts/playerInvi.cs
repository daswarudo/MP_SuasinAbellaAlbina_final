using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInvi : MonoBehaviour
{
    public Renderer model;
    // Start is called before the first frame update
    void Start()
    {
        model = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }
}
