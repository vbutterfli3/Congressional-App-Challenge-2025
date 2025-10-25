using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotData : MonoBehaviour
{
    public int State = 0;
    public FlowerData Flower;
    public Image thepot;
    public Image Water;
    public Sprite potsell;
    public Sprite dirt;
    public Image potanddirt;
    public Sprite blank;
    
    // Start is called before the first frame update
    void Start()
    {
        Water.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
