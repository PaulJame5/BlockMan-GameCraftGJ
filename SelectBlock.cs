using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBlock : MonoBehaviour 
{
    public Vector2 size;
    public Vector2 expandSize;
    public float percentageIncrease = 0.1f;
    public Bag bag;

    public AudioClip pickUp;
    AudioSource aud;
	// Use this for initialization
	void Start () 
	{
        aud = GetComponent<AudioSource>();
        bag = GameObject.Find("GameManager").GetComponent<Bag>();
        size = this.gameObject.transform.localScale;
        expandSize = size + (size * percentageIncrease);
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}


    private void OnMouseOver()
    {
        if (gameObject.tag != "NotSelectable")
        {


            gameObject.transform.localScale = expandSize;
            Debug.Log("touched object" + gameObject.name);

            bag.hoveringOnBlock = true;
        }

    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = size;
        Debug.Log("left object" + gameObject.name);
        bag.hoveringOnBlock = false;
    }

    private void OnMouseDown()
    {
        if (gameObject.tag != "NotSelectable" && bag.pickUps > 0)
        {
            bag.blocks.Add(gameObject);
            gameObject.SetActive(false);
            bag.pressed = true;
            bag.hoveringOnBlock = false;
            bag.pickUps--;
            bag.aud.PlayOneShot(bag.pickUp);
        }
    }

}
