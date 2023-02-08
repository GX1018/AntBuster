using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Main : MonoBehaviour
{
    public bool isTarget;
    private float timeAfterSpawn;
    GameObject bullet;

    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        isTarget = false;
        //GameObject.Find("GameObjs");
    }

    // Update is called once per frame
    void Update()
    {
        if(isTarget == true)
        {
            timeAfterSpawn +=Time.deltaTime;
            GFunc.LookAt2D(gameObject ,target.gameObject);
            if(timeAfterSpawn>1)
            {
                bullet = Instantiate(Resources.Load<GameObject>("Prefabs/Canon_Bullet"),transform.position,transform.rotation);
                bullet.transform.parent = GameObject.Find("GameObjs").transform;
                bullet.name = this.transform.parent.name + "_bullet";
                bullet.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
                timeAfterSpawn = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ant")
        {
            if(isTarget == false)
            {
                target = other.gameObject;
                isTarget = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Ant")
        {
            if(isTarget == true)
            {
                target = other.gameObject;
                isTarget = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Ant")
        {
            if(isTarget == false)
            {
                target = other.gameObject;
                isTarget = true;
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D other) {
        if(other.collider.name == bullet.name)
        {
            Destroy(other.gameObject);
            //other.gameObject.SetActive(false); //objectpool 만든다음
        }
    }
}
