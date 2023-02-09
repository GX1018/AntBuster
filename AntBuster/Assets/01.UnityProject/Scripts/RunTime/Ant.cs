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

    public GameObject target;

    public float speed;

    public int lv = default;
    public int maxHp = default;
    public int currentHp = default;

    public GameObject hpBar;

    public Image hpGauge;

    public float RandomMoveTime;

    float directionX = default;
    float directionY = default;

    //개미 2d lookat
    private float angle;

    int ranX;
    int ranY;

    
    float DieAfterTime;


    public float timeAfterStart = 0f;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.005f;
        animator = GetComponent<Animator>();
        cake = GFunc.GetRootObj("GameObjs").FindChildObj("Cake");
        spawningPool = GFunc.GetRootObj("GameObjs").FindChildObj("SpawningPool");
        hpGauge = gameObject.FindChildObj("HpGauge").GetComponent<Image>();
        RandomMoveTime = 0f;
        DieAfterTime = 0f;
        isDead = false;
        
        
        StartCoroutine(RandomTarget());
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
        
        //Debug.Log(RandomMoveTime);


        /* if( RandomMoveTime>= 1&&RandomMoveTime<=2)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x+50,transform.position.y+50), speed);
        }
        else if(RandomMoveTime>2){
            RandomMoveTime=0;
        }  */


        if (isDead == true)
        {
            DieAfterTime += Time.deltaTime;
            if(getCake==true&&GameObject.Find("Cake").GetComponent<Cake>().pieceOfCake <8)
            {
                GameObject.Find("Cake").GetComponent<Cake>().pieceOfCake++;
            }
            animator.SetBool("isDead", true);
            gameObject.FindChildObj("PeiceOfCake").SetActive(false);
            getCake = false;
            isDead = false;
            if(DieAfterTime >= 2)
            {
                DieAfterTime=0;
                this.gameObject.SetActive(false);
            }

        }
        else if(isDead ==false)
        {
            animator.SetBool("isDead", false);
            Move();
        }
        
        hpGauge.fillAmount = (float)currentHp / maxHp;

        if(currentHp<=0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpawningPool" && getCake == true)
        {
            
            getCake = false;
            gameObject.FindChildObj("PeiceOfCake").SetActive(false);
            GameManager.Instance.stolenCake++;
        }
    }

    public void Move()
    {
        Vector3 dir = target.transform.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            //2d Vector3.foward?
        transform.Translate(Vector3.up * speed);
            //transform.position = Vector3.MoveTowards(transform.position, cake.transform.position, speed);
    }

    IEnumerator RandomTarget()
    {
        while(true)
        {
            
                int ranNum = Random.Range(0,15);
                if(ranNum == 0|| ranNum >=9)
                {
                    if (getCake == false)
                    {
                        target =cake;
                    }
                    else if(getCake == true)
                    {
                        target =  spawningPool;
                    }
                }
                else
                {
                    target = GameObject.Find($"target{ranNum}");
                }
                yield return new WaitForSeconds(0.1f);
        }
            
    }

    void OnEnable(){
        StartCoroutine(RandomTarget());
    }




}
