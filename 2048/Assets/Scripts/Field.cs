using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [Header("FieldProperties")]
    public float CellSize;
    public float Spacing;
    public int FieldSize;
    public int InitCellCount;

    [Space(10)]
    [SerializeField] Cell cellPref;
    [SerializeField] RectTransform rt;
    private Cell[,] field;


    private void Start()
    {
        GenerateField();
    }

    private void CreateField()
    {
        field = new Cell[FieldSize, FieldSize];
        float fieldWidth = FieldSize * (CellSize + Spacing) + Spacing;
        rt.sizeDelta = new Vector2(fieldWidth, fieldWidth);
        float startX = -(fieldWidth / 2) + (CellSize / 2) + Spacing;
        float startY = (fieldWidth / 2) - (CellSize / 2) - Spacing;

        for (int x=0;x<FieldSize;x++)
        {
            for(int y=0;y<FieldSize;y++)
            {
                var cell = Instantiate(cellPref, transform, false);
                var position = new Vector2(startX + (x * (CellSize + Spacing)), startY - (y * (CellSize + Spacing)));
                cell.transform.localPosition = position;

                field[x, y] = cell;
                cell.SetValue(x, y, 1);
            }
        }
    }

    public void GenerateField()
    {
        if (field == null)
            CreateField();

        for (int x = 0; x < FieldSize; x++)
            for (int y = 0; y < FieldSize; y++)
                field[x, y].SetValue(x, y, 1);

        for (int i = 0; i < InitCellCount; i++)
            GenerateRandomCell();

    }
    private void GenerateRandomCell()
    {
        var empryCell = new List<Cell>();
        for (int x = 0; x < FieldSize; x++)
            for (int y = 0; y < FieldSize; y++)
                if (field[x, y].IsEmpty)
                    empryCell.Add(field[x, y]);


        if (empryCell.Count == 0)
            throw new System.Exception("STOP!!");

        int value = Random.Range(0, 10) == 0 ? 2 : 1;
        var cell = empryCell[Random.Range(0, empryCell.Count)];
        cell.SetValue(cell.X, cell.Y, value);





    }
}
