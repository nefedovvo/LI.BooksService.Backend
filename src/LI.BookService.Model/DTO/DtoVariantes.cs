using LI.BookService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LI.BookService.Model.DTO
{
    /// <summary>
    /// дто с вариантами и процентом совпадения
    /// </summary>
    public class DtoVariantes
    {
        /// <summary>
        /// список с вариантами
        /// </summary>
        public List<UserList> VariantesList { get; set; }

        /// <summary>
        /// процент совпадения
        /// </summary>
        public double PercentCoincidence { get; set; }
    }
}
