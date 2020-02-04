namespace DDD.NetCore.Domain.Entities
{
    public class CervejaEntity : EntityBase
    {
        public string DsNome { get; set; }
        public float VlTeorAlcoolico { get; set; }
        public float VlPreco { get; set; }
    }
}