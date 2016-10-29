using ColossalFramework;
using ColossalFramework.UI;
using System;
using UnityEngine;

namespace CityVitalsWatcher
{
	public class ElectricityAvailability : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(ElectricityInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_ELECTRICITY_AVAILABILITY";
		protected override string IconSpriteName => "InfoIconElectricity";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetElectricityCapacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetElectricityConsumption();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.Electricity;
		protected override string MetricSliderName => "ElectricityMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Electricity;
	}

	public class WaterAvailability : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(WaterInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_WATER_WATERAVAILABILITY";
		protected override string IconSpriteName => "InfoIconWater";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetWaterCapacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetWaterConsumption();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.Water;
		protected override string MetricSliderName => "WaterMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Water;
	}

	public class SewageAvailability : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(WaterInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_WATER_SEWAGEAVAILABILITY";
		protected override string IconSpriteName => "InfoIconWater";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetSewageCapacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetSewageAccumulation();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.Sewage;
		protected override string MetricSliderName => "SewageMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Water;
	}

	public class ResidentialHappiness : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(HappinessInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_HAPPINESS_RESIDENTIAL";
		protected override string IconSpriteName => "InfoIconHappiness";
		protected override int Capacity => 0;
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].m_residentialData.m_finalHappiness;
		protected override Metric Metric => CityVitalsWatcherMod.Settings.ResidentialHappiness;
		protected override string MetricSliderName => "ResidentialBar";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Happiness;
		protected override bool IsUnlocked => (Singleton<DistrictManager>.instance.m_districts.m_buffer[0].m_residentialData.m_finalHomeOrWorkCount > 0);

