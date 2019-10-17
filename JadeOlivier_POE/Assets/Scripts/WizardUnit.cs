using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 15;
        maxHP = hp;
        attk = 3;
        range = 1;
        speed = 0.25f;

        team = 2;
        GetComponent<MeshRenderer>().material = mat[team];
        gameObject.tag = "Wizard";
    }


}
