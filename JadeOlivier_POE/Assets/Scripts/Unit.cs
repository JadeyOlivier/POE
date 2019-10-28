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

    GameObject[] opposition = null;
    GameObject[] secondOpposition = null;

    protected Image healthbar;

    public int Hp { get => hp; set => hp = value; }
    public int MaxHP { get => maxHP;}
    public int Attk { get => attk;}
    public float Speed { get => speed;}
    public int Range { get => range;}
    public int Team { get => team;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        if(gameObject.tag != "Wizard")
        {
            if(!IsDead())
            {
                if (this.Hp >= (0.25 * MaxHP))
                {
                    GameObject closest = GetClosestUnit();
                    if (!IsInRange(closest))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, closest.transform.position, speed * Time.deltaTime);
                    }
                    else if (IsInRange(closest))
                    {
                        Attack(closest);
                    }
                }
                else
                {
                    GameObject movePoint = new GameObject();
                    movePoint.transform.position = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
                    transform.position = Vector3.MoveTowards(transform.position, movePoint.transform.position, speed * Time.deltaTime);
                }
            }
            else
            {
                GameObject.Destroy(gameObject);
            }
         
        }
        else if (gameObject.tag == "Wizard")
        {
            GameObject closest = GetClosestUnit();
            if (!IsDead())
            {
                if (this.Hp >= (0.25 * MaxHP))
                {
                    
                    if (!IsInRange(closest))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, closest.transform.position, speed * Time.deltaTime);
                    }
                    else 
                    {
                        opposition = GameObject.FindGameObjectsWithTag("Day Walkers");
                        secondOpposition = GameObject.FindGameObjectsWithTag("Night Riders");
                        foreach (GameObject temp in opposition)
                        {
                            if (!temp.name.Contains("Building"))
                            {
                                if (IsInRange(temp))
                                {
                                    Attack(temp);
                                }
                            }
                        }

                        foreach (GameObject temp in secondOpposition)
                        {
                            if (!temp.name.Contains("Building"))
                            {
                                if (IsInRange(temp))
                                {
                                    Attack(temp);
                                }
                            }
                        }
                    }
                }
                else
                {
                    GameObject movePoint = new GameObject();
                    movePoint.transform.position = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
                    transform.position = Vector3.MoveTowards(transform.position, movePoint.transform.position, speed * Time.deltaTime);
                }
            }
            else
            {
                GameObject.Destroy(gameObject);
            }
        }

        healthbar.fillAmount = (float)hp / maxHP;
    }

    protected GameObject GetClosestUnit()
    {
        GameObject unit = null;       
        //GameObject[] buildings = null;

        switch (team)
        {
            case 0:
                {
                    opposition = GameObject.FindGameObjectsWithTag("Day Walkers");
                    secondOpposition = GameObject.FindGameObjectsWithTag("Wizard");
                    break;
                }
            case 1:
                {
                    opposition = GameObject.FindGameObjectsWithTag("Night Riders");
                    secondOpposition = GameObject.FindGameObjectsWithTag("Wizard");
                    break;
                }
            case 2:
                {
                    opposition = GameObject.FindGameObjectsWithTag("Day Walkers");
                    secondOpposition = GameObject.FindGameObjectsWithTag("Night Riders");
                    break;
                }
        }

        float distance = 9999;

        foreach(GameObject temp in opposition)
        {
            float tempDist = Vector3.Distance(transform.position, temp.transform.position);
            if (tempDist <= distance)
            {
                distance = tempDist;
                unit = temp;
            }
        }

        foreach (GameObject temp in secondOpposition)
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

    protected bool IsDead()
    {
        bool dead = false;
        ResourceBuilding resourceBuildingUsed = GameObject.FindObjectOfType<ResourceBuilding>();
        if (this.Hp <= 0)
        {
            dead = true;
            if (gameObject.tag == "Day Walkers")
            {
                resourceBuildingUsed.generatedNR++;
            }
            else if (gameObject.tag == "Night Riders")
            {
                resourceBuildingUsed.generatedDW++;
            }
        }

        return dead;
    }
}
