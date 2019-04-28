using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public string Status;
    public string Requirement;
    public SpriteRenderer spriteRenderer;
    public Sprite DeadBaby;

    public float StartPercent;
    public float hungerWarning;
    public float waterWarning;
    public float waterLossASecond;
    public float hungerPerSecond;
    public float growthSpeed;
    public float water;
    public float food;
    public float growth;

    public List<Sprite> GrowthStages;
    public List<float> RequiredGrowth;

    public bool dead;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        foreach (float amount in RequiredGrowth)
        {
            if (growth >= amount)
            {
                spriteRenderer.sprite = GrowthStages[RequiredGrowth.IndexOf(amount)];
            }
        }
        Requirement = "None";
        if (Status == "Planted")
        {
            if (!dead)
            {
                growth += growthSpeed * Time.deltaTime;
                food -= hungerPerSecond * Time.deltaTime;
                water -= waterLossASecond * Time.deltaTime;
            }
            else
            {
                spriteRenderer.sprite = DeadBaby;
                Requirement = "Harvest";
                return;
            }
            if (food <= 0 || water <= 0)
            {
                dead = true;
            }
            if (growth >= 100)
            {
                Requirement = "Harvest";
            }
            else if (food <= hungerWarning)
            {
                Requirement = "Feed";
            }
            else if (water <= waterWarning)
            {
                Requirement = "Water";
            }
        }
        else
        {
            dead = false;
            growth = 0;
            water = StartPercent;
            food = StartPercent;
            Requirement = "None";
            Status = "Empty";
        }
    }
}
