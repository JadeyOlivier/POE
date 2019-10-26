using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int range;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHP;
    [SerializeField] protected int attk;
    [SerializeField] protected float speed;
    [SerializeField] protected int team;
    [SerializeField] protected Material[] mat;

    protected Image healthbar;

    public int Hp { get => hp; set => hp = value; }
    public int MaxHP { get => maxHP;}
    public int Attk { get => attk;}
    public float Speed { get => speed;}
    public int Range { get => range;}
    public int Team { get => team;}

    int duration = 1;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsInRange(GetClosestUnit()))
        {
            transform.position = Vector3.MoveTowards(transform.position, GetClosestUnit().transform.position, speed * Time.deltaTime);
        }
        else
        {
            //Attack(GetClosestUnit());
        }

        /*timer += Time.deltaTime;
        if(timer >= duration)
        {
            hp--;
            timer = 0;
        }*/

        healthbar.fillAmount = (float)hp / maxHP;
    }

    protected GameObject GetClosestUnit()
    {
        GameObject unit = null;
        GameObject[] units = null;
        GameObject[] units2 = null;
        GameObject[] opposingUnits = null;
        int count;
        //GameObject[] buildings = null;

        switch (team)
        {
            case 0:
                {
                    count = 0;
                    units = GameObject.FindGameObjectsWithTag("Day Walkers");
                    units2 = GameObject.FindGameObjectsWithTag("Wizard");
                    foreach(GameObject temp in units)
                    {
                        opposingUnits[count] = temp;
                        count++;
                    }
                    foreach (GameObject temp in units2)
                    {
                        opposingUnits[count] = temp;
                        count++;
                    }
                    break;
                }
            case 1:
                {
                    count = 0;
                    units = GameObject.FindGameObjectsWithTag("Night Riders");
                    units2 = GameObject.FindGameObjectsWithTag("Wizard");
                    foreach (GameObject temp in units)
                    {
                        opposingUnits[count] = temp;
                        count++;
                    }
                    foreach (GameObject temp in units2)
                    {
                        opposingUnits[count] = temp;
                        count++;
                    }
                    break;
                }
            case 2:
                {
                    count = 0;
                    units = GameObject.FindGameObjectsWithTag("Day Walkers");
                    units2 = GameObject.FindGameObjectsWithTag("Night Riders");
                    foreach (GameObject temp in units)
                    {
                        opposingUnits[count] = temp;
                        count++;
                    }
                    foreach (GameObject temp in units2)
                    {
                        opposingUnits[count] = temp;
                        count++;
                    }
                    break;
                }
        }

        float distance = 9999;

        foreach(GameObject temp in opposingUnits)
        {
            float tempDist = Vector3.Distance(transform.position, temp.transform.position);
            if (tempDist <= distance)
            {
                distance = tempDist;
                unit = temp;
            }
        }

        return unit;
    }

    protected bool IsInRange(GameObject Enemy)
    {
        bool returnVal = false;

        if (Vector3.Distance(transform.position, Enemy.transform.position) <= range)
        {
            returnVal = true;
        }
        else
        {
            returnVal = false;
        }

        return returnVal;
    }

    protected void Attack(GameObject Enemy)
    {
        if (Enemy.name.Contains("Unit"))
        {
            Enemy.GetComponent<Unit>().Hp -= this.Attk;
        }
        else if (Enemy.name.Contains("Building"))
        {
            Enemy.GetComponent<Building>().BuildingHp -= this.Attk;
        }      
    }

    protected void IsDead()
    {
        if(this.Hp <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
