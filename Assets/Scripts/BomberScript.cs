using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberScript : EnemyBehavior
{
    
    Vector2 bomberMove;



    public override void EnemyMove()
    {
        bomberMove = Vector2.down;

        eRB.MovePosition(eRB.position + (bomberMove * speed) * Time.fixedDeltaTime);
    }

    public override void KillEntity()
    {
        EnemyLives -= 1;

        Debug.Log("Enemy killed, call event to decrease Bomber count");
    }
}
