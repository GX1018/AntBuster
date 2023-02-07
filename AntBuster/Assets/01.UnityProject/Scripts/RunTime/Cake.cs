using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{
    public int pieceOfCake = default;

    Sprite[] sprites;

    public Image curruntImage= default;

    
    // Start is called before the first frame update
    void Start()
    {
        pieceOfCake= 8;

        sprites = Resources.LoadAll<Sprite>("Sprites/cake");
        curruntImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sprites[pieceOfCake]);
        Debug.Log(pieceOfCake);
        curruntImage.sprite = sprites[pieceOfCake];

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ant")
        {
            if(pieceOfCake>0)
            {
            pieceOfCake--;
            other.gameObject.FindChildObj("PeiceOfCake").SetActive(true);
            other.gameObject.GetComponent<Ant>().getCake = true;
            }

            //other.gameObject.SetActive(false);
        }
    }
}
