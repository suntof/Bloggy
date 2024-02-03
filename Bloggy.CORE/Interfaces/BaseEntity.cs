namespace Bloggy.CORE.Interfaces
{
	public abstract class BaseEntity : IBaseEntity
	{
        public Guid Id { get; set; } = Guid.NewGuid();
		public virtual string CreatedBy { get; set; } = "Undefined"; 
		public virtual string? UpdatedBy { get; set; }
		public virtual string? DeletedBy { get; set; }
		public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
		public virtual DateTime? UpdatedDate { get; set; }
		public virtual DateTime? DeleteDate { get; set; }
		public virtual bool IsDeleted { get; set; } = false;
	}
}
