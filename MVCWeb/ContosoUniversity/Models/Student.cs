using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Student
    {

        public int ID { get; set; }
        [StringLength(50)]

        [Display(Name="姓名")] //数据注解
          public string Name { get; set; }
     //   [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]

        [DataType(DataType.Date)]
        //显式指定日期格式
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "注册日期")]
        public DateTime EnrollmentDate { get; set; }  //注册事件

        [Display(Name ="头像")]
        public string Image { get; set; }
        [Display(Name ="选课信息")]

        //导航属性 来表示（一对多关系）   Enrollment注册
        public virtual ICollection<Enrollment> Enrollments { get; set; }
                  
    }
}