using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=fkSW0eSF9mg
namespace myCollegeApp.Model
{
    [Table("Goal")]
    public class Goal
    {
        [Key]//Key for a table(Id is the primary key)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity column
        public int GoalId { get; set; }//Id number
        public string Name { get; set; }//Module name
        public decimal GradeGoal { get; set; }//Grade value
        public string Notes { get; set; }//Additional notes
        public DateTime Date { get; set; }//Date when the goal was made
        public decimal Balance { get; set; }//How much of goal was completed
        public List<Progress> Progresses { get; set; }
    }//End of Goal class

}//End of namespace
