using BepInEx;
using UnityEngine;

namespace Chickenification {

	[BepInPlugin("teamgrad.chickenification", "Chickenification", "1.0.0")]
	public class CHLauncher : BaseUnityPlugin {

		public CHLauncher()
		{
			CHBinder.UnitGlad();
		}
		
	}
}
