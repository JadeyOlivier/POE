using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    [SerializeField] GameObject[] units = new GameObject[3];
    [SerializeField] GameObject[] buildings = new GameObject[2];
    [SerializeField] static int MIN_X = -20, MAX_X = 20, MIN_Z = -20, MAX_Z = 20, UNITS = 15, BUILDINGS = 6;
     // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < UNITS; i++)
        {
            CreateUnit();
        }

        for (int j = 0; j < BUILDINGS; j++)
        {
            CreateBuilding();
        }
    }

    void CreateUnit()
    {
        GameObject unit = Instantiate(units[Random.Range(0, 3)]);
        unit.transform.position = new Vector3(Random.Range(MIN_X, MAX_X), 0, Random.Range(MIN_Z, MAX_Z));
    }

    void CreateBuilding()
    {
        GameObject building = Instantiate(buildings[Random.Range(0, 2)]);
        building.transform.position = new Vector3(Random.Range(MIN_X, MAX_X), 0, Random.Range(MIN_Z, MAX_Z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
