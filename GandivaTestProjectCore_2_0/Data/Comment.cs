using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GandivaTestProject
{
    public class Comment
    {

        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public int ID                 { get; set; }

        public int? TaskID { get; set; }
        /// <summary>
        /// Связанная задача
        /// </summary>
        public Task Task              { get; set; }

        public int? CreatorID { get; set; }
        /// <summary>
        /// Пользователь создатель коментария
        /// </summary>
        public User Creator     { get; set; }

        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Description     { get; set; }

        /// <summary>
        /// Дата создания комментария 
        /// </summary>
        public DateTime CreateDate    { get; set; }

        /// <summary>
        /// Под удалением подразумевается пометка isActual = false, 
        /// при таком значении элемент становится не доступен в стандартных интерфейсах
        /// </summary>
        public bool IsActual          { get; set; }

        public Comment()
        {
            IsActual = true;
            CreateDate = DateTime.Now;
        }
    }
}