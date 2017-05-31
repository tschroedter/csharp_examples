namespace Rules.Logic.Tests
{
    public interface ICellInformation
    {
        int ColumnIndex { get; set; }
        int RowIndex { get; set; }
        int Status { get; set; }
    }
}