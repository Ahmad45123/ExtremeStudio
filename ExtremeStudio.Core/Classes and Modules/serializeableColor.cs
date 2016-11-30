using System.Windows.Media;

namespace ExtremeStudio.Core.Modules
{
	public class SerializeableColor
	{
		public byte R {get; set;}
		public byte G {get; set;}
		public byte B {get; set;}
		public byte A {get; set;}
		
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
