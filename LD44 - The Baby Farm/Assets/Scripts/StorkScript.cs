using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorkScript : MonoBehaviour
{
    public float InteractionRadius;
    public int ScorePerBaby;
    public float EnterTime;
    public int ScoreLossPerBadBaby;
    public ScoreScript scoreScript;
    public Animator StorkAnimator;
    public DayScript dayScript;
    public float StorkWaitTime;
    public float StorkInterval;

    public SpriteRenderer sprndr;
    public Sprite fly1;
    public Sprite fly2;
    public Sprite Idle;

    float waited;
    float nextinterval;

    bool waiting;
    bool stop;

    float enter;
    float changesprite;

    IEnumerator Leave()
    {
        enter = 0;
        StorkAnimator.SetTrigger("Leave");
        yield return new WaitForSeconds(1);
        dayScript.Storks++;
    }



    // Update is called once per frame
    void Update()
    {
        if (EnterTime < enter)
        {
            sprndr.sprite = Idle;
        }
        else
        {
            enter += Time.deltaTime;
            changesprite += Time.deltaTime;
            if (changesprite >= 0.5)
            {
                changesprite = 0;
                if (sprndr.sprite == fly1)
                {
                    sprndr.sprite = fly2;
                }
                else if (sprndr.sprite == fly2)
                {
                    sprndr.sprite = fly1;
                }
                else
                {
                    sprndr.sprite = fly2;
                }
            }
        }
        if (nextinterval < StorkInterval)
        {
            nextinterval += Time.deltaTime;
            return;
        }
        else if (!waiting)
        {
            StorkAnimator.SetTrigger("Enter");
            enter = 0;
            waited = 0;
            waiting = true;
        }
        if (waiting)
        {
            waited += Time.deltaTime;
        }
        if (waited >= StorkWaitTime)
        {
            waiting = false;
            nextinterval = 0;
            StartCoroutine(Leave());
        }

        if (Input.GetButtonDown("Action"))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + new Vector3(0.5f, -0.5f), InteractionRadius);
            foreach (Collider2D hit in hits)
            {
                if (hit.gameObject.GetComponent<ItemHoldScript>() != null)
                {
                    if (hit.gameObject.GetComponent<ItemHoldScript>().HeldItem == "Baby")
                    {
                        scoreScript.Score += ScorePerBaby;
                        hit.gameObject.GetComponent<ItemHoldScript>().HeldItem = "None";
                    }
                    else if (hit.gameObject.GetComponent<ItemHoldScript>().HeldItem == "Teen" || hit.gameObject.GetComponent<ItemHoldScript>().HeldItem == "DeadBaby")
                    {
                        scoreScript.Score -= ScoreLossPerBadBaby;
                        hit.gameObject.GetComponent<ItemHoldScript>().HeldItem = "None";
                    }
                }
            }
        }
    }
}
