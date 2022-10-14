using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealthUI : MonoBehaviour
{
    //��Ҫ֪��slider����Ϣ
    [SerializeField] private Slider healthBar;
    [SerializeField] private Health health;

    //����Ѫ��
    public void UpdateUI()
    {
        healthBar.value = health.value;
    }
    private void Awake()//�ս�����Ϸ�������¼�
    {
        healthBar.maxValue = health.value;//��slider�����ֵ=health bar����ʼֵ
        healthBar.value = health.value;
    }
}
