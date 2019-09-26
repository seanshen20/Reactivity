using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
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
                // handler logic goes here
                var delete_Object = await _context.Activity.FindAsync(request.Id);
                if (delete_Object is null)
                {
                    throw new Exception("Could not find activity");
                }
                // tracked 
                _context.Remove(delete_Object);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }


    }
}
