using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour{
    // Declare the ArrayList
    public List<Item> itemList;

    public void AddItem(Item item){
        itemList.Add(item);
    }
    public void DeleteItem(Item item){
        if (itemList.Contains(item)){
            itemList.Remove(item);
        }
        else{
            Debug.Log($"Item not found: {item}");
        }
    }
    public void DisplayInventory(){
        Debug.Log("Inventory This has not been added yet");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayInventory();
        }
    }
}
