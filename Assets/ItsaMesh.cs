using UnityEngine;

public class ItsaMesh : MonoBehaviour
{
	public Transform otherObject;
    public Vector3[] newVertices;
    public Vector2[] newUV;
    public int[] newTriangles;

    void Start()
    {
        Mesh mesh = new Mesh();
        otherObject.GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
    }
}