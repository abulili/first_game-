using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    //��Ϊϣ����unity��inspectorȥ������������
    [SerializeField] private int health;
    [SerializeField] private UnityEvent<int> healthChanged;//��֪Ѫ������
    
    public int value
    {
        get { return health; }
    }
    public void DecreaseHealth(int amount)
    {
        health -= amount;
        healthChanged.Invoke(health);//����Ѫ���ı�
    }
}
