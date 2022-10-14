using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
public class Damageable : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private SpriteRenderer spriteRenderer;//知道被伤害了
    [SerializeField] private UnityEvent damaged;
     private Color _defaultColor;//存储原本的颜色v0.2
    public void TakeDamage(int damage)//当其它脚本呼叫这个方法的时候就可以对角色造成伤害
    {
        health.DecreaseHealth(damage);
        spriteRenderer.DOColor(Color.red, 0.2f).SetLoops(2, LoopType.Yoyo).ChangeStartValue(_defaultColor);//要转变的颜色 几秒转换,再变回来,红到白一圈，白再到红两圈 慢慢转换， 起始颜色
        damaged.Invoke();
    }
    private void Awake()//v0.2
    {
        _defaultColor = spriteRenderer.color;
    }
}
