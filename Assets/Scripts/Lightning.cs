using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning
{
    public static Vector3[] GenerateLightning(Vector3 pointStart, Vector3 pointEnd, int points)
    {
        Vector3[] res = new Vector3[Mathf.Max(points, 2)];
        res[0] = pointStart;
        res[res.Length - 1] = pointEnd;
        GenerateLightningSection(0, res.Length - 1, res, 0.1f);
        return res;
    }
    private static void GenerateLightningSection(int indexStart, int indexEnd, Vector3[] data, float deviation)
    {
        int indexMiddle = (indexStart + indexEnd) / 2;
        if (indexMiddle == indexStart || indexMiddle == indexEnd) return;

        float len = Vector3.Distance(data[indexStart], data[indexEnd]);
        Vector3 deviationVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * len * deviation;
        Debug.Log(deviationVector);
        Vector3 middlePoint = (data[indexStart] + data[indexEnd]) / 2;
        data[indexMiddle] = middlePoint + deviationVector;

        GenerateLightningSection(indexStart, indexMiddle, data, deviation);
        GenerateLightningSection(indexMiddle, indexEnd, data, deviation);
    }
}
