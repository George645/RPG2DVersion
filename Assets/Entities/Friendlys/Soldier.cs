using UnityEngine;
public class Soldier : Entity{
    [SerializeField]int  /*baseAttack = 5, dexterity = 5, strength = 5, */constitution = 5;
    int /*level = 0, experience = 0,*/ health, maxhealth;
    public int orderInArmy = 0;
    public int orderInLine = 0;
    [SerializeField] Player player;
    public bool selected = false;
    private LineRenderer lr;
    [SerializeField] bool canPlayerControl;
    private float healthHeight = 1f;
    //Ability ability
    //string dialogue option? so that the player can interact with them
    private void Start(){
        if (canPlayerControl)
        {
            //level = level;
            //experience = experience;
            //strength = strength;
            //dexterity = dexterity;
            //constitution = constitution;
            //baseattack = baseattack;
            health = constitution * 10; ;
            maxhealth = health;
            player.AddSoldier(this);
            orderInArmy = player.totalSoldiers;
            try
            {
                lr = GetComponent<LineRenderer>();
            }
            catch
            {
                lr = new LineRenderer();
                lr = GetComponent<LineRenderer>();
            }
            lr.positionCount = 2;
            lr.SetPosition(0, new Vector3(-1f, healthHeight));
            lr.startColor = Color.red;
            lr.endColor = Color.red;
        }
    }
    void Update()
    {
        if (canPlayerControl)
        {
            lr.SetPosition(1, new Vector3((health*2 / maxhealth)-1, healthHeight));
        }
    }
}