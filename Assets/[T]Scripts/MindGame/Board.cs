using System.Collections.Generic;
using UnityEngine;

public enum Owners//кому принадлежит гекс
{
    Player,
    AI,
    Neutral
}

public class Board : MonoBehaviour
{
    public AllCells container;
    public PatientSO curPatient;
    public int playerScore = 0;
    public int aiScore = 0;

    public bool CanSelect(Cell curCell, int turn)//можем ли мы выбрать данный гекс
    {
        return false;
    }
    public int Move(Cell fromCell, Cell toCell)
    {
        int distance = -1;
        Debug.Log("Diff: " + (toCell.pos.First - fromCell.pos.First));
        switch (toCell.pos.First - fromCell.pos.First)
        {
            case 0:
                distance = Mathf.Abs(toCell.pos.Second - fromCell.pos.Second);
                break;
            case 1:
                Debug.Log(fromCell.pos.Second + " " + toCell.pos.Second);
                if ((toCell.pos.Second >= fromCell.pos.Second - 1) && (toCell.pos.Second <= fromCell.pos.Second + 2))
                {
                    if (fromCell.pos.Second == toCell.pos.Second || toCell.pos.Second == fromCell.pos.Second + 1)
                    {
                        Debug.Log(fromCell.pos.Second + " " + toCell.pos.Second);
                        distance = 1;
                    }
                    else
                        distance = 2;
                }
                break;
            case -1:
                if ((toCell.pos.Second >= fromCell.pos.Second - 2) && (toCell.pos.Second <= fromCell.pos.Second + 1))
                {
                    if (fromCell.pos.Second == toCell.pos.Second || toCell.pos.Second == fromCell.pos.Second - 1)
                        distance = 1;
                    else
                        distance = 2;
                }
                break;
            case 2:
                if ((toCell.pos.Second >= fromCell.pos.Second) && (toCell.pos.Second <= fromCell.pos.Second + 2))
                {
                    distance = 2;
                }
                break;
            case -2:
                if ((toCell.pos.Second <= fromCell.pos.Second) && (toCell.pos.Second >= fromCell.pos.Second - 2))
                {
                    distance = 2;
                }
                break;
            default:
                distance = -1;
                break;
        }

        return distance;
    }
    public void UpdateScore()
    {
        
    }
    public List<Cell> AfterMove(Cell fromCell, Cell toCell)
    {
        List<Cell> changedCells = new List<Cell>();

        return changedCells;
    }

    private void Awake()
    {
        container = new AllCells();
    }
}

//[System.Serializable]
public class AllCells//массив всех гексов доски
{
    public Cell[] cells;//зависит от уровня сложности пациента
    public AllCells()
    {
        cells = new Cell[61];
    }
}
//[System.Serializable]
public class Cell//отдельный гекс
{
    public Pair<int, int> pos = new Pair<int, int>();
    public Owners owner;
    public int id;

    public Cell()
    {
        owner = Owners.Neutral;
        pos.First = -1;
        pos.Second = -1;
        id = -1;
    }
    
    public Cell(int _row, int _col, int _id)
    {
        owner = Owners.Neutral;
        id = _id;
        pos.First = _row;
        pos.Second = _col;
    }

    public void ChangeOwner(Owners newOwner)
    {
        this.owner = newOwner;
    }

    public void SetPosition(int row, int col)
    {
        pos.First = row;
        pos.Second = col;
    }

    public void SetId(int id)
    {
        this.id = id;
    }
}

public class Pair<T, U>
{
    public Pair() {}

    public Pair(T first, U second)
    {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }

    public override string ToString()
    {
        return this.First.ToString() + "  " + this.Second.ToString();
    }
};