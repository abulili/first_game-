using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;//˵�������rb��unity player�� ����Ҫץ��ȥ
    private Vector2 _inputDirection;
    [SerializeField] private float _speed;
    public void Move(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();//���������ȡ��context�е�wasd��������vector2�ķ�ʽ�洢��������ά������
       // Debug.Log(inputDirection);//�����������ʾ��unity��concole��inputDirection������ ���̵����ϣ����ǰ������ĸ�
        //compile���� control + shift + b

    }
    private void FixedUpdate()//unity�ڲ����� ������ִ������Ū�ĺü���
    {
        //player->rigidbody 2D �����ý�ɫ����Ϸ�е�������Ӱ��
        //��Ϊÿ��֡����Ҫ�ƶ���ɫ
        //���ڵ�λ��
        var position = (Vector2)transform.position;//ʵ������vector3
        //ָ��λ��
        var targetPosition = position + _inputDirection;

        //���һֱ�����ķ���
        if (position == targetPosition) return;

        //��һ��������ָ���ص���㣺���ڵ�λ��+�ƶ��ķ��� �ڶ���Ϊ�ٶ�
        rb.DOMove(targetPosition, _speed).SetSpeedBased();//��������ǰ����˲�Ƶ�ָ���ص�  ����˵���ٶ�
    }
}
