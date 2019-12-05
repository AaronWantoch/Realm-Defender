using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    [SerializeField] Material enemyMaterial;

    [Tooltip("seconds")] [SerializeField] float burnInterval = 3f;
    [SerializeField] int numberOfBurns = 3;

    override public void AdditionalEffect(Enemy enemy)
    {
        enemy.ClearEffect();
        SetEnemyMaterial(enemy, enemyMaterial);
        enemy.affectedBy = this;

        StartCoroutine(Burnning(enemy));
    }


    IEnumerator Burnning(Enemy enemy)
    {
        
        for (int i = 0; i < numberOfBurns; i++)
        {
            if (enemy != null && enemy.affectedBy == this)
            { 
                enemy.DecreaseEnemyHealth(damageDealt);
                yield return new WaitForSeconds(burnInterval);
            }
        }

        if (enemy != null)
            enemy.ClearEffect();
    }
}
