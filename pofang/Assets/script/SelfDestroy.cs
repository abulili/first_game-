using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    //���ӵ����ڵ��˺���ʧ
    public void Destroy()
    {
        Destroy(gameObject);//���ڷɵ��� �ݻ��ӵ����� �ӵ��Ե��˽��й���ʱ�ݻ��ӵ�->attack
    }
}
