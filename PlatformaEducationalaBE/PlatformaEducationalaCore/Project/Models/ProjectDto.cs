﻿
namespace PlatformaEducationala.Core.Project.Models;
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Xml { get; set; }
        public Guid UserId { get; set; }
    }
