using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 1500;
        maxHP = hp;
        attk = 30;
        range = 1;
        speed = 0.5f;

        team = 2;
        GetComponent<MeshRenderer>().material = mat[team];
        gameObject.tag = "Wizard";
    }


}
