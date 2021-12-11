using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private SpawnComponent ammo;
    [SerializeField] private Transform player;
    [SerializeField] private float rangeBetweenShoot;
    [SerializeField] private OnVisionEnter vision;
    [SerializeField] private float rotationSpeed;
    private Vector2 direction;
    //this function always turn the spawn vector torwards the player
    private void LookAtPlayer()
    {
        direction = (player.position - transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }
    //if player is in vision spawn ammo after certain time
    //private IEnumerator Shoot()
    //{ 
    //    while (true)
    //    {
    //        //if player is no more in vision then enemy stops shooting
    //        if (vision.inVision == false)
    //            break;
    //        ammo.Spawn();
    //        yield return new WaitForSeconds(rangeBetweenShoot);
    //    }
    //}
    //public void StartShooting()
    //{
    //    StartCoroutine(Shoot());
    //}
    private void Update()
    {
        LookAtPlayer();
    }
}
