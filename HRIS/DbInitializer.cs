using System;
using System.Linq;
using HRIS.Data;

public static class DbInitializer {
    public static void Initialize(ApplicationDbContext context) {
        context.Database.EnsureCreated();

        if (!context.VnzLists.Any()) {
            var vnz = new VnzList {
                VnzName = "Університет",
                VnzNameFull = "Національний університет",
                VnzAddress = "вул. Університетська, 1"
            };
            context.VnzLists.Add(vnz);
            context.SaveChanges();
        }

        if (!context.Faculties.Any()) {
            var faculty = new Faculty {
                FacultyName = "Інформатики",
                FacultyNameFull = "Факультет інформатики",
                VnzId = context.VnzLists.First().Id
            };
            context.Faculties.Add(faculty);
            context.SaveChanges();
        }

        if (!context.Positions.Any()) {
            var positions = new[]
            {
                new Position { PositionName = "Інженер", PositionNameFull = "Інженер програмного забезпечення" },
                new Position { PositionName = "Аналітик", PositionNameFull = "Аналітик даних" }
            };
            context.Positions.AddRange(positions);
            context.SaveChanges();
        }

        if (!context.UnitsGroups.Any()) {
            var group = new UnitsGroup { UnitsGroupName = "Розробка" };
            context.UnitsGroups.Add(group);
            context.SaveChanges();
        }

        if (!context.Units.Any()) {
            var unit = new Unit {
                UnitName = "Відділ розробки",
                GroupId = context.UnitsGroups.First().Id
            };
            context.Units.Add(unit);
            context.SaveChanges();
        }

        if (!context.ScientificTitles.Any()) {
            var titles = new[]
            {
                new ScientificTitle { ScientificTitleName = "доцент", ScientificTitleNameFull = "Доцент" },
                new ScientificTitle { ScientificTitleName = "професор", ScientificTitleNameFull = "Професор" }
            };
            context.ScientificTitles.AddRange(titles);
            context.SaveChanges();
        }

        if (!context.ScientificDegrees.Any()) {
            var degrees = new[]
            {
                new ScientificDegree { ScientificDegreeName = "PhD", ScientificDegreeNameFull = "Доктор філософії" },
                new ScientificDegree { ScientificDegreeName = "DSc", ScientificDegreeNameFull = "Доктор наук" }
            };
            context.ScientificDegrees.AddRange(degrees);
            context.SaveChanges();
        }

        if (!context.Specialties.Any()) {
            var specialties = new[]
            {
                new Specialty { Chiper = 101, SpecialtyName = "Інформатика" },
                new Specialty { Chiper = 102, SpecialtyName = "Математика" }
            };
            context.Specialties.AddRange(specialties);
            context.SaveChanges();
        }

        if (!context.Persons.Any()) {
            var person = new Person {
                PersonName = "Іванов Іван",
                PersonNameFull = "Іванов Іван Іванович",
                IsMale = true,
                MaritalStatus = true,
                BirthDate = new DateTime(1990, 1, 1),
                Residence = "м. Київ",
                PhoneNumber = "1234567890",
                MilitaryRegistrationStatus = false,
                IsPensioner = false,
                HasChildren = false,
                IdentificationNumber = "1111111111",
                PassportNumber = "123456",
                PassportSeries = "AA",
                PassportIssueDate = new DateTime(2010, 1, 1),
                PassportIssuePlace = "Київ",
                PersonEducation = "Вища",
                PersonQualification = "Інженер",
                DiplomaNumber = "Д123456",
                DateOfGraduation = new DateTime(2012, 6, 1),
                Category = "A",
                Discharge = "1",
                FacultyId = context.Faculties.First().Id,
                ScientificTitleId = context.ScientificTitles.First().Id,
                ScientificDegreeId = context.ScientificDegrees.First().Id,
                SpecialtyId = context.Specialties.First().Id,
                IsDisabled = false,
                DisabilityGroup = null,
                DisabledCertificate = null
            };
            context.Persons.Add(person);
            context.SaveChanges();
        }

        if (!context.Employees.Any()) {
            var employee = new Employee {
                EmployeePersonId = context.Persons.First().Id,
                PositionId = context.Positions.First().Id,
                UnitId = context.Units.First().Id,
                DateEmployment = DateTime.Now.AddYears(-1),
                DateDismissal = null,
                EmployeeWorkingRate = 1.00m
            };
            context.Employees.Add(employee);
            context.SaveChanges();
        }
    }
}
