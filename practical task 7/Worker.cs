using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_task_7
{
    /// <summary>
    /// Описание работника
    /// </summary>
    struct Worker
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public string DateOfBirth { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceOfBirth { get; set; }
    }
}
