using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    //������Ƶ��˵Ķ���
    [SerializeField] private Animator animator;
    [SerializeField] private string moveState;

    public void Move(Vector2 direction)
    {
        if(direction.x > 0)
        {
            //�ұ��ƶ�
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        animator.Play(moveState);
    }
}
