using UnityEngine;
using Timers;
using UnityEngine.Events;
public class Attack : MonoBehaviour
{
    private bool _canAttack = true;//���������˲��ûѪ
    [SerializeField] private string targetTag;//��������
    [SerializeField] private UnityEvent attack;
    private void OnTriggerEnter2D(Collider2D collision) //objectײ����һ��object�ͻᴥ����unity���õ�
    {
        /*if (!_canAttack) return;
        //��Ϊ���ڵ�������
        if (collision.CompareTag("Player"))//��ǩ
        {
            var damageable = collision.GetComponent<Damageable>();
            damageable.TakeDamage(1);//��Ѫ
            TimersManager.SetTimer(this, 1, CanAttack);//��ȴʱ�� ��ʱ�� 
            _canAttack = false;//�õ�����ʱû������
        }*/
        DealDamage(collision);
    }
    private void CanAttack()
    {
        _canAttack = true;
    }
    //�ص�ʱ
    private void OnTriggerStay2D(Collider2D collision)
    {
        /*if (!_canAttack) return;
        if (collision.CompareTag("Player"))//��ǩ
        {
            var damageable = collision.GetComponent<Damageable>();
            damageable.TakeDamage(1);//��Ѫ
            TimersManager.SetTimer(this, 1, CanAttack);//��ȴʱ�� ��ʱ��
            _canAttack = false;
        }*/
        DealDamage(collision);
    }

    private void DealDamage(Collider2D collision)
    {
        if (!_canAttack) return;
        if (collision.CompareTag(targetTag))//��ǩ //v0.2���Ծ�������˭��
        {
            var damageable = collision.GetComponent<Damageable>();
            damageable.TakeDamage(1);//��Ѫ
            TimersManager.SetTimer(this, 1, CanAttack);//��ȴʱ�� ��ʱ��
            _canAttack = false;
            attack.Invoke();
        }
    }
}
