using Microsoft.AspNetCore.Mvc;
using Samples.Lib.Impl;
using Samples.Lib.Interfaces;

namespace Samples.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SampleController : ControllerBase
{
    readonly IService service;
    readonly Context context;

    public SampleController(
        IService service,
        Context context)
    {
        this.service = service;
        this.context = context;
    }

    [HttpGet(Name = "hello")]
    public string Hello([FromServices] IComplexService complexService)
    {
        return "Hello World";
    }

    [HttpGet(Name = "generics")]
    public string Generics([FromServices] IGenericService<string> genericService)
    {
        return "Hello Generics";
    }
}