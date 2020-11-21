using System;
using System.IO;
using System.Xml.Serialization;
using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace TrueBrigands
{
	public class SubModule : MBSubModuleBase
	{
		protected override void OnBeforeInitialModuleScreenSetAsRoot()
		{
			base.OnBeforeInitialModuleScreenSetAsRoot();
			new Harmony("HLC.TrueBrigands").PatchAll();
			Support.LogMessage("True Brigands Loaded");
			try
			{
				using (Stream stream = new FileStream(Path.Combine(BasePath.Name, "Modules", "TrueBrigands", "Settings.xml"), FileMode.Open))
				{
					Support.settings = (Settings)new XmlSerializer(typeof(Settings)).Deserialize(stream);
				}
				SubModule.GenerateTemplate();
			}
			catch (Exception ex)
			{
				Support.LogMessage("True Brigands: Could not read setting, using default values!");
				Support.settings = new Settings();
			}
		}

		private static void GenerateTemplate()
		{
			string text = "";
			using (StreamReader streamReader = new StreamReader(Path.Combine(BasePath.Name, "Modules", "TrueBrigands\\ModuleData", "partyTemplates_TrueBrigands_dummy.xml"), false))
			{
				text = streamReader.ReadToEnd();
			}
			double num = Support.settings.looters_female_percentage;
			bool flag = num < 0.0;
			if (flag)
			{
				num = 0.0;
			}
			else
			{
				bool flag2 = num > 1.0;
				if (flag2)
				{
					num = 1.0;
				}
			}
			double num2 = 1.0 - num;
			text = text.Replace("LBNDT_M_M_MIN", ((int)((double)Support.settings.looters_minimum_melee * num2)).ToString());
			text = text.Replace("LBNDT_M_M_MAX", ((int)((double)Support.settings.looters_maximum_melee * num2)).ToString());
			text = text.Replace("LBNDT_F_M_MIN", ((int)((double)Support.settings.looters_minimum_melee * num)).ToString());
			text = text.Replace("LBNDT_F_M_MAX", ((int)((double)Support.settings.looters_maximum_melee * num)).ToString());
			text = text.Replace("LBNDT_M_R_MIN", ((int)((double)Support.settings.looters_minimum_ranged * num2)).ToString());
			text = text.Replace("LBNDT_M_R_MAX", ((int)((double)Support.settings.looters_maximum_ranged * num2)).ToString());
			text = text.Replace("LBNDT_F_R_MIN", ((int)((double)Support.settings.looters_minimum_ranged * num)).ToString());
			text = text.Replace("LBNDT_F_R_MAX", ((int)((double)Support.settings.looters_maximum_ranged * num)).ToString());
			num = Support.settings.sea_raiders_female_percentage;
			bool flag3 = num < 0.0;
			if (flag3)
			{
				num = 0.0;
			}
			else
			{
				bool flag4 = num > 1.0;
				if (flag4)
				{
					num = 1.0;
				}
			}
			num2 = 1.0 - num;
			text = text.Replace("SBNDT_M_M1_MIN", ((int)((double)Support.settings.sea_raiders_minimum_melee_level1 * num2)).ToString());
			text = text.Replace("SBNDT_M_M1_MAX", ((int)((double)Support.settings.sea_raiders_maximum_melee_level1 * num2)).ToString());
			text = text.Replace("SBNDT_F_M1_MIN", ((int)((double)Support.settings.sea_raiders_minimum_melee_level1 * num)).ToString());
			text = text.Replace("SBNDT_F_M1_MAX", ((int)((double)Support.settings.sea_raiders_maximum_melee_level1 * num)).ToString());
			text = text.Replace("SBNDT_M_M2_MIN", ((int)((double)Support.settings.sea_raiders_minimum_melee_level2 * num2)).ToString());
			text = text.Replace("SBNDT_M_M2_MAX", ((int)((double)Support.settings.sea_raiders_maximum_melee_level2 * num2)).ToString());
			text = text.Replace("SBNDT_F_M2_MIN", ((int)((double)Support.settings.sea_raiders_minimum_melee_level2 * num)).ToString());
			text = text.Replace("SBNDT_F_M2_MAX", ((int)((double)Support.settings.sea_raiders_maximum_melee_level2 * num)).ToString());
			text = text.Replace("SBNDT_M_M3_MIN", ((int)((double)Support.settings.sea_raiders_minimum_melee_level3 * num2)).ToString());
			text = text.Replace("SBNDT_M_M3_MAX", ((int)((double)Support.settings.sea_raiders_maximum_melee_level3 * num2)).ToString());
			text = text.Replace("SBNDT_F_M3_MIN", ((int)((double)Support.settings.sea_raiders_minimum_melee_level3 * num)).ToString());
			text = text.Replace("SBNDT_F_M3_MAX", ((int)((double)Support.settings.sea_raiders_maximum_melee_level3 * num)).ToString());
			text = text.Replace("SBNDT_M_R_MIN", Support.settings.sea_raiders_minimum_ranged.ToString());
			text = text.Replace("SBNDT_M_R_MAX", Support.settings.sea_raiders_maximum_ranged.ToString());
			num = Support.settings.highlanders_female_percentage;
			bool flag5 = num < 0.0;
			if (flag5)
			{
				num = 0.0;
			}
			else
			{
				bool flag6 = num > 1.0;
				if (flag6)
				{
					num = 1.0;
				}
			}
			num2 = 1.0 - num;
			text = text.Replace("MBNDT_M_M1_MIN", ((int)((double)Support.settings.highlanders_minimum_melee_level1 * num2)).ToString());
			text = text.Replace("MBNDT_M_M1_MAX", ((int)((double)Support.settings.highlanders_maximum_melee_level1 * num2)).ToString());
			text = text.Replace("MBNDT_F_M1_MIN", ((int)((double)Support.settings.highlanders_minimum_melee_level1 * num)).ToString());
			text = text.Replace("MBNDT_F_M1_MAX", ((int)((double)Support.settings.highlanders_maximum_melee_level1 * num)).ToString());
			text = text.Replace("MBNDT_M_M2_MIN", Support.settings.highlanders_minimum_melee_level2.ToString());
			text = text.Replace("MBNDT_M_M2_MAX", Support.settings.highlanders_maximum_melee_level2.ToString());
			text = text.Replace("MBNDT_M_R1_MIN", ((int)((double)Support.settings.highlanders_minimum_ranged_level1 * num2)).ToString());
			text = text.Replace("MBNDT_M_R1_MAX", ((int)((double)Support.settings.highlanders_maximum_ranged_level1 * num2)).ToString());
			text = text.Replace("MBNDT_F_R1_MIN", ((int)((double)Support.settings.highlanders_minimum_ranged_level1 * num)).ToString());
			text = text.Replace("MBNDT_F_R1_MAX", ((int)((double)Support.settings.highlanders_maximum_ranged_level1 * num)).ToString());
			text = text.Replace("MBNDT_F_R2_MIN", ((int)((double)Support.settings.highlanders_minimum_ranged_level2 * num)).ToString());
			text = text.Replace("MBNDT_F_R2_MAX", ((int)((double)Support.settings.highlanders_maximum_ranged_level2 * num)).ToString());
			text = text.Replace("MBNDT_F_R3_MIN", ((int)((double)Support.settings.highlanders_minimum_ranged_level3 * num)).ToString());
			text = text.Replace("MBNDT_F_R3_MAX", ((int)((double)Support.settings.highlanders_maximum_ranged_level3 * num)).ToString());
			text = text.Replace("MBNDT_M_C_MIN", Support.settings.highlanders_minimum_cavalry.ToString());
			text = text.Replace("MBNDT_M_C_MAX", Support.settings.highlanders_maximum_cavalry.ToString());
			text = text.Replace("FBNDT_M1_MIN", Support.settings.forest_bandits_minimum_melee_level1.ToString());
			text = text.Replace("FBNDT_M1_MAX", Support.settings.forest_bandits_maximum_melee_level1.ToString());
			text = text.Replace("FBNDT_M2_MIN", Support.settings.forest_bandits_minimum_melee_level2.ToString());
			text = text.Replace("FBNDT_M2_MAX", Support.settings.forest_bandits_maximum_melee_level2.ToString());
			text = text.Replace("FBNDT_R1_MIN", Support.settings.forest_bandits_minimum_ranged_level1.ToString());
			text = text.Replace("FBNDT_R1_MAX", Support.settings.forest_bandits_maximum_ranged_level1.ToString());
			text = text.Replace("FBNDT_R2_MIN", Support.settings.forest_bandits_minimum_ranged_level2.ToString());
			text = text.Replace("FBNDT_R2_MAX", Support.settings.forest_bandits_maximum_ranged_level2.ToString());
			text = text.Replace("FBNDT_C_MIN", Support.settings.forest_bandits_minimum_cavalry.ToString());
			text = text.Replace("FBNDT_C_MAX", Support.settings.forest_bandits_maximum_cavalry.ToString());
			text = text.Replace("DBNDT_M1_MIN", Support.settings.bedouin_minimum_melee_level1.ToString());
			text = text.Replace("DBNDT_M1_MAX", Support.settings.bedouin_maximum_melee_level1.ToString());
			text = text.Replace("DBNDT_M2_MIN", Support.settings.bedouin_minimum_melee_level2.ToString());
			text = text.Replace("DBNDT_M2_MAX", Support.settings.bedouin_maximum_melee_level2.ToString());
			text = text.Replace("DBNDT_R_MIN", Support.settings.bedouin_minimum_ranged.ToString());
			text = text.Replace("DBNDT_R_MAX", Support.settings.bedouin_maximum_ranged.ToString());
			text = text.Replace("DBNDT_C1_MIN", Support.settings.bedouin_minimum_cavalry_level1.ToString());
			text = text.Replace("DBNDT_C1_MAX", Support.settings.bedouin_maximum_cavalry_level1.ToString());
			text = text.Replace("DBNDT_C2_MIN", Support.settings.bedouin_minimum_cavalry_level2.ToString());
			text = text.Replace("DBNDT_C2_MAX", Support.settings.bedouin_maximum_cavalry_level2.ToString());
			text = text.Replace("DBNDT_H_MIN", Support.settings.bedouin_minimum_cavalry_archers.ToString());
			text = text.Replace("DBNDT_H_MAX", Support.settings.bedouin_maximum_cavalry_archers.ToString());
			num = Support.settings.khuzait_female_percentage;
			bool flag7 = num < 0.0;
			if (flag7)
			{
				num = 0.0;
			}
			else
			{
				bool flag8 = num > 1.0;
				if (flag8)
				{
					num = 1.0;
				}
			}
			num2 = 1.0 - num;
			text = text.Replace("KBNDT_M_C_MIN", ((int)((double)Support.settings.khuzait_minimum_cavalry * num2)).ToString());
			text = text.Replace("KBNDT_M_C_MAX", ((int)((double)Support.settings.khuzait_maximum_cavalry * num2)).ToString());
			text = text.Replace("KBNDT_F_C_MIN", ((int)((double)Support.settings.khuzait_minimum_cavalry * num)).ToString());
			text = text.Replace("KBNDT_F_C_MAX", ((int)((double)Support.settings.khuzait_maximum_cavalry * num)).ToString());
			text = text.Replace("KBNDT_M_H1_MIN", ((int)((double)Support.settings.khuzait_minimum_cavalry_archers_level1 * num2)).ToString());
			text = text.Replace("KBNDT_M_H1_MAX", ((int)((double)Support.settings.khuzait_maximum_cavalry_archers_level1 * num2)).ToString());
			text = text.Replace("KBNDT_F_H1_MIN", ((int)((double)Support.settings.khuzait_minimum_cavalry_archers_level1 * num)).ToString());
			text = text.Replace("KBNDT_F_H1_MAX", ((int)((double)Support.settings.khuzait_maximum_cavalry_archers_level1 * num)).ToString());
			text = text.Replace("KBNDT_M_H2_MIN", ((int)((double)Support.settings.khuzait_minimum_cavalry_archers_level2 * num2)).ToString());
			text = text.Replace("KBNDT_M_H2_MAX", ((int)((double)Support.settings.khuzait_maximum_cavalry_archers_level2 * num2)).ToString());
			text = text.Replace("KBNDT_F_H2_MIN", ((int)((double)Support.settings.khuzait_minimum_cavalry_archers_level2 * num)).ToString());
			text = text.Replace("KBNDT_F_H2_MAX", ((int)((double)Support.settings.khuzait_maximum_cavalry_archers_level2 * num)).ToString());
			using (StreamWriter streamWriter = new StreamWriter(Path.Combine(BasePath.Name, "Modules", "TrueBrigands\\ModuleData", "partyTemplates_TrueBrigands.xml"), false))
			{
				streamWriter.Write(text);
			}
		}

		public SubModule()
		{
		}
	}
}
