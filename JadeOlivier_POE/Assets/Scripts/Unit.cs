﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int range;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHP;
    [SerializeField] protected int attk;
    [SerializeField] protected float speed;
    [SerializeField] protected int team;
    [SerializeField] protected Material[] mat;

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
        if (!IsInRange(GetClosestUnit()))
        {
            transform.position = Vector3.MoveTowards(transform.position, GetClosestUnit().transform.position, speed * Time.deltaTime);
        }
        else Debug.Log(Vector3.Distance(transform.position, GetClosestUnit().transform.position));
    }

    protected GameObject GetClosestUnit()
    {
        GameObject unit = null;
        GameObject[] units = null;

        switch (team)
        {
            case 0:
                {
                    units = GameObject.FindGameObjectsWithTag("Day Walkers");
                    break;
                }
            case 1:
                {
                    units = GameObject.FindGameObjectsWithTag("Night Riders");
                    break;
                }
        }

        float distance = 9999;

        foreach(GameObject temp in units)
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
}