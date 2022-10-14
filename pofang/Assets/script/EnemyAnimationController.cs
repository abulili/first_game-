using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    //负责控制敌人的动画
    [SerializeField] private Animator animator;
    [SerializeField] private string moveState;

    public void Move(Vector2 direction)
    {
        if(direction.x > 0)
        {
            //右边移动
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        animator.Play(moveState);
    }
}
