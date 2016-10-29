using ColossalFramework;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CityVitalsWatcher
{
	public abstract class CityVitalsWatcherAlertPanel : UIPanel
	{
		protected UISlider m_Meter;
		protected UITextureSprite m_TextureSprite;
		protected UITextureSprite m_CopiedTextureSprite;
		protected bool m_initialized;


		protected CityVitalsWatcherAlertPanel()
		{
			size = new Vector2(300f, 32f);
		}


		public virtual int GetPercentage(int capacity, int need) => GetPercentage(capacity, need, 45, 55);

		protected virtual int GetPercentage(int capacity, int need, int needMin, int needMax)
		{
			if(need != 0)
			{
				float percent = ((float)capacity) / ((float)need);
				return (int)(percent * ((needMin + needMax) / 2));
			}

			if(capacity == 0)
			{
				return 0;
			}

			return 100;
		}

		protected abstract string StatisticLocaleId
		{
			get;
		}

		protected abstract Type InfoPanelType
		{
			get;
		}

		protected abstract string IconSpriteName
		{
			get;
		}

		protected abstract int Capacity
		{
			get;
		}

		protected abstract int Need
		{
			get;
		}

		protected abstract Metric Metric
		{
			get;
		}

		protected virtual string InfoViewPanelGameObjectName => "(Library) " + InfoPanelType.Name;

		protected abstract string MetricSliderName
		{
			get;
		}

		protected abstract InfoManager.InfoMode InfoMode
		{
			get;
		}

		protected virtual string UnlockedMilestone => null;

		protected virtual bool IsUnlocked => true;


		protected virtual void AddSettingsToInfoPanel(string namePrefix, UISlider meter)
		{
			var parent = meter.parent;

			var maxMeter = new GameObject(namePrefix + "MaxSlider") { transform = { parent = parent.transform } }.AddComponent<UISlider>();
			maxMeter.size = meter.size;
			maxMeter.isInteractive = true;
			maxMeter.relativePosition = new Vector3(meter.relativePosition.x, meter.relativePosition.y - 6f);
			var maxThumb = new GameObject(namePrefix + "MaxThumb") { transform = { parent = maxMeter.transform } }.AddComponent<UISprite>();
			maxThumb.spriteName = "LocationMarkerActiveHovered";
			maxThumb.size = new Vector2(16f, 16f);
			maxMeter.thumbObject = maxThumb;

			var minMeter = new GameObject(namePrefix + "MinSlider") { transform = { parent = parent.transform } }.AddComponent<UISlider>();
			minMeter.size = meter.size;
			minMeter.isInteractive = true;
			minMeter.relativePosition = new Vector3(meter.relativePosition.x, meter.relativePosition.y + meter.size.y - 6f);
			var minThumb = new GameObject(namePrefix + "MinThumb") { transform = { parent = minMeter.transform } }.AddComponent<UISprite>();
			minThumb.spriteName = "LocationMarkerActiveHovered";
			minThumb.flip = UISpriteFlip.FlipVertical;
			minThumb.size = new Vector2(16f, 16f);
			minMeter.thumbObject = minThumb;

			maxMeter.eventValueChanged += delegate (UIComponent component, float value)
			{
				if(value < minMeter.value)
				{
					maxMeter.value = minMeter.value;
				}

				maxThumb.spriteName = maxMeter.value == 100 ? "LocationMarkerActiveDisabled" : "LocationMarkerActiveHovered";

				Metric.MaxValue = maxMeter.value;
			};

			minMeter.eventValueChanged += delegate (UIComponent component, float value)
			{
				if(value > maxMeter.value)
				{
					minMeter.value = maxMeter.value;
				}

				minThumb.spriteName = minMeter.value == 0 ? "LocationMarkerActiveDisabled" : "LocationMarkerActiveHovered";

				Metric.MinValue = minMeter.value;
			};

			maxMeter.value = Metric.MaxValue;
			minMeter.value = Metric.MinValue;
		}


		public override void Start()
		{
			var fontColor = new Color32(254, 254, 254, 255);
			var namePrefix = GetType().Name;
			var go = GameObject.Find(InfoViewPanelGameObjectName);
			var ivp = go.GetComponent(InfoPanelType) as InfoViewPanel;
			var meter = ivp.Find<UISlider>(MetricSliderName);

			var sprite = new GameObject(namePrefix + "Sprite") { transform = { parent = transform } }.AddComponent<UISprite>();
			sprite.spriteName = IconSpriteName;
			sprite.size = new Vector2(26f, 26f);
			sprite.relativePosition = new Vector3(6f, 3f);

			var label = new GameObject(namePrefix + "Label") { transform = { parent = transform } }.AddComponent<UILabel>();
			label.textColor = fontColor;
			label.textScale = 0.9f;
			label.textScaleMode = UITextScaleMode.ScreenResolution;
			label.localeID = StatisticLocaleId;
			label.relativePosition = new Vector3(35f, 0f);

			m_Meter = new GameObject(namePrefix + "Slider") { transform = { parent = transform } }.AddComponent<UISlider>();
			m_Meter.backgroundSprite = meter.backgroundSprite;
			m_Meter.size = new Vector2(260f, 12f);
			m_Meter.relativePosition = new Vector3(35f, 18f);

			var thumb = new GameObject(namePrefix + "Thumb") { transform = { parent = m_Meter.transform } }.AddComponent<UISprite>();
			thumb.spriteName = "MeterIndicator";
			thumb.size = new Vector2(14f, 14f);

			m_Meter.thumbObject = thumb;

			foreach(var component in meter.components)
			{
				var textureSprite = component as UITextureSprite;
				if(textureSprite != null)
				{
					m_CopiedTextureSprite = textureSprite;
					m_TextureSprite = GameObject.Instantiate<UITextureSprite>(textureSprite);
					m_TextureSprite.name = (namePrefix + "Gradient");
					m_TextureSprite.transform.parent = m_Meter.transform;
					m_TextureSprite.size = m_Meter.size;
					m_TextureSprite.transform.localPosition = Vector3.zero;
					m_TextureSprite.relativePosition = Vector3.zero;
					m_TextureSprite.renderMaterial.CopyPropertiesFromMaterial(textureSprite.renderMaterial);
				}
			}

			AddSettingsToInfoPanel(namePrefix, meter);
		}

		public override void Update()
		{
			int capacity = 0;
			int need = 0;

			if(Singleton<DistrictManager>.exists)
			{
				capacity = Capacity;
				need = Need;
			}

			var milestoneUnlocked = true;

			if(string.IsNullOrEmpty(UnlockedMilestone) == false)
			{
				milestoneUnlocked = Singleton<UnlockManager>.instance.Unlocked(MilestoneCollection.FindMilestone(UnlockedMilestone));
			}

			var isUnlocked = Singleton<UnlockManager>.instance.Unlocked(InfoMode) && milestoneUnlocked && IsUnlocked;

			var value = GetPercentage(capacity, need);
			var minValue = Metric.MinValue;
			var maxValue = Metric.MaxValue;

			bool oldIsAlertActive = IsAlertActive;

			IsAlertActive = isUnlocked && ((value < minValue && minValue > 0) || (value > maxValue && maxValue < 100));
			m_Meter.value = value;

			if(m_TextureSprite != null)
			{
				m_TextureSprite.size = m_Meter.size;
				m_TextureSprite.relativePosition = Vector3.zero;
				m_TextureSprite.isEnabled = false;
				m_TextureSprite.isEnabled = true;
			}

			m_initialized = true;
		}

		public bool IsAlertActive
		{
			get; set;
		}
	}
}