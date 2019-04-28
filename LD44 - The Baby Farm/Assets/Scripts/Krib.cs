using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krib : MonoBehaviour
{
    public Transform PlayerFrontPoint;
    public ItemHoldScript PlayerHold;
    public int Babies;
    public float InteractionRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + new Vector3(0.5f, -0.5f), InteractionRadius);
            foreach (Collider2D hit in hits)
            {
                if (hit.gameObject.GetComponent<ItemHoldScript>() != null && hit.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    if (hit.gameObject.GetComponent<ItemHoldScript>().HeldItem != "Baby" && Babies > 0)
                    {
                        hit.gameObject.GetComponent<ItemHoldScript>().HeldItem = "Baby";
                        Babies--;
                    }
                }
            }
        }
        if (Input.GetButtonDown("Action"))
        {
            Collider2D[] areas = Physics2D.OverlapCircleAll(PlayerFrontPoint.position, 0.1f);
            foreach(Collider2D area in areas)
            {
                if (area.gameObject == gameObject && PlayerHold.HeldItem == "Baby")
                {
                    PlayerHold.HeldItem = "None";
                    Babies++;
                }
            }
        }
    }
}
