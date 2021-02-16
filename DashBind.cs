using Terraria.ModLoader;

namespace DashBind
{
	public class DashBind : Mod
	{
		public static ModHotKey DashKey;

		public override void Load()
        {
			DashKey = RegisterHotKey("Dash", "Z");
        }

        public override void Unload()
        {
            DashKey = null;
        }
    }
}