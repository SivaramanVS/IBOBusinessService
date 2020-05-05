namespace BusinessService.Api.Data
{
    public interface IMapper<TDomainModel, TDbModel>
    {
        TDomainModel MapTo(TDbModel dbModel);
        TDbModel MapFrom(TDomainModel dbModel);
    }
}