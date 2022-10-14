using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCreator : MonoBehaviour
{
    //生成飞弹
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform playerTransform;//玩家的位置 
    public void CreateMissile()
    {
        Instantiate(missilePrefab,playerTransform.position,Quaternion.identity);//复制魔法飞弹 最后一个是旋转
    }
}
