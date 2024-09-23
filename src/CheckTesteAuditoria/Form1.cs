using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using CheckTesteAuditoria.Model;
using Microsoft.Win32;
using DllCheckTesteAuditorialog;
using CheckTesteAuditoria.Controller;
using CheckTesteAuditoria.Model.Request;
using CheckTesteAuditoria.Services;
using System.Threading.Tasks;

namespace CheckTesteAuditoria
{
    public partial class Form1 : Form
    {
        private ArrayList lista = new ArrayList();
        private ControleAplicacao controleAplicacao;
        private ControleArquivo controleArquivo;
        private ControleBateria controleBateria;
        private Thread thread;
        private LinhaProducao linhaProducao = new LinhaProducao();
        public RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\SFTClassic");

        public Form1()
        {
            InitializeComponent();
            ConfigurationVersion();
        }

        private void ConfigurationVersion()
        {
            // AssemblyVersion
            var currentVersion = Application.ProductVersion.ToString();
            this.lb_version.Text = $"Version: {currentVersion}";
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                controleArquivo = new ControleArquivo();
                controleAplicacao = new ControleAplicacao();
                ConfigurationFiles();
                PanelConfiguration();
                VerifyStatusTest();
                VerifyBattery();
            }
            catch (Exception ex)
            {
                string mensagem = ex.Message;
                Log.LogInfo(mensagem);
                MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controleBateria != null)
                controleBateria.ShouldTerminate();
        }

