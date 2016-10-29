using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CityVitalsWatcher
{
	public class CityVitalsWatcherMod : IUserMod
	{
		public static CityVitalsWatcherSettings Settings = new CityVitalsWatcherSettings();

		public CityVitalsWatcherMod()
		{
			Debug.Log("Created");
		}

		public string Description => "";

		public string Name => "City Vitals Watcher";
	}
}