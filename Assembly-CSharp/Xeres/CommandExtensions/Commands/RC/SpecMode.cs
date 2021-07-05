using UnityEngine;
namespace Xeres.CommandExtensions.Commands
{
	public class SpecMode : Command
	{
		private string[] names = { "specmode" };
		public override string[] commandNames
		{
			get
			{
				return names;
			}
		}
		public override string description
		{
			get
			{
				return "Puts you into spectator mode";
			}
		}
		public override void executeCommand(string args)
		{
			if (((int)FengGameManagerMKII.settings[0xf5]) == 0)
			{
				FengGameManagerMKII.settings[0xf5] = 1;
				FengGameManagerMKII.instance.EnterSpecMode(true);
				this.addLINE("You have entered spectator mode.");
			}
			else
			{
				FengGameManagerMKII.settings[0xf5] = 0;
				FengGameManagerMKII.instance.EnterSpecMode(false);
				this.addLINE("You have exited spectator mode.");
			}
		}
	}
}
