using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<GameObject> objectPool;
    public static List<GameObject> objectPool_Tower;//+
    private int objNum;
    private int objNum_Tower;//+
    public GameObject objClone;
    public GameObject objClone_Tower;//+

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

        //Debug.Log(transform.Find("SpawningPool"));

        for(int i =0; i<objNum; i++)
        {
            objClone = Instantiate(Resources.Load<GameObject>("Prefabs/Ant"));
            objClone.transform.parent = GFunc.GetRootObj("GameObjs").transform;
            
            objClone.GetComponent<RectTransform>().localScale= new Vector2(1,1);
            objClone.transform.position = GFunc.GetRootObj("GameObjs").FindChildObj("SpawningPool").transform.position;

            objClone.SetActive(false);
            objectPool.Add(objClone);
        }

        objNum_Tower=20;
        objectPool_Tower = new List<GameObject>();

        for(int i =0; i<objNum_Tower; i++)
        {
            objClone_Tower = Instantiate(Resources.Load<GameObject>("Prefabs/Canon"));
            objClone_Tower.transform.parent = GFunc.GetRootObj("GameObjs").transform;
            
            objClone_Tower.GetComponent<RectTransform>().localScale= new Vector2(1,1);
            objClone_Tower.transform.position = GFunc.GetRootObj("GameObjs").FindChildObj("TowerPool").transform.position;
            objClone_Tower.name = "Canon"+$"{i}";

            objClone_Tower.SetActive(false);
            objectPool_Tower.Add(objClone_Tower);
        }
        
    }

    public void antSpawn()
    {
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

    public void TowerSpawn()
    {
        for(int i = 0; i <objectPool_Tower.Count; i++)
        {
            if(objectPool_Tower[i].activeSelf ==false)
            {
                objectPool_Tower[i].SetActive(true);
                break;
            }
        }
    }


}
