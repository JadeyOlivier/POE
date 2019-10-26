using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBuilding : Building
{
    // Start is called before the first frame update
    int neededResources;
    [SerializeField] GameObject[] generatedUnits = new GameObject[2];
    [SerializeField]
    static int MIN_X = -20, MAX_X = 20, MIN_Z = -20, MAX_Z = 20;

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

        neededResources = 5;
    }

    public void genUnit()
    {
        if(gameObject.tag == "Night Riders")
        {
            if(GetComponent<ResourceBuilding>().generatedNR >= neededResources)
            {
                GameObject unit = Instantiate(generatedUnits[Random.Range(0, 2)]);
                unit.tag = "Night Riders";
                unit.GetComponent<MeshRenderer>().material = mat[0];
                unit.transform.position = this.transform.position;
            }
            else if (gameObject.tag == "Day Walkers")
            {
                if (GetComponent<ResourceBuilding>().generatedDW >= neededResources)
                {
                    GameObject unit = Instantiate(generatedUnits[Random.Range(0, 2)]);
                    unit.tag = "Day Walkers";
                    unit.GetComponent<MeshRenderer>().material = mat[1];
                    unit.transform.position = this.transform.position;
                }
            }
        }
    }
}


