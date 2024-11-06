using System.Diagnostics;

string veyonPath = @"c:\Program Files\Veyon";
string keyFolder = "keys";

if (args.Length > 0)
	keyFolder = args[0];
if (args.Length > 1)
	veyonPath = args[1];

using (Process configTool = new Process())
{
	configTool.StartInfo.FileName = Path.Combine(veyonPath, "veyon-cli.exe");

	configTool.StartInfo.Arguments = $"config set Authentication/PrivateKeyBaseDir \"%GLOBALAPPDATA%\\{keyFolder}\\private\"";
	configTool.StartInfo.UseShellExecute = true;
	configTool.StartInfo.Verb = "runas";
	configTool.Start();
	configTool.WaitForExit();
}

//using (Process configTool = new Process())
//{
//	configTool.StartInfo.FileName = Path.Combine(veyonPath, "veyon-cli.exe");

//	configTool.StartInfo.Arguments = $"config get Authentication/PrivateKeyBaseDir";
//	configTool.Start();
//	configTool.WaitForExit();
//}

using (Process configTool = new Process())
{
	configTool.StartInfo.FileName = Path.Combine(veyonPath, "veyon-master.exe");
	configTool.Start();
}