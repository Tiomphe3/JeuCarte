using System.Collections.Generic;
using SinuousProductions;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Card", menuName = "Card/Spell")]
public class Spell : Card
{
    public SpellType spellType;
    public List<AttributeTarget> attributeTarget;
    public List<int> attributeChangeAmount;
    public AttackPattern attackPatternToChangeTo;
    public ElementType damageTypeToChangeTo;
    public ElementType cardTypeToChangeTo;
    public PriorityTarget priorityTargetToChangeTo;

    public void CastSpell(List<Character> targets)
    {
        foreach (var target in targets)
        {
            // Appliquer les effets du sort
            if (spellType == SpellType.Buff)
            {
                // Logique pour appliquer un buff (exemple)
                target.health += attributeChangeAmount[0]; // Exemple d'augmentation de la santé
                Debug.Log($"{target.cardName} a été buffé !");
            }
            else if (spellType == SpellType.Debuff)
            {
                // Logique pour appliquer un debuff (exemple)
                target.health -= attributeChangeAmount[0]; // Exemple de réduction de la santé
                Debug.Log($"{target.cardName} a été debuffé !");
            }
        }
    }
}
