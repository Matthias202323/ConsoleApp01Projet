using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp01Projet
{
    public class Tableau
    {
        public int CourseId { get; set; }
        public double Note { get; set; }
        public string Commentary { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grade"/> class.
        /// </summary>
        /// <param name="courseId">The ID of the course.</param>
        /// <param name="note">The note for the course.</param>
        /// <param name="commentary">The optional commentary for the grade.</param>
        public Tableau(int courseId, double note, string commentary = "")
        {
            CourseId = courseId;
            Note = note;
            Commentary = commentary;
        }
    }
}
