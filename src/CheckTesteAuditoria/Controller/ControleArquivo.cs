using System;
using System.IO;

namespace CheckTesteAuditoria
{
    class ControleArquivo
    {
        private StreamWriter streamWriter;

        public void setResultFile()
        {
            try
            {
                streamWriter = new StreamWriter("AUDITOK.txt");
                streamWriter.AutoFlush = true;
                streamWriter.WriteLine(DateTime.Now + ":\tAUDITOU");
            }
            catch (Exception e)
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter = null;
                }
                string mensagem = "Erro na inicialização do log: " + e.Message;
                Console.WriteLine(mensagem);
                throw new Exception(mensagem);
            }
        }
    }
}
