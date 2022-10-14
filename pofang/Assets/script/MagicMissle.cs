using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;
using UnityEngine.Events;
public class MagicMissle : MonoBehaviour
{
    //每隔一段时间创造魔法飞弹
    //呼叫missilecreator
    [SerializeField] private MissileCreator creator;
    [SerializeField] private UnityEvent missileLaunch;  
    private void LaunchMissile()
    {
        creator.CreateMissile();
        missileLaunch.Invoke();
    }
    private void Awake()
    {
        // LaunchMissile();能发一个
        TimersManager.SetLoopableTimer(this, 1,LaunchMissile);//不断重复倒数计时
    }
}
