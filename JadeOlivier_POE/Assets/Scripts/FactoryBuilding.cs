using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBuilding : Building
{
    // Start is called before the first frame update
    void Start()
    {
        buildingHp = 15;
        buidlingMaxHP = buildingHp;
        buildingTeam = Random.Range(0, 2);
        GetComponent<MeshRenderer>().material = mat[buildingTeam];
        switch (buildingTeam)
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
    }
}


