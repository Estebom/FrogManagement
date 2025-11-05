using FrogManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FrogManagement.Data.Repositories
{
    public class FrogRepository : IFrogRepository
    {
        private readonly FrogManagementContext Context;
        public FrogRepository(FrogManagementContext context)
        {
            Context = context;
        }
        public async Task<bool> Add(FrogDTO frogDTO)
        {
            try
            {
                var tempfrog = await Context.Frogs.Where(f => f.Name == frogDTO.Name).FirstOrDefaultAsync();

                if (tempfrog is null) 
                {
                    Frog frog = new Frog() 
                    {
                        Name = frogDTO.Name,
                        JumpHeight = frogDTO.JumpHeight,
                        Weight = frogDTO.Weight,
                    };

                    Context.Add(frog);
                    await Context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var frog = await Context.Frogs.FindAsync(id);

                if (frog is null) 
                {
                    return false;
                }
                Context.Remove(frog);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<Frog>> Get()
        {
            try
            {
                return await Context.Frogs.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Frog> Get(Guid id)
        {
            try
            {
                return await Context.Frogs.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> Update(Guid id, FrogDTO frogDTO)
        {
            try
            {
                var frog = await Context.Frogs.FindAsync(id);

                if (frog is null) 
                {
                    return false;
                }
                frog.Name = frogDTO.Name;
                frog.JumpHeight = frogDTO.JumpHeight;
                frog.Weight = frogDTO.Weight;
                Context.Frogs.Update(frog);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
