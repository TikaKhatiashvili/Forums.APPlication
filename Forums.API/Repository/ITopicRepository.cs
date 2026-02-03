using Forums.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forums.API.Repository;

public interface ITopicRepository:IBaseRepository<Topic, DbContext>
{
}
