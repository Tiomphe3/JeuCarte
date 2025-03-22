using SinuousProductions;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterStats : MonoBehaviour
{
    public Character characterStartData;

    public string cardName;
    public List<Card.ElementType> cardType;

    public int health
    {
        get => _health;
        set
        {
            if (healthInit && !hasAbsorded && (characterStartData.passive == Card.Passive.Absorbe))
            {
                hasAbsorded = true;
                return;
            }

            healthInit = true;
            _health = value;
            if (_health <= 0)
            {
                if (!hasRevived && (characterStartData.passive == Card.Passive.Revive))
                {
                    hasRevived = true;
                    _health = characterStartData.health;
                }
                else
                    Die();
            }

            if (toolTip != null)
                toolTip.tooltip.SetStatsText(this);
        }
    }

    public int damageMin;
    public int damageMax;
    public List<Card.ElementType> damageType;
    public int range;
    public Card.AttackPattern attackPattern;
    public Card.Passive passive;
    public Card.PriorityTarget priorityTarget;
    public int _playerOwner = -1;
    private bool hasRevived = false;
    private bool hasAbsorded = false;
    private bool healthInit = false;

    private CharacterTooltip toolTip;

    public int Damage { get => Random.Range(damageMin, damageMax + 1); }

    public GridCell GridCell { get => transform.parent.GetComponent<GridCell>(); }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;

            if (value)
            {
                if (GameManager.Instance.CurrentSelectionnedCard != null)
                    GameManager.Instance.CurrentSelectionnedCard.IsSelected = false;

                GameManager.Instance.CurrentSelectionnedCard = this;
                _defaultScale = transform.localScale;
                transform.localScale = _defaultScale * 1.25f;
            }
            else
            {
                if (GameManager.Instance.CurrentSelectionnedCard == this)
                    GameManager.Instance.CurrentSelectionnedCard = null;

                transform.localScale = _defaultScale;
            }

        } 
    }

    private Vector3 _defaultScale;
    private bool _isSelected;
    private int _health;
    private bool statsSet = false;

    public void RefreshUI() => toolTip.tooltip.SetStatsText(this);

    void Update()
    {
        if (!statsSet && characterStartData != null)
        {
            SetStartStats();
        }
    }

    private void SetStartStats()
    {
        cardName = characterStartData.cardName;
        cardType = characterStartData.cardType;
        health = characterStartData.health;
        damageMin = characterStartData.damageMin;
        damageMax = characterStartData.damageMax;
        damageType = characterStartData.damageType;
        range = characterStartData.range;
        attackPattern = characterStartData.attackPattern;
        passive = characterStartData.passive;
        _playerOwner = GameManager.Instance.NextPlayer;
        statsSet = true;
    }

    private void Awake()
    {
        toolTip = GetComponent<CharacterTooltip>();
    }

    private void Die()
    {
        toolTip.tooltip.canvasGroup.alpha = 0;

        GameManager.Instance.DiscardManager.AddToDiscard(characterStartData);

        GridCell cell = transform.parent.GetComponent<GridCell>();
        cell.objectInCell = null;
        cell.cellFull = false;
        Destroy(gameObject);
    }
}
