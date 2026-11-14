using UnityEngine;
using NavMeshPlus.Components;

public class AutoBakeScript : MonoBehaviour
{

    private NavMeshSurface NavMeshMap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        NavMeshMap = GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Start()
    {
        NavMeshMap.BuildNavMesh();

    }
}
