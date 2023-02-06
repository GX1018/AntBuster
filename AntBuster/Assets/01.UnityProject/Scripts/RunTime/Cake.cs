using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{
    public int pieceOfCake = default;

    Sprite[] sprites;

    Image curruntImage;

    
    // Start is called before the first frame update
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("Sprites/cake");
        pieceOfCake= 8;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sprites[8]);
        //curruntImage.GetComponent<Image>().sprite = sprites[8];
        Debug.Log(pieceOfCake);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ant")
        {
            pieceOfCake--;
            other.GetComponent<GameObject>().SetActive(false);
        }
    }
}
