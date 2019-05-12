using UnityEditor;

public class BlockMaker_MenuItem : Editor
{
	[MenuItem("Dustin's Tools/Block Maker")]
	public static void CreateWindow()
	{
		BlockMaker.InstantiateWindow();
	}
}