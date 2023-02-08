using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Bullet : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed); //* speed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ant")
        {
            other.GetComponent<Ant>().currentHp -= damage;
            gameObject.SetActive(false);
        }
    }
}
