using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePosition : MonoBehaviour
{
    public float createTime = 1.5f;

    //����ð�
    float currentTime;

    //�������
    public GameObject fireFactory;

    public GameObject firePosition;  // ���� ������ �Ŵϱ� �������� �־���� ?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ����ð��� �����ϴٰ�
        currentTime += Time.deltaTime;
        // ���� ����ð��� �����ð��� �ʰ��ϸ�
        if (currentTime > createTime)
        {
            // ������忡�� ���⸦ ����� �� ��ġ�� ������ ����ʹ�.
            GameObject fire = Instantiate(fireFactory);
            fire.transform.position = firePosition.transform.position;
            //  ����ð��� 0���� �ʱ�ȭ

            currentTime = 0;
            transform.LookAt(transform.position);

            fire.transform.forward = transform.forward;
        }
    }
}
