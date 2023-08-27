using Microsoft.AspNetCore.Mvc;
using Samples.Lib.Impl;
using Samples.Lib.Interfaces;

namespace Samples.Api.Controllers;

[ApiController]
[Route("[controller]")]
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

    [HttpGet(Name = "GetSample")]
    public string Get()
    {
        return "Hello World";
    }
}