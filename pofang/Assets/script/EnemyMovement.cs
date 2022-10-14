using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.Events;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private UnityEvent<Vector2> moveDirection;
   //[SerializeField] private PlayerManager playerManager;
   private void FixedUpdate()
    {
        var playerPosition = PlayerManager.Position;//�����ˣ�Ҫ����һ�ַ����ҵ�playmanager �����Ϳ���ֱ���ҵ���ҵ�λ����
        var position = (Vector2)transform.position;
        var direction = playerPosition - position;
        direction.Normalize();//����֮�����ֻ�ȽϺü���

        var targetPosition = position + direction;
        rb.DOMove(targetPosition, speed).SetSpeedBased();
        moveDirection.Invoke(direction);//����������֪���֪���еĶ�����˵���ƶ��ˣ�Ҳ����ƶ��ķ�����ߴ��

    }
}
