using System;
using System.Linq;
using HRIS.Data;
using Microsoft.EntityFrameworkCore;

public static class DbInitializer {
    public static void Initialize(ApplicationDbContext context) {
        context.Database.EnsureCreated();

        if (!context.VnzLists.Any()) {
            var vnzLists = new List<VnzList>
            {
        new VnzList
        {
            VnzName = "КНУ ім. Шевченка",
            VnzNameFull = "Київський національний університет імені Тараса Шевченка",
            VnzAddress = "вул. Академіка Туполєва, 4, Київ"
        },
        new VnzList
        {
            VnzName = "ХНУ ім. Каразіна",
            VnzNameFull = "Харківський національний університет імені В. Н. Каразіна",
            VnzAddress = "вул. Сумська, 2, Харків"
        },
        new VnzList
        {
            VnzName = "ЛНУ ім. Франка",
            VnzNameFull = "Львівський національний університет імені Івана Франка",
            VnzAddress = "вул. Пестеля, 6, Львів"
        },
        new VnzList
        {
            VnzName = "ОНУ",
            VnzNameFull = "Одеський національний університет",
            VnzAddress = "вул. Генуезька, 3, Одеса"
        },
        new VnzList
        {
            VnzName = "ДНУ ім. Гончара",
            VnzNameFull = "Дніпровський національний університет імені Олеся Гончара",
            VnzAddress = "вул. Гончара, 4, Дніпро"
        },
        new VnzList
        {
            VnzName = "КПІ",
            VnzNameFull = "Національний технічний університет України «КПІ ім. Ігоря Сікорського»",
            VnzAddress = "вул. Академіка Глушкова, 15, Київ"
        },
        new VnzList
        {
            VnzName = "ЧНУ ім. Федьковича",
            VnzNameFull = "Чернівецький національний університет ім. Юрія Федьковича",
            VnzAddress = "вул. Героїв, 14, Чернівці"
        },
        new VnzList
        {
            VnzName = "ІНУ",
            VnzNameFull = "Івано-Франківський національний університет",
            VnzAddress = "вул. Незалежності, 10, Івано-Франківськ"
        },
        new VnzList
        {
            VnzName = "ПНУ",
            VnzNameFull = "Полтавський національний університет імені В. Г. Короленка",
            VnzAddress = "вул. Героїв, 1, Полтава"
        },
        new VnzList
        {
            VnzName = "ЗНУ",
            VnzNameFull = "Запорізький національний університет",
            VnzAddress = "вул. Перемоги, 2, Запоріжжя"
        }
    };

            context.VnzLists.AddRange(vnzLists);
            context.SaveChanges();
        }


        if (!context.Faculties.Any()) {
            var vnzList = context.VnzLists.OrderBy(x => x.Id).ToList();
            var faculties = new List<Faculty>
            {
        new Faculty
        {
            FacultyName = "Інформатики",
            FacultyNameFull = "Факультет інформатики",
            VnzId = vnzList[(0) % vnzList.Count].Id
        },
        new Faculty
        {
            FacultyName = "Електроніки",
            FacultyNameFull = "Факультет електроніки",
            VnzId = vnzList[(1) % vnzList.Count].Id
        },
        new Faculty
        {
            FacultyName = "Механіки",
            FacultyNameFull = "Факультет механіки",
            VnzId = vnzList[(2) % vnzList.Count].Id
        },
        new Faculty
        {
            FacultyName = "Економіки",
            FacultyNameFull = "Факультет економіки",
            VnzId = vnzList[(3) % vnzList.Count].Id
        },
        new Faculty
        {
            FacultyName = "Права",
            FacultyNameFull = "Факультет права",
            VnzId = vnzList[(4) % vnzList.Count].Id
        },
        new Faculty
        {
            FacultyName = "Медицини",
            FacultyNameFull = "Факультет медицини",
            VnzId = vnzList[(5) % vnzList.Count].Id
        },
        new Faculty
        {
            FacultyName = "Архітектури",
            FacultyNameFull = "Факультет архітектури",
            VnzId = vnzList[(6) % vnzList.Count].Id
        },
        new Faculty
        {
            FacultyName = "Педагогіки",
            FacultyNameFull = "Факультет педагогіки",
            VnzId = vnzList[(7) % vnzList.Count].Id
        },
        new Faculty
        {
            FacultyName = "Філології",
            FacultyNameFull = "Факультет філології",
            VnzId = vnzList[(8) % vnzList.Count].Id
        },
        new Faculty
        {
            FacultyName = "Історії",
            FacultyNameFull = "Факультет історії",
            VnzId = vnzList[(9) % vnzList.Count].Id
        }
    };
            context.Faculties.AddRange(faculties);
            context.SaveChanges();
        }

        if (!context.Positions.Any()) {
            var positions = new[]
            {
        new Position { PositionName = "Програміст", PositionNameFull = "Інженер програмного забезпечення" },
        new Position { PositionName = "Аналітик", PositionNameFull = "Аналітик даних" },
        new Position { PositionName = "Адміністратор", PositionNameFull = "Системний адміністратор" },
        new Position { PositionName = "Фахівець з безпеки", PositionNameFull = "Фахівець з інформаційної безпеки" },
        new Position { PositionName = "Моб. розробник", PositionNameFull = "Розробник мобільних додатків" },
        new Position { PositionName = "Електронік", PositionNameFull = "Інженер електроніки" },
        new Position { PositionName = "Бізнес-аналітик", PositionNameFull = "Бізнес-аналітик" },
        new Position { PositionName = "Менеджер", PositionNameFull = "Менеджер проектів" },
        new Position { PositionName = "QA інженер", PositionNameFull = "Інженер контролю якості" },
        new Position { PositionName = "ІТ спеціаліст", PositionNameFull = "Фахівець з інформаційних технологій" }
    };
            context.Positions.AddRange(positions);
            context.SaveChanges();
        }

        if (!context.UnitsGroups.Any()) {
            var groups = new[]
            {
        new UnitsGroup { UnitsGroupName = "Розробка" },
        new UnitsGroup { UnitsGroupName = "Адміністрація" },
        new UnitsGroup { UnitsGroupName = "Маркетинг" },
        new UnitsGroup { UnitsGroupName = "Фінанси" },
        new UnitsGroup { UnitsGroupName = "Логістика" },
        new UnitsGroup { UnitsGroupName = "Продаж" },
        new UnitsGroup { UnitsGroupName = "Підтримка" },
        new UnitsGroup { UnitsGroupName = "Інновації" },
        new UnitsGroup { UnitsGroupName = "Аналітика" },
        new UnitsGroup { UnitsGroupName = "Дослідження" }
    };
            context.UnitsGroups.AddRange(groups);
            context.SaveChanges();
        }


        if (!context.Units.Any()) {
            var groups = context.UnitsGroups.OrderBy(x => x.Id).ToList();
            var units = new List<Unit>
            {
        new Unit { UnitName = "Відділ розробки", GroupId = groups[0].Id },
        new Unit { UnitName = "Відділ маркетингу", GroupId = groups[1 % groups.Count].Id },
        new Unit { UnitName = "Відділ продажу", GroupId = groups[2 % groups.Count].Id },
        new Unit { UnitName = "Відділ фінансів", GroupId = groups[3 % groups.Count].Id },
        new Unit { UnitName = "Відділ кадрів", GroupId = groups[4 % groups.Count].Id },
        new Unit { UnitName = "Відділ логістики", GroupId = groups[5 % groups.Count].Id },
        new Unit { UnitName = "Відділ закупівель", GroupId = groups[6 % groups.Count].Id },
        new Unit { UnitName = "Відділ ІТ підтримки", GroupId = groups[7 % groups.Count].Id },
        new Unit { UnitName = "Відділ виробництва", GroupId = groups[8 % groups.Count].Id },
        new Unit { UnitName = "Відділ досліджень", GroupId = groups[9 % groups.Count].Id }
    };
            context.Units.AddRange(units);
            context.SaveChanges();
        }

        if (!context.ScientificTitles.Any()) {
            var titles = new[]
            {
        new ScientificTitle { ScientificTitleName = "асистент", ScientificTitleNameFull = "Асистент" },
        new ScientificTitle { ScientificTitleName = "доцент", ScientificTitleNameFull = "Доцент" },
        new ScientificTitle { ScientificTitleName = "ст доцент", ScientificTitleNameFull = "Старший доцент" },
        new ScientificTitle { ScientificTitleName = "професор", ScientificTitleNameFull = "Професор" },
        new ScientificTitle { ScientificTitleName = "академік", ScientificTitleNameFull = "Академік" }
    };
            context.ScientificTitles.AddRange(titles);
            context.SaveChanges();
        }

        if (!context.ScientificDegrees.Any()) {
            var degrees = new[]
            {
        new ScientificDegree { ScientificDegreeName = "PhD", ScientificDegreeNameFull = "Кандидат наук" },
        new ScientificDegree { ScientificDegreeName = "DSc", ScientificDegreeNameFull = "Доктор наук" },
        new ScientificDegree { ScientificDegreeName = "MSc", ScientificDegreeNameFull = "Магістр наук" },
        new ScientificDegree { ScientificDegreeName = "BSc", ScientificDegreeNameFull = "Бакалавр наук" },
        new ScientificDegree { ScientificDegreeName = "Dr", ScientificDegreeNameFull = "Доктор філософії" }
    };
            context.ScientificDegrees.AddRange(degrees);
            context.SaveChanges();
        }

        if (!context.Specialties.Any()) {
            var specialties = new[]
            {
        new Specialty { Chiper = 101, SpecialtyName = "Інформатика" },
        new Specialty { Chiper = 102, SpecialtyName = "Математика" },
        new Specialty { Chiper = 103, SpecialtyName = "Фізика" },
        new Specialty { Chiper = 104, SpecialtyName = "Хімія" },
        new Specialty { Chiper = 105, SpecialtyName = "Біологія" },
        new Specialty { Chiper = 106, SpecialtyName = "Економіка" },
        new Specialty { Chiper = 107, SpecialtyName = "Правознавство" },
        new Specialty { Chiper = 108, SpecialtyName = "Історія" },
        new Specialty { Chiper = 109, SpecialtyName = "Філологія" },
        new Specialty { Chiper = 110, SpecialtyName = "Соціологія" }
    };
            context.Specialties.AddRange(specialties);
            context.SaveChanges();
        }

        if (!context.Persons.Any()) {
            var faculties = context.Faculties.OrderBy(x => x.Id).ToList();
            var scientificTitles = context.ScientificTitles.OrderBy(x => x.Id).ToList();
            var scientificDegrees = context.ScientificDegrees.OrderBy(x => x.Id).ToList();
            var specialties = context.Specialties.OrderBy(x => x.Id).ToList();

            var persons = new List<Person>
            {
        new Person
        {
            PersonName = "Коваленко Олена",
            PersonNameFull = "Коваленко Олена Сергіївна",
            IsMale = false,
            MaritalStatus = false,
            BirthDate = new DateTime(1985, 5, 15),
            Residence = "м. Київ",
            PhoneNumber = "3805012345",
            MilitaryRegistrationStatus = false,
            IsPensioner = false,
            HasChildren = true,
            IdentificationNumber = "1234567890",
            PassportNumber = "654321",
            PassportSeries = "AB",
            PassportIssueDate = new DateTime(2005, 7, 10),
            PassportIssuePlace = "Київ",
            PersonEducation = "Вища",
            PersonQualification = "Менеджер",
            DiplomaNumber = "Д000001",
            DateOfGraduation = new DateTime(2007, 6, 1),
            Category = "B",
            Discharge = "2",
            FacultyId = faculties[0].Id,
            ScientificTitleId = scientificTitles[0].Id,
            ScientificDegreeId = scientificDegrees[0].Id,
            SpecialtyId = specialties[0].Id,
            IsDisabled = false
        },
        new Person
        {
            PersonName = "Сидоренко Андрій",
            PersonNameFull = "Сидоренко Андрій Миколайович",
            IsMale = true,
            MaritalStatus = true,
            BirthDate = new DateTime(1990, 2, 20),
            Residence = "м. Харків",
            PhoneNumber = "3806712345",
            MilitaryRegistrationStatus = true,
            IsPensioner = false,
            HasChildren = true,
            IdentificationNumber = "0987654321",
            PassportNumber = "123456",
            PassportSeries = "CD",
            PassportIssueDate = new DateTime(2010, 3, 15),
            PassportIssuePlace = "Харків",
            PersonEducation = "Вища",
            PersonQualification = "Інженер",
            DiplomaNumber = "Д000002",
            DateOfGraduation = new DateTime(2012, 6, 1),
            Category = "A",
            Discharge = "1",
            FacultyId = faculties[1].Id,
            ScientificTitleId = scientificTitles[1].Id,
            ScientificDegreeId = scientificDegrees[1].Id,
            SpecialtyId = specialties[1].Id,
            IsDisabled = false
        },
        new Person
        {
            PersonName = "Петренко Марія",
            PersonNameFull = "Петренко Марія Олександрівна",
            IsMale = false,
            MaritalStatus = true,
            BirthDate = new DateTime(1988, 7, 10),
            Residence = "м. Львів",
            PhoneNumber = "3809312345",
            MilitaryRegistrationStatus = false,
            IsPensioner = false,
            HasChildren = true,
            IdentificationNumber = "1122334455",
            PassportNumber = "789012",
            PassportSeries = "EF",
            PassportIssueDate = new DateTime(2008, 8, 20),
            PassportIssuePlace = "Львів",
            PersonEducation = "Вища",
            PersonQualification = "Викладач",
            DiplomaNumber = "Д000003",
            DateOfGraduation = new DateTime(2010, 6, 1),
            Category = "A",
            Discharge = "1",
            FacultyId = faculties[2].Id,
            ScientificTitleId = scientificTitles[0].Id,
            ScientificDegreeId = scientificDegrees[0].Id,
            SpecialtyId = specialties[2].Id,
            IsDisabled = false
        },
        new Person
        {
            PersonName = "Гончаренко Сергій",
            PersonNameFull = "Гончаренко Сергій Петрович",
            IsMale = true,
            MaritalStatus = true,
            BirthDate = new DateTime(1982, 11, 5),
            Residence = "м. Одеса",
            PhoneNumber = "3805011122",
            MilitaryRegistrationStatus = true,
            IsPensioner = false,
            HasChildren = true,
            IdentificationNumber = "2233445566",
            PassportNumber = "345678",
            PassportSeries = "GH",
            PassportIssueDate = new DateTime(2002, 4, 10),
            PassportIssuePlace = "Одеса",
            PersonEducation = "Вища",
            PersonQualification = "Фахівець",
            DiplomaNumber = "Д000004",
            DateOfGraduation = new DateTime(2004, 6, 1),
            Category = "B",
            Discharge = "2",
            FacultyId = faculties[3].Id,
            ScientificTitleId = scientificTitles[1].Id,
            ScientificDegreeId = scientificDegrees[1].Id,
            SpecialtyId = specialties[3].Id,
            IsDisabled = false
        },
        new Person
        {
            PersonName = "Мельник Олександр",
            PersonNameFull = "Мельник Олександр Вікторович",
            IsMale = true,
            MaritalStatus = true,
            BirthDate = new DateTime(1987, 3, 12),
            Residence = "м. Дніпро",
            PhoneNumber = "3806612345",
            MilitaryRegistrationStatus = false,
            IsPensioner = false,
            HasChildren = true,
            IdentificationNumber = "3344556677",
            PassportNumber = "567890",
            PassportSeries = "IJ",
            PassportIssueDate = new DateTime(2007, 5, 15),
            PassportIssuePlace = "Дніпро",
            PersonEducation = "Вища",
            PersonQualification = "Аналітик",
            DiplomaNumber = "Д000005",
            DateOfGraduation = new DateTime(2009, 6, 1),
            Category = "A",
            Discharge = "1",
            FacultyId = faculties[4].Id,
            ScientificTitleId = scientificTitles[2].Id,
            ScientificDegreeId = scientificDegrees[2].Id,
            SpecialtyId = specialties[4].Id,
            IsDisabled = false
        },
        new Person
        {
            PersonName = "Кравченко Ірина",
            PersonNameFull = "Кравченко Ірина Олександрівна",
            IsMale = false,
            MaritalStatus = false,
            BirthDate = new DateTime(1992, 9, 18),
            Residence = "м. Чернівці",
            PhoneNumber = "3809311122",
            MilitaryRegistrationStatus = false,
            IsPensioner = false,
            HasChildren = false,
            IdentificationNumber = "4455667788",
            PassportNumber = "678901",
            PassportSeries = "KL",
            PassportIssueDate = new DateTime(2012, 10, 1),
            PassportIssuePlace = "Чернівці",
            PersonEducation = "Вища",
            PersonQualification = "Психолог",
            DiplomaNumber = "Д000006",
            DateOfGraduation = new DateTime(2014, 6, 1),
            Category = "B",
            Discharge = "2",
            FacultyId = faculties[5].Id,
            ScientificTitleId = scientificTitles[3].Id,
            ScientificDegreeId = scientificDegrees[3].Id,
            SpecialtyId = specialties[5].Id,
            IsDisabled = false
        },
        new Person
        {
            PersonName = "Литвиненко Олег",
            PersonNameFull = "Литвиненко Олег Миколайович",
            IsMale = true,
            MaritalStatus = true,
            BirthDate = new DateTime(1980, 12, 22),
            Residence = "м. Полтава",
            PhoneNumber = "3806711122",
            MilitaryRegistrationStatus = true,
            IsPensioner = false,
            HasChildren = true,
            IdentificationNumber = "5566778899",
            PassportNumber = "789012",
            PassportSeries = "MN",
            PassportIssueDate = new DateTime(2000, 1, 15),
            PassportIssuePlace = "Полтава",
            PersonEducation = "Вища",
            PersonQualification = "Юрист",
            DiplomaNumber = "Д000007",
            DateOfGraduation = new DateTime(2002, 6, 1),
            Category = "A",
            Discharge = "1",
            FacultyId = faculties[6].Id,
            ScientificTitleId = scientificTitles[0].Id,
            ScientificDegreeId = scientificDegrees[0].Id,
            SpecialtyId = specialties[6].Id,
            IsDisabled = false
        },
        new Person
        {
            PersonName = "Бойко Тетяна",
            PersonNameFull = "Бойко Тетяна Сергіївна",
            IsMale = false,
            MaritalStatus = false,
            BirthDate = new DateTime(1995, 4, 5),
            Residence = "м. Івано-Франківськ",
            PhoneNumber = "3805011122",
            MilitaryRegistrationStatus = false,
            IsPensioner = false,
            HasChildren = false,
            IdentificationNumber = "6677889900",
            PassportNumber = "890123",
            PassportSeries = "OP",
            PassportIssueDate = new DateTime(2015, 5, 10),
            PassportIssuePlace = "Івано-Франківськ",
            PersonEducation = "Вища",
            PersonQualification = "Психолог",
            DiplomaNumber = "Д000008",
            DateOfGraduation = new DateTime(2017, 6, 1),
            Category = "B",
            Discharge = "2",
            FacultyId = faculties[7].Id,
            ScientificTitleId = scientificTitles[1].Id,
            ScientificDegreeId = scientificDegrees[1].Id,
            SpecialtyId = specialties[7].Id,
            IsDisabled = false
        },
        new Person
        {
            PersonName = "Соколенко Дмитро",
            PersonNameFull = "Соколенко Дмитро Олександрович",
            IsMale = true,
            MaritalStatus = true,
            BirthDate = new DateTime(1983, 8, 30),
            Residence = "м. Запоріжжя",
            PhoneNumber = "380661112",
            MilitaryRegistrationStatus = true,
            IsPensioner = false,
            HasChildren = true,
            IdentificationNumber = "7788990011",
            PassportNumber = "901234",
            PassportSeries = "QR",
            PassportIssueDate = new DateTime(2003, 9, 5),
            PassportIssuePlace = "Запоріжжя",
            PersonEducation = "Вища",
            PersonQualification = "Фахівець",
            DiplomaNumber = "Д000009",
            DateOfGraduation = new DateTime(2005, 6, 1),
            Category = "A",
            Discharge = "1",
            FacultyId = faculties[8].Id,
            ScientificTitleId = scientificTitles[2].Id,
            ScientificDegreeId = scientificDegrees[2].Id,
            SpecialtyId = specialties[8].Id,
            IsDisabled = false
        },
        new Person
        {
            PersonName = "Марченко Олексій",
            PersonNameFull = "Марченко Олексій Вікторович",
            IsMale = true,
            MaritalStatus = true,
            BirthDate = new DateTime(1986, 6, 12),
            Residence = "м. Київ",
            PhoneNumber = "380501113",
            MilitaryRegistrationStatus = false,
            IsPensioner = false,
            HasChildren = true,
            IdentificationNumber = "8899001122",
            PassportNumber = "012345",
            PassportSeries = "ST",
            PassportIssueDate = new DateTime(2006, 7, 20),
            PassportIssuePlace = "Київ",
            PersonEducation = "Вища",
            PersonQualification = "Аналітик",
            DiplomaNumber = "Д000010",
            DateOfGraduation = new DateTime(2008, 6, 1),
            Category = "A",
            Discharge = "1",
            FacultyId = faculties[9].Id,
            ScientificTitleId = scientificTitles[3].Id,
            ScientificDegreeId = scientificDegrees[3].Id,
            SpecialtyId = specialties[9].Id,
            IsDisabled = false
        }
    };

            context.Persons.AddRange(persons);
            context.SaveChanges();
        }

        if (!context.Employees.Any()) {
            var persons = context.Persons.OrderBy(x => x.Id).ToList();
            var positions = context.Positions.OrderBy(x => x.Id).ToList();
            var units = context.Units.OrderBy(x => x.Id).ToList();
            var employees = new List<Employee>
            {
        new Employee { EmployeePersonId = persons[0].Id, PositionId = positions[0].Id, UnitId = units[0].Id, DateEmployment = DateTime.Now.AddYears(-5), DateDismissal = null, EmployeeWorkingRate = 1.0m },
        new Employee { EmployeePersonId = persons[1].Id, PositionId = positions[1].Id, UnitId = units[1].Id, DateEmployment = DateTime.Now.AddYears(-4), DateDismissal = null, EmployeeWorkingRate = 1.1m },
        new Employee { EmployeePersonId = persons[2].Id, PositionId = positions[2].Id, UnitId = units[2].Id, DateEmployment = DateTime.Now.AddYears(-3), DateDismissal = null, EmployeeWorkingRate = 1.2m },
        new Employee { EmployeePersonId = persons[3].Id, PositionId = positions[3].Id, UnitId = units[3].Id, DateEmployment = DateTime.Now.AddYears(-6), DateDismissal = null, EmployeeWorkingRate = 1.3m },
        new Employee { EmployeePersonId = persons[4].Id, PositionId = positions[4].Id, UnitId = units[4].Id, DateEmployment = DateTime.Now.AddYears(-2), DateDismissal = null, EmployeeWorkingRate = 1.4m },
        new Employee { EmployeePersonId = persons[5].Id, PositionId = positions[5].Id, UnitId = units[5].Id, DateEmployment = DateTime.Now.AddYears(-5), DateDismissal = null, EmployeeWorkingRate = 1.5m },
        new Employee { EmployeePersonId = persons[6].Id, PositionId = positions[6].Id, UnitId = units[6].Id, DateEmployment = DateTime.Now.AddYears(-4), DateDismissal = null, EmployeeWorkingRate = 1.6m },
        new Employee { EmployeePersonId = persons[7].Id, PositionId = positions[7].Id, UnitId = units[7].Id, DateEmployment = DateTime.Now.AddYears(-3), DateDismissal = null, EmployeeWorkingRate = 1.7m },
        new Employee { EmployeePersonId = persons[8].Id, PositionId = positions[8].Id, UnitId = units[8].Id, DateEmployment = DateTime.Now.AddYears(-6), DateDismissal = null, EmployeeWorkingRate = 1.8m },
        new Employee { EmployeePersonId = persons[9].Id, PositionId = positions[9].Id, UnitId = units[9].Id, DateEmployment = DateTime.Now.AddYears(-2), DateDismissal = null, EmployeeWorkingRate = 1.9m }
    };
            context.Employees.AddRange(employees);
            context.SaveChanges();
        }

        if (!context.EmploymentOrders.Any()) {
            var employeesForEmployment = context.Employees
                .Include(e => e.EmployeePerson)
                .Include(e => e.Position)
                .Include(e => e.Unit)
                .Take(10)
                .ToList();

            var employmentOrders = new List<EmploymentOrder>();
            for (int i = 0; i < employeesForEmployment.Count; i++) {
                var emp = employeesForEmployment[i];
                employmentOrders.Add(new EmploymentOrder {
                    EmploymentDate = emp.DateEmployment.Value.AddDays(30),
                    WorkingRates = 1.00m + i * 0.1m,
                    Pluralist = (i % 2 == 0),
                    UnitId = emp.UnitId,
                    PositionId = emp.PositionId,
                    PersonId = emp.EmployeePersonId
                });
            }
            context.EmploymentOrders.AddRange(employmentOrders);
            context.SaveChanges();
        }

        if (!context.DismissalOrders.Any()) {
            var employeesForDismissal = context.Employees
                .Where(e => e.DateDismissal == null)
                .Take(5)
                .ToList();

            var dismissalOrders = new List<DismissalOrder>();
            foreach (var emp in employeesForDismissal) {
                var dismissalDate = emp.DateEmployment.Value.AddYears(3);
                dismissalOrders.Add(new DismissalOrder {
                    DismissalDate = dismissalDate,
                    EmployeeId = emp.Id
                });
                emp.DateDismissal = dismissalDate;
            }
            context.DismissalOrders.AddRange(dismissalOrders);
            context.SaveChanges();
        }

        if (!context.JobChangeOrders.Any()) {
            var employeesForJobChange = context.Employees
                .Include(e => e.EmployeePerson)
                .Include(e => e.Position)
                .Include(e => e.Unit)
                .Take(5)
                .ToList();

            var positions = context.Positions.OrderBy(p => p.Id).ToList();
            var units = context.Units.OrderBy(u => u.Id).ToList();

            var jobChangeOrders = new List<JobChangeOrder>();
            for (int i = 0; i < employeesForJobChange.Count; i++) {
                var emp = employeesForJobChange[i];
                jobChangeOrders.Add(new JobChangeOrder {
                    EmployeeId = emp.Id,
                    NewPositionId = positions[(i + 1) % positions.Count].Id,
                    NewUnitId = units[(i + 1) % units.Count].Id,
                    JobChangeDate = emp.DateEmployment.Value.AddYears(2),
                    NewWorkingRates = emp.EmployeeWorkingRate + 0.2m
                });
            }
            context.JobChangeOrders.AddRange(jobChangeOrders);
            context.SaveChanges();
        }

        if (!context.StaffSchedules.Any()) {
            var units = context.Units.OrderBy(u => u.Id).ToList();
            var positions = context.Positions.OrderBy(p => p.Id).ToList();

            var staffSchedules = new List<StaffSchedule>();

            for (int i = 0; i < 10; i++) {
                staffSchedules.Add(new StaffSchedule {
                    UnitId = units[i % units.Count].Id,
                    PositionId = positions[i % positions.Count].Id,
                    NumberOfPositions = 10m + i, 
                    NumberOfPositionsOccupied = 5m + (i * 1m) 
                });
            }

            context.StaffSchedules.AddRange(staffSchedules);
            context.SaveChanges();
        }

    }
}
