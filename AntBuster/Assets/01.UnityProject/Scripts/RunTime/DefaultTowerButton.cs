using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTowerButton : MonoBehaviour
{
    public bool isClicked = default;
    
    // Start is called before the first frame update
    void Start()
    {
         isClicked =false;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void PointEnter() {
        gameObject.FindChildObj("MouseOverInfo").SetActive(true);
        gameObject.FindChildObj("MouseOverInfoImg").SetActive(true);

    }

    public void PointExit() {
        gameObject.FindChildObj("MouseOverInfo").SetActive(false);
        gameObject.FindChildObj("MouseOverInfoImg").SetActive(false);

    }

    public void PointClick() {
        isClicked = true;
        Debug.Log("클릭!");
        Debug.Log(isClicked);
    }

}

