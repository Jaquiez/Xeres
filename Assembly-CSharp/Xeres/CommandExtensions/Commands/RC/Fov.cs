using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
	public class Fov : Command
	{
		private string[] names = { "fov" };
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
				return "Changes your FOV";
			}
		}
		public override void executeCommand(string args)
		{
			int num = Convert.ToInt32(args);
			Camera.main.fieldOfView = num;
			addLINE("<color=#a60d1a>Field of vision set to " + num + ".</color>");
		}
	}
}
