using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUps : MonoBehaviour 
{

    public Text display;
    public string message;
    Bag bag; // use bag script that holds object you clicked on stared in a list
    
    // Use this for initialization
    void Start () 
    {
        bag = GameObject.Find("GameManager").GetComponent<Bag>();
        display = GetComponent<Text>();
	
    }

	// LateUpdate is called  last at end of frame
	void LateUpdate () 
    	{
        	display.text = message + bag.pickUps;
	}
}
