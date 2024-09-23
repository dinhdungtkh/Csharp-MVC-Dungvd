using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class Board : MonoBehaviour
{
    [SerializeField] public GameObject boardGameObject;
    [SerializeField] private GameObject itemPrefab;

    [System.Serializable]
    public struct ItemSprite
    {
        public Items.ItemType type;
        public Sprite sprite;
    }

    [SerializeField] private ItemSprite[] itemSprites;

    [SerializeField] public float boardWidth = 5f;
    [SerializeField] public float boardHeight = 5f;
    [SerializeField] public float itemPadding = 0.8f;
    [SerializeField] public float itemScale = 0.8f;

    private GameObject[,] itemGrid;
    private Items.ItemType[,] itemTypes;
    private const int GRID_SIZE = 2;

    private void Start()
    {
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        itemGrid = new GameObject[GRID_SIZE, GRID_SIZE];
        itemTypes = new Items.ItemType[GRID_SIZE, GRID_SIZE];
        for (int i = 0; i < GRID_SIZE; i++)
        {
            for (int j = 0; j < GRID_SIZE; j++)
            {
                GameObject item = Instantiate(itemPrefab, transform);
                itemGrid[i, j] = item;
                SetItemPosition(i, j);
            }
        }
        ChangeItemLevel("1"); // Bắt đầu với level 1
    }

    private void SetItemPosition(int i, int j)
    {
        if (itemGrid[i, j] != null)
        {
            float x = (i == 0) ? -boardWidth / 2 + itemPadding : boardWidth / 2 - itemPadding;
            float y = (j == 0) ? -boardHeight / 2 + itemPadding : boardHeight / 2 - itemPadding;
            itemGrid[i, j].transform.localPosition = new Vector3(x, y, 0);

            float itemSize = Mathf.Min(boardWidth, boardHeight) / 4f * itemScale;
            itemGrid[i, j].transform.localScale = new Vector3(itemSize, itemSize, 1);
        }
    }

    [ContextMenu("Shuffle Items")]
    public void ShuffleItems()
    {
        for (int i = 0; i < GRID_SIZE; i++)
        {
            for (int j = 0; j < GRID_SIZE; j++)
            {
                int randomI = Random.Range(0, GRID_SIZE);
                int randomJ = Random.Range(0, GRID_SIZE);
                SwapItems(i, j, randomI, randomJ);
            }
        }
    }

    private void SwapItems(int i1, int j1, int i2, int j2)
    {
        Items.ItemType tempType = itemTypes[i1, j1];
        itemTypes[i1, j1] = itemTypes[i2, j2];
        itemTypes[i2, j2] = tempType;

        UpdateItemSprite(i1, j1);
        UpdateItemSprite(i2, j2);
    }

    public void ChangeItemLevel(string level)
    {
        switch (level)
        {
            case "1":
                SetLevelItems(Items.ItemType.MOM, Items.ItemType.BABY);
                break;
            case "2":
                SetLevelItems(Items.ItemType.BABY, Items.ItemType.DAD);
                break;
            case "3":
                SetLevelItems(Items.ItemType.DAD, Items.ItemType.MOM);
                break;
            case "4":
                SetLevelItems(Items.ItemType.BABY, Items.ItemType.MOM);
                break;
            default:
                Debug.LogWarning("Invalid level: " + level);
                break;
        }
    }

    private void SetLevelItems(Items.ItemType type1, Items.ItemType type2)
    {
        List<Items.ItemType> itemTypesList = new List<Items.ItemType> { type1, type1, type2, type2 };
        ShuffleList(itemTypesList);

        for (int i = 0; i < GRID_SIZE; i++)
        {
            for (int j = 0; j < GRID_SIZE; j++)
            {
                int index = i * GRID_SIZE + j;
                itemTypes[i, j] = itemTypesList[index];
                UpdateItemSprite(i, j);
            }
        }
    }

    private void UpdateItemSprite(int i, int j)
    {
        SpriteRenderer spriteRenderer = itemGrid[i, j].GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            Sprite newSprite = GetSpriteForType(itemTypes[i, j]);
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
            }
        }
    }

    private Sprite GetSpriteForType(Items.ItemType type)
    {
        foreach (var itemSprite in itemSprites)
        {
            if (itemSprite.type == type)
            {
                return itemSprite.sprite;
            }
        }
        return null;
    }

    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    [ContextMenu("Center Board")]
    private void CenterBoard()
    {
        if (boardGameObject != null)
        {
            RectTransform rectTransform = boardGameObject.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.sizeDelta = new Vector2(boardWidth, boardHeight);
            }
        }
    }

    [ContextMenu("Apply All Adjustments")]
    private void ApplyAllAdjustments()
    {
        CenterBoard();
        for (int i = 0; i < GRID_SIZE; i++)
        {
            for (int j = 0; j < GRID_SIZE; j++)
            {
                SetItemPosition(i, j);
            }
        }
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(Board))]
public class BoardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Board board = (Board)target;

        if (GUILayout.Button("Initialize Grid"))
        {
            board.SendMessage("InitializeGrid");
        }

        if (GUILayout.Button("Shuffle Items"))
        {
            board.SendMessage("ShuffleItems");
        }

        if (GUILayout.Button("Center Board"))
        {
            board.SendMessage("CenterBoard");
        }

        if (GUILayout.Button("Apply All Adjustments"))
        {
            board.SendMessage("ApplyAllAdjustments");
        }

        GUILayout.Space(10);
        GUILayout.Label("Change Level", EditorStyles.boldLabel);

        if (GUILayout.Button("Level 1 (Mom-Baby)"))
        {
            board.ChangeItemLevel("1");
        }
        if (GUILayout.Button("Level 2 (Baby-Dad)"))
        {
            board.ChangeItemLevel("2");
        }
        if (GUILayout.Button("Level 3 (Dad-Mom)"))
        {
            board.ChangeItemLevel("3");
        }
        if (GUILayout.Button("Level 4 (Baby-Mom)"))
        {
            board.ChangeItemLevel("4");
        }
    }
}
#endif