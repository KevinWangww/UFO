using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{

    [Header("�������� (0~1 ��Ӧ��/���Ľ���)")]
    public AnimationCurve moveCurve;

    // ������ʼλ�ú�����λ��
    public Vector2 originalPos;
    Vector2 endPos;
    // ��ֵ�õı��� t��0��ʾԭλ�ã�1��ʾ��ȫ����
    private float t = 0f;
    float targetT = 0f;

    void Start()
    {
        //��������λ��Ϊ��ʼλ�õ�y���3
        endPos = originalPos;
        endPos.y += 3;
    }

    void Update()
    {
        // 1. ��ȡ�������Ļ�ϵ�λ�ã�Ȼ��ת������������
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // 2. ������������� X ����֮��ľ��Ծ���
        float distanceX = worldPos.x - transform.position.x;

        // 3. ������С�� Range�������� (targetT=1)������ص�ԭλ�� (targetT=0)
        if((distanceX < 2 && distanceX >0) || (distanceX < 0 && distanceX > -2))
        {
            targetT = 1f;
        }
        else
        {
            targetT = 0f;
        }
        
        // 4. �� t �� targetT ƽ������
        t = Mathf.Lerp(t, targetT, 3 * Time.deltaTime);

        // 5. �ö������������㵱ǰ��/���Ľ��� (curveValue)
        transform.position = Vector2.Lerp(originalPos, endPos, moveCurve.Evaluate(t));

    }
}

