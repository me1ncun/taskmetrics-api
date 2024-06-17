﻿using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.TaskItems.AddTaskItem;

public class AddTaskRequest
{
    [Required]
    [StringLength(50)]
    public string Title { get; set; }
    [Required]
    [StringLength(255)]
    public string Description { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public string Priority { get; set; }
}