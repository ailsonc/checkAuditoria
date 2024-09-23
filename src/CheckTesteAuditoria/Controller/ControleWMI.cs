using System;
using System.Collections.Generic;
using System.Management;
using CheckTesteAuditoria.Model;
using System.Net.NetworkInformation;

namespace CheckTesteAuditoria.Controller
{
    class ControleWMI
    {
        public static String GetModel()
        {
            String modelo = "";
            ManagementObjectSearcher s2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject mo in s2.Get())
            {
                modelo = mo["SystemSKUNumber"].ToString().Trim();
            }

            return modelo;
        }

        public static String GetSystemVersion()
        {
            String biosManufacturer = "";
            ManagementObjectSearcher s2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystemProduct");
            foreach (ManagementObject mo in s2.Get())
            {
                biosManufacturer = mo["Version"].ToString().Trim();
            }

            return biosManufacturer;
        }

        public static String GetSerialNumber()
        {
            String serial = "";
            ManagementObjectSearcher s2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
            foreach (ManagementObject mo in s2.Get())
            {
                serial = mo["SerialNumber"].ToString().Trim();
            }

            return serial;
        }

        public static String GetSerialNumberPlaca()
        {
            String serial = "";
            ManagementObjectSearcher s2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BASEBOARD");
            foreach (ManagementObject mo in s2.Get())
            {
                serial = mo["SerialNumber"].ToString().Trim();
            }

            return serial;
        }

        public static List<NetworkAdapter> GetMACAddress()
        {
            List<NetworkAdapter> networkAdapters = new List<NetworkAdapter>();

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.Description.Contains("ASIX AX88179") || ni.Description.Contains("Ethernet") || ni.Description.Contains("Conexão Local") || ni.Description.Contains("Fortinet") || ni.Description.Contains("Loopback") || ni.Description.Contains("Virtual"))
                {
                    continue;
                }

                NetworkAdapter networkAdapter = new NetworkAdapter();
                networkAdapter.MACAddress = BitConverter.ToString(ni.GetPhysicalAddress().GetAddressBytes());
                networkAdapter.Name = ni.Description;

                networkAdapters.Add(networkAdapter);
            }

            return networkAdapters;
        }

        public static int GetChargeRemaining()
        {
            int status = 0;
            ManagementObjectSearcher s2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Battery");

            foreach (ManagementObject mo in s2.Get())
            {
                status = Int32.Parse(mo["EstimatedChargeRemaining"].ToString().Trim());
            }

            return status;
        }
    }
}
