using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCreator : MonoBehaviour
{
    //���ɷɵ�
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform playerTransform;//��ҵ�λ�� 
    public void CreateMissile()
    {
        Instantiate(missilePrefab,playerTransform.position,Quaternion.identity);//����ħ���ɵ� ���һ������ת
    }
}
