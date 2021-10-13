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
    public List<Cell> AfterMove(Cell cell)//ѕќћ≈Ќя“№ ѕ–ќ¬≈– ” я„≈≈  „“ќЅџ Ќ≈ ƒ≈Ћј“№ 12 ƒ”ѕЋ» ј“ќ¬
    {
        List<Cell> changedCells = new List<Cell>();
        int i = cell.pos.First;
        int j = cell.pos.Second;
        changedCells.Add(new Cell(i, j - 1));
        changedCells.Add(new Cell(i, j + 1/*, cell.id*/));
        changedCells.Add(new Cell(i - 1, j - 1/*, cell.id*/));
        changedCells.Add(new Cell(i - 1, j/*, cell.id*/));
        changedCells.Add(new Cell(i + 1, j/*, cell.id*/));
        changedCells.Add(new Cell(i + 1, j + 1/*, cell.id*/));

        changedCells.Add(new Cell(i, j - 1/*, cell.id*/, Owners.AI));
        changedCells.Add(new Cell(i, j + 1/*, cell.id*/, Owners.AI));
        changedCells.Add(new Cell(i - 1, j - 1/*, cell.id*/, Owners.AI));
        changedCells.Add(new Cell(i - 1, j/*, cell.id*/, Owners.AI));
        changedCells.Add(new Cell(i + 1, j/*, cell.id*/, Owners.AI));
        changedCells.Add(new Cell(i + 1, j + 1/*, cell.id*/, Owners.AI));

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
    public Cell[] cells;//зависит от уровн€ сложности пациента
    public AllCells()
    {
        cells = new Cell[61];
    }
}
//[System.Serializable]
public class Cell //: System.IComparable<Cell>//отдельный гекс
{
    public Pair<int, int> pos = new Pair<int, int>();
    public Owners owner;
    //public int id;

    public Cell()
    {
        owner = Owners.Neutral;
        pos.First = -1;
        pos.Second = -1;
        //id = -1;
    }

    public Cell(int _row, int _col, /*int _id,*/ Owners _owner = Owners.Neutral)
    {
        owner = _owner;
        //id = _id;
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
        //this.id = id;
    }
    
    public static bool operator ==(Cell cell1, Cell cell2)
    {
        return (cell1.pos.First == cell2.pos.First) && (cell1.pos.Second == cell2.pos.Second);
    }

    public static bool operator !=(Cell cell1, Cell cell2)
    {
        return !(cell1.pos.First == cell2.pos.First) && (cell1.pos.Second == cell2.pos.Second);
    }
    
    public override string ToString()
    {
        return this.pos.ToString() + " " /*+ this.id.ToString()*/ + " " + this.owner.ToString();
    }

    //public int CompareTo(Cell obj)
    //{
    //    Cell c = obj as Cell;
    //    if (c != null)
    //    {
    //        if ((this.pos.First == c.pos.First) && (this.pos.Second == c.pos.Second))
    //            return 0;
    //        else
    //            return this.id >= c.id ? 1 : -1;
    //    }
    //    else
    //        throw new System.NotImplementedException();
    //}


    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        Cell c = obj as Cell;
        if ((this.pos.First == c.pos.First) && (this.pos.Second == c.pos.Second))
            return true;
        else
            return false;
    }

    public bool Equals(Cell obj)
    {
        return obj != null && (this.pos.First == obj.pos.First) && (this.pos.Second == obj.pos.Second);
    }

    public override int GetHashCode()
    {
        return this.pos.First + this.pos.Second;
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