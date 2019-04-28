using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{
    public float InteractionRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + new Vector3(0.5f, -0.5f), InteractionRadius);
            foreach (Collider2D hit in hits)
            {
                
                if (hit.gameObject.GetComponent<ItemHoldScript>() != null)
                {
                    hit.gameObject.GetComponent<ItemHoldScript>().HeldItem = "None";
                }
            }
        }
        
    }
}
