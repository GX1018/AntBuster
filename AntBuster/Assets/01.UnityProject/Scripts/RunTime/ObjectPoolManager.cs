using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<GameObject> objectPool;
    private int objNum;
    public GameObject objClone;

    private int poolIndex =default;
    private static ObjectPoolManager instance;

    public GameObject SpawningPool;

    public static ObjectPoolManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }


    // Start is called before the first frame update
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start() {
        poolIndex=0;
        objNum = 6;
        objectPool = new List<GameObject>();

        Debug.Log(transform.Find("SpawningPool"));

        for(int i =0; i<objNum; i++)
        {
            objClone = Instantiate(Resources.Load<GameObject>("Prefabs/Ant"));
            objClone.transform.parent = GFunc.GetRootObj("GameObjs").transform;
            
            objClone.GetComponent<RectTransform>().localScale= new Vector2(1,1);
            objClone.transform.position = GFunc.GetRootObj("GameObjs").FindChildObj("SpawningPool").transform.position;

            objClone.SetActive(false);
            objectPool.Add(objClone);
        }
    }

    public void antSpawn()
    {
        //if(objectPool[poolIndex].activeSelf == true)
        
        /* if(poolIndex >= objectPool.Count)
        {
            poolIndex = 0;
        } */
        //test

        /* objectPool[poolIndex].GetComponent<Ant>().lv = 1;
        objectPool[poolIndex].GetComponent<Ant>().maxHp = (int)(4* Mathf.Pow(1.1f, objectPool[poolIndex].GetComponent<Ant>().lv));
        objectPool[poolIndex].GetComponent<Ant>().currentHp =objectPool[poolIndex].GetComponent<Ant>().maxHp;

        objectPool[poolIndex].SetActive(true);
        poolIndex ++; */

        for(int i = 0; i <objectPool.Count; i++)
        {
            if(objectPool[i].activeSelf ==false)
            {
                objectPool[i].GetComponent<Ant>().lv = 1;
                objectPool[i].GetComponent<Ant>().maxHp = (int)(4* Mathf.Pow(1.1f, objectPool[i].GetComponent<Ant>().lv));
                objectPool[i].GetComponent<Ant>().currentHp =objectPool[i].GetComponent<Ant>().maxHp;

                objectPool[i].transform.position = GFunc.GetRootObj("GameObjs").FindChildObj("SpawningPool").transform.position;
                objectPool[i].SetActive(true);
                break;
            }
        }
    }


}
