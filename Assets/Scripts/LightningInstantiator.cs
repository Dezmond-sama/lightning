using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningInstantiator : MonoBehaviour
{
    [SerializeField] private Transform _pointStart;
    [SerializeField] private Transform _pointEnd;
    [SerializeField] private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LightningCoroutine(0.01f, 0.1f));
    }
    private IEnumerator LightningCoroutine(float deltaT, float time)
    {

        line.positionCount = 0;
        int pointCount = 1024;
        int step = Mathf.Max(1, Mathf.FloorToInt(pointCount * deltaT / time));
        Vector3[] points = Lightning.GenerateLightning(_pointStart.position, _pointEnd.position, pointCount);
        for (int i = 2; i < pointCount; i += step)
        {
            line.positionCount = i;
            line.SetPositions(points);
            yield return new WaitForSeconds(deltaT);
        }
        yield return new WaitForSeconds(deltaT * 3);
        line.positionCount = 0;
        yield return new WaitForSeconds(deltaT);
        StartCoroutine(LightningCoroutine(deltaT, time));
    }

}
