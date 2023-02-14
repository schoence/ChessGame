using ChessGame.Common;
using Microsoft.AspNetCore.Components;

namespace ChessGame.Client.Pages.ChessGameComponent
{
    public class ChessGameBase : ComponentBase
    {
        public readonly Game _game;
        private Coords _selectedPieceCoord;

        public ChessGameBase()
        {
            _game = new Game();
        }
        
        public async void MovePiece(Coords coord)
        {
            Console.WriteLine("Move from ChessGameBase.cs");
            if (_selectedPieceCoord == null)
            {
                return;
            }

            await _game.MovePiece(_selectedPieceCoord.x, _selectedPieceCoord.y, coord.x, coord.y);

            _game.RemoveHighlightedSquares();
            ResetSelectedPiece(false);
            StateHasChanged();
        }

        public void SetHighlighted(List<Coords> coords)
        {
            Console.WriteLine("Third One");
            _game.SetHighlightedSquares(coords);
            StateHasChanged();
        }

        public void RemoveHighlighted()
        {
            ResetSelectedPiece(false);
            _game.RemoveHighlightedSquares();
            StateHasChanged();
        }

        public void ResetSelectedPiece(bool updateState = true)
        {
            _selectedPieceCoord = null;
            if (updateState)
                StateHasChanged();
        }

        public void SetSelectedSquare(Coords coord)
        {
            _selectedPieceCoord = coord;
        }
    }
}
