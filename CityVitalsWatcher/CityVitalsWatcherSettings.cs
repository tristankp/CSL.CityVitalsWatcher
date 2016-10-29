using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityVitalsWatcher
{
	public class CityVitalsWatcherSettings
	{
		public Metric Electricity = new Metric() { MinValue = 55f, MaxValue = 100f };

		public Metric Water = new Metric() { MinValue = 55f, MaxValue = 100f };

		public Metric Sewage = new Metric() { MinValue = 55f, MaxValue = 100f };

		public Metric ResidentialHappiness = new Metric() { MinValue = 60f, MaxValue = 100f };

		public Metric CommercialHappiness = new Metric() { MinValue = 60f, MaxValue = 100f };

		public Metric OfficeHappiness = new Metric() { MinValue = 60f, MaxValue = 100f };

		public Metric IndustrialHappiness = new Metric() { MinValue = 60f, MaxValue = 100f };

		public Metric Garbage = new Metric() { MinValue = 50f, MaxValue = 60f };

		public Metric Incinerator = new Metric() { MinValue = 55f, MaxValue = 100f };

		public Metric ElementarySchool = new Metric() { MinValue = 55f, MaxValue = 100f };

		public Metric HighSchool = new Metric() { MinValue = 55f, MaxValue = 100f };

		public Metric University = new Metric() { MinValue = 55f, MaxValue = 100f };

		public Metric Healthcare = new Metric() { MinValue = 55f, MaxValue = 100f };

		public Metric AverageHealth = new Metric() { MinValue = 60f, MaxValue = 100f };

		public Metric Cemetary = new Metric() { MinValue = 0f, MaxValue = 60f };

		public Metric Crematorium = new Metric() { MinValue = 55f, MaxValue = 100f };

		public Metric GroundPollution = new Metric() { MinValue = 0f, MaxValue = 25f };

		public Metric WaterPollution = new Metric() { MinValue = 0f, MaxValue = 1f };

		public Metric NoisePollution = new Metric() { MinValue = 0f, MaxValue = 25f };

		public Metric FireSafety = new Metric() { MinValue = 0f, MaxValue = 25f };

		public Metric CrimeRate = new Metric() { MinValue = 0f, MaxValue = 25f };

		public Metric Jails = new Metric() { MinValue = 55f, MaxValue = 100f };

		public Metric Heating = new Metric() { MinValue = 55f, MaxValue = 100f };
	}

	public class Metric
	{
		public float MinValue;

		public float MaxValue;
	}
}