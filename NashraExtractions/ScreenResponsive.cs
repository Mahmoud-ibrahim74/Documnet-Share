using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NashraExtractions
{
    internal class ScreenResponsive
    {
        public double _Width { get; set; }
        public double _Height { get; set; }
        public ScreenResponsive(Window window)
        {
            _Width = SystemParameters.PrimaryScreenWidth-50;
            _Height = SystemParameters.PrimaryScreenHeight-50;
             window.Width = _Width;
             window.Height = _Height;
        }
        public void SetCardResponsive(MaterialDesignThemes.Wpf.Card[] cards)
        {
            foreach (var card in cards)
            {
                card.Width = _Width-50;
            }

        }
        public void SetGridsResponsive(Grid[] grids)
        {
            foreach (Grid grid in grids)
            {
                grid.Width = _Width;
            }
        }
    }
}
