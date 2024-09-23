using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTesteAuditoria.Model
{
   public class ResultTeste
    {
        string nome;
        Boolean status;

        public ResultTeste()
        {

        }

        public ResultTeste(string nome, bool status)
        {
            this.nome = nome;
            this.status = status;
        }

        public string Nome { get => nome; set => nome = value; }
        public bool Status { get => status; set => status = value; }
    }
}
