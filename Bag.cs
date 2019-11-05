// hoveringOnblock bool is changed by SelectBlock class to prevent placing and picking up objects at the same time

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public float distance = 50f;
    public List<GameObject> blocks;
    public bool hoveringOnBlock;
    public int pickUps = 4;

    public bool pressed = false;

    public AudioClip place;
    public AudioClip pickUp;
    public AudioSource aud;


    // Use this for initialization
    void Start()
    {
        hoveringOnBlock = false;
    }


    private void LateUpdate()
    {
        // this is changed with SelectBlock when attempting to pick one up
        if (!hoveringOnBlock)
        {

            // Left mouse button
            if (Input.GetMouseButtonDown(0))
            {

                if (!pressed)
                {
                    if (blocks.Count > 0)
                    {


                        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        point.z = 0;
                        blocks[0].transform.position = point;
                        blocks[0].SetActive(true);
                        blocks.RemoveAt(0);
                        pressed = true;
                        aud.PlayOneShot(place);

                    } // end check list count
                } // end !pressed
            } // end mouse button down
        } // End hovering on block

        // Left mouse button
        if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
        }
    }
}

