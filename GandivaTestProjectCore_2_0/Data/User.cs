using System;
using System.Collections.Generic;

namespace GandivaTestProject
{
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string SecondaryName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Под удалением подразумевается пометка isActual = false, 
        /// при таком значении элемент становится не доступен в стандартных интерфейсах
        /// </summary>
        public bool IsActual { get; set; }

        public virtual ICollection<Task> CreatedTasks { get; set; }
        public virtual ICollection<Task> ContractedTasks { get; set; }
        public virtual ICollection<Comment> UserComments { get; set; }

        public User()
        {
            IsActual = true;
            CreateDate = DateTime.Now;
        }

    }
}
