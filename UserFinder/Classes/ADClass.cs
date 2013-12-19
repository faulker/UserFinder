using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace Faulk_Me
{
    class ActiveDirectory
    {
        /// <summary>
        /// Get all child object in a OU.
        /// </summary>
        /// <param name="domain">LDAP formated path, exp. LDAP://DOMAIN/OU=test,DC=faulk,DC=com</param>
        /// <param name="filiter">String[] [Options: computer, user, group, ou]</param>
        /// <returns>List of child object under given LDAP path.</returns>
        public Dictionary<string, string[]> GetOUList(string domain, string[] filiter = null)
        {
            // LDAP://FULL_PATH, { CN=Name, Type }
            Dictionary<string, string[]> OUs = new Dictionary<string, string[]>();
            string entryString = "LDAP://";

            try
            {

                if (domain.StartsWith("LDAP"))
                {
                    entryString = domain;
                }
                else
                {
                    entryString = "LDAP://" + domain;
                }
                DirectoryEntry directoryObject = new DirectoryEntry(entryString);
                foreach (DirectoryEntry child in directoryObject.Children)
                {
                    if (filiter != null)
                    {
                        string flt = "";
                        foreach (string f in filiter)
                        {
                            switch (f.ToUpper())
                            {
                                case "COMPUTER":
                                    flt = "COMPUTER";
                                    break;
                                case "USER":
                                    flt = "USER";
                                    break;
                                case "GROUP":
                                    flt = "GROUP";
                                    break;
                                case "OU":
                                    flt = "ORGANIZATIONALUNIT";
                                    break;
                            }
                            if (child.SchemaEntry.Name.ToUpper() == flt)
                            {
                                string[] prop = { (child.Name.Split('='))[1], child.SchemaEntry.Name };
                                OUs.Add(child.Path, prop);
                            }
                        }
                    }
                    else
                    {
                        string[] prop = { (child.Name.Split('='))[1], child.SchemaEntry.Name };
                        OUs.Add(child.Path, prop);
                    }
                }
                directoryObject.Close();
                directoryObject.Dispose();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            return OUs;
        }

        /// <summary>
        /// Get active directory object type.
        /// </summary>
        /// <param name="ouPath">LDAP formated path, exp. LDAP://DOMAIN/OU=test,DC=faulk,DC=com</param>
        /// <returns>Object Type as string</returns>
        public string GetObjectType(string ouPath)
        {
            string path = ouPath;
            if (ouPath.StartsWith("LDAP"))
            {
                path = ouPath;
            }
            else
            {
                path = "LDAP://" + ouPath;
            }
            DirectoryEntry directoryObject = new DirectoryEntry(ouPath);

            return directoryObject.SchemaEntry.Name;
        }
    }
}
