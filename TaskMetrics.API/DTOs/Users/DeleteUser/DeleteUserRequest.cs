﻿using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.Users.DeleteUser;

public class DeleteUserRequest
{
    [Required]
    public int Id { get; set; }
}