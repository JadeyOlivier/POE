using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        //Random team, x and y
        x = Random.Range(0, 20); //Unity random
        hp = 10;
        maxHP = hp;
        attk = 2;
        range = 1;

        team = Random.Range(0, 2);
        GetComponent<MeshRenderer>().material = mat[team];
    }

}
