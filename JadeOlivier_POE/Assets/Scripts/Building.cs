using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] protected int buildingHp;
    [SerializeField] protected int buidlingMaxHP;
    [SerializeField] protected int buildingTeam;
    [SerializeField] protected Material[] mat;

    protected Image healthbar;

    public int BuildingHp { get => buildingHp; set => buildingHp = value; }
    public int BuildingMaxHP { get => buidlingMaxHP; set => buidlingMaxHP = value; }
    public int BuildingTeam { get => buildingTeam; set => buildingTeam = value; }
    public Material[] Mat { get => mat; set => mat = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name.Contains("ResourceBuilding"))
        {
            if (GetComponent<ResourceBuilding>().IsDead() == false)
            {
                GetComponent<ResourceBuilding>().GenResources();
                GetComponent<ResourceBuilding>().DisplayResources();
            }
        }
        else if (gameObject.name.Contains("FactoryBuilding"))
        {
            if(GetComponent<FactoryBuilding>().IsDead() == false)
            {
                GetComponent<FactoryBuilding>().GenUnit();
            }
        }

        healthbar.fillAmount = (float)buildingHp / BuildingMaxHP;
    }
}
