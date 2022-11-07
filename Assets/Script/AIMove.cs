using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{

    public float range = 10000; // searching range 

    [SerializeField]GameObject targetObject; // �߰� object
    Transform target;  // �߰� ��� transform

    Transform[] targets;  // �߰� ������ transform

    NavMeshAgent navMeshAgent;  // ��� ��� AI Agent


    bool IsGameOver = false;     // ���� ���� ���ΰ�? 

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        ////�÷��̾� gameObject�� ������ 
        //targetObject = GameObject.FindWithTag("Player");

        StartCoroutine(UpdatePath());
    }


    // ����� ���� Ȥ�� �������� ã�´� -> 
    // ������ ���� �� -> �÷��̾ ã�´�. 
    private IEnumerator UpdatePath()
    {
        while (IsGameOver != true)
        {

            // �ʿ��� ������ 
            // ���� ����� object�� ��ġ ����
            //Transform closestTarget = null;

            // path�� ���� ũ�� ������ ǥ���� �� �ִ� �ִ� ���� ������ �� target�� �� �ϱ� ����
           // float closestTargetDistance = float.MaxValue;


            //���� Collider �� Gotcha layer�� ���� �͸� �����´�. 
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);

            //������ Gotcha �� ���� ����� Gotcha path ��� 

            // navigation system���� ���Ǵ� path 
            // object������ waypoint�� corner �迭�� ���� �� 

            NavMeshPath path = new NavMeshPath();

            ////ã�ƿ� collider�� transform�� ���� 
            //for (int i = 0; i < colliders.Length; i++)
            //{

            //    Debug.Log("## Collider �̸� ��ġ! " + colliders[i].name + colliders[i].transform.position);

            //    // ���� �� ��ġ���� �迭 ù��° collider�� ��ġ������ path 
            //    // true => path, false => no path 
            //    if (NavMesh.CalculatePath(transform.position, colliders[i].transform.position, navMeshAgent.areaMask, path))
            //    {
            //        // ù��° collider�� path�� ù���� corner������ �Ÿ� ��� 
            //        // path�� target������ waypoint�� corner �迭�� ����� 
            //        float distance = Vector3.Distance(transform.position, path.corners[0]);

            //        //Debug.Log("ù��° �ڳʱ��� �Ÿ�! " + colliders[i].name + distance);


            //        // ���� corner�� �ִٸ� for�� ����, ������ ù�ڳʿ��� ��
            //        for (int j = 1; j < path.corners.Length; j++)
            //        {
            //            // �� �ڳʿ� �� �ڳʿ��� �Ÿ��� ����Ͽ� distance�� ����
            //            distance += Vector3.Distance(path.corners[j - 1], path.corners[j]);
            //        }


            //        //collier���� �Ÿ��� closest target �Ÿ����� ª���� closest target�� ���� collider�� ���� 
            //        if (distance < closestTargetDistance)
            //        {
            //            closestTargetDistance = distance;
            //            closestTarget = colliders[i].transform;

            //            //Debug.Log("### ���� ª�� �Ÿ�!!! " + closestTargetDistance);

            //        }
            //    }

            //    // corner�� ���� path�� �Ÿ��� �ִܰŸ� ��
            //    else
            //    {
            //        float distance = float.MaxValue;
            //        distance = Vector3.Distance(transform.position, colliders[i].transform.position);

            //        if (distance < closestTargetDistance)
            //        {
            //            closestTargetDistance = distance;
            //            closestTarget = colliders[i].transform;
            //        }
            //    }
            //}

            navMeshAgent.SetDestination(target.position); // Ÿ���� pos�� �̵� 
            yield return new WaitForSeconds(0.25f);

        }

        yield return null;

    }



}
