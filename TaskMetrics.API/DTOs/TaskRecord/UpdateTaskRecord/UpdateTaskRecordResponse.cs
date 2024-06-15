﻿namespace task_api.TaskMetrics.API.DTOs.TaskRecord.UpdateTaskRecord;

public class UpdateTaskRecordResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TaskId { get; set; }
    public DateTime DateCompleted { get; set; }
    public int TimeSpent { get; set; }
}