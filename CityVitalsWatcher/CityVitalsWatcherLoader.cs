using ColossalFramework.UI;
using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CityVitalsWatcher
{
	public class CityVitalsWatcherLoader : LoadingExtensionBase
	{
		private CityVitalsWatcherAlertsPanel _alertPanel;


		public override void OnLevelLoaded(LoadMode mode)
		{
			if(mode == LoadMode.LoadGame || mode == LoadMode.NewGame)
			{
				DebugUtils.Log("Loading");

				UIView uiView = null;
				foreach(var view in UnityEngine.Object.FindObjectsOfType<UIView>())
				{
					if(view.name == "UIView")
					{
						uiView = view;
						break;
					}
				}

				if(uiView != null)
				{
					_alertPanel = new GameObject("CVW_AlertPanel") { transform = { parent = uiView.cachedTransform } }.AddComponent<CityVitalsWatcherAlertsPanel>();
				}
			}
		}

		public override void OnLevelUnloading()
		{
			DebugUtils.Log("Unloading");

			if(_alertPanel != null)
			{
				_alertPanel.gameObject.SetActive(false);
				UnityEngine.Object.Destroy(_alertPanel.gameObject);
			}
			_alertPanel = null;
		}
	}
}