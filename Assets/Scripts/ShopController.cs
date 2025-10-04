using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

    public GameObject Shop;
    public GameObject Field;
    public List <FlowerData> Flowers = new List <FlowerData> ();
    public int Index = 0;
    public List<FlowerData> Inventory = new List<FlowerData>();

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Cost;
    public Image seeds;
    public Image pot;

    public int potOneState = 0;
    public bool isWatering = false;

    public void MoveRight()
    {
        Index++;
        if (Index == Flowers.Count)
        {
            Index = 0;
        }
        UpdateUi();

    }
    public void MoveLeft()
    {
        Index--;
        if (Index <0)
        {
            Index = Flowers.Count -1;
        }
        UpdateUi();

    }

    public void UpdateUi() {
        Name.text = Flowers[Index].Name + " Seeds";
        Cost.text = "Cost $" + Flowers[Index].Cost;
        seeds.sprite = Flowers[Index].seed;

    }

    public void EnterShop() { 
    Shop.SetActive (true);
        Field.SetActive(false);
    }

    public void ExitShop() {
        Field.SetActive(true);
        Shop.SetActive (false);
    }

    public void Buy() { 
    Inventory.Add (Flowers[Index]);

    }

    public void PlantAction(PotData data) {
        if(data.State == 0)
        {
            pot.sprite = Inventory[0].seed;
            data.Flower = Inventory[0];  
            Inventory.RemoveAt(0);
            data.State = 1;
        }
        if (data.State == 1 && isWatering)
        {
            isWatering = false;
            pot.sprite = data.Flower.flower;
            data.State = 2;
        }
    }

    public void GetWater() {
        isWatering = true;
    }

}
