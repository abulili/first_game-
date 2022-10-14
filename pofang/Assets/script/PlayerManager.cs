using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //抓到玩家的位置以后，让其他脚本去取得玩家的位置
    //把player拖到manage里，这样就是在使用player身上的transform
    [SerializeField] private Transform playerTransform;
    private static PlayerManager _instance;
    public static Vector2 Position
    {
        get { return (Vector2)_instance.playerTransform.position; }//任何脚本呼叫position时，就可以i取得玩家的位置
    }
    private void Awake()
    {
        _instance = this;//v0.2
    }
}