		public override int GetPercentage(int capacity, int need)
		{
			return need;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_modeProperties[5].m_targetColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[5].m_negativeColor);
				m_TextureSprite.renderMaterial.SetFloat("_Step", 0.2f);
				m_TextureSprite.renderMaterial.SetFloat("_Scalar", 1.25f);
				m_TextureSprite.renderMaterial.SetFloat("_Offset", 0f);
			}
			base.Update();
		}
	}

	public class CommercialHappiness : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(HappinessInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_HAPPINESS_COMMERCIAL";
		protected override string IconSpriteName => "InfoIconHappiness";
		protected override int Capacity => 0;
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].m_commercialData.m_finalHappiness;
		protected override Metric Metric => CityVitalsWatcherMod.Settings.CommercialHappiness;
		protected override string MetricSliderName => "CommercialBar";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Happiness;
		protected override bool IsUnlocked => (Singleton<DistrictManager>.instance.m_districts.m_buffer[0].m_commercialData.m_finalHomeOrWorkCount > 0);

		public override int GetPercentage(int capacity, int need)
		{
			return need;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_modeProperties[5].m_targetColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[5].m_negativeColor);
				m_TextureSprite.renderMaterial.SetFloat("_Step", 0.2f);
				m_TextureSprite.renderMaterial.SetFloat("_Scalar", 1.25f);
				m_TextureSprite.renderMaterial.SetFloat("_Offset", 0f);
			}
			base.Update();
		}
	}

	public class OfficeHappiness : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(HappinessInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_HAPPINESS_OFFICE";
		protected override string IconSpriteName => "InfoIconHappiness";
		protected override int Capacity => 0;
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].m_officeData.m_finalHappiness;
		protected override Metric Metric => CityVitalsWatcherMod.Settings.OfficeHappiness;
		protected override string MetricSliderName => "OfficeBar";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Happiness;
		protected override bool IsUnlocked => (Singleton<DistrictManager>.instance.m_districts.m_buffer[0].m_officeData.m_finalHomeOrWorkCount > 0);

		public override int GetPercentage(int capacity, int need)
		{
			return need;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_modeProperties[5].m_targetColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[5].m_negativeColor);
				m_TextureSprite.renderMaterial.SetFloat("_Step", 0.2f);
				m_TextureSprite.renderMaterial.SetFloat("_Scalar", 1.25f);
				m_TextureSprite.renderMaterial.SetFloat("_Offset", 0f);
			}
			base.Update();
		}
	}

	public class IndustrialHappiness : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(HappinessInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_HAPPINESS_INDUSTRIAL";
		protected override string IconSpriteName => "InfoIconHappiness";
		protected override int Capacity => 0;
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].m_industrialData.m_finalHappiness;
		protected override Metric Metric => CityVitalsWatcherMod.Settings.IndustrialHappiness;
		protected override string MetricSliderName => "IndustrialBar";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Happiness;
		protected override bool IsUnlocked => (Singleton<DistrictManager>.instance.m_districts.m_buffer[0].m_industrialData.m_finalHomeOrWorkCount > 0);

		public override int GetPercentage(int capacity, int need)
		{
			return need;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_modeProperties[5].m_targetColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[5].m_negativeColor);
				m_TextureSprite.renderMaterial.SetFloat("_Step", 0.2f);
				m_TextureSprite.renderMaterial.SetFloat("_Scalar", 1.25f);
				m_TextureSprite.renderMaterial.SetFloat("_Offset", 0f);
			}
			base.Update();
		}
	}

	public class LandfillUsage : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(GarbageInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_GARBAGE_LANDFILL";
		protected override string IconSpriteName => "InfoIconGarbage";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetGarbageCapacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetGarbageAmount();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.Garbage;
		protected override string MetricSliderName => "LandfillMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Garbage;

		public override int GetPercentage(int capacity, int need)
		{
			if(capacity > 0)
			{
				return (int)((need / (float)capacity) * 100);
			}

			return 0;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_modeProperties[16].m_targetColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[16].m_negativeColor);
			}
			base.Update();
		}
	}

	public class IncineratorUsage : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(GarbageInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_GARBAGE_INCINERATOR";
		protected override string IconSpriteName => "InfoIconGarbage";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetIncinerationCapacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetGarbageAccumulation();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.Incinerator;
		protected override string MetricSliderName => "IncineratorMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Garbage;
		protected override string UnlockedMilestone => "Milestone6";
	}

	public class ElementarySchoolAvailability : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(EducationInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_EDUCATION_AVAILABILITY1";
		protected override string IconSpriteName => "InfoIconEducation";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetEducation1Capacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetEducation1Need();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.ElementarySchool;
		protected override string MetricSliderName => "ElementaryMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Education;
	}

	public class HighSchoolAvailability : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(EducationInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_EDUCATION_AVAILABILITY2";
		protected override string IconSpriteName => "InfoIconEducation";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetEducation2Capacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetEducation2Need();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.HighSchool;
		protected override string MetricSliderName => "HighMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Education;
		protected override string UnlockedMilestone => "Milestone3";
	}

	public class UniversityAvailability : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(EducationInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_EDUCATION_AVAILABILITY3";
		protected override string IconSpriteName => "InfoIconEducation";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetEducation3Capacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetEducation3Need();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.University;
		protected override string MetricSliderName => "UnivMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Education;
		protected override string UnlockedMilestone => "Milestone6";
	}

	public class HealthcareAvailability : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(HealthInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_HEALTH_HEALTHCARE_AVAILABILITY";
		protected override string IconSpriteName => "InfoIconHealth";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetHealCapacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetSickCount();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.Healthcare;
		protected override string MetricSliderName => "HealthcareMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Health;
	}

	public class AverageHealth : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(HealthInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_HEALTH_AVERAGE";
		protected override string IconSpriteName => "InfoIconHealth";
		protected override int Capacity => 0;
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].m_residentialData.m_finalHealth;
		protected override Metric Metric => CityVitalsWatcherMod.Settings.AverageHealth;
		protected override string MetricSliderName => "AvgHealthBar";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Health;

		public override int GetPercentage(int capacity, int need)
		{
			return need;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_modeProperties[4].m_negativeColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[4].m_targetColor);
				m_TextureSprite.renderMaterial.SetFloat("_Step", 0.1666667f);
				m_TextureSprite.renderMaterial.SetFloat("_Scalar", 1.2f);
				m_TextureSprite.renderMaterial.SetFloat("_Offset", 0f);
			}
			base.Update();
		}
	}

	public class CemetaryUsage : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(HealthInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_HEALTH_CEMETARYUSAGE";
		protected override string IconSpriteName => "InfoIconHealth";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetDeadCapacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetDeadAmount();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.Cemetary;
		protected override string MetricSliderName => "CemetaryMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Health;

		public override int GetPercentage(int capacity, int need)
		{
			if(capacity > 0)
			{
				return (int)((need / (float)capacity) * 100);
			}

			return 0;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_modeProperties[4].m_targetColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[4].m_negativeColor);
				m_TextureSprite.renderMaterial.SetFloat("_Step", 0.1666667f);
				m_TextureSprite.renderMaterial.SetFloat("_Scalar", 1.2f);
				m_TextureSprite.renderMaterial.SetFloat("_Offset", 0f);
			}
			base.Update();
		}
	}

	public class CrematoriumAvailability : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(HealthInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_HEALTH_CREMATORIUMAVAILABILITY";
		protected override string IconSpriteName => "InfoIconHealth";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetCremateCapacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetDeadAmount();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.Crematorium;
		protected override string MetricSliderName => "DeathcareMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Health;
	}

	public class GroundPolution : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(PollutionInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_POLLUTION_GROUND";
		protected override string IconSpriteName => "InfoIconPollution";
		protected override int Capacity => 0;
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetGroundPollution();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.GroundPollution;
		protected override string MetricSliderName => "GroundPollutionBar";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Pollution;

		public override int GetPercentage(int capacity, int need)
		{
			return need;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_neutralColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[9].m_activeColor);
				m_TextureSprite.renderMaterial.SetFloat("_Step", 0.1666667f);
				m_TextureSprite.renderMaterial.SetFloat("_Scalar", 1.2f);
				m_TextureSprite.renderMaterial.SetFloat("_Offset", 0f);
			}
			base.Update();
		}
	}

	public class WaterPolution : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(PollutionInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_POLLUTION_WATER";
		protected override string IconSpriteName => "InfoIconPollution";
		protected override int Capacity => 0;
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetWaterPollution();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.WaterPollution;
		protected override string MetricSliderName => "WaterPollutionBar";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Pollution;

		public override int GetPercentage(int capacity, int need)
		{
			return need;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_neutralColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[9].m_activeColor);
				m_TextureSprite.renderMaterial.SetFloat("_Step", 0.1666667f);
				m_TextureSprite.renderMaterial.SetFloat("_Scalar", 1.2f);
				m_TextureSprite.renderMaterial.SetFloat("_Offset", 0f);
			}
			base.Update();
		}
	}

	public class NoisePolution : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(NoisePollutionInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_NOISEPOLLUTION_AVERAGE";
		protected override string IconSpriteName => "InfoIconNoisePollution";
		protected override int Capacity => 0;
		protected override int Need
		{
			get
			{
				int need = 0;
				Singleton<ImmaterialResourceManager>.instance.CheckTotalResource(ImmaterialResourceManager.Resource.NoisePollution, out need);
				return need;
			}
		}
		protected override Metric Metric => CityVitalsWatcherMod.Settings.NoisePollution;
		protected override string MetricSliderName => "NoisePollutionBar";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.NoisePollution;

		public override int GetPercentage(int capacity, int need)
		{
			return need;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_neutralColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[7].m_activeColorB);
				m_TextureSprite.renderMaterial.SetColor("_ColorC", Singleton<InfoManager>.instance.m_properties.m_modeProperties[7].m_activeColor);
				m_TextureSprite.renderMaterial.SetFloat("_Step", 0.2222222f);
				m_TextureSprite.renderMaterial.SetFloat("_Scalar", 1.1f);
				m_TextureSprite.renderMaterial.SetFloat("_Offset", 0f);
			}
			base.Update();
		}
	}

	public class FireSafety : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(FireSafetyInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_FIRE_SAFETY";
		protected override string IconSpriteName => "InfoIconFireSafety";
		protected override int Capacity => 0;
		protected override int Need
		{
			get
			{
				int need = 0;
				Singleton<ImmaterialResourceManager>.instance.CheckTotalResource(ImmaterialResourceManager.Resource.FireHazard, out need);
				return need;
			}
		}
		protected override Metric Metric => CityVitalsWatcherMod.Settings.FireSafety;
		protected override string MetricSliderName => "SafetyMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.FireSafety;

		public override int GetPercentage(int capacity, int need)
		{
			return need;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_modeProperties[18].m_targetColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[18].m_negativeColor);
			}
			base.Update();
		}
	}

	public class CrimeRate : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(CrimeInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_CRIMERATE_METER";
		protected override string IconSpriteName => "InfoIconCrime";
		protected override int Capacity => 0;
		protected override int Need
		{
			get
			{
				int need = 0;
				Singleton<ImmaterialResourceManager>.instance.CheckTotalResource(ImmaterialResourceManager.Resource.CrimeRate, out need);
				return need;
			}
		}
		protected override Metric Metric => CityVitalsWatcherMod.Settings.CrimeRate;
		protected override string MetricSliderName => "SafetyMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.CrimeRate;

		public override int GetPercentage(int capacity, int need)
		{
			return need;
		}
		public override void Update()
		{
			if(!m_initialized)
			{
				m_TextureSprite.renderMaterial.SetColor("_ColorA", Singleton<InfoManager>.instance.m_properties.m_modeProperties[3].m_targetColor);
				m_TextureSprite.renderMaterial.SetColor("_ColorB", Singleton<InfoManager>.instance.m_properties.m_modeProperties[3].m_negativeColor);
			}
			base.Update();
		}
	}

	public class JailsAvailability : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(CrimeInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_CRIME_JAIL_AVAILABILITY";
		protected override string IconSpriteName => "InfoIconCrime";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetCriminalCapacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetCriminalAmount();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.Jails;
		protected override string MetricSliderName => "JailMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.CrimeRate;
	}

	public class HeatingAvailability : CityVitalsWatcherAlertPanel
	{
		protected override Type InfoPanelType => typeof(HeatingInfoViewPanel);
		protected override string StatisticLocaleId => "INFO_HEATING_AVAILABILITY";
		protected override string IconSpriteName => "InfoIconHeating";
		protected override int Capacity => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetHeatingCapacity();
		protected override int Need => Singleton<DistrictManager>.instance.m_districts.m_buffer[0].GetHeatingConsumption();
		protected override Metric Metric => CityVitalsWatcherMod.Settings.Heating;
		protected override string MetricSliderName => "HeatingMeter";
		protected override InfoManager.InfoMode InfoMode => InfoManager.InfoMode.Heating;
	}
}