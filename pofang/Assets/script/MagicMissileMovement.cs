using UnityEngine;
using DG.Tweening;
public class MagicMissileMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 _direction;
    private GameObject LocateEnemy()//自动飞弹
    {
        var results = new Collider2D[5];
        //画圆检测圆中object
        Physics2D.OverlapCircleNonAlloc(transform.position, 10, results);

        foreach (var result in results)//看哪一个有敌人的tag就对其造成伤害
        {
            if (result != null && result.CompareTag("Enemy"))
            {
                return result.gameObject;
            }
        }
        return null;//虽然不是好习惯，但在这里先写
    }

    private Vector2 MoveDirection(Transform target)//计算子弹移动的方向
    {
        var direction = new Vector2(1, 0);//先给个方向
        if(target != null)
        {
            //计算移动的方向 目的地-起始地
            direction = target.position - transform.position;
            direction.Normalize();
        }
        return direction;
    }

    private void Awake()//在游戏一开始就会侦测敌人的位置 更正，不是一开始，perfab被复制出来那瞬间
    {
        var enemy = LocateEnemy();
        if (enemy == null)
            _direction = MoveDirection(null);
        else _direction = MoveDirection(enemy.transform);
        //调整子弹的头，让他面对敌人
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _direction);//旋转 第一个：方向 第二个参数填这个就可以保证子弹的头是朝向敌人的
    }
    private void FixedUpdate()
    {
        //移动的地点 = 子弹现在的位置 + 移动的方向
        var targetPosition = (Vector2)transform.position + _direction;
        rb.DOMove(targetPosition,speed).SetSpeedBased();
    }
}
