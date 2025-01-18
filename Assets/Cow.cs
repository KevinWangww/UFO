using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{

    [Header("动画曲线 (0~1 对应升/降的进度)")]
    public AnimationCurve moveCurve;

    // 创建初始位置和最终位置
    public Vector2 originalPos;
    Vector2 endPos;
    // 插值用的变量 t，0表示原位置，1表示完全上升
    private float t = 0f;
    float targetT = 0f;

    void Start()
    {
        //设置最终位置为起始位置的y轴加3
        endPos = originalPos;
        endPos.y += 3;
    }

    void Update()
    {
        // 1. 获取鼠标在屏幕上的位置，然后转换到世界坐标
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // 2. 计算鼠标与物体 X 坐标之间的绝对距离
        float distanceX = worldPos.x - transform.position.x;

        // 3. 若距离小于 Range，则升起 (targetT=1)，否则回到原位置 (targetT=0)
        if((distanceX < 2 && distanceX >0) || (distanceX < 0 && distanceX > -2))
        {
            targetT = 1f;
        }
        else
        {
            targetT = 0f;
        }
        
        // 4. 让 t 朝 targetT 平滑过渡
        t = Mathf.Lerp(t, targetT, 3 * Time.deltaTime);

        // 5. 用动画曲线来计算当前升/降的进度 (curveValue)
        transform.position = Vector2.Lerp(originalPos, endPos, moveCurve.Evaluate(t));

    }
}

