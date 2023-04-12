namespace ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineList;

public class DisciplineListViewModel
{
    public DisciplineListViewModel()
    {
        Disciplines = new List<DisciplineLookupDto>();
    }

    public DisciplineListViewModel(IList<DisciplineLookupDto> disciplines)
    {
        Disciplines = disciplines;
    }

    public IList<DisciplineLookupDto> Disciplines { get; set; }
}