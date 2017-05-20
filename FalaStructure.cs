using UnityEngine;
using System.Collections;
using System.Xml; 
using System.Xml.Serialization; 
using System.Collections.Generic;
[System.Serializable]
public class FalaStructure : System.Object{
	
		public Fala fal;

	[System.Serializable]
	public struct Fala
	{
		//public int lvl;
		public int iletypow;
		public falmob[] mobfal;
	}
	[System.Serializable]
	public struct falmob
	{
		public int typ;
		public int ilo;
	}
	}
