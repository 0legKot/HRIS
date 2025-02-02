using System.ComponentModel.DataAnnotations;
public class VnzList : Entity {

    [Required]
    [MaxLength(20)]
    public string VnzName { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string VnzNameFull { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    public string VnzAddress { get; set; } = null!;

    public ICollection<Faculty>? Faculties { get; set; }

    public override void Copy(Entity entity) {
        var copy = entity as VnzList;
        if (copy != null) {
            VnzName = copy.VnzName;
            VnzNameFull = copy.VnzNameFull;
            VnzAddress = copy.VnzAddress;
            Faculties ??= [];
            Faculties.Clear();
            foreach (var item in copy.Faculties ?? []) {
                Faculties.Add(item);
            }
        }
    }
}
