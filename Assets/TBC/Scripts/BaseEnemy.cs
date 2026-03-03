using UnityEngine;

[System.Serializable]
public class BaseEnemy
{
    public string name;

    public enum Type
    {
           GRASS,
           FIRE,
           WATER,
           ELECTRIC,

    }

    public enum Rarity // For use if I decide to use it for later for something else
    {
        COMMON,
        UNCOMMON,
        RARE,
        EPIC,
        LEGENDARY
    }

    public Type type;
    public Rarity rarity;


    public float baseHp;
    public float curHP;

    public float baseMP;
    public float curMP;

    public float baseATK;
    public float curATK;

    public float baseDEF;
    public float curDEF;
}
