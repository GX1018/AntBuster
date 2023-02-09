using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefaultTowerButton : MonoBehaviour , IPointerDownHandler, 
    IPointerUpHandler, IDragHandler
{
    public bool isClicked = default;
    public int towerNum = default;
    
    // Start is called before the first frame update
    void Start()
    {
         isClicked =false;
         towerNum = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //test
        
        //test        

    }

    public void PointEnter() {
        gameObject.FindChildObj("MouseOverInfo").SetActive(true);
        gameObject.FindChildObj("MouseOverInfoImg").SetActive(true);

    }

    public void PointExit() {
        gameObject.FindChildObj("MouseOverInfo").SetActive(false);
        gameObject.FindChildObj("MouseOverInfoImg").SetActive(false);

    }

    /* public void PointClick() {
        isClicked = true;
        Debug.Log("클릭!");
        Debug.Log(isClicked);
        TowerManager.Instance.isTowerBtnClicked = true;
    }  */


    public void OnPointerDown(PointerEventData eventData)
    {
        //기본
        isClicked = true;
        ObjectPoolManager.Instance.TowerSpawn();
        //test
        if(isClicked == false)
        {
            isClicked = true;
        }

        else if(isClicked == true)
        {
            isClicked = false;
        }
        //test

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //test
        isClicked = false;
        //
        towerNum ++;
    }

    public void OnDrag(PointerEventData eventData)
    {
        /* if(isClicked == true)
        {
            transform.Find($"Canon{towerNum}").position = transform.Find("MakeTower").GetComponent<MakeTower>().MousePosition;
        } */
    }

    

}

