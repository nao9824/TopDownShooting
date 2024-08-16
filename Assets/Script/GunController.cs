using System.Collections;
using UnityEngine;
public class GunControler : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawn = null;
    [SerializeField, Min(1)]
    int damage = 1;
    [SerializeField, Min(1)]
    int maxAmmo = 30;
    [SerializeField, Min(1)]
    float maxRange = 30;
    [SerializeField]
    LayerMask hitLayers = 0;
    [SerializeField, Min(0.01f)]
    float fireInterval = 0.1f;
    bool fireTimerIsActive = false;
    RaycastHit hit;
    WaitForSeconds fireIntervalWait;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject moveWall;
    GameObject moveWall2;
    GameObject moveWall5;

    void Start()
    {
        fireIntervalWait = new WaitForSeconds(fireInterval);  // WaitForSecondsをキャッシュしておく（高速化）

        player = GameObject.FindGameObjectWithTag("Player");
        moveWall = GameObject.FindGameObjectWithTag("MoveWall");
        moveWall2 = GameObject.FindGameObjectWithTag("MoveWall2");
        moveWall5 = GameObject.FindGameObjectWithTag("MoveWall5");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && player.gameObject.GetComponent<Player>().isHaveGun)
        {
            Fire();
        }
    }
    // 弾の発射処理
    void Fire()
    {
        if (fireTimerIsActive)
        {
            return;
        }
        if (Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, maxRange, hitLayers, QueryTriggerInteraction.Ignore))
        {
            BulletHit();
        }
        
        StartCoroutine(nameof(FireTimer));
    }
    // 弾がヒットしたときの処理
    void BulletHit()
    {
        // テスト用
        Debug.Log("弾が「" + hit.collider.gameObject.name + "」にヒットしました。");
        if(hit.collider.gameObject.name == ("Switch")){
        moveWall.gameObject.GetComponent<MoveWall>().isPush = true;
            Destroy(hit.collider.gameObject);
        }
        if (hit.collider.gameObject.name == ("Switch2") || hit.collider.gameObject.name == ("Switch3"))
        {
            moveWall2.gameObject.GetComponent<MoveWall>().isPush = true;
            Destroy(hit.collider.gameObject);
        }
        if (hit.collider.gameObject.name == ("Enemy"))
        {
            moveWall5.gameObject.GetComponent<MoveWall>().isPush = true;
            Destroy(hit.collider.gameObject);
        }
    }
    // 弾を発射する間隔を制御するタイマー
    IEnumerator FireTimer()
    {
        fireTimerIsActive = true;
        yield return fireIntervalWait;
        fireTimerIsActive = false;
    }
}