using System;
using System.ComponentModel.DataAnnotations;

namespace Tasks.DAL.ViewModel
{
    public class CreateCourseViewModel
    {
        // أضف الـ Id عشان صفحة الـ List تقدر تستخدمه في الروابط
        public Guid Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
