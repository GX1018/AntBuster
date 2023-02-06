using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    public float timeAfterStart = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartPooling());
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterStart+=Time.deltaTime;
        if(timeAfterStart > 3)
        {
            
        spawnAnt();
        timeAfterStart=0;
        }
    }


    private IEnumerator StartPooling()
    {
        ObjectPoolManager.Instance.antSpawn();

        yield return new WaitForSeconds(2.0f);
    }

    public void spawnAnt()
    {
        ObjectPoolManager.Instance.antSpawn();
    }
}
