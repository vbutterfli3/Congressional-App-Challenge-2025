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
    public TextMeshProUGUI PlayerMoney;
    public Image seeds;
    public Image pot;

    public int potOneState = 0;
    public bool isWatering = false;
    public bool isGetFact = false;
    public int money;
    public TextMeshProUGUI Fact;
    public GameObject popUp;

    public float sproutTime;
    public float potTime;

    private void Start()
    {
        PlayerMoney.text = "$" + money.ToString();
    }
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
        if (Flowers[Index].Cost <= money)
        {
            money -= Flowers[Index].Cost;
            Inventory.Add(Flowers[Index]);
            PlayerMoney.text = "$" + money.ToString();

        } }

    public void closePopup() {
    popUp.SetActive (false);
    }

    public void IsGetFact() {
        isGetFact = true;
    }

    public void PlantAction(PotData data) {

        if(data.State != 0 && isGetFact)
        {
            popUp.SetActive (true);
            if (data.State == 1)
            {

                Fact.text = data.Flower.fact1;
            }
            if (data.State == 2 || data.State == 3)
            {

                Fact.text = data.Flower.fact2;
            }
            isGetFact = false;

        }

        if(data.State == 0 && Inventory.Count > 0)
        {
            data.Water.enabled = true;
            data.thepot.sprite = Inventory[0].seed;
            data.Flower = Inventory[0];  
            Inventory.RemoveAt(0);
            data.State = 1;
        }
        if (data.State == 1 && isWatering)
        {
            data.Water.enabled = false;
            isWatering = false;
            StartCoroutine(WaitAndSprout(data));
        }
        if(data.State == 2 && isWatering)
        {
            data.Water.enabled = false;
            isWatering = false;
            StartCoroutine(WaitAndFlower(data));
        }

        if (data.State == 3)
        {
            data.State = 4;
        }
        if(data.State == 4)
        {
            money += data.Flower.Sell;
            PlayerMoney.text = "$"+ money.ToString();
            data.potanddirt.sprite = data.dirt;
            data.thepot.sprite = data.blank;
            data.State = 0;
        }
    }

    IEnumerator WaitAndSprout(PotData data)
    {

            yield return new WaitForSeconds(data.Flower.sproutTime); // wait for 10 seconds
        if (data.State == 1)
        {
            data.thepot.sprite = data.Flower.sprout;
            data.State = 2;
            data.Water.enabled = true;
        }
    }
    IEnumerator WaitAndFlower(PotData data)
    {
            yield return new WaitForSeconds(data.Flower.potTime); // wait for 30 seconds
        if (data.State == 2)
        {
            data.thepot.sprite = data.Flower.flower;
            data.State = 3;
            data.potanddirt.sprite = data.potsell;
        }
    }


    public void GetWater() {
        isWatering = true;
    }

}
