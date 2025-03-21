﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class EmploymentOrder : Entity {

    [Column(TypeName = "date")]
    [Display(Name = "Дата прийняття на роботу")]
    public DateTime EmploymentDate { get; set; }

    [Column(TypeName = "decimal(3,2)")]
    [Display(Name = "Зарплатний коефіцієнт")]
    public decimal WorkingRates { get; set; }
    
    [Display(Name = "Плюралізм")]
    public bool Pluralist { get; set; }

    public int UnitId { get; set; }
    public Unit? Unit { get; set; }

    public int PositionId { get; set; }
    public Position? Position { get; set; }

    public int PersonId { get; set; }
    public Person? Person { get; set; }
    public override void Copy(Entity entity) {
        var copy = entity as EmploymentOrder;
        if (copy != null) {
            EmploymentDate = copy.EmploymentDate;
            WorkingRates = copy.WorkingRates;
            Pluralist = copy.Pluralist;
            UnitId = copy.UnitId;
            PositionId = copy.PositionId;
            PersonId = copy.PersonId;
        }
    }
}
