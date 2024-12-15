using Core.Models;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IProfileRepository
    {
        Task<Result> Add(Profile profile);

        Task<Result<Profile>> GetBySearchTag(string searchTag);
    }
}
