using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;
using UnityEngine.Events;
public class MagicMissle : MonoBehaviour
{
    //ÿ��һ��ʱ�䴴��ħ���ɵ�
    //����missilecreator
    [SerializeField] private MissileCreator creator;
    [SerializeField] private UnityEvent missileLaunch;  
    private void LaunchMissile()
    {
        creator.CreateMissile();
        missileLaunch.Invoke();
    }
    private void Awake()
    {
        // LaunchMissile();�ܷ�һ��
        TimersManager.SetLoopableTimer(this, 1,LaunchMissile);//�����ظ�������ʱ
    }
}
