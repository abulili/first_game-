using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Death : MonoBehaviour
{
    [SerializeField] private UnityEvent died;//�������� cavaus
    // ����Һ͵��˶���������
    public void checkDeath(int health)//��Ѫ��
    {
        if (health <= 0) Die();
    }
    public void Die()//�����ر��Ǹ�object
    {
        
        gameObject.SetActive(false);//�ص��Ժ����еĹ��ܶ�������ִ���� �趨�Ǹ�trueҲ��ͬ��
        died.Invoke();
    }

}
