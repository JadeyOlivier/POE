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
    public int productTime = 0;

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
        genAmount = 5;
        productTime = 5;
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
        if (this.BuildingHp <= 0)
        {           
            if (gameObject.tag == "Day Walkers")
            {
                generatedNR++;
            }
            else if (gameObject.tag == "Night Riders")
            {
                generatedDW++;
            }
            GameObject.Destroy(gameObject);
            dead = true;
        }

        return dead;
    }

    public void DisplayResources()
    {
        Text resourceDisplay = GameObject.Find("ResourceDisplay").GetComponent<Text>(); resourceDisplay.text += "Night Riders Resources: ";
        resourceDisplay.text = "";
        resourceDisplay.text += "Resources: " + "\n";
        resourceDisplay.text += "Night Riders Resources: " + generatedNR + "\n";
        resourceDisplay.text += "Day Walkers Resources: " + generatedDW;
    }

}
