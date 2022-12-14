using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.StudyFiles;

public class Course
{
    public class Query : IRequest<List<StudyFile>>
    {
        public byte Course { get; set; }
    }
    public class Handler : IRequestHandler<Query, List<StudyFile>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<StudyFile>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.StudyFiles.Where(x=> x.Course == request.Course).ToListAsync();
        }
    }
}