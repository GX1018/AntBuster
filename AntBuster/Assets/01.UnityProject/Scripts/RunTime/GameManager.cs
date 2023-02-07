using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int point = default;
    public int money = default;

    public int stolenCake = default;
    
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        money = 300;
        point = 0;
    }

    private void Update() {
        if(stolenCake == 8)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GFunc.LoadScene(GData.SCENE_NAME_GAMEOVER);
    }


}
