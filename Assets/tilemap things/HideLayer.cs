using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
public class HideLayer : MonoBehaviour{
    public void Start(){
        TilemapRenderer tilemap = GetComponent<TilemapRenderer>();
        tilemap.enabled = false;
    }
}