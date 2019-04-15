using System.Collections.Generic;
using Game.Controllers;
using Game.Data.Grid;

public class GridData
{
    public enum DIRECTION
    {
        UP,
        DOWN,
        RIGHT,
        LEFT
    }

    public delegate void ForEachDelegate(GridItemData itemData, int rowId, int collumnId);

    private List<List<GridItemData>> grid;
    private GridSize size;
    private DIRECTION _currentDirection;

    public DIRECTION currentDirection
    {
        get { return _currentDirection; }
        set { _currentDirection = value; }
    }

    public GridSize Size
    {
        get { return size; }
    }

    public GridData(GridSize gridSize)
    {
        size = gridSize;
        grid = new List<List<GridItemData>>();
        for (int rowId = 0; rowId < size.height; rowId++)
        {
            grid.Add(new List<GridItemData>());
            for (int collumnId = 0; collumnId < size.height; collumnId++)
            {
                grid[rowId].Add(null);
            }
        }
    }

    public void Dispose()
    {
        foreach (List<GridItemData> row in grid)
        {
            row.Clear();
        }
        grid.Clear();
    }

    public int GetRowsCount()
    {
        return grid.Count;
    }

    public int getCollumnsCountInRow(int rowId)
    {
        if (grid.Count <= rowId)
            return 0;
        return grid[rowId].Count;
    }

    public void AddGridItem(GridItemData gridItem, int rowId, int collumnId)
    {
        if (rowId < 0 || rowId >= grid.Count || collumnId < 0 || collumnId >= getCollumnsCountInRow(rowId))
            return;

        grid[rowId][collumnId] = gridItem;
    }

    public GridItemData GetGridItem(int rowId, int collumnId)
    {
        if (rowId < 0 || rowId >= grid.Count || collumnId < 0 || collumnId >= getCollumnsCountInRow(rowId))
            return null;

        return grid[rowId][collumnId];
    }

    public GridItemData GetNextItemByDirection(int rowId, int collumnId)
    {
        switch (_currentDirection)
        {
            case DIRECTION.DOWN:
                rowId++;
                break;
            case DIRECTION.UP:
                rowId--;
                break;
            case DIRECTION.LEFT:
                collumnId--;
                break;
            case DIRECTION.RIGHT:
                collumnId++;
                break;
        }

        if (rowId < 0 || rowId >= grid.Count || collumnId < 0 || collumnId >= getCollumnsCountInRow(rowId))
            return null;

        return grid[rowId][collumnId];
    }

    /*
     * For Each.
     */

    public void forEachByDirection(ForEachDelegate callbackFunction)
    {
        switch (_currentDirection)
        {
            case DIRECTION.UP:
                forEachUpToDown(callbackFunction);
                break;
            case DIRECTION.DOWN:
                forEachDownToUp(callbackFunction);
                break;
            case DIRECTION.LEFT:
                forEachLeftToRight(callbackFunction);
                break;
            case DIRECTION.RIGHT:
                forEachRightToLeft(callbackFunction);
                break;
        }
    }

    private void forEachUpToDown(ForEachDelegate callbackFunction)
    {
        int rowIndex = 0;
        int collumnIndex;
        int collumnsCount;
        for (; rowIndex < size.height; rowIndex++)
        {
            collumnIndex = 0;
            collumnsCount = size.width;
            for (; collumnIndex < collumnsCount; collumnIndex++)
                callbackFunction(GetGridItem(rowIndex, collumnIndex), rowIndex, collumnIndex);
        }
    }

    private void forEachDownToUp(ForEachDelegate callbackFunction)
    {
        int rowIndex = size.height - 1;
        int collumnIndex;
        int collumnsCount;
        for (; rowIndex >= 0; rowIndex--)
        {
            collumnIndex = 0;
            collumnsCount = size.width;
            for (; collumnIndex < collumnsCount; collumnIndex++)
                callbackFunction(GetGridItem(rowIndex, collumnIndex), rowIndex, collumnIndex);
        }
    }

    private void forEachLeftToRight(ForEachDelegate callbackFunction)
    {
        int rowIndex;
        int collumnIndex = 0;
        int rowsCount;
        for (; collumnIndex < size.width; collumnIndex++)
        {
            rowIndex = 0;
            rowsCount = size.height;
            for (; rowIndex < rowsCount; rowIndex++)
                callbackFunction(GetGridItem(rowIndex, collumnIndex), rowIndex, collumnIndex);
        }
    }

    private void forEachRightToLeft(ForEachDelegate callbackFunction)
    {
        int rowIndex;
        int collumnIndex = size.width - 1;
        int rowsCount;
        for (; collumnIndex >= 0; collumnIndex--)
        {
            rowIndex = 0;
            rowsCount = size.height;
            for (; rowIndex < rowsCount; rowIndex++)
                callbackFunction(GetGridItem(rowIndex, collumnIndex), rowIndex, collumnIndex);
        }
    }
}