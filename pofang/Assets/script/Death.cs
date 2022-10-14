using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Death : MonoBehaviour
{
    [SerializeField] private UnityEvent died;//死亡窗口 cavaus
    // 让玩家和敌人都可以死亡
    public void checkDeath(int health)//查血量
    {
        if (health <= 0) Die();
    }
    public void Die()//单纯关闭那个object
    {
        
        gameObject.SetActive(false);//关掉以后所有的功能都不会再执行了 设定那个true也是同理
        died.Invoke();
    }

}
