using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //ץ����ҵ�λ���Ժ��������ű�ȥȡ����ҵ�λ��
    //��player�ϵ�manage�����������ʹ��player���ϵ�transform
    [SerializeField] private Transform playerTransform;
    private static PlayerManager _instance;
    public static Vector2 Position
    {
        get { return (Vector2)_instance.playerTransform.position; }//�κνű�����positionʱ���Ϳ���iȡ����ҵ�λ��
    }
    private void Awake()
    {
        _instance = this;//v0.2
    }
}
