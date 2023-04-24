﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlatformaEducationala.Core.Common;
using PlatformaEducationala.Core.Group.Commands.DeleteStudentGroup;
using PlatformaEducationala.Core.User.Commands.SaveOrUpdateStudentGroup;
using PlatformaEducationala.Core.User.Commands.SaveStudentGroup;
using PlatformaEducationala.Core.User.Models;
using PlatformaEducationala.Core.User.Queries.Get;

namespace PlatformaEducationala.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = TeacherOrStudent)]
public class StudentsController : ApiController
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<StudentDto>>> Get()
    {
        var result = await _mediator.Send(new GetQuery { CurrentUserId = Guid.Parse(UserId) });

        return HandleMediatorResponse(result);
    }

    [HttpPatch("{studentId}/Groups/{groupId}")]
    public async Task<ActionResult<SaveOrUpdateGroupResponse>> SaveStudentGroup([FromRoute] Guid studentId,
        [FromRoute] Guid groupId, [FromBody] SaveOrUpdateGroupCommand command)
    {
        command.CurrentUserId = Guid.Parse(UserId);
        command.OldGroupId = groupId;
        command.StudentId = studentId;

        var result = await _mediator.Send(command);

        return HandleMediatorResponse(result);
    }

}