using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipPosition : MonoBehaviour
{
    // �����ð����� ���⸦ �����ؼ� ��ġ�� ���� �ʹ�

    //�����ð�
    public float createTime = 1.5f;

    //����ð�
    float currentTime;

    //�������
    public GameObject weaponFactory;

    public GameObject weaponPosition;  // ���� ������ �Ŵϱ� �������� �־���� ?

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
            GameObject whip = Instantiate(weaponFactory);
            whip.transform.position = weaponPosition.transform.position;
            //  ����ð��� 0���� �ʱ�ȭ

            currentTime = 0;
            transform.LookAt(transform.position); // ���� ��ġ��

            whip.transform.forward = transform.forward;
        }

    }
}
// �������� ������ �δ��� << ���� ������
// �� �����ǿ��� ���⸦ ���� �ִ��� << ���̵� ���� ��