using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DllCheckTesteAuditorialog;

namespace CheckTesteAuditoria.Controller
{
    class ControleBateria
    {
        private Label _lbChargeRemaining = new Label();
        private bool _shouldContinue = true;
        private int _cargaInicial;
        private ManualResetEventSlim mainThreadShouldTerminate = new ManualResetEventSlim();

        public ControleBateria(Label label)
        {
            this._lbChargeRemaining = label;
            this._shouldContinue = true;
            this._cargaInicial = 0;
        }

        public void ShouldTerminate()
        {
            this._shouldContinue = false;
            this.mainThreadShouldTerminate.Set();
        }

        public void run()
        {
            try
            {
                this._cargaInicial = ControleWMI.GetChargeRemaining();

                while (this._shouldContinue)
                {
                    VerificarDescargaPorMinuto();
                    mainThreadShouldTerminate.Wait(60000);
                }
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                Log.LogInfo(mensagem);
                SoundAlert();
                MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void VerificarDescargaPorMinuto()
        {
            int atualCarga = ControleWMI.GetChargeRemaining();

            if (atualCarga.Equals(0))
            {
                AddLabel($"{Convert.ToString(atualCarga)}%", Color.Red);
                throw new Exception($"A bateria está atualmente com uma carga de 0%");
            }
            else 
            {
                if (this._cargaInicial - atualCarga >= 2)
                {
                    AddLabel($"{Convert.ToString(atualCarga)}%", Color.Red);
                    throw new Exception($"A bateria está descarregando muito rápido: 2% por minuto");
                }
                else
                {
                    AddLabel($"{Convert.ToString(atualCarga)}%", Color.FromArgb(0, 80, 220));
                    Console.WriteLine("A taxa de descarga da bateria está dentro da faixa normal.");
                }

            }

            this._cargaInicial = atualCarga;
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

        private void AddLabel(String message, Color foreColor)
        {
            _lbChargeRemaining.Invoke(new Action(() =>
            {
                _lbChargeRemaining.Text = message;
                _lbChargeRemaining.ForeColor = foreColor;
            }));
        }
    }
}
