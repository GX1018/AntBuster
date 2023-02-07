using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ant : MonoBehaviour
{
    private Animator animator;
    
    public bool isDead = false;

    public bool getCake = false;

    public GameObject cake;
    public GameObject spawningPool;

    public float speed;

    public int lv = default;
    public int maxHp = default;
    public int currentHp = default;

    public GameObject hpBar;

    public Image hpGauge;





    public float timeAfterStart = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
        animator = GetComponent<Animator>();
        cake = GFunc.GetRootObj("GameObjs").FindChildObj("Cake");
        spawningPool = GFunc.GetRootObj("GameObjs").FindChildObj("SpawningPool");
        hpGauge = gameObject.FindChildObj("HpGauge").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        /* timeAfterStart += Time.deltaTime;
        if(timeAfterStart>3)
        {
            Dead();
        } */
        //애니메이션 테스트용



        if(isDead ==true)
        {
            animator.SetBool("isDead", true);
        }

        if(getCake== false)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, cake.transform.position, speed);
        }
        
        else if(getCake == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawningPool.transform.position, speed);
        }

        hpGauge.fillAmount = (float)currentHp/maxHp;


    }

    public void Dead()
    {
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "SpawningPool"&& getCake == true)
        {
            getCake = false;
            gameObject.FindChildObj("PeiceOfCake").SetActive(false);
            GameManager.Instance.stolenCake ++;
        }
    }
}
