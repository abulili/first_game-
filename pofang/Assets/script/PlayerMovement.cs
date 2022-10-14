using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;//说明这里的rb是unity player的 ，还要抓过去
    private Vector2 _inputDirection;
    [SerializeField] private float _speed;
    public void Move(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();//用这个方法取出context中的wasd方法，以vector2的方式存储起来（二维向量）
       // Debug.Log(inputDirection);//把这个资料显示在unity的concole（inputDirection）上面 键盘的资料（就是按键是哪个
        //compile程序 control + shift + b

    }
    private void FixedUpdate()//unity内部方法 几毫秒执行里卖弄的好几次
    {
        //player->rigidbody 2D 可以让角色被游戏中的物理法则影响
        //因为每几帧就需要移动角色
        //现在的位置
        var position = (Vector2)transform.position;//实际他是vector3
        //指定位置
        var targetPosition = position + _inputDirection;

        //解决一直抖动的方法
        if (position == targetPosition) return;

        //第一个参数：指定地点计算：现在的位置+移动的方向 第二个为速度
        rb.DOMove(targetPosition, _speed).SetSpeedBased();//这个方法是把玩家瞬移到指定地点  告诉说是速度
    }
}
