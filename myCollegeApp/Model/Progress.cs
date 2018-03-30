using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author:Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=mNC_UQD0ysI
namespace myCollegeApp.Model
{
    public class Progress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity column
        public int Id { get; set; }//Id primary key for this table
        public DateTime Date { get; set; }//Date
        public decimal Amount { get; set; }//Amout that was increase or decrease
        public int GoalId { get; set; }//Foregin key to a table
        [ForeignKey("GoalId")]//Passing GoalId
        public Goal Goal { get; set; }//Assign this goal object to the goal associated with it

        
    }//End of progress class

}//End of namespace
