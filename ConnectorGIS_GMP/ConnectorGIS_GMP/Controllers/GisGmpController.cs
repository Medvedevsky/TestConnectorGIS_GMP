using ConnectorGIS_GMP.ApiClient;
using ConnectorGIS_GMP.ApiClient.Model.Request;
using ConnectorGIS_GMP.ApiClient.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConnectorGIS_GMP.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GisGmpController : ControllerBase
    {
        private readonly GisGmpClient _gisGmpClient;
        public GisGmpController(GisGmpClient gisGmpClient)
        {
            _gisGmpClient = gisGmpClient;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Response>> SearchCalculation(CheckPayRequest request)
        {
            (CheckPayResponse? data, ResponseError err) = await _gisGmpClient.Search(request);
            return new Response
            {
                Error = err,
                Data = data
            };
        }
    }
}
