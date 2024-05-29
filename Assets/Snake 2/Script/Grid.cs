using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int size;

    [SerializeField] private GameObject cellPrefab;

    [SerializeField] private GameObject blockPrefab;

    public int Size => size;

    public void Init()
    {
        Clear();

        for (int i = -1; i <= size; i++)
        {
            for (int j = -1; j <= size; j++)
            {
                if (i == -1 ||  j == -1 || i == size || j == size)
                {
                    Vector3 pos = new Vector3(j, 0f, i);
                    Instantiate(blockPrefab, pos, Quaternion.identity);
                }
                else
                {
                    Vector3 pos = new Vector3(j, -0.5f, i);
                    Instantiate(cellPrefab, pos, Quaternion.Euler(90f, 0f, 0f));
                }
            }
        }
    }
    public List<Vector3> GetEmptyCells(IReadOnlyList<Segment> segments)
    {
        List<Vector3> emptyCells = new List<Vector3>();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0;j < size; j++)
            {
                Vector3 pos = new Vector3(j, 0f, i);
                var segment = segments.FirstOrDefault(s => s.Position == pos);
                if (segment == null)
                {
                    emptyCells.Add(pos);
                }
            }
        }
        return emptyCells;
    }
    public void Clear()
    {
        var list1 = FindObjectsOfType<Cell>();
        foreach(var item in list1)
        {
            GameObject.Destroy(item);
        }
        var list2 = FindObjectsOfType<Block>();
        foreach (var item in list2)
        {
            GameObject.Destroy(item);
        }
    }
}
