using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 1250;
        maxHP = hp;
        attk = 20;
        range = 1;
        speed = 0.5f;

        team = Random.Range(0, 2);
        GetComponent<MeshRenderer>().material = mat[team];
        switch (team)
        {
            case 0:
                {
                    gameObject.tag = "Night Riders";
                    break;
                }
            case 1:
                {
                    gameObject.tag = "Day Walkers";
                    break;
                }                
        }

        healthbar = GetComponentsInChildren<Image>()[1];
    }

}
