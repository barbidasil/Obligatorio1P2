namespace Obligatorio2.Models
{
    public class SubastaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string Status { get; set; }
        public string MejorOferta { get; set; }
        public bool EsAbierta { get; set; }
    }
}
