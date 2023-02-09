using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTower : MonoBehaviour
{
    public Vector2 MousePosition;

    Camera Camera;
    float mPosX;
    float mPosY;
    // Start is called before the first frame update
    void Start()
    {
        //test
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //test
    }

    // Update is called once per frame
    void Update()
    {
        //test
        MousePosition = Input.mousePosition;
        MousePosition = Camera.ScreenToWorldPoint(MousePosition);
        mPosX =MousePosition.x;
        mPosY =MousePosition.y;
        //Debug.Log(mPosY);
        //test
    }

    private void OnMouseDown() {

        if(mPosY>=-2.9)
        {
        GameObject Canon = Instantiate(Resources.Load<GameObject>("Prefabs/Canon"),new Vector3(mPosX,mPosY,1),transform.rotation);
        Canon.transform.SetParent(GameObject.Find("TowerBox").transform);
        Canon.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        Canon.FindChildObj("Canon_Main").SetActive(true);
        }

    }

}
