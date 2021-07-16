﻿using Course.Services.Catalog.Dtos.Feature;

namespace Course.Services.Catalog.Dtos.Course
{
    internal class CourseCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string UserId { get; set; }

        public string Picture { get; set; }

        public FeatureDto Feature { get; set; }

        public string CategoryId { get; set; }
    }
}
