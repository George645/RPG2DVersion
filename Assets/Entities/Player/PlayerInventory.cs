using System.Collections;
using UnityEngine;

public class PlayerInventory : MonoBehaviour{
    // Declare the ArrayList
    [SerializeField]private ArrayList itemList;

    void Start(){
        itemList = new ArrayList();
    }
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
