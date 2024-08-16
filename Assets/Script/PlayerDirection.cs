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

        // カメラとマウスの位置を元にRayを準備
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        

        // プレイヤーの高さにPlaneを更新して、カメラの情報を元に地面判定して距離を取得
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {

            // 距離を元に交点を算出して、交点の方を向く
            lookPoint = ray.GetPoint(distance);
            transform.LookAt(lookPoint);
        }
    }

    

}
