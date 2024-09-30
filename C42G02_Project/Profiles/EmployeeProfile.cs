namespace C42G02_Project.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap <Employee, EmployeeViewModel>().ReverseMap(); //This is a simpler configuration process
        }
    }
}
// Search about mapping a model to a view model using "Mapster"