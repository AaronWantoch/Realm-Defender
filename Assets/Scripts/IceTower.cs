using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower
{
    [SerializeField] Material enemyMaterial;

    [SerializeField] float newSpeed = 2f;
    [Tooltip("seconds")] [SerializeField] float effectLength = 3f;

    override public void AdditionalEffect(Enemy enemy)
    {
        enemy.ClearEffect();
        SetEnemyMaterial(enemy, enemyMaterial);
        enemy.affectedBy = this;

        StartCoroutine(Freeze(enemy));
    }

    IEnumerator Freeze(Enemy enemy)
    {

        float oldSpeed = enemy.moveSpeed;
        enemy.moveSpeed = newSpeed;

        yield return new WaitForSeconds(effectLength);

        if (enemy != null)
        {
            enemy.ClearEffect();
        }  
    }
}
