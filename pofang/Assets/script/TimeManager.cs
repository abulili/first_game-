using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //��gameoverʱҪ����ʱ����ͣ
    public void Stop()
    {
        Time.timeScale = 0;
    }
    public void Resume()//restart��ʱ���ٴ�����
    {
        Time.timeScale = 1;
    }
}
