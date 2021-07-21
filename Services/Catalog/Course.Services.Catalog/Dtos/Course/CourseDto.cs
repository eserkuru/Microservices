﻿using Course.Services.Catalog.Dtos.Category;
using Course.Services.Catalog.Dtos.Feature;
using System;

namespace Course.Services.Catalog.Dtos.Course
{
    public class CourseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public DateTime CreatedTime { get; set; }

        public string UserId { get; set; }

        public FeatureDto Feature { get; set; }

        public string CategoryId { get; set; }

        public CategoryDto Category { get; set; }
    }
}
