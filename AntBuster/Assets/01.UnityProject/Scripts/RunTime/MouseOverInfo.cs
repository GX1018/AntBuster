using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseOverInfo : MonoBehaviour
{
    BaseTower baseTower;
    // Start is called before the first frame update
    void Start()
    {
        baseTower = GFunc.GetRootObj("BaseTower").GetComponent<BaseTower>();

        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TMP_Text>().text = $"{baseTower.towerName} \n Price : {baseTower.price}\n Speed : {baseTower.speed}\n Range : {baseTower.range}\n Damage : {baseTower.damage}";
    }
}
