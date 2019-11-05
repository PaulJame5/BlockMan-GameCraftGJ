using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoredBlocks : MonoBehaviour 
{
    public int blockPosition;
    Bag bag;
	// Use this for initialization
	void Start () 
    {
        bag = GameObject.Find("GameManager").GetComponent<Bag>();
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
		if(bag.blocks.Count > blockPosition)
        {
            GetComponent<Image>().sprite = bag.blocks[blockPosition].GetComponent<SpriteRenderer>().sprite;

            GetComponent<Image>().color = bag.blocks[blockPosition].GetComponent<SpriteRenderer>().color;
        }
        else
        {
            GetComponent<Image>().sprite = null;
            GetComponent<Image>().color = new Color(0,0,0,0);
        }
	}
}
