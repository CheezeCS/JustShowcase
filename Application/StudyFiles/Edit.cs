using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.StudyFiles;

public class Edit
{
    public class Command : IRequest
    {
        public StudyFile StudyFile { get; set; }
    }
    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var studyFile = await _context.StudyFiles.FindAsync(request.StudyFile.Id);
            _mapper.Map(request.StudyFile, studyFile);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}