namespace ToNinetyOne.Application.Operations.Queries.Disciplines.GetDisciplineList;

public class DisciplineListViewModel
{
    public IList<DisciplineLookupDto> Disciplines { get; set; }

    public DisciplineListViewModel()
    {
        Disciplines = new List<DisciplineLookupDto>();
    }

    public DisciplineListViewModel(IList<DisciplineLookupDto> disciplines)
    {
        Disciplines = disciplines;
    }
}