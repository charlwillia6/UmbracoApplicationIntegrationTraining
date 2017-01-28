using System;
using System.IO;
using System.Net.Mail;

namespace Training.Umbraco.WebSite.UI.Extensions
{
    public static class SmtpClientExtension
    {
        public static void SetPickupDirectoryLocation(this SmtpClient smtpClient)
        {
            if (smtpClient.PickupDirectoryLocation == null || Path.IsPathRooted(smtpClient.PickupDirectoryLocation))
                return;

            // If PickupDirectory is relative, change it to absolute
            smtpClient.PickupDirectoryLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                smtpClient.PickupDirectoryLocation);

            if (Directory.Exists(smtpClient.PickupDirectoryLocation) == false)
                Directory.CreateDirectory(smtpClient.PickupDirectoryLocation);
        }
    }
}