using UnityEngine;
using TMPro;

public class DisplayGold : MonoBehaviour
{
    public GameObject inventory;
    public int displayGold;

    void Start()
    {
        SetGold();
    }

    void Update()
    {
        UpdateGold();
    }

    public void UpdateGold()
    {
        displayGold = inventory.GetComponent<Inventory>().inventory.resources.gold;
        this.GetComponent<TextMeshProUGUI>().text = displayGold.ToString() + '$';
    }

    public void SetGold()
    {
        displayGold = inventory.GetComponent<Inventory>().inventory.resources.gold;
    }
}
