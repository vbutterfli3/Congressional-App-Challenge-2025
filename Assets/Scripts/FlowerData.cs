using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class FlowerData : MonoBehaviour
{
    public string Name;
    public int Cost;
    public int Sell;
    public Sprite flower;
    public Sprite seed;
    public Sprite dead;
      

    public FlowerData(FlowerData newFlower)
    {
        name = newFlower.Name;
        Cost = newFlower.Cost;
        Sell = newFlower.Sell;
        flower = newFlower.flower;
        seed = newFlower.seed;
        dead = newFlower.dead;
    }
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
