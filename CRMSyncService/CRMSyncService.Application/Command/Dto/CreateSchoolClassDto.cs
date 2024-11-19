﻿
using CRMSyncService.Application.IQueries.Dto;

namespace CRMSyncService.Application.Command.Dto
{
    public class CreateSchoolClassDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Term { get; set; }
        public List<StudentDto> StudentsDtos { get; set; }
    }


}