namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public abstract class BaseEntity : IBaseEntity
    {
        protected BaseEntity()
        {
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order=0)]
        public virtual int Id { get; set; }
    }
}

