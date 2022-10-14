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
        var playerPosition = PlayerManager.Position;//报错了，要用另一种方法找到playmanager 这样就可以直接找到玩家的位置了
        var position = (Vector2)transform.position;
        var direction = playerPosition - position;
        direction.Normalize();//这样之后数字会比较好计算

        var targetPosition = position + direction;
        rb.DOMove(targetPosition, speed).SetSpeedBased();
        moveDirection.Invoke(direction);//这样，他不知会告知所有的订阅者说他移动了，也会把移动的方向告诉大家

    }
}
