using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //在gameover时要控制时间暂停
    public void Stop()
    {
        Time.timeScale = 0;
    }
    public void Resume()//restart后时间再次流逝
    {
        Time.timeScale = 1;
    }
}
