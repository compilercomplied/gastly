using domain.extensions.Core.Result;
using domain.models.Usecases.WeatherQuery;
using domain.models.Usecases.WeatherQuery.Aemet;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace infra.http.Clients.Aemet
{

  #region aliases
  using WeatherLocationResult = Result<WeatherLocationQueryRes>;
  #endregion aliases

  public partial class AemetClient
  {

    public async Task<WeatherLocationResult> QueryLocation(
      WeatherLocationQueryReq req
    )
    {

      var path = string.Format(DayQueryLocationPath, req.LocationID);

      var datapath = await GetWrapperData(path);


      var clientResponse = await SafeGetAsync(datapath);

      var result = 
        await HandleResponse<AemetLocationQueryRes[]>(clientResponse);

      if (!result.IsSuccess) 
        return WeatherLocationResult.FAIL(result.Error);

      var today = result.Value[0].Prediccion.Dia
        .FirstOrDefault(day => day.Fecha.Day == DateTime.Now.Day);


      var payload = _mapper.Map<WeatherLocationQueryRes>(today);

      return WeatherLocationResult.OK(payload);

    }

  }

}
