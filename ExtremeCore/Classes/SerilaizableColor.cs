using System.Drawing;

namespace ExtremeCore.Classes
{
    public class SerilaizableColor
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }

        public Color GetColor()
        {
            return Color.FromArgb(A, R, G, B);
        }

        public void SetColor(Color clr)
        {
            A = clr.A;
            R = clr.R;
            G = clr.G;
            B = clr.B;
        }
    }
}