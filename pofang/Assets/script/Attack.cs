using UnityEngine;
using Timers;
using UnityEngine.Events;
public class Attack : MonoBehaviour
{
    private bool _canAttack = true;//避免让玩家瞬间没血
    [SerializeField] private string targetTag;//攻击敌人
    [SerializeField] private UnityEvent attack;
    private void OnTriggerEnter2D(Collider2D collision) //object撞到另一个object就会触发，unity内置的
    {
        /*if (!_canAttack) return;
        //因为挂在敌人身上
        if (collision.CompareTag("Player"))//标签
        {
            var damageable = collision.GetComponent<Damageable>();
            damageable.TakeDamage(1);//损血
            TimersManager.SetTimer(this, 1, CanAttack);//冷却时间 计时器 
            _canAttack = false;//让敌人暂时没法攻击
        }*/
        DealDamage(collision);
    }
    private void CanAttack()
    {
        _canAttack = true;
    }
    //重叠时
    private void OnTriggerStay2D(Collider2D collision)
    {
        /*if (!_canAttack) return;
        if (collision.CompareTag("Player"))//标签
        {
            var damageable = collision.GetComponent<Damageable>();
            damageable.TakeDamage(1);//损血
            TimersManager.SetTimer(this, 1, CanAttack);//冷却时间 计时器
            _canAttack = false;
        }*/
        DealDamage(collision);
    }

    private void DealDamage(Collider2D collision)
    {
        if (!_canAttack) return;
        if (collision.CompareTag(targetTag))//标签 //v0.2可以决定攻击谁了
        {
            var damageable = collision.GetComponent<Damageable>();
            damageable.TakeDamage(1);//损血
            TimersManager.SetTimer(this, 1, CanAttack);//冷却时间 计时器
            _canAttack = false;
            attack.Invoke();
        }
    }
}
