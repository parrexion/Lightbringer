using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public Transform lightbringer;
	public Block nextCorner;
	public Transform meshTriangle;
	public Vector3 hitPos;

	private LineRenderer line;
	private Vector3[] positions;
	private Mesh mesh;
	private Vector3 hitPos0;


	private void Start () {
        line = GetComponent<LineRenderer>();
		positions = new Vector3[3];
		positions[0] = hitPos0;
		positions[1] = lightbringer.position;
		positions[2] = nextCorner.transform.position;

		meshTriangle.position = Vector3.zero;
        meshTriangle.GetComponent<MeshFilter>().mesh = mesh = new Mesh();
		mesh.name = "LightArea";
        mesh.vertices = positions;
        mesh.triangles = new int[] {0, 1, 2};
	}

	private void Update() {
		positions[0] = hitPos;
		positions[1] = lightbringer.position;
		positions[2] = nextCorner.hitPos;
		line.SetPositions(positions);

		mesh.Clear();
        mesh.vertices = positions;
        mesh.triangles = new int[] {0, 1, 2};
	}

	private void FixedUpdate() {
		Quaternion spreadAngle = Quaternion.AngleAxis(-15, Vector3.up);
		Vector3 dir = transform.position - lightbringer.position;
		RaycastHit2D hit = Physics2D.Raycast(lightbringer.position, spreadAngle * dir);
		// Debug.Log("Pos x  " + hit.point.x + " - y: " + hit.point.y);
		hitPos0 = hit.point;

		spreadAngle = Quaternion.AngleAxis(15, Vector3.up);
		hit = Physics2D.Raycast(lightbringer.position, spreadAngle * dir);
		hitPos = hit.point;
	}
}
