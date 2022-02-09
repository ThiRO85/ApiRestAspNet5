using ApiRestAspNet5_01.Data.VO;
using ApiRestAspNet5_01.Model;
using System.Collections.Generic;

namespace ApiRestAspNet5_01.Services.Implementations
{
    public interface IPersonService
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        PersonVO Disable(long id);
        void Delete(long id);
    }
}
