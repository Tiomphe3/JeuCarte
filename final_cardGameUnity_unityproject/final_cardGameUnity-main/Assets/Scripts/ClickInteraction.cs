using UnityEngine;

public class ClickInteraction : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit.collider != null && hit.collider.TryGetComponent<CharacterStats>(out var targetStats))
            {
                GameManager gm = GameManager.Instance;
                CharacterStats c = gm.CurrentSelectionnedCard;

                if (c != null)
                {
                    c.IsSelected = !c.IsSelected;

                    if ((c._playerOwner != GameManager.Instance.CurrentPlayer) ||  (c == targetStats) || (c._playerOwner == targetStats._playerOwner)) return;

                    if (((c.attackPattern.ToString() == "Column") || (c.attackPattern.ToString() == "Cross")) &&
                        (Mathf.Abs(c.GridCell.gridIndex.x - targetStats.GridCell.gridIndex.x) == 0) &&
                        (Mathf.Abs(c.GridCell.gridIndex.y - targetStats.GridCell.gridIndex.y) <= c.characterStartData.range))
                    {
                        int damageDealed = Mathf.Clamp(c.Damage, 0, targetStats.health);

                        targetStats.health -= damageDealed;
                        gm.SetPlayerHealth(targetStats._playerOwner, gm.PlayersHealth[targetStats._playerOwner] - damageDealed);
                        if (c.passive.ToString() == "Relentless") {
                            targetStats.health -= damageDealed;
                            gm.SetPlayerHealth(targetStats._playerOwner, gm.PlayersHealth[targetStats._playerOwner] - damageDealed);
                        }

                        GameManager.Instance.NextTurn(false);
                    }

                    else if (((c.attackPattern.ToString() == "Row") || (c.attackPattern.ToString() == "Cross")) &&
                        (Mathf.Abs(c.GridCell.gridIndex.y - targetStats.GridCell.gridIndex.y) == 0) &&
                        (Mathf.Abs(c.GridCell.gridIndex.x - targetStats.GridCell.gridIndex.x) <= c.characterStartData.range))
                    {
                        int damageDealed = Mathf.Clamp(c.Damage, 0, targetStats.health);
                        
                        targetStats.health -= damageDealed;
                        gm.SetPlayerHealth(targetStats._playerOwner, gm.PlayersHealth[targetStats._playerOwner] - damageDealed);
                        if (c.passive.ToString() == "Relentless") {
                            targetStats.health -= damageDealed;
                            gm.SetPlayerHealth(targetStats._playerOwner, gm.PlayersHealth[targetStats._playerOwner] - damageDealed);
                        }

                        GameManager.Instance.NextTurn(false);
                    }

                    else
                        return;
                }
                else
                    targetStats.IsSelected = !targetStats.IsSelected;
            }
        }
    }
}
