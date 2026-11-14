using UnityEngine;
using UnityEngine.AI;

public class NavmeshMove : MonoBehaviour
{

    [SerializeField] private Transform targetPositionTransform;
    private NavMeshAgent navMeshAgent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        targetPositionTransform = Players[0].GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = targetPositionTransform.position;
    }
}
