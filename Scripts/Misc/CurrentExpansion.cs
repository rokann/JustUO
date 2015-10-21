#region References
using System;
using Server.Network;
using Server.Accounting;
#endregion

namespace Server
{
	public class CurrentExpansion
	{
		private static readonly Expansion Expansion = (Expansion)Convert.ToInt32(Shard.Xml("era"));

		public static void Configure()
		{
			Core.Expansion = Expansion;
			
			AccountGold.Enabled = Core.TOL;
			AccountGold.ConvertOnBank = true;
			AccountGold.ConvertOnTrade = false;
			VirtualCheck.UseEditGump = true;

			bool Enabled = Core.AOS;

			Mobile.InsuranceEnabled = Enabled;
			ObjectPropertyList.Enabled = Enabled;
			Mobile.VisibleDamageType = Enabled ? VisibleDamageType.Related : VisibleDamageType.None;
			Mobile.GuildClickMessage = !Enabled;
			Mobile.AsciiClickMessage = !Enabled;

			if (Enabled)
			{
				AOS.DisableStatInfluences();

				if (ObjectPropertyList.Enabled)
				{
					PacketHandlers.SingleClickProps = true; // single click for everything is overriden to check object property list
				}

				Mobile.ActionDelay = 1000;
				Mobile.AosStatusHandler = AOS.GetStatus;
			}
		}
	}
}
