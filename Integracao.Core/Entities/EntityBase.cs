namespace Integracao.Core.Base.Entities
{
    public class EntityBase
    {
        public virtual long Codigo { get; protected set; }

        public virtual void SetId(long key)
        {
            if (key.Equals(default)) throw new Exception("Index not found");
            Codigo = key;
        }
    }
}
