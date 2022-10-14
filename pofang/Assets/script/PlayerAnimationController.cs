using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationController : MonoBehaviour
{
    //������ҵĶ���
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer SpriteRenderer;
    [SerializeField] private string walkState;
    [SerializeField] private string idleState;
    [SerializeField] private string attackState;

    public void Move(InputAction.CallbackContext context)
    {
        //֮ǰ����������ƶ���������������ƶ���
        var direction = context.ReadValue<Vector2>();
        if(direction == Vector2.zero)
        {
            animator.Play(idleState);
        }
        else
        {
            animator.Play(walkState);
        }
        //�����ɫ��������
        if(direction.x > 0)
        {
            SpriteRenderer.flipX = false;//��ͼ�ν����
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
