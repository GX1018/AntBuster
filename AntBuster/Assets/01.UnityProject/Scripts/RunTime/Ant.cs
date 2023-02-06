using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    private Animator animator;
    
    public bool isDead = false;

    public bool getCake = false;

    public GameObject cake;

    public float speed;

    public float timeAfterStart = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.05f;
        animator = GetComponent<Animator>();
        cake = GFunc.GetRootObj("GameObjs").FindChildObj("Cake");
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
    }

    public void Dead()
    {
        isDead = true;
    }
}
