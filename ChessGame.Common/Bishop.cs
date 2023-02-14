﻿namespace ChessGame.Common
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color) : base(PieceValue.Bishop, color)
        {

        }

        public override async Task<List<Coords>> TheoreticallyPossibleMoves(Coords startingCoords)
        {
            List<Coords> possibleMoves = new List<Coords>();

            int x = startingCoords.x;
            int y = startingCoords.y;

            possibleMoves.AddRange(UpLeft(startingCoords));
            possibleMoves.AddRange(DownLeft(startingCoords));
            possibleMoves.AddRange(UpRight(startingCoords));
            possibleMoves.AddRange(DownRight(startingCoords));

            return possibleMoves;

        }

        public override async Task<bool> CanMakeMove(int sx, int sy, int ex, int ey)
        {
            Coords startingCoord = new Coords(sx, sy);
            Coords endingCoord = new Coords(ex, ey);

            List<Coords> possibleMoves = await TheoreticallyPossibleMoves(startingCoord);

            foreach (var cord in possibleMoves)
            {
                if (cord.x == endingCoord.x && cord.y == endingCoord.y)
                    return true;
            }

            return false;
        }
    }
}