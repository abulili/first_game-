using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    //让子弹大众敌人后消失
    public void Destroy()
    {
        Destroy(gameObject);//挂在飞弹上 摧毁子弹本身 子弹对敌人进行攻击时摧毁子弹->attack
    }
}
