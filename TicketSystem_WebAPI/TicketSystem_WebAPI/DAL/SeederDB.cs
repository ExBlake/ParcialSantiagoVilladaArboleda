namespace TicketSystem_WebAPI.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();//This line helps me create my database automatically
            await PopulateTicketsAsync();
            
        }

        private async Task PopulateTicketsAsync()
        {
            if (!_context.Tickets.Any())
            {
                for(int i = 0; i <= 50000; i++)
                {
                    _context.Tickets.Add(new Entities.Tickets { IsUsed = false });
                }
                await _context.SaveChangesAsync();//Save the database
            }
            
        }
    }
}
