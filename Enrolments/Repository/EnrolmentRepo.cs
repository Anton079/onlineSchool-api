using AutoMapper;
using online_school_api.Data;
using online_school_api.Enrolments.Dtos;
using System.Data.Entity;

namespace online_school_api.Enrolments.Repository
{
    public class EnrolmentRepo:IEnrolmentRepo
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public EnrolmentRepo(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAllEnrolmentsDto> GetAllEnrolAsync()
        {
            var enrolments = await _dbContext.Enrolments
                .Include(e => e.Student )
                .ToListAsync();

            var mapperd = _mapper .Map<List<EnrolmentResponse>>(enrolments);

            return new GetAllEnrolmentsDto
            {
                ListEnrolment = mapperd
            };
        }
    }
}
