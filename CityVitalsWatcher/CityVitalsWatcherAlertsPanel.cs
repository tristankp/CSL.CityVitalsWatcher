using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CityVitalsWatcher
{
	public class CityVitalsWatcherAlertsPanel : UIPanel
	{
		private UIPanel _layerPanel;
		private List<CityVitalsWatcherAlertPanel> _alertPanels;


		public override void Start()
		{
			backgroundSprite = "InfoPanelBack";
			relativePosition = new Vector3(1400f, -6f);
			isVisible = true;
			size = new Vector2(305f + 12f, 100f);

			_layerPanel = new GameObject("Panel") { transform = { parent = transform } }.AddComponent<UIPanel>();
			_layerPanel.backgroundSprite = "TutorialGlow";
			_layerPanel.relativePosition = new Vector3(0f, 0f);
			_layerPanel.size = new Vector2(305f + 12f, 100f);

			_alertPanels = new List<CityVitalsWatcherAlertPanel>();
			_alertPanels.Add(new GameObject("ElectricityAvailability") { transform = { parent = _layerPanel.transform } }.AddComponent<ElectricityAvailability>());

			_alertPanels.Add(new GameObject("WaterAvailability") { transform = { parent = _layerPanel.transform } }.AddComponent<WaterAvailability>());
			_alertPanels.Add(new GameObject("SewageAvailability") { transform = { parent = _layerPanel.transform } }.AddComponent<SewageAvailability>());

			_alertPanels.Add(new GameObject("LandfillUsage") { transform = { parent = _layerPanel.transform } }.AddComponent<LandfillUsage>());
			_alertPanels.Add(new GameObject("IncineratorUsage") { transform = { parent = _layerPanel.transform } }.AddComponent<IncineratorUsage>());

			_alertPanels.Add(new GameObject("ElementarySchoolAvailability") { transform = { parent = _layerPanel.transform } }.AddComponent<ElementarySchoolAvailability>());
			_alertPanels.Add(new GameObject("HighSchoolAvailability") { transform = { parent = _layerPanel.transform } }.AddComponent<HighSchoolAvailability>());
			_alertPanels.Add(new GameObject("UniversityAvailability") { transform = { parent = _layerPanel.transform } }.AddComponent<UniversityAvailability>());

			_alertPanels.Add(new GameObject("ResidentialHappiness") { transform = { parent = _layerPanel.transform } }.AddComponent<ResidentialHappiness>());
			_alertPanels.Add(new GameObject("CommercialHappiness") { transform = { parent = _layerPanel.transform } }.AddComponent<CommercialHappiness>());
			_alertPanels.Add(new GameObject("OfficeHappiness") { transform = { parent = _layerPanel.transform } }.AddComponent<OfficeHappiness>());
			_alertPanels.Add(new GameObject("IndustrialHappiness") { transform = { parent = _layerPanel.transform } }.AddComponent<IndustrialHappiness>());

			_alertPanels.Add(new GameObject("HealthcareAvailability") { transform = { parent = _layerPanel.transform } }.AddComponent<HealthcareAvailability>());
			_alertPanels.Add(new GameObject("AverageHealth") { transform = { parent = _layerPanel.transform } }.AddComponent<AverageHealth>());
			_alertPanels.Add(new GameObject("CemetaryUsage") { transform = { parent = _layerPanel.transform } }.AddComponent<CemetaryUsage>());
			_alertPanels.Add(new GameObject("CrematoriumAvailability") { transform = { parent = _layerPanel.transform } }.AddComponent<CrematoriumAvailability>());

			_alertPanels.Add(new GameObject("GroundPolution") { transform = { parent = _layerPanel.transform } }.AddComponent<GroundPolution>());
			_alertPanels.Add(new GameObject("WaterPolution") { transform = { parent = _layerPanel.transform } }.AddComponent<WaterPolution>());

			_alertPanels.Add(new GameObject("NoisePolution") { transform = { parent = _layerPanel.transform } }.AddComponent<NoisePolution>());

			_alertPanels.Add(new GameObject("FireSafety") { transform = { parent = _layerPanel.transform } }.AddComponent<FireSafety>());

			_alertPanels.Add(new GameObject("CrimeRate") { transform = { parent = _layerPanel.transform } }.AddComponent<CrimeRate>());
			_alertPanels.Add(new GameObject("JailsAvailability") { transform = { parent = _layerPanel.transform } }.AddComponent<JailsAvailability>());

			_alertPanels.Add(new GameObject("HeatingAvailability") { transform = { parent = _layerPanel.transform } }.AddComponent<HeatingAvailability>());
		}

		public override void Update()
		{
			bool hasActiveAlert = false;
			float curHeight = 12f;
			foreach(var alert in _alertPanels)
			{
				if(alert.IsAlertActive)
				{
					alert.isVisible = true;
					alert.relativePosition = new Vector3(6f, curHeight);

					hasActiveAlert = true;
					curHeight += alert.size.y + 6f;
				}
				else
				{
					alert.isVisible = false;
				}
			}

			if(hasActiveAlert)
			{
				height = curHeight + 6f;
			}
			else
			{
				height = 6f;
			}

			_layerPanel.height = height;
		}
	}
}