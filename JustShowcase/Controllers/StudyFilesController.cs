using Application.StudyFiles;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace JustShowcase.Controllers;

public class StudyFilesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<StudyFile>>> GetStudyFiles()
    {
        return await Mediator.Send(new List.Query());
    }
    [HttpGet("byId")]
    public async Task<ActionResult<StudyFile>> GetStudyFile(Guid id)
    {
        return await Mediator.Send(new Details.Query {Id = id});
    }
    [HttpGet("byCourse")]
    public async Task<ActionResult<List<StudyFile>>> GetStudyFiles(byte course)
    {
        return await Mediator.Send(new Course.Query {Course = course});
    }

    [HttpPut]
    public async Task<IActionResult> CreateStudyFile(StudyFile studyFile)
    {
        return Ok(await Mediator.Send(new Create.Command {StudyFile = studyFile}));
    }
    [HttpPost]
    public async Task<IActionResult> EditStudyFile(StudyFile studyFile)
    {
        return Ok(await Mediator.Send(new Edit.Command {StudyFile = studyFile}));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudyFile(Guid id)
    {
        return Ok(await Mediator.Send(new Delete.Command {Id = id}));
    }
}