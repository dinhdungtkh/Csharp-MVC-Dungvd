using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DynamicWheel : MonoBehaviour
{
    public float wheelRadius = 2f;
    public float spinDuration = 5f;
    public AnimationCurve spinCurve;

    private List<WheelSegment> segments = new List<WheelSegment>();
    private float currentAngle = 0f;
    private bool isSpinning = false;

    [System.Serializable]
    public class WheelSegment
    {
        public string prize;
        public Color color;
    }

    void Start()
    {
        // Thêm một số phần tử mẫu
        AddSegment("Giải 1", Color.red);
        AddSegment("Giải 2", Color.blue);
        AddSegment("Giải 3", Color.green);
        AddSegment("Giải 4", Color.yellow);

        DrawWheel();
    }

    public void AddSegment(string prize, Color color)
    {
        segments.Add(new WheelSegment { prize = prize, color = color });
        DrawWheel();
    }

    public void RemoveSegment(int index)
    {
        if (index >= 0 && index < segments.Count)
        {
            segments.RemoveAt(index);
            DrawWheel();
        }
    }

    void DrawWheel()
    {
        // Xóa các phần tử con cũ
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Vẽ các phần tử mới
        float angleStep = 360f / segments.Count;
        for (int i = 0; i < segments.Count; i++)
        {
            float startAngle = i * angleStep;
            DrawSegment(segments[i], startAngle, angleStep);
        }
    }

    void DrawSegment(WheelSegment segment, float startAngle, float angleStep)
    {
        GameObject segmentObj = new GameObject("Segment");
        segmentObj.transform.SetParent(transform);

        MeshFilter meshFilter = segmentObj.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = segmentObj.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[3];
        int[] triangles = new int[] { 0, 1, 2 };

        vertices[0] = Vector3.zero;
        vertices[1] = Quaternion.Euler(0, 0, -startAngle) * Vector3.up * wheelRadius;
        vertices[2] = Quaternion.Euler(0, 0, -(startAngle + angleStep)) * Vector3.up * wheelRadius;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        meshFilter.mesh = mesh;
        meshRenderer.material = new Material(Shader.Find("Unlit/Color"));
        meshRenderer.material.color = segment.color;

        // Thêm text cho phần thưởng
        GameObject textObj = new GameObject("PrizeText");
        textObj.transform.SetParent(segmentObj.transform);
        TextMesh textMesh = textObj.AddComponent<TextMesh>();
        textMesh.text = segment.prize;
        textMesh.color = Color.black;
        textMesh.fontSize = 14;
        textMesh.alignment = TextAlignment.Center;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textObj.transform.localPosition = Quaternion.Euler(0, 0, -(startAngle + angleStep / 2)) * Vector3.up * (wheelRadius / 2);
        textObj.transform.localRotation = Quaternion.Euler(0, 0, startAngle + angleStep / 2);
    }

    public void Spin()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinCoroutine());
        }
    }

    System.Collections.IEnumerator SpinCoroutine()
    {
        isSpinning = true;
        float elapsedTime = 0f;
        float startAngle = currentAngle;
        float targetAngle = startAngle + Random.Range(720f, 1440f); // 2-4 vòng quay

        while (elapsedTime < spinDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spinDuration;
            float curveValue = spinCurve.Evaluate(t);
            currentAngle = Mathf.Lerp(startAngle, targetAngle, curveValue);
            transform.rotation = Quaternion.Euler(0, 0, -currentAngle);
            yield return null;
        }

        currentAngle = targetAngle % 360f;
        isSpinning = false;

        // Xác định phần thưởng
        float anglePerSegment = 360f / segments.Count;
        int winningIndex = Mathf.FloorToInt(currentAngle / anglePerSegment);
        Debug.Log("Phần thưởng: " + segments[winningIndex].prize);
    }

    public void GeneratePrefab()
    {
        #if UNITY_EDITOR
        DrawWheel();
        string localPath = "Assets/Prefabs/DynamicWheel.prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, localPath, InteractionMode.UserAction);
        Debug.Log("Prefab đã được tạo tại: " + localPath);
        #endif
    }
}