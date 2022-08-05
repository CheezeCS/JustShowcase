using MediatR;
using Persistence;

namespace Application.StudyFiles;

public class Delete
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
    }
    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var studyFile = await _context.StudyFiles.FindAsync(request.Id);

            _context.Remove(studyFile);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}