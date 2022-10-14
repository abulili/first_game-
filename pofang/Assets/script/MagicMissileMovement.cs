using UnityEngine;
using DG.Tweening;
public class MagicMissileMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 _direction;
    private GameObject LocateEnemy()//�Զ��ɵ�
    {
        var results = new Collider2D[5];
        //��Բ���Բ��object
        Physics2D.OverlapCircleNonAlloc(transform.position, 10, results);

        foreach (var result in results)//����һ���е��˵�tag�Ͷ�������˺�
        {
            if (result != null && result.CompareTag("Enemy"))
            {
                return result.gameObject;
            }
        }
        return null;//��Ȼ���Ǻ�ϰ�ߣ�����������д
    }

    private Vector2 MoveDirection(Transform target)//�����ӵ��ƶ��ķ���
    {
        var direction = new Vector2(1, 0);//�ȸ�������
        if(target != null)
        {
            //�����ƶ��ķ��� Ŀ�ĵ�-��ʼ��
            direction = target.position - transform.position;
            direction.Normalize();
        }
        return direction;
    }

    private void Awake()//����Ϸһ��ʼ�ͻ������˵�λ�� ����������һ��ʼ��perfab�����Ƴ�����˲��
    {
        var enemy = LocateEnemy();
        if (enemy == null)
            _direction = MoveDirection(null);
        else _direction = MoveDirection(enemy.transform);
        //�����ӵ���ͷ��������Ե���
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _direction);//��ת ��һ�������� �ڶ�������������Ϳ��Ա�֤�ӵ���ͷ�ǳ�����˵�
    }
    private void FixedUpdate()
    {
        //�ƶ��ĵص� = �ӵ����ڵ�λ�� + �ƶ��ķ���
        var targetPosition = (Vector2)transform.position + _direction;
        rb.DOMove(targetPosition,speed).SetSpeedBased();
    }
}
