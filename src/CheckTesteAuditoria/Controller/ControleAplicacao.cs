using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using DllCheckTesteAuditorialog;
using CheckTesteAuditoria.Controller;

namespace CheckTesteAuditoria
{
    class ControleAplicacao
    {
        public RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\SFTClassic");
        public RegistryKey registryKeyMultilaser = Registry.CurrentUser.OpenSubKey(@"Software\Multilaser");

        public bool VerifyRegistryKey()
        {
            return registryKey == null;
        }

        public bool VerifyStatusTest(string teste)
        {
            String valor = null;

            if (registryKey != null)
                valor = (string)registryKey.GetValue(teste);

            if (valor != "" && valor == null)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(valor);
            }

        }

        public int CountTrueValues()
        {
            int count = 0;

            try
            {
                if (registryKey != null)
                {
                    foreach (string keyID in registryKey.GetValueNames())
                    {
                        bool testResult = Convert.ToBoolean((string)registryKey.GetValue(keyID));

                        if (testResult != null && testResult.Equals(true))
                        {
                            count++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("A chave do registro não pôde ser aberta.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar o registro: {ex.Message}");
            }

            return count;
        }

        public void CreateSTRESSRegister()
        {
            
            //Criar Registro para INICIAR STRESS
            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64); //here you specify where exactly you want your entry

            var reg = localMachine.OpenSubKey("Software\\Multilaser", true);
            if (reg == null)
            {
                reg = localMachine.CreateSubKey("Software\\Multilaser");
                
            }

            if (reg.GetValue("STRESS") == null)
            {
                reg.SetValue("STRESS", false);
            }

        }
 
        public bool VerifySTRESSRegister()
        {

            //Criar Registro para INICIAR STRESS
            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64); //here you specify where exactly you want your entry

            var reg = localMachine.OpenSubKey("Software\\Multilaser", true);
            if (reg == null)
            {
                return false;
            }

            if (reg.GetValue("STRESS") == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool VerifyStatusStress()
        {

            String valor = (string)registryKeyMultilaser.GetValue("STRESS");

            if (valor != "" && valor == null)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(valor);
            }

        }

        public bool VerifySMTRegister()
        {

            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64); //here you specify where exactly you want your entry

            var reg = localMachine.OpenSubKey("Software\\Multilaser", true);
            if (reg == null)
            {
                return false;
            }

            if (reg.GetValue("SMT") == null)
            {
                return false;
            }else
            {
                return true;
            }

        }
               
        public void SetRegister(String nome)
        {

            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64); //here you specify where exactly you want your entry

            var reg = localMachine.OpenSubKey("Software\\SFTClassic", true);
            if (reg == null)
            {
                reg = localMachine.CreateSubKey("Software\\SFTClassic");
            }

            if (reg.GetValue(nome) == null)
            {
                reg.SetValue(nome, false);
            }

        }

        public void SetRegister(String nome, bool status)
        {

            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64); //here you specify where exactly you want your entry

            var reg = localMachine.OpenSubKey("Software\\SFTClassic", true);
            if (reg == null)
            {
                reg = localMachine.CreateSubKey("Software\\SFTClassic");
            }

            if (reg.GetValue(nome) == null)
            {
                reg.SetValue(nome, status);
            }

        }

        public void SetRegisterFalse(String nome)
        {

            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64); //here you specify where exactly you want your entry

            var reg = localMachine.OpenSubKey("Software\\SFTClassic", true);
            if (reg == null)
            {
                reg = localMachine.CreateSubKey("Software\\SFTClassic");
            }

            if (reg.GetValue(nome) == null)
            {
                reg.SetValue(nome, false);
            }
            else
            {
                reg.SetValue(nome, false);
            }

        }

        public bool VerificarNS()
        {

            var retorno = false;

            var ns = ControleWMI.GetSerialNumber();

            if (Regex.IsMatch(ns, @"^\w{15}$"))
            {
                retorno = true;
            }

            return retorno;

        }

        public bool VerificarNSPlaca()
        {

            var retorno = false;

            var ns = ControleWMI.GetSerialNumberPlaca();

            if (Regex.IsMatch(ns, @"^\w{15}$"))
            {
                retorno = true;
            }

            return retorno;

        }

        public bool ExecutarTestes()
        {

            bool retorno = true;

            string caminhoAfuwin = @"C:\TEST_TOOL\executar.cmd";

            Process p = null;
            try
            {
                p = new Process();
                p.StartInfo.FileName = caminhoAfuwin;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = true;
               // p.StartInfo.RedirectStandardError = true;
               // p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                
                p.WaitForExit();             
               
            }
            catch (Exception e)
            {

                string mensagem = "Erro na execução do TESTETOOL : " + e.Message;
                Console.WriteLine(mensagem);
                Log.LogStart(mensagem);

            }
            finally
            {

                if (p != null)
                  
                p.Close();

            }
        
            return retorno;

        }

        public bool ExecutarPrepDownload()
        {

            bool retorno = true;
            //vai ser sempre x64
            string caminhoAfuwin = @"C:\TEST_TOOL\TrocaBoot.cmd";

            Process p = null;
            try
            {
                p = new Process();
                p.StartInfo.FileName = caminhoAfuwin;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.WorkingDirectory = @"C:\TEST_TOOL";
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                
                while (!p.StandardOutput.EndOfStream)
                {
                    string mensagem = p.StandardOutput.ReadLine();
                    Log.LogStart($"TrocaBoot: {mensagem}");
                    p.WaitForExit();
                }
            }
            catch (Exception e)
            {
                string mensagem = "Erro na execução do Bath Download : " + e.Message;
                Console.WriteLine(mensagem);
                Log.LogStart(mensagem);
            }
            finally
            {
                if (p != null)

                    p.Close();
            }

            return retorno;

        }

        public bool VerifyStressComplete()
        {

            bool texecute = File.Exists(@"C:\Program Files\BurnInTest\stress.log");

            return texecute;

        }


        public bool CheckConectividade(string ip)
        {

            Log.LogStart("Verificando Conectividade com Servidor");
            bool status = false;
            try
            {
                var ping = new Ping();
                var reply = ping.Send(ip);
                if (reply.Status == IPStatus.Success)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                Log.LogStart("nao foi possivel realizar o ping ao servidor ");
            }

            return status;

        }
     
        public void Desligue()
        {

            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                     mcWin32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            mboShutdownParams["Flags"] = "5";
            mboShutdownParams["Reserved"] = "0";
            
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                               mboShutdownParams, null);
            }

        }

    }
}
