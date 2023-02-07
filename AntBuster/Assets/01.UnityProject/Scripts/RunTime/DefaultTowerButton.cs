using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTowerButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointEnter() {
        gameObject.FindChildObj("MouseOverInfo").SetActive(true);
        gameObject.FindChildObj("MouseOverInfoImg").SetActive(true);

        
        Debug.Log("하하");
    }

    public void PointExit() {
        gameObject.FindChildObj("MouseOverInfo").SetActive(false);
        gameObject.FindChildObj("MouseOverInfoImg").SetActive(false);

        Debug.Log("하하");
    }
}

