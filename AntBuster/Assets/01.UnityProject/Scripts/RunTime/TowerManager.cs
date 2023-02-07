using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private static TowerManager instance;

    public static TowerManager Instance
    {
        get
        {
            if(instance = null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    int towerInField = 0;
    string towerName;
    int price;
    int speed;
    int range;
    int damage;



}
