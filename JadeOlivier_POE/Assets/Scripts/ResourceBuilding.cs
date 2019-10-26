using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBuilding : Building
{
    // Start is called before the first frame update
    public int resources;
    public int generatedNR = 0;
    public int generatedDW = 0;
    public int genAmount = 0;

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
        resources = Random.Range(50, 201);
        genAmount = Random.Range(1, 5);
    }

    public void GenResources()
    {
        if (IsDead() == false && resources > 0)
        {
            switch (buildingTeam)
            {
                case 0:
                    {
                        generatedNR += genAmount;
                        resources -= genAmount;
                        break;
                    }
                case 1:
                    {
                        generatedDW += genAmount;
                        resources -= genAmount;
                        break;
                    }
            }
        }
    }

    public bool IsDead()
    {
        bool dead = false;
        if(this.BuildingHp <= 0)
        {
            GameObject.Destroy(gameObject);
            if (gameObject.tag == "Day Walkers")
            {
                generatedNR++;
            }
            else if (gameObject.tag == "Night Riders")
            {
                generatedDW++;
            }
            dead = true;
        }

        return dead;
    }

}
