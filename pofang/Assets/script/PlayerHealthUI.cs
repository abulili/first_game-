using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealthUI : MonoBehaviour
{
    //需要知道slider的信息
    [SerializeField] private Slider healthBar;
    [SerializeField] private Health health;

    //更新血条
    public void UpdateUI()
    {
        healthBar.value = health.value;
    }
    private void Awake()//刚进入游戏发生的事件
    {
        healthBar.maxValue = health.value;//让slider的最大值=health bar的起始值
        healthBar.value = health.value;
    }
}
