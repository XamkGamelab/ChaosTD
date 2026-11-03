using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;
using System.Collections.Generic;

[ExecuteInEditMode]
public class SplineSampler : MonoBehaviour
{
    [SerializeField]
    public SplineContainer m_splineContainer;
    [SerializeField]
    [Range(0f, 1f)]
    private float m_time;
    [SerializeField]
    private float m_width;

    //[HideInInspector]
    public int numSplines;


    float3 position;
    float3 forward;
    float3 upVector;
    Vector3 p1, p2;

    private List<Vector3> m_vertsP1;
    private List<Vector3> m_vertsP2;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        numSplines = m_splineContainer.Splines.Count;
        // Tangent is the forward direction of travel
        // Find the right direction based on this
        // SampleSplineWidth(m_time, out p1, out p2);
    }
    public void SampleSplineWidth(int j, float t, out Vector3 p1, out Vector3 p2)
    {
        m_splineContainer.Evaluate(j, t, out position, out forward, out upVector);
        float3 right = Vector3.Cross(forward, upVector).normalized;
        p1 = position + (right * m_width);
        p2 = position + (-right * m_width);
    }
    private void OnDrawGizmos()
    {
        Handles.matrix = transform.localToWorldMatrix;
        Handles.SphereHandleCap(0, p1, Quaternion.identity, 1f, EventType.Repaint);
        Handles.SphereHandleCap(0, p2, Quaternion.identity, 1f, EventType.Repaint);
        Handles.DrawLine(p1, p2);
    }
   
}
