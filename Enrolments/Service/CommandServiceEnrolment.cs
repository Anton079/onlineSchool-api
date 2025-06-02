using online_school_api.Enrolments.Dtos;
using online_school_api.Enrolments.Exceptions;
using online_school_api.Enrolments.Repository;
using online_school_api.Enrolments.Models;
using AutoMapper;

namespace online_school_api.Enrolments.Service
{
    public class CommandServiceEnrolment : ICommandServiceEnrolment
    {
        private readonly IEnrolmentRepo _repo;
        private readonly IMapper _mapper;

        public CommandServiceEnrolment(IEnrolmentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<EnrolmentResponse> CreateEnrolmentAsync(EnrolmentStudentRequest request)
        {
            EnrolmentResponse verif = await this._repo.AreCourseIdAndStudentIdASync(request.StudentId, request.CourseId);

            if(verif == null)
            {
                EnrolmentResponse response = await _repo.CreateAsync(request);

                return response;
            }

            throw new EnrolmentAlreadyExistsException();
        }

        public async Task<EnrolmentResponse> UpdateEnrolmentAsync(int id, EnrolmentStudentRequest update)
        {
            EnrolmentResponse verf = await _repo.FindByIdAsync(id);
            if(verf != null)
            {
                if(verf is EnrolmentStudentRequest)
                {
                    verf.CourseId = update.CourseId;
                    verf.StudentId = update.StudentId;
                }
            }

            throw new EnrolmentNotFoundException();
        }

        public async Task<EnrolmentResponse> DeleteEnrolmentAsync(int id)
        {
            var existing = await _repo.FindByIdAsync(id);
            if (existing != null)
            {
                var deleted = await _repo.DeleteEnrolment(id);
                return _mapper.Map<EnrolmentResponse>(deleted);
            }

            throw new EnrolmentNotFoundException();
        }

    }
}