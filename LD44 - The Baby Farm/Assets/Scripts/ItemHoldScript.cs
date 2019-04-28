using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHoldScript : MonoBehaviour
{
    public string HeldItem;
    public Sprite Baby;
    public Sprite DeadBaby;
    public Sprite Teen;
    public Sprite Seed;
    public Sprite Bottle;
    public Sprite BabyFood;
    public Sprite Shovel;
    public GameObject Board;
    public SpriteRenderer Item;
    public Transform frontpoint;

    public float InteractionBox;

    // Update is called once per frame
    void Update()
    {
        Board.SetActive(true);
        if (HeldItem == "Seed")
        {
            Item.sprite = Seed;
        }
        else if (HeldItem == "Shovel")
        {
            Item.sprite = Shovel;
        }
        else if (HeldItem == "Bottle")
        {
            Item.sprite = Bottle;
        }
        else if (HeldItem == "Food")
        {
            Item.sprite = BabyFood;
        }
        else if (HeldItem == "Baby")
        {
            Item.sprite = Baby;
        }
        else if (HeldItem == "Teen")
        {
            Item.sprite = Teen;
        }
        else if (HeldItem == "DeadBaby")
        {
            Item.sprite = DeadBaby;
        }
        else
        {
            Board.SetActive(false);
        }



        if (Input.GetButtonDown("Action"))
        {
            Collider2D[] areas = Physics2D.OverlapBoxAll(frontpoint.position + new Vector3(-0.5f,0.5f),new Vector2(InteractionBox,InteractionBox),0);
            foreach (Collider2D area in areas)
            {
                if (area.gameObject.GetComponent<PlantScript>())
                {
                    if (area.gameObject.GetComponent<PlantScript>().Status == "Planted")
                    {
                        if (HeldItem == "Bottle" && area.gameObject.GetComponent<PlantScript>().Requirement == "Water")
                        {
                            HeldItem = "";
                            area.gameObject.GetComponent<PlantScript>().water = 100;
                        }
                        else if (HeldItem == "Food" && area.gameObject.GetComponent<PlantScript>().Requirement == "Feed")
                        {
                            HeldItem = "";
                            area.gameObject.GetComponent<PlantScript>().food = 100;
                        }
                        else if (HeldItem == "Shovel" && area.gameObject.GetComponent<PlantScript>().Requirement == "Harvest")
                        {
                            if (area.gameObject.GetComponent<PlantScript>().growth > 150)
                            {
                                HeldItem = "Teen";
                            }
                            else if (area.gameObject.GetComponent<PlantScript>().dead)
                            {
                                HeldItem = "DeadBaby";
                            }
                            else
                            {
                                HeldItem = "Baby";
                            }
                            if (area.gameObject.GetComponent<PlantScript>().growth < 100 && !area.gameObject.GetComponent<PlantScript>().dead)
                            {
                                HeldItem = "Shovel";
                                return;
                            }
                            area.gameObject.GetComponent<PlantScript>().Status = "Empty";
                        }
                    }
                    else if (HeldItem == "Seed")
                    {
                        if (area.gameObject.GetComponent<PlantScript>().Status == "Empty")
                        {
                            HeldItem = "";
                            area.gameObject.GetComponent<PlantScript>().Status = "Planted";
                        }
                    }
                }
            }
        }
    }
}
