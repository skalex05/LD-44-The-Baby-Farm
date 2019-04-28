using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementScript : MonoBehaviour
{
    public PlantScript PScript;
    public GameObject board;
    public SpriteRenderer requirement;
    public Sprite Bottle;
    public Sprite BabyFood;
    public Sprite Shovel;

    // Update is called once per frame
    void Update()
    {
        board.SetActive(true);
        if (PScript.Requirement == "Water")
        {
            requirement.sprite = Bottle;
        }
        else if (PScript.Requirement == "Feed")
        {
            requirement.sprite = BabyFood;
        }
        else if (PScript.Requirement == "Harvest")
        {
            requirement.sprite = Shovel;
        }
        else
        {
            board.SetActive(false);
        }
    }
}
