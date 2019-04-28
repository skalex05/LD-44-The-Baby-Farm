using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float Speed;
    public Animator anim;
    public float interactDist;
    public Rigidbody2D RB;
    public Transform interactPoint;
    public Vector2 InteractpointOffset;

    void Start()
    {
        interactPoint.localPosition = (new Vector2(0, -1) * interactDist) + InteractpointOffset;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Back", false);
        anim.SetBool("Forward", false);
        anim.SetBool("Right", false);
        anim.SetBool("Left", false);

        float xmov = Input.GetAxisRaw("Horizontal");
        float ymov = Input.GetAxisRaw("Vertical");

        if (ymov != 0)
        {
            interactPoint.localPosition = (new Vector2(0, ymov) * interactDist) + InteractpointOffset;
        }
        else if (xmov != 0)
        {
            interactPoint.localPosition = (new Vector2(xmov,0) * interactDist) + InteractpointOffset;
        }

        if (ymov > 0)
        {
            anim.SetBool("Back", true);
        }
        else if (ymov < 0)
        {
            anim.SetBool("Forward", true);
        }
        else if (xmov > 0)
        {
            anim.SetBool("Right", true);
        }
        else if (xmov < 0)
        {
            anim.SetBool("Left", true);
        }

        xmov = new Vector2(xmov, ymov).normalized.x;
        ymov = new Vector2(xmov, ymov).normalized.y;

        Vector2 addedPosition = new Vector2(xmov, ymov) * Speed * Time.deltaTime;
        RB.MovePosition(new Vector2(transform.position.x, transform.position.y) + addedPosition);
    }
}
