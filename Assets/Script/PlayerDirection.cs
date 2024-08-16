using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{

    [SerializeField] UnityEngine.Camera mainCamera;
    Plane plane = new Plane();
    float distance = 0;

    public Vector3 lookPoint;

    // Start is called before the first frame update

    void Start()
    {
        //mainCamera = GetComponent<UnityEngine.Camera>();
        

    }


    void Update()
    {

        // �J�����ƃ}�E�X�̈ʒu������Ray������
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        

        // �v���C���[�̍�����Plane���X�V���āA�J�����̏������ɒn�ʔ��肵�ċ������擾
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {

            // ���������Ɍ�_���Z�o���āA��_�̕�������
            lookPoint = ray.GetPoint(distance);
            transform.LookAt(lookPoint);
        }
    }

    

}
