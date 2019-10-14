using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int range;
    [SerializeField] protected int x;
    [SerializeField] protected int y;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHP;
    [SerializeField] protected int attk;
    [SerializeField] protected int speed;
    [SerializeField] protected int team;
    [SerializeField] protected Material[] mat;

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    public int Hp { get => hp; set => hp = value; }
    public int MaxHP { get => maxHP;}
    public int Attk { get => attk;}
    public int Speed { get => speed;}
    public int Range { get => range;}
    public int Team { get => team;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
