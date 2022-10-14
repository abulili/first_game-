using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
public class Damageable : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private SpriteRenderer spriteRenderer;//֪�����˺���
    [SerializeField] private UnityEvent damaged;
     private Color _defaultColor;//�洢ԭ������ɫv0.2
    public void TakeDamage(int damage)//�������ű��������������ʱ��Ϳ��ԶԽ�ɫ����˺�
    {
        health.DecreaseHealth(damage);
        spriteRenderer.DOColor(Color.red, 0.2f).SetLoops(2, LoopType.Yoyo).ChangeStartValue(_defaultColor);//Ҫת�����ɫ ����ת��,�ٱ����,�쵽��һȦ�����ٵ�����Ȧ ����ת���� ��ʼ��ɫ
        damaged.Invoke();
    }
    private void Awake()//v0.2
    {
        _defaultColor = spriteRenderer.color;
    }
}
