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
        GameObject[] opposition = null;
        GameObject[] secondOpposition = null;
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

    protected void IsDead()
    {
        if(this.Hp <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
