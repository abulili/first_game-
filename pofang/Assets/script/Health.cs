using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    //因为希望在unity的inspector去调整他的数字
    [SerializeField] private int health;
    [SerializeField] private UnityEvent<int> healthChanged;//告知血量减少
    
    public int value
    {
        get { return health; }
    }
    public void DecreaseHealth(int amount)
    {
        health -= amount;
        healthChanged.Invoke(health);//呼叫血量改变
    }
}
