using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]
    int resources;
    // Start is called before the first frame update
    void Start()
    {
        resources = Random.Range(0, 101);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
