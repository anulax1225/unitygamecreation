using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPoper : MonoBehaviour
{
    public int NbTail;
    public string[] TailList;
    private GameObject[] lsTails;
    public Texture2D tex;
    private SpriteRenderer sr;
    public  Transform player;
    private Sprite mySprite;
    int sprite = 0;

    private Sprite CreateSprit() 
    {
        return Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    void Start()
    {  
        lsTails = new GameObject[NbTail]; 
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        sr.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);
        mySprite = CreateSprit();
        sr.sprite = mySprite;
        int i = 0;
        foreach(string tail in TailList)
        {
            lsTails[i] = GameObject.Find(tail);
            i++;
        }
    }

    private void FixedUpdate() {
        if(sprite == 0)
        {
            transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0.0f);
            sprite = 1;
            foreach(GameObject tail in lsTails)
            {
                Debug.Log(tail);
                tail.GetComponent<Tentacule>().setLength(1);
            }
        }
        if ((player.position.x - transform.position.x) < 0.3f && (player.position.y - transform.position.y) < 0.3f)
        {
            sprite = 0;
        }
    }
}
