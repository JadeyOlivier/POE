using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBuilding : Building
{
    // Start is called before the first frame update
    int neededResources;
    [SerializeField] GameObject[] generatedUnits = new GameObject[2];

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

        neededResources = 15;
    }

    public void GenUnit()
    {
        ResourceBuilding resourceBuildingUsed = GameObject.FindObjectOfType<ResourceBuilding>();
        if(gameObject.tag == "Night Riders")
        {
            if(resourceBuildingUsed.generatedNR >= neededResources)
            {
                GameObject unit = Instantiate(generatedUnits[Random.Range(0, 2)]);
                unit.tag = "Night Riders";
                unit.GetComponent<MeshRenderer>().material = mat[0];
                unit.transform.position = this.transform.position;
            }
        }
        else if (gameObject.tag == "Day Walkers")
        {
            if (resourceBuildingUsed.generatedDW >= neededResources)
            {
                GameObject unit = Instantiate(generatedUnits[Random.Range(0, 2)]);
                unit.tag = "Day Walkers";
                unit.GetComponent<MeshRenderer>().material = mat[1];
                unit.transform.position = this.transform.position;
            }
        }
    }

    public bool IsDead()
    {
        bool dead = false;
        ResourceBuilding resourceBuildingUsed = GameObject.FindObjectOfType<ResourceBuilding>();
        if (this.BuildingHp <= 0)
        {
            GameObject.Destroy(gameObject);
            if (gameObject.tag == "Day Walkers")
            {
                resourceBuildingUsed.generatedNR++;
            }
            else if (gameObject.tag == "Night Riders")
            {
                resourceBuildingUsed.generatedDW++;
            }
            dead = true;
        }

        return dead;
    }
}


