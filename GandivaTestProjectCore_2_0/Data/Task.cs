using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GandivaTestProject
{
    public class Task
    {
        public Task()
        {
            IsActual = true;
            CreateDate = DateTime.Now;
        }
        public int ID                   { get; set; }
        public string Title             { get; set; }
        public string Description       { get; set; }
        public DateTime CreateDate      { get; set; }

        public int? CreatorID           { get; set; }
        public User Creator             { get; set; }

        public int? ContractorID        { get; set; }
        public User Contractor          { get; set; }
        public bool IsActual           { get; set; }

        public ICollection<Comment> TaskComments { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}