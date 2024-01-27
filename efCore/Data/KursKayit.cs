using System.ComponentModel.DataAnnotations;

namespace efCore.Data
{
    public class KursKayit{
        [Key]
        public int KayitId {get;set;}
        public int OgrenciId {get;set;}
        public int KursId{get;set;}
        public DateTime KayitTarihi {get;set;}

    }
}