using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

public class Employee : Entity {
    [Display(Name = "ID особи")]
    public int EmployeePersonId { get; set; }

    [Display(Name = "ПІБ")]
    public Person? EmployeePerson { get; set; }

    [Display(Name = "ID посади")]
    public int PositionId { get; set; }

    [Display(Name = "Посада")]
    public Position? Position { get; set; }

    [Display(Name = "ID підрозділу")]
    public int UnitId { get; set; }

    [Display(Name = "Підрозділ")]
    public Unit? Unit { get; set; }

    [Display(Name = "Дата прийняття на роботу")]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateTime? DateEmployment { get; set; }

    [Display(Name = "Дата звільнення")]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateTime? DateDismissal { get; set; }

    [Display(Name = "Зарплатний коефіцієнт")]
    [Column(TypeName = "decimal(10,2)")]
    public decimal EmployeeWorkingRate { get; set; }

    [Display(Name = "Накази про звільнення")]
    public ICollection<DismissalOrder>? DismissalOrders { get; set; }

    [Display(Name = "Накази про зміну роботи")]
    public ICollection<JobChangeOrder>? JobChangeOrders { get; set; }

    public override void Copy(Entity entity) {
        var copy = entity as Employee;
        if (copy != null) {
            EmployeePersonId = copy.EmployeePersonId;
            PositionId = copy.PositionId;
            UnitId = copy.UnitId;
            DateEmployment = copy.DateEmployment;
            DateDismissal = copy.DateDismissal;
            EmployeeWorkingRate = copy.EmployeeWorkingRate;

            DismissalOrders ??= new List<DismissalOrder>();
            DismissalOrders.Clear();
            foreach (var item in copy.DismissalOrders ?? new List<DismissalOrder>()) {
                DismissalOrders.Add(item);
            }

            JobChangeOrders ??= new List<JobChangeOrder>();
            JobChangeOrders.Clear();
            foreach (var item in copy.JobChangeOrders ?? new List<JobChangeOrder>()) {
                JobChangeOrders.Add(item);
            }
        }
    }
}
