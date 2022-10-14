using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationController : MonoBehaviour
{
    //控制玩家的动画
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer SpriteRenderer;
    [SerializeField] private string walkState;
    [SerializeField] private string idleState;
    [SerializeField] private string attackState;

    public void Move(InputAction.CallbackContext context)
    {
        //之前用这个控制移动，现在用这个控制动画
        var direction = context.ReadValue<Vector2>();
        if(direction == Vector2.zero)
        {
            animator.Play(idleState);
        }
        else
        {
            animator.Play(walkState);
        }
        //解决角色朝向问题
        if(direction.x > 0)
        {
            SpriteRenderer.flipX = false;//由图形界面得
        }
        else if(direction.x < 0)
        {
            SpriteRenderer.flipX = true;
        }
    }

    public void Attack()
    {
        animator.Play(attackState);
    }
}