        private void VerifyBattery()
        {
            try
            {
                string dischargeTest =  ConfigurationManager.AppSettings["DischargeTest"];

                if (dischargeTest != null && dischargeTest.Equals("true"))
                {
                    controleBateria = new ControleBateria(lbChargeRemaining);
                    thread = new Thread(new ThreadStart(controleBateria.run));
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
                else
                {
                    lbTitleChargeRemaining.Visible = false;
                    lbChargeRemaining.Visible = false;
                }                
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                Log.LogInfo(mensagem);
                throw new Exception(mensagem);
            }
        }

        private void ConfigurationFiles()
        {
            try
            {
                using (StreamReader r = new StreamReader("config.json"))
                {
                    string json = r.ReadToEnd();
                    List<Testes> ro = JsonConvert.DeserializeObject<List<Testes>>(json);
                }

                using (StreamReader r = new StreamReader("lineConfig.json"))
                {
                    string json = r.ReadToEnd();
                    this.linhaProducao = JsonConvert.DeserializeObject<LinhaProducao>(json);
                    this.lbLine.Text = this.linhaProducao.Linha;
                }
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                Log.LogInfo(mensagem);
                throw new Exception(mensagem);
            }
        }

        private void PanelConfiguration()
        {
            try
            {
                lbModel.Text = ControleWMI.GetModel();

                if (controleAplicacao.VerifySMTRegister())
                {
                    if (controleAplicacao.VerificarNSPlaca())
                    {
                        lbSerialNumber.Text = ControleWMI.GetSerialNumberPlaca();
                    }
                    else
                    {
                        WriteListview("Numero de Serie", "Falhou");
                        lbSerialNumber.Text = ControleWMI.GetSerialNumberPlaca();
                        return;
                    }
                }
                else
                {
                    if (controleAplicacao.VerificarNS())
                    {
                        lbSerialNumber.Text = ControleWMI.GetSerialNumber();
                    }
                    else
                    {
                        WriteListview("Numero de Serie", "Falhou");
                        lbSerialNumber.Text = ControleWMI.GetSerialNumber();
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                Log.LogInfo(mensagem);
                throw new Exception(mensagem);
            }
        }

        private void VerifyStatusTest()
        {
            try
            {
                controleAplicacao = new ControleAplicacao();
                listView1.Items.Clear();

                var listaArq = ConfigurationManager.AppSettings.AllKeys;

                for (int j=3; j < listaArq.Count(); j++)
                {
                    string testeAtual = listaArq[j];
                    ResultTeste t = new ResultTeste();
                    if (controleAplicacao.VerifyStatusTest(testeAtual))
                    {
                        t.Nome = testeAtual;
                        t.Status = true;
                        Log.LogStart($"addItem: {t.Nome}");
                        WriteListview(testeAtual, "Aprovado");
                    }
                    else
                    {
                        t.Nome = testeAtual;
                        t.Status = false;
                        Log.LogStart($"addItem: {t.Nome}");
                        WriteListview(testeAtual, "Reprovado");
                    }
                }
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                Log.LogInfo(mensagem);
                throw new Exception(mensagem);
            }
        }

        public async void SetRegistro()
        {
            try
            {
                bool statusrede = controleAplicacao.CheckConectividade(Constantes.IPSRVBD);

                while (!statusrede)
                {
                    statusrede = controleAplicacao.CheckConectividade(Constantes.IPSRVBD);
                    MessageBox.Show("Conecte a uma rede....", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                for (int i = 0; i < lista.Count; i++)
                {
                    var teste = (ResultTeste)lista[i];
                    if (!(teste.Status))
                    {
                        MessageBox.Show("Existe teste que foram reprovador!!!! Por favor, verifique e tente novamente.");
                        return;
                    }
                }

                var historicoRequest = new HistoricoRequest()
                {
                    ns = ControleWMI.GetSerialNumber(),
                    modelo = ControleWMI.GetModel(),
                    linha = this.linhaProducao.Linha,
                };

                bool status = await HistoricoService.SetHistoricoAuditoria(historicoRequest);

                if (status)
                {
                    Log.LogStart("AUDITOU");

                    MessageBox.Show("ENVIADO COM SUCESSO!");
                    controleArquivo.setResultFile();
                    string modelo = ControleWMI.GetModel();
                    Log.LogStart($"Modelo: {modelo}");

                    controleAplicacao.ExecutarPrepDownload();

                    if (modelo.Equals("UL154JO"))
                    {
                        Application.Exit();
                    }
                    else
                    {
                        controleAplicacao.Desligue();
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao enviar o LOG");
                    return;
                }
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                Log.LogInfo(mensagem);
                throw new Exception(mensagem);
            }
        }

        public async void SetMacAddress()
        {
            try
            {
                List<NetworkAdapter> networkAdapters = new List<NetworkAdapter>();
                networkAdapters = ControleWMI.GetMACAddress();

                foreach (NetworkAdapter networkAdapter in networkAdapters)
                {

                    var historicoMacAddressRequest = new HistoricoMacAddressRequest()
                    {
                        ns = ControleWMI.GetSerialNumber(),
                        name = networkAdapter.Name,
                        macaddress = networkAdapter.MACAddress,
                    };

                    bool status = await HistoricoService.SetHistoricoMacAddress(historicoMacAddressRequest);
                }
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                Log.LogInfo(mensagem);
                throw new Exception(mensagem);
            }
        }

        public void WriteListview(String desc, String status)
        {
            try
            {
                ListViewItem lvg = new ListViewItem(desc);
                lvg.SubItems.Add(status);
                listView1.Items.Add(lvg);
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                Log.LogInfo(mensagem);
                throw new Exception(mensagem);
            }
        }

        public Boolean GetValorRegistro(String campo)
        {
            try
            {
                String teste = (string)registryKey.GetValue(campo);

                if (teste != "" || teste == null)
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(teste);
                }
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                Log.LogInfo(mensagem);
                throw new Exception(mensagem);
            }
        }

        static async Task SoundAlert()
        {
            try
            {
                await Task.Run(() => Console.Beep((int)Tone.Gsharp, 1000));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao emitir som: {ex.Message}");
            }
        }

        private bool TestesOK()
        {
            try
            {
                controleAplicacao = new ControleAplicacao();

                var test = controleAplicacao.CountTrueValues();

                if (listView1.Items.Count != controleAplicacao.CountTrueValues())
                {
                    SoundAlert();
                    MessageBox.Show("EXISTE TESTES NAO EXECUTADOS!");
                    return false;
                }

                int count = 1;

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    var status = listView1.Items[i].SubItems[1].Text;

                    if (status.Contains("Reprovado"))
                    {
                        SoundAlert();
                        MessageBox.Show("EXISTE TESTES NAO EXECUTADOS!");
                        return false;
                    }

                    count++;
                }

                return true;
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                Log.LogInfo(mensagem);
                throw new Exception(mensagem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!controleAplicacao.VerificarNS())
                {
                    SoundAlert();
                    MessageBox.Show("Numero de serie Invalido....", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                controleAplicacao = new ControleAplicacao();

                if (controleAplicacao.ExecutarTestes())
                {
                    VerifyStatusTest();
                }
                else
                {
                    VerifyStatusTest();
                }
            }
            catch (Exception ex)
            {
                string mensagem = ex.Message;
                Log.LogInfo(mensagem);
                throw new Exception(mensagem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controleAplicacao.Desligue();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.buttonEnabled(false);

                if (controleAplicacao.VerifyRegistryKey())
                {
                    SoundAlert();
                    MessageBox.Show("EXISTE TESTES NAO EXECUTADOS!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.buttonEnabled(true);
                    return;
                }

                if (!TestesOK())
                {
                    this.buttonEnabled(true);
                    return;
                }

                bool statusrede = controleAplicacao.CheckConectividade(Constantes.IPSRVBD);

                while (!statusrede)
                {
                    statusrede = controleAplicacao.CheckConectividade(Constantes.IPSRVBD);
                    MessageBox.Show("Conecte a uma rede....", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                SetMacAddress();
                SetRegistro();

                this.buttonEnabled(true);
            }
            catch (Exception ex)
            {
                string mensagem = ex.Message;
                Log.LogInfo(mensagem);
                MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            if (controleBateria != null)
                controleBateria.ShouldTerminate();
            Close();
        }

        private void buttonEnabled(bool enabled)
        {
            this.button1.Enabled = enabled;
            this.button2.Enabled = enabled;
            this.button3.Enabled = enabled;
        }
    }
}
