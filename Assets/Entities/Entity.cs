using UnityEngine;

public class Entity : MonoBehaviour
{
    private protected int health, baseAttack;
    public new string name;

    public Entity(string name, int health, int baseAttack /*There will be more once I have done the item class*/)
    {
        this.name = name;
        this.health = health;
        this.baseAttack = baseAttack;
    }
}
