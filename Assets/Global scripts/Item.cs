public class Item{
    public enum Rarity{
        common, uncommon, rare, epic, legendary, mythic
    }
    int? requiredStrength, requiredDexterity, requiredIntelligence;
    int weight, price;
    string name, description;
    Rarity rarity;
    public Item(string name, string description, int price, int weight, int? requiredStrength = null, int? requiredDexterity = null, int? requiredIntelligence = null){
        this.requiredStrength = requiredStrength;
        this.requiredIntelligence = requiredIntelligence;
        this.requiredDexterity = requiredDexterity;
        this.name = name;
        this.description = description;
        this.price = price;
        this.weight = weight;
    }
    public void canAllyUse(Entity Ally){
        if (requiredStrength != null){
         //   if Ally.
        }
    }
}