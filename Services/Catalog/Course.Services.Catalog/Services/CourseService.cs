using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Course.Services.Catalog.Dtos.Course;
using Course.Services.Catalog.Models;
using Course.Services.Catalog.Settings;
using Course.Shared.Dtos;
using MongoDB.Driver;

namespace Course.Services.Catalog.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMongoCollection<Models.Course> _courseCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _courseCollection = database.GetCollection<Models.Course>(databaseSettings.CourseCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseCollection.Find(course => true).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find(category => category.Id == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Models.Course>();
            }

            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            var course = await _courseCollection.Find(course => course.Id == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return Response<CourseDto>.Fail("Course not found.", 400);
            }

            course.Category = await _categoryCollection.Find(category => category.Id == course.CategoryId).FirstAsync();

            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }

        public async Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            var courses = await _courseCollection.Find(course => course.UserId == userId).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find(category => category.Id == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Models.Course>();
            }

            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto)
        {
            var newCourse = _mapper.Map<Models.Course>(courseCreateDto);
            await _courseCollection.InsertOneAsync(newCourse);

            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var updateCourse = _mapper.Map<Models.Course>(courseUpdateDto);

            var result = await _courseCollection.FindOneAndReplaceAsync(course => course.Id == courseUpdateDto.Id, updateCourse);
            
            if (result == null)
            {
                return Response<NoContent>.Fail("Course not found.", 400);
            }

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _courseCollection.DeleteOneAsync(course => course.Id == id);

            if (result.DeletedCount == 0)
            {
                return Response<NoContent>.Fail("Course not found.", 400);
            }

            return Response<NoContent>.Success(204);
        }
    }
}
