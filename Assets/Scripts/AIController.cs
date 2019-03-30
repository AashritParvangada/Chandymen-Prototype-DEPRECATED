using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AIController : MonoBehaviour
{

    NavMeshAgent agent;
    PlayerController player;
    List<Transform> NavPoints = new List<Transform>();

    Gun AIGun;
    // Use this for initialization
    void Start()
    {
        GetComponentsForScript();
        FindNavPoints();
        ChangePosition();
		Shoot();
    }

    private void Update()
    {
        LookAtPlayer();
    }
    void GetComponentsForScript()
    {
        AIGun = GetComponentInChildren<Gun>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<PlayerController>();
        agent.updateRotation = false;
    }

    void Shoot()
    {
        AIGun.ShootProjectile(AIGun.transform);
        StartCoroutine(ShootAtIntervals());
    }

    void FindNavPoints()
    {
        foreach (GameObject _NavObject in GameObject.FindGameObjectsWithTag("NavPoint"))
            NavPoints.Add(_NavObject.transform);
    }

    void ChangePosition()
    {
        StartCoroutine(MoveToPoint());
    }

    void LookAtPlayer()
    {
        Vector3 targetPosition = new Vector3(player
        .transform.position.x, transform.position.y, player.transform.position.z);

        transform.LookAt(targetPosition);
    }
    IEnumerator MoveToPoint()
    {
        Transform nextPoint = NavPoints[Random.Range(0, NavPoints.Count - 1)];
        agent.SetDestination(nextPoint.position);

        yield return new WaitForSeconds(5);
        ChangePosition();
    }

    IEnumerator ShootAtIntervals()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        Shoot();
    }
}
