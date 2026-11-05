using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SplineRoadBuilder : MonoBehaviour
{
    [SerializeField]
    private int resolution;

    private List<Vector3> m_vertsP1;
    private List<Vector3> m_vertsP2;

    [SerializeField]
    private SplineSampler m_splineSampler;

    [SerializeField]
    private MeshFilter m_meshFilter;
    [SerializeField]
    private float debugPointSize = 1.0f;

    private Mesh m_mesh;


    private void Awake()
    {
        Rebuild();
    }
    private void OnEnable()
    {
        Spline.Changed += OnSplineChanged;
        Rebuild();
    }
    private void Start()
    {
        Rebuild();
    }
    private void OnDisable()
    {
        Spline.Changed -= OnSplineChanged;
    }

    private void OnSplineChanged(Spline arg1, int arg2, SplineModification arg3)
    {
        Rebuild();
    }
    private void OnValidate()              // rebuild when you change resolution in the Inspector
    {
        if (isActiveAndEnabled) Rebuild();
    }

    private void Update()
    {
        Rebuild();
    }
    
    private void Rebuild()
    {
        if (m_splineSampler == null || m_meshFilter == null || resolution < 1) return;
        GetVerts();
        BuildMesh();
    }

    private void GetVerts()
    {
        m_vertsP1 = new List<Vector3>();
        m_vertsP2 = new List<Vector3>();

        float step = 1f / (float)resolution;
        Vector3 p1;
        Vector3 p2;

        for (int j = 0; j < m_splineSampler.numSplines; j++)
        {
            for (int i = 0; i < resolution; i++)
            {
                float t = i * step;
                m_splineSampler.SampleSplineWidth(j, t, out p1, out p2);
                m_vertsP1.Add(p1);
                m_vertsP2.Add(p2);
            }
            m_splineSampler.SampleSplineWidth(j, 1f, out p1, out p2);
            m_vertsP1.Add(p1);
            m_vertsP2.Add(p2);
        }
    }


    private void BuildMesh()
    {
        if (m_mesh == null)
        {
            m_mesh = new Mesh { name = "Road Mesh" };
        }
        m_mesh.Clear();

        List<Vector3> verts = new List<Vector3>();
        List<int> tris = new List<int>();
        //int offset = 0;

        int length = m_vertsP2.Count;
        for (int currentSplineIndex = 0; currentSplineIndex < m_splineSampler.numSplines; currentSplineIndex++)
        {
            int splineOffset = (resolution +1) * currentSplineIndex;
            for (int currentSplinePoint = 1; currentSplinePoint < resolution + 1; currentSplinePoint++)
            {
                int vertOffset = splineOffset + currentSplinePoint;
                Vector3 p1 = m_vertsP1[vertOffset - 1];
                Vector3 p2 = m_vertsP2[vertOffset - 1];
                Vector3 p3 = m_vertsP1[vertOffset];
                Vector3 p4 = m_vertsP2[vertOffset];


                int offset = verts.Count;   // simpler than computing it by hand

                verts.AddRange(new[] { p1, p2, p3, p4 });
                tris.AddRange(new[]
                {
                offset + 0, offset + 2, offset + 3,
                offset + 3, offset + 1, offset + 0
                });
            }
        }

        m_mesh.SetVertices(verts);
        m_mesh.SetTriangles(tris, 0);
        m_mesh.RecalculateNormals();
        m_meshFilter.sharedMesh = m_mesh;
    }


    private void OnDrawGizmos()
    {
        for (int i = 0; i < m_vertsP1.Count; i++)
        {
            Handles.matrix = transform.localToWorldMatrix;
            Handles.SphereHandleCap(0, m_vertsP1[i], Quaternion.identity, debugPointSize, EventType.Repaint);
            Handles.SphereHandleCap(0, m_vertsP2[i], Quaternion.identity, debugPointSize, EventType.Repaint);
            Handles.DrawLine(m_vertsP1[i], m_vertsP2[i]);
        }
    }
}
