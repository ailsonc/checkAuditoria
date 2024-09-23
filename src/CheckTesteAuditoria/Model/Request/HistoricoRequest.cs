namespace CheckTesteAuditoria.Model.Request
{
    class HistoricoRequest
    {
        public string ns { get; set; }
        public long idPosto { get; set; }
        public string modelo { get; set; }
        public string linha { get; set; }
        public string dataInicio { get; set; }
        public string dataFim { get; set; }
    }
}
