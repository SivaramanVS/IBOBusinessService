namespace BusinessService.Api.Data
{
    public static class BoardModel
    {
        internal static BoardId BoardId(long value) => new BoardId(value);
        internal static BoardName BoardName(string value) => new BoardName(value);
        internal static Board Board(BoardId id, BoardName name) => new Board(id, name);
        internal static Board Board(BoardName name) => new Board(name);
    }
}