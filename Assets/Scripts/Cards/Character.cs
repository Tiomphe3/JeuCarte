using System.Collections.Generic;
using SinuousProductions;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Card", menuName = "Card/Character")]
public class Character : Card
{
    public int health;
    public int damageMin;
    public int damageMax;
    public List<ElementType> damageType;
    public GameObject prefab;
    public int range;
    public AttackPattern attackPattern;
    public PriorityTarget priorityTarget;

    public void Attack(Character target)
    {
        int damage = Random.Range(damageMin, damageMax);
        target.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log($"{cardName} est vaincu !");
        }
    }
}
