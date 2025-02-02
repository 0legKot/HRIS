using System.ComponentModel.DataAnnotations;

public abstract class Entity {
    [Key]
    public int Id { get; set; }
    public abstract void Copy(Entity entity);
}
