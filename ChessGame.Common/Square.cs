namespace ChessGame.Common
{
    public class Square
    {
        private Piece? _piece;
        //private bool _occupied;
        //private bool _threatened;
        //"a3|a4"
        //private string _threatenedBy;
        private List<Coords> _threatenedBy;
        private Coords _coords;

        private SquareColor _color;
        private bool _highlighted = false;
        private bool _clicked = false;
        public SquareColor Color { get { return _color; } }

        
        public bool IsThreatened { get { return _threatenedBy.Any(); } }
        public bool IsOccupied { get { return _piece == null ? false : true; } }
        public bool IsHighlighted { get { return _highlighted; } }
        public bool IsClicked { get { return _clicked; } }

        public Piece? Piece { get { return _piece; } }

        public IEnumerable<Coords> ThreatenedBy { get { return _threatenedBy; } }
        public Coords Coords { get { return _coords; } }

        public Square(int x, int y, SquareColor color) : this(new Coords() { x = x, y = y }, color ) { }
        public Square(Coords coords, SquareColor color)
        {
            _color = color;
            _coords = coords;
            _piece = null;
            _threatenedBy = new List<Coords>();
        }

        //public Square(Piece? piece)
        //{
        //    _piece = piece;
        //    _threatenedBy = new List<Coords>();
        //}

        public void AddThreatenedBy(Coords coords)
        {
            _threatenedBy.Add(coords);
        }

        public void SetHighlighted(bool highlighted)
        {
            _highlighted = highlighted;
        }

        public void ClearThreatenedBy()
        {
            _threatenedBy.Clear();
        }

        public void RemovePiece()
        {
            _piece = null;
        }

        public void SetPiece(Piece? piece)
        {
            _piece = piece;
        }
    }

    public enum SquareColor
    {
        Black,
        White
    }
}