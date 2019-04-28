using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGive : MonoBehaviour
{
    public Vector3 Offset;
    public string GivenItem;
    public float InteractionRadius;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + Offset, InteractionRadius);
            foreach(Collider2D hit in hits)
            {
                if (hit.gameObject.GetComponent<ItemHoldScript>() != null && hit.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    if (hit.gameObject.GetComponent<ItemHoldScript>().HeldItem != "Baby")
                    {
                        hit.gameObject.GetComponent<ItemHoldScript>().HeldItem = GivenItem;
                    }
                }
            }
        }
    }
}
