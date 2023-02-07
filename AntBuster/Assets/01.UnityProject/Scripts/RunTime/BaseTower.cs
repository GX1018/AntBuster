using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public int towerInField = 0;
    public string towerName;
    public int price;
    public int sellPrice;
    public int speed;
    public int range;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        towerName = "canon";
        price = 50;
        sellPrice = 50;
        speed = 4;
        range = 100;
        damage = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
