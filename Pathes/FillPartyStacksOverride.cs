using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace TrueBrigands
{
	[HarmonyPatch(typeof(MobileParty), "FillPartyStacks")]
	internal class FillPartyStacksOverride
	{
		public static bool Prefix(ref MobileParty __instance, PartyTemplateObject pt, MobileParty.PartyTypeEnum partyType, int troopNumberLimit = -1)
		{
			bool result = true;
			if (partyType == MobileParty.PartyTypeEnum.Bandit)
			{
				int num = 0;
				for (int i = 0; i < pt.Stacks.Count; i++)
				{
					num = Support.Random(pt.Stacks[i].MinValue, pt.Stacks[i].MaxValue);
					if (num > 0 && pt.Stacks[i].Character != null)
					{
						__instance.AddElementToMemberRoster(pt.Stacks[i].Character, num);
					}
				}
				result = false;
			}
			return result;
		}
	}
}
