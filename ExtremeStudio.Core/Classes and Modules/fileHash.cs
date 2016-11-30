using System;
using System.IO;
using System.Security.Cryptography;


namespace ExtremeStudio.Core.Modules
{
	public sealed class FileHashGenerator
	{
		public static string GetFileHash(string fileName)
		{
			var sha = SHA1.Create();
			
			if (File.Exists(fileName) == false)
			{
				return System.Convert.ToString( false);
			}
			
			//To skipe file being used shit.
			byte[] fle = File.ReadAllBytes(fileName);
			return Convert.ToBase64String(sha.ComputeHash(fle));
		}
	}
}
