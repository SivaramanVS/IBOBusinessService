namespace BusinessService.Api.Data
{
    public sealed class Board
    {
        internal Board(BoardName name)
        {
            Name = name;
        }
        internal Board(BoardId id, BoardName name) : this(name)
        {
            Id = id;
        }
        public BoardId Id { get; }
        public BoardName Name { get; }

        // Is 
        public bool IsBoardNameSame(BoardName name) => Name.Value.Equals(name.Value);
    }
}