using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Faulk_Me
{
    class WMIClass
    {
        /// <summary>
        /// List all users logged into a computer
        /// </summary>
        /// <param name="computer">Computer Name</param>
        /// <returns>List of users</returns>
        public static List<string> getUsersFromComputer(string computer)
        {
            List<string> users = new List<string>();
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\\\" + computer + "\\root\\CIMV2", "SELECT * FROM Win32_ComputerSystem"))
                {
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        users.Add(queryObj["UserName"].ToString());
                    }
                }
            }
            catch(UnauthorizedAccessException uae)
            {
                //System.Windows.Forms.MessageBox.Show(uae.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                users.Add("Access Issue");
                Console.WriteLine("{0}, Error: {1}", computer, uae.Message);
                return users;
            }
            catch (Exception e)
            {
                if ((long)e.HResult == -2147023174)
                {
                    //System.Windows.Forms.MessageBox.Show(e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    users.Add("Access Issue");
                    Console.WriteLine("{0}, Error: {1}", computer, e.Message);
                    return users;
                }
                else
                {
                    Console.WriteLine("{0}, Error: {1}", computer, e.Message);
                }
            }
            return users;
        }
    }
}
